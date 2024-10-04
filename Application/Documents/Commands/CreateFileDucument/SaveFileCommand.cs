using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Commands.CreateFileDucument
{
    public class SaveFileCommand : IRequest<string>
    {

        public byte[] FileData { set; get; }
        public string FileName { set; get; }
        public string ContentType { set; get; }
    }
}
