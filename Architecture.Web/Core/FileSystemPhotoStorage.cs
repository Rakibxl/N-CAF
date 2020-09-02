using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Architecture.Core.Common.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Architecture.Web.Core
{
    public class FileSystemPhotoStorage : IPhotoStorage
    {
        private readonly PhotoSettings _photoSettings;
        private readonly IWebHostEnvironment _host;

        public FileSystemPhotoStorage(
            IOptionsSnapshot<PhotoSettings> photoOptions,
            IWebHostEnvironment host)
        {
            this._photoSettings = photoOptions.Value;
            this._host = host;
        }

        public async Task<string> StorePhotoAsync(string uploadsFolderPath, IFormFile file)
        {
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task<string> SaveImageAsync(IFormFile file, string fileName, EnumFileUploadFolderCode type)
        {
            string filePath = this.ImageFolderPath(type);

            if (!Directory.Exists(Path.Combine(_host.WebRootPath, filePath)))
                Directory.CreateDirectory(Path.Combine(_host.WebRootPath, filePath));

            fileName += Path.GetExtension(file.FileName);
            filePath = Path.Combine(filePath, fileName);

            using (var stream = new FileStream(Path.Combine(_host.WebRootPath, filePath), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        public string SaveImage(IFormFile file, string fileName, EnumFileUploadFolderCode type, int width, int height)
        {
            string filePath = this.ImageFolderPath(type);

            if (!Directory.Exists(Path.Combine(_host.WebRootPath, filePath)))
                Directory.CreateDirectory(Path.Combine(_host.WebRootPath, filePath));

            fileName += Path.GetExtension(file.FileName);
            filePath = Path.Combine(filePath, fileName);

            using (Image image = Image.FromStream(file.OpenReadStream()))
            {
                Image newImage = image;
                if (image.Width > width || image.Height > height)
                {
                    newImage = ResizeImage(image, width, height);
                }
                newImage.Save(Path.Combine(_host.WebRootPath, filePath));
            }

            return filePath;
        }

        public string SaveImage(string base64String, string fileName, EnumFileUploadFolderCode type)
        {
            string filePath = this.ImageFolderPath(type);

            if (!Directory.Exists(Path.Combine(_host.WebRootPath, filePath)))
                Directory.CreateDirectory(Path.Combine(_host.WebRootPath, filePath));

            fileName += ".jpg";
            filePath = Path.Combine(filePath, fileName);

            byte[] bytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image image = Image.FromStream(ms);
                Image newImage = image;
                newImage.Save(Path.Combine(_host.WebRootPath, filePath));
            }

            return filePath;
        }

        public string SaveImage(string base64String, string fileName, EnumFileUploadFolderCode type, int width, int height)
        {
            string filePath = this.ImageFolderPath(type);

            if (!Directory.Exists(Path.Combine(_host.WebRootPath, filePath)))
                Directory.CreateDirectory(Path.Combine(_host.WebRootPath, filePath));

            fileName += ".jpg";
            filePath = Path.Combine(filePath, fileName);

            byte[] bytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image image = Image.FromStream(ms);
                Image newImage = image;
                if (image.Width > width || image.Height > height)
                {
                    newImage = ResizeImage(image, width, height);
                }
                newImage.Save(Path.Combine(_host.WebRootPath, filePath));
            }

            return filePath;
        }

        public Image ResizeImage(Image image, int width, int height)
        {
            Image newImage = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return newImage;
        }

        public void DeleteImage(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(Path.Combine(_host.WebRootPath, filePath)))
                File.Delete(Path.Combine(_host.WebRootPath, filePath));
        }

        public bool IsValidImage(IFormFile file)
        {
            if (file == null) throw new Exception("Null file");
            if (file.Length == 0) throw new Exception("Empty file");
            if (file.Length > _photoSettings.MaxBytes) throw new Exception("Max file size exceeded");
            if (!_photoSettings.IsSupported(file.FileName)) throw new Exception("Invalid file type.");
            return true;
        }

        public string ImageFolderPath(EnumFileUploadFolderCode type)
        {
            string filePath = Path.Combine("Uploads", "Images");
            switch (type)
            {
                case EnumFileUploadFolderCode.Example:
                    filePath = Path.Combine(filePath, "Examples");
                    break;
                default:
                    break;
            }

            return filePath;
        }
    }
}