using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.RefreshToken
{
    public class RefreshTokenCommand :IRequest<string>
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
