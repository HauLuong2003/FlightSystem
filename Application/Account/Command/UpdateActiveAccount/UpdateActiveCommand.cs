using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Account.Command.UpdateActiveAccount
{
    public class UpdateActiveCommand : IRequest<Unit>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
