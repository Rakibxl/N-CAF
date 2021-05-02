using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public static string SaveFile(IFormFile file, string folder, string docName)
        {

            try
            {
                string fileName = docName==null? RemoveSpecialCharacters(file.FileName): docName;
                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), defaultRoot + "/documents", folder);
                CreateFolder(SavePath);
                DeleteFile(SavePath);
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


        public static void DeleteFile(string path)
        {
            if (Directory.Exists(path))
            {
                Array.ForEach(Directory.GetFiles(path), File.Delete);
            }
          
        }
        public static string CreateFolder(string path)
        {

            System.IO.Directory.CreateDirectory(path);
            return path;
        }
        public static string[] GetFiles(string folder,string documents= "documents")
        {
            var filePath =  Path.Combine(Directory.GetCurrentDirectory(), defaultRoot + documents, folder);
            if (Directory.Exists(filePath))
            {
                string[] fileEntries = Directory.GetFiles(filePath);
                for(var i =0; i<fileEntries.Length; i++)
                {
                    Uri uri = new Uri(fileEntries[i]);
                    if (uri.IsFile)
                    {
                        string filename = System.IO.Path.GetFileName(uri.LocalPath);
                        fileEntries[i] ="/assets/"+ documents + "/" +folder + "/" + filename;
                    }
                }
               
                return fileEntries;
            }
            return null;
        }
        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
