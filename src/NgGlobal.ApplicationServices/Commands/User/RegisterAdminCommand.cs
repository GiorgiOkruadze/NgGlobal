﻿using MediatR;

namespace NgGlobal.ApplicationServices.Commands
{
    public class RegisterAdminCommand:IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}