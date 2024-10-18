using Application.Common.ServiceResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.ChangePasswordCommand
{
    public class ChangePasswordCommand :IRequest<ServiceResponse>
    {
        [Required]
        public string Email {  get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string  NewPassword { get; set; } = string.Empty;
        [Required, Compare("NewPassword")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
