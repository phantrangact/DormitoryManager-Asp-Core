using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryManager.Utilities.DTO
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public PagedResult()
        {
            Results = new List<T>();
        }
        public IList<T> Results { get; set; }
    }

    public class PageResultCustomer<T> : PagedResult<T> where T : class
    {
        public PageResultCustomer()
        {
            Results = new List<T>();
        }
        public int TotalCustomer { get; set; }
    }
}
