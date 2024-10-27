using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.Logout
{
    public class LogoutCommand : IRequest<Unit>
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        public Guid Id { get; set; }
    }
}
