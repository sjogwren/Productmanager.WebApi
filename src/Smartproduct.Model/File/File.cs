using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartproduct.Model.File
{
    [Table("File")]
    public class File
    {
        [Key]
        public int FileId { get; set; }
        public int? ProductId { get; set; } 
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string FileContentType { get; set; }
        public int FileLength { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public int? DeletedByUserID { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
