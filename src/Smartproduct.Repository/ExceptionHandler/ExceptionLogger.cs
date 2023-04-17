using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartproduct.Repository.ExceptionHandler
{
    public class ExceptionLogger
    {
        public static void ErrorHelper(string exception)
        {
            var startupPath = $"{System.IO.Directory.GetCurrentDirectory()}\\logs\\log.txt";

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(startupPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Error("Content: {@error}", exception);
        }
    }
}
