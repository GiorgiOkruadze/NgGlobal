using NgGlobal.ApplicationServices.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationShared.Paging
{
    public class PagingOutput<T> where T : class
    {
        public PagingHeader Paging { get; set; }
        public List<T> Items { get; set; }
    }
}
