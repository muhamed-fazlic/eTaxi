using eTaxi.Application.Contracts.Photo;
using eTaxi.Application.Exceptions;
using eTaxi.Application.Models.Photo;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace eTaxi.Infrastructure.ImageService
{
    public class PhotoServer : IPhotoServer
    {
        public string GenerateLink(string Name)
        {
            var regex = @"\s+";
            Name = Name.Trim().ToLower();
            Name = Regex.Replace(Name, regex, "-");
            Name = Uri.EscapeDataString(Name);

            return Name;
        }
        public PhotoResponse? UploadPhoto<T>(IFormFile file, string ImagePath) where T : new()
        {
            if (file != null)
            {
                string uploadFolder = "Resources/";
                var guid = Guid.NewGuid().ToString();
                string uploadFileName = guid + "_" + file.FileName;
                string filePath = uploadFolder + uploadFileName;
                string dbPathName = guid + "_" + Uri.EscapeDataString(file.FileName);
                string dbPath = ImagePath + dbPathName;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                PhotoResponse result = new()
                {
                    FileName = uploadFileName,
                    OriginalName = file.FileName,
                    Url = dbPath
                };

                return result;
            }
            return default;
        }

        public void RemoveImage(string name, string url)
        {
            if (url.Contains("/Resources/"))
            {
                try
                {
                    File.Delete(@"Resources/" + name);
                }
                catch (BadRequestException ex)
                {
                    throw new BadRequestException(ex.Message);

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
