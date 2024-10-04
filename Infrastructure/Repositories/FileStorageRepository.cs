using FlightSystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FileStorageRepository : IFileStorageService
    {
        public async Task<string> UploadFile(byte[] fileData, string fileName, string contentType)
        {
            // tạo đường dẫn tới thư mục lưu
            var folderPath = Path.Combine("wwwroot", "FileDocument");

            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Đường dẫn nơi file sẽ được lưu
            var path = Path.Combine(folderPath, fileName);

            // Ghi file vào đường dẫn đã chỉ định
            await File.WriteAllBytesAsync(path, fileData);
            var pathDoc = "FileDocument/" + fileName;
            return pathDoc;
        }
    }
}
