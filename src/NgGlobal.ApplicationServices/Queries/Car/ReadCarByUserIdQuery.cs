﻿using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Queries
{
    public class ReadCarByUserIdQuery : IRequest<CarDto>
    {
        public int UserId { get; set; } 
    }
}
