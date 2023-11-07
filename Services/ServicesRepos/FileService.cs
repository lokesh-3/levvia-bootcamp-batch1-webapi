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
        public async Task<bool> UploadFile(IFormFile file, int clientId)
        {
            try
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
                        newFile.Content = ms.ToArray();

                        var supportedTypes = new[] { "pdf", "xls", "xlsx" };

                        var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);

                        if (supportedTypes.Contains(fileExt))
                        {
                            await _unitOfWork.file.AddAsync(newFile);
                            _unitOfWork.Complete();
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
