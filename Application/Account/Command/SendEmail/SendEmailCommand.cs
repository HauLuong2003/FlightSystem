using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.SendEmail
{
    public class SendEmailCommand : IRequest<bool>
    {
        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
