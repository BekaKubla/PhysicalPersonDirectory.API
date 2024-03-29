﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PhysiscalPersonDirectory.Application.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysiscalPersonDirectory.Infrastructure.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string Folder = "Images";

        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<byte[]> Download(string path)
        {
            if (!File.Exists(path)) return null;

            return await File.ReadAllBytesAsync(path);
        }

        public async Task<string> Upload(IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var path = GetFullPath(fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return path;
        }

        private string GetFullPath(string file)
        {
            if (!Directory.Exists(Path.Combine(_hostingEnvironment.ContentRootPath, Folder)))
            {
                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.ContentRootPath,
                    Folder));
            }
            return Path.Combine(_hostingEnvironment.ContentRootPath, Folder, file);
        }
    }
}
