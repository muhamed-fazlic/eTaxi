using eTaxi.Application.Models.Photo;
using Microsoft.AspNetCore.Http;

namespace eTaxi.Application.Contracts.Photo
{
    public interface IPhotoServer
    {
        public string GenerateLink(string Name);
        public PhotoResponse UploadPhoto<T>(IFormFile file, string ImagePath) where T : new();
        public void RemoveImage(string name, string url);
    }
}
