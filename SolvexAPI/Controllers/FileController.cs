using GenericApi.Bl.DTOs;
using GenericApi.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        readonly IFileService _fileService;
        readonly IDocumentService _documentService;
        public FileController(IDocumentService documentService, IFileService fileService)
        {
            _fileService = fileService;
            _documentService = documentService;
        }

        [Route("upload-many")]
        [HttpPost]
        public async Task<IActionResult> UploadFiles(IFormFile[] files)
        {
            if (files == null || files.Any() == false)
                return UnprocessableEntity();

            var filesDto = new List<DocumentDto>();

            var result = await _fileService.Upload(files);
            foreach (var item in result)
            {
                if (item.Success)
                {
                    filesDto.Add(new DocumentDto
                    {
                        ContentType = item.Entity.ContentType,
                        FileName = item.FileName,
                        OriginalName = item.Entity.FileName.Replace("\"", string.Empty)
                    });
                }
            }
            return Ok(filesDto);
        }

        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null)
                return UnprocessableEntity();

            var result = await _fileService.Upload(file);
            if (!result.Success)
                return BadRequest(result);

            return Ok(new DocumentDto
            {
                ContentType = result.Entity.ContentType,
                FileName = result.FileName,
                OriginalName = result.Entity.FileName.Replace("\"", string.Empty)
            });
        }
        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download([FromRoute] int id)
        {
            var doc = await _documentService.GetByIdAsync(id);
            if (doc == null)
                return BadRequest();

            var response = _fileService.Download(doc.FileName, doc.ContentType);

            return response;
        }

        [HttpGet("download")]
        public FileStreamResult Download([FromQuery] string fileName, [FromQuery] string contentType)
        {
            var response = _fileService.Download(fileName, contentType);

            return response;
        }
    }
}
