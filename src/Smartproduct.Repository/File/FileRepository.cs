using Smartproduct.Data;
using Smartproduct.Interface.File;
using Smartproduct.Model.Category;
using Smartproduct.Repository.ExceptionHandler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace Smartproduct.Repository.File
{
    public class FileRepository : IFile
    {
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        public FileRepository(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<Model.File.File> GetFileById(int Id)
        {
            try
            {
                return await _context.Files.FindAsync(Id);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<List<Model.File.File>> GetAllFiles()
        {
            return await _context.Files.ToListAsync();
        }

        public async Task<bool> Insert(Model.File.File file)
        {
            try
            {
                file.CreatedOn = DateTime.Now;
                _context.Files.Add(file);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                ExceptionLogger.ErrorHelper(e.Message);
                return false;
            }
        }
    }
}
