using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace LTCSDL.Common.Req
{
    public class SearchProductReq
    {
        public string keyword { get; set; }
        public int page { get; set; }
        public int size { get; set; }
        public int CategoryID { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }

    }
}
