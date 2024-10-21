using MediatR;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Query.Captcha
{
    public class GetCaptchaQuery : IRequest<FileContentResult>
    {
    }
}
