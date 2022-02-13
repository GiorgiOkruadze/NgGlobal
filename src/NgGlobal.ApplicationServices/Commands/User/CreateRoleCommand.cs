using MediatR;
using NgGlobal.ApplicationShared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Commands.User
{
    public class CreateRoleCommand : IRequest<Unit>
    {
        public UserType Role { get; set; }
    }
}
