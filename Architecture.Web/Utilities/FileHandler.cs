using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Web.Utilities
{
    public static class FileHandler
    {
        public static string[] ExcelFileType = { ".xlsx", ".xls", ".csv" };
        public static string[] ImageFileType = { ".png", ".bmp", ".jpg", ".jpeg" };
        public static string[] PdfType = { ".pdf" };
        public static float MaxFileSize = 5; // size in MB  
        private static string defaultRoot = "wwwroot/assets/";

        public static string SaveFile(IFormFile file, string folder)
        {

            try
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), defaultRoot, folder);
                CreateFolder(SavePath);
                using (var stream = new FileStream(Path.Combine(SavePath, fileName), FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return fileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string CreateFolder(string path)
        {

            System.IO.Directory.CreateDirectory(path);
            return path;
        }
    }
}
