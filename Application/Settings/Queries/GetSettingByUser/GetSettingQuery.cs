using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Settings.Queries.GetSettingByUser
{
    public class GetSettingQuery:IRequest<SettingDTO>
    {
        public Guid UserId { get; set; }
    }
}
