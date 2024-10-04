using FlightSystem.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.CreateFileDucument
{
    public class SaveFileCommandHandler : IRequestHandler<SaveFileCommand, string>
    {
        private IFileStorageService _fileStorageService;
        public SaveFileCommandHandler(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }
        public async Task<string> Handle(SaveFileCommand request, CancellationToken cancellationToken)
        {
            var filedata = request.FileData;
            var fileName = request.FileName;
            var contentType = request.ContentType;
            var result = await _fileStorageService.UploadFile(filedata, fileName, contentType);
            return result;
        }
    }
}
