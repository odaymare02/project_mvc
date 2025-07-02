using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace project_mvc.Services
{
    public  class ImageService
    {
        private string ImagFolderPath;
        public ImageService() {
            ImagFolderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");
        }
        public async Task<string>  UploadImage(IFormFile image)
        {
            var fileName=Guid.NewGuid().ToString()+Path.GetExtension(image.FileName);
            var filePath=Path.Combine(ImagFolderPath, fileName);
            /*now copy the image to the file*/
            using (var stream = System.IO.File.Create(filePath))//create file inside this path 
            {
                  await image.CopyToAsync(stream);
            }
            return fileName;
        }
        public bool DeleteImage(string image)
        {
            var fullePath=Path.Combine(ImagFolderPath,image);
            if (File.Exists(fullePath))
            {
                File.Delete(fullePath);
                return true;
            }
            return false;

        }
    }
}
