﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.Common.Req
{
    public class SearchProductWithoutOrderReq
    {
        public DateTime date { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
}
