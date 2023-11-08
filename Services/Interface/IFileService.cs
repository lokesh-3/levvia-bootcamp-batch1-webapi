using DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IFileService
    {
        Task UploadFile(IFormFile file, int clientId);
        Task UploadFile(List<IFormFile> files, int clientId);
    }
}
