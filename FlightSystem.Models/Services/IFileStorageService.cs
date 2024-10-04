using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Domain.Services
{
    public interface IFileStorageService
    {
        Task<string> UploadFile(byte[] fileData, string fileName, string contentType);
    }
}
