﻿using Application.Common.Mapping;
using FlightSystem.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GroupDTO : IMapFrom<Group>
    {
        public Guid GroupId { get; set; }

        public string Group_Name { get; set; } = string.Empty;

        public string? Note { get; set; }
        public DateTime? Create_at { get; set; }
        public DateTime? Update_at { get; set; }
        public Guid PermissionId { get; set; }
    }
}
