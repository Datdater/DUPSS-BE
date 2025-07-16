using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Abtractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace DUPSS.Application.Services
{
    public class FileService : IFileService
    {
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty or null", nameof(file));
            }

            // Create a unique filename
            string fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";

            // Define upload folder path (consider making this configurable via options)
            string uploadsFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "uploads"
            );

            // Ensure directory exists
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string filePath = Path.Combine(uploadsFolder, fileName);

            // Save file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Return relative path that can be used in URLs
            return Path.Combine("uploads", fileName).Replace('\\', '/');
        }

        public async Task<byte[]> LoadFileAsync(string filePath)
        {
            string fullPath = GetFullPath(filePath);

            return await File.ReadAllBytesAsync(fullPath);
        }

        private string GetFullPath(string relativePath)
        {
            // Remove any leading slash or "uploads/" prefix if present
            relativePath = relativePath.TrimStart('/');
            if (relativePath.StartsWith("uploads/"))
            {
                relativePath = relativePath.Substring(8);
            }

            return Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "uploads",
                relativePath
            );
        }

        public void DeleteFileAsync(string filePath)
        {
            string fullPath = GetFullPath(filePath);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
