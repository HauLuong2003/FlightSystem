using Application.Common.ServiceResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.VerificationToken
{
    public class VerificationTokenCommand : IRequest<ServiceResponse>
    {
        [Required]
        public string Email {  get; set; } = string.Empty;
        [Required, StringLength(6, MinimumLength = 6)]
        public string Token {  get; set; } =string.Empty;
    }
}
