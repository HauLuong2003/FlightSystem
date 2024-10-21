using Application.Common.ServiceResponse;
using FlightSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.LoginCommand
{
    public class Login : IRequest<string>
    {
        [Required(ErrorMessage ="Email required"), EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password required"), MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [ StringLength(6, MinimumLength = 6)]
        public string? Captcha { get; set; } = string.Empty;
    }
}
