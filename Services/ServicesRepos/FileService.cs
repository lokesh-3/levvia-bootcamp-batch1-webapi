using AutoMapper;
using DataBase.UnitOfWork;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesRepos
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task UploadFile(IFormFile file, int clientId)
        {
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var newFile = new Attachment();
                    newFile.ClientId = clientId;
                    newFile.MimeType = file.ContentType;
                    newFile.FileName = Path.GetFileName(file.FileName);
                    newFile.FileContent = ms.ToArray();

                    var supportedTypes = new[] { "pdf", "xls", "xlsx" };

                    var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);

                    if (supportedTypes.Contains(fileExt))
                    {
                        await _unitOfWork.file.AddAsync(newFile);
                        _unitOfWork.Complete();
                    }
                }
            }
        }

        public async Task UploadFile(List<IFormFile> files, int clientId)
        {
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    await UploadFile(file, clientId);
                }
            }
        }
    }
}
