﻿using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documents.Queries.GetDocumentByType
{
    public  class GetDocumentByType : IRequest<List<DocumentDTO>>
    {
        [Required]
        public Guid TypeId {  get; set; }
    }
}
