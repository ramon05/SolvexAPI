using GenericApi.Core.Adstract;
using GenericApi.Core.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Services.Services
{
    public interface IFileService
    {
        Task<IFileOperationResult<IFormFile>> Upload(IFormFile file, string folder = null);
        Task<List<IFileOperationResult<IFormFile>>> Upload(IFormFile[] files, string folder = null);
        FileStreamResult Download(FileInfoModel file, string folder = null);
        FileStreamResult Download(string fileName, string contentType, string folder = null);
    }

    public class FileService : IFileService
    {
        readonly FileStoreSettings _fileStoreSettings;
        public FileService(IOptions<FileStoreSettings> _appConfiguration)
        {
            _fileStoreSettings = _appConfiguration.Value;
        }

        public FileStreamResult Download(FileInfoModel file, string folder = null)
        {
            return Download(file.FileName, file.ContentType, folder);
        }

        public FileStreamResult Download(string fileName, string contentType, string folder = null)
        {
            string fldr = folder ?? _fileStoreSettings.Path;

            var completePath = Path.Combine(fldr, fileName);
            var content = File.OpenRead(completePath);

            return new FileStreamResult(content, contentType);
        }

        public async Task<IFileOperationResult<IFormFile>> Upload(IFormFile fileToSave, string folder = null)
        {
            string fldr = folder ?? _fileStoreSettings.Path;

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileToSave.FileName);

            if (Directory.Exists(fldr) == false)
                Directory.CreateDirectory(fldr);

            var filePath = Path.Combine(fldr, fileName);

            try
            {
                await Save(fileToSave, filePath);
                return new FileOperationResult<IFormFile>
                {
                    Success = true,
                    Message = string.Format("Archivo {0} subido con éxito", fileToSave.FileName),
                    Entity = fileToSave,
                    Path = filePath,
                    FileName = filePath.Replace(fldr + "\\", string.Empty)
                };
            }
            catch (Exception ex)
            {
                return new FileOperationResult<IFormFile>
                {
                    Success = false,
                    Message = ex.Message,
                    Entity = fileToSave
                };
            }
        }

        public async Task<List<IFileOperationResult<IFormFile>>> Upload(IFormFile[] files, string folder = null)
        {
            var resultLists = new List<IFileOperationResult<IFormFile>>();

            foreach (var file in files)
            {
                var result = await Upload(file, folder);
                resultLists.Add(result);
            }

            return resultLists;
        }

        private async Task Save(IFormFile fileToSave, string folder)
        {
            using (var stream = new FileStream(path: folder, mode: FileMode.Create))
            {
                await fileToSave.CopyToAsync(stream);
            }
        }
    }
}

