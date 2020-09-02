using System.Drawing;
using System.Threading.Tasks;
using Architecture.Core.Common.Enums;
using Microsoft.AspNetCore.Http;

namespace Architecture.Web.Core
{
    public interface IPhotoStorage
    {
        Task<string> StorePhotoAsync(string uploadsFolderPath, IFormFile file);
        Task<string> SaveImageAsync(IFormFile file, string fileName, EnumFileUploadFolderCode type);
        string SaveImage(IFormFile file, string fileName, EnumFileUploadFolderCode type, int width, int height);
        string SaveImage(string base64String, string fileName, EnumFileUploadFolderCode type);
        string SaveImage(string base64String, string fileName, EnumFileUploadFolderCode type, int width, int height);
        Image ResizeImage(Image image, int width, int height);
        void DeleteImage(string filePath);
        bool IsValidImage(IFormFile file);
        string ImageFolderPath(EnumFileUploadFolderCode type);
    }
}