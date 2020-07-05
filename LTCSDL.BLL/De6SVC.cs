using LTCSDL.Common.BLL;
using LTCSDL.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.BLL
{
    using DAL;
    using DAL.Models;
    using LTCSDL.Common.Rsp;

    public  class De6SVC : GenericSvc<De6Rep, Products>
    {
        public object cau1A_getproductbykeyword(string keyword, int page, int size)
        {
            var res = new SingleRsp();

            var m = _rep.Cau1A_getproductbykeyword(keyword, page, size);
            res.Data = m;

            return res;
        }
        public object Cau1b_getProductbyCategoryID(int CategoryID, int page, int size)
        {
            var res = new SingleRsp();

            var m = _rep.Cau1b_getProductbyCategoryID(CategoryID, page, size);
            res.Data = m;

            return res;

        }
        public object Cau1c_getProductbyPriceMinMax(double MinPrice, double MaxPrice, int page, int size)
        {
            var res = new SingleRsp();

            var m = _rep.Cau1c_getProductbyPriceMinMax(MinPrice, MaxPrice, page, size);
            res.Data = m;

            return res;
        }


    }
}
