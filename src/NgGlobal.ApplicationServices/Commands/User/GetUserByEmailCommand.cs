using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using System.Collections.Generic;

namespace NgGlobal.ApplicationServices.Commands
{
    public class GetUserByEmailCommand:IRequest<List<UserDto>>
    {
        public string Email { get; set; }
    }
}
