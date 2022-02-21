using MediatR;
using NgGlobal.DatabaseModels.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Commands.User
{
    public class ChangeUserStatusCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public UserStatus Status { get; set; }
    }
}
