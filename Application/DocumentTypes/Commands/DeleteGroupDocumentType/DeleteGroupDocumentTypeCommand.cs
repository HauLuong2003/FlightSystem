﻿using Application.Common.ServiceResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DocumentTypes.Commands.DeleteGroupDocumentType
{
    public class DeleteGroupDocumentTypeCommand : IRequest<ServiceResponse>
    {
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public Guid TypeId { get; set; }
    }
}
