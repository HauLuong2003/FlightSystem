﻿using Application.Account.Command.LoginCommand;
using Application.Common.ServiceResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.ForgetPasswordCommand
{
    public class ForgetPassWordCommand : IRequest<string>
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
