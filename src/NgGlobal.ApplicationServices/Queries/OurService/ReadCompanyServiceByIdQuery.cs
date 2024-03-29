﻿using MediatR;
using NgGlobal.ApplicationShared.DTOs;

namespace NgGlobal.ApplicationServices.Queries
{
    public class ReadCompanyServiceByIdQuery : IRequest<CompanyServiceDto> 
    { 
        public int CompanyServiceId { get; set; }
    }
}
