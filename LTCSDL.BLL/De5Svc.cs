using LTCSDL.Common.BLL;
using LTCSDL.Common.Rsp;
using LTCSDL.DAL;
using LTCSDL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.BLL
{
    public class De5Svc : GenericSvc<De5Rep, Employees>
    {
        public object Cau1C_searchemployeebykeyword(string keyword, int page, int size)
        {
            var res = new SingleRsp();

            var m = _rep.Cau1C_searchemployeebykeyword(keyword, page, size);
            res.Data = m;

            return res;
        }
    }
}
