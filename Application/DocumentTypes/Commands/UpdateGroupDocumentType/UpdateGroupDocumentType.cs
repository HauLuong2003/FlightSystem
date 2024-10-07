﻿using Application.Common.ServiceResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Commands.UpdateGroupDocumentType
{
    public class UpdateGroupDocumentType : IRequest<ServiceResponse>
    {
        public Guid GroupId { get; set; }
        public Guid TypeId { get; set; }
    }
}
