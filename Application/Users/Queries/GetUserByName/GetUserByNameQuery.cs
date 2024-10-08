using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByName
{
    public class GetUserByNameQuery : IRequest<List<UserDTO>>
    {
        [Required]
        public string Name { get; set; }    
    }
}
