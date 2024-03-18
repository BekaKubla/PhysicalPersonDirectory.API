using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysiscalPersonDirectory.Application.Infrastructure.Services
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile file);
        Task<byte[]> Download(string path);
    }
}
