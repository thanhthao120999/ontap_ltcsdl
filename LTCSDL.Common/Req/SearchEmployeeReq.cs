using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.Common.Req
{
    public class SearchEmployeeReq
    {
        public string keyword { get; set; }
        public int page { get; set; }
        public int size { get; set; }
       
    }
}
