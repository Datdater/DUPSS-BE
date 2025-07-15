using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DUPSS.Application.Abtractions
{
    public interface IFileService
    {
        public Task<string> UploadFileAsync(IFormFile file);

        public Task<byte[]> LoadFileAsync(string filePath);

        public void DeleteFileAsync(string filePath);
    }
}
