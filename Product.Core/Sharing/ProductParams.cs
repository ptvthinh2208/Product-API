using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Sharing
{
    public class ProductParams
    {
        private string _search;
        //Filter By Category
        public int? Categoryid { get; set; }
        //Sorting
        public string Sorting { get; set; }
        //Page size
        public int maxpagesize { get; set; } = 50;
        private int pagesize = 13;
        public int Pagesize
        {
            get => pagesize;
            set => pagesize = value > maxpagesize ? maxpagesize : value;
        }
        public int PageNumber { get; set; } = 1;
        //Search Web api
        public string Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }
    }
}
