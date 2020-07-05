using Newtonsoft.Json;

using LTCSDL.BLL;
using LTCSDL.Common.Rsp;
using LTCSDL.Common.BLL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LTCSDL.BLL
{
    using DAL;    
    using DAL.Models;

    public class De7Svc : GenericSvc<De7Rep, Orders>
    {
        #region -- Overrides --

        // Câu 2 cho 1A
        public object cau1A_getOrderByEmployeeNameWithPaging(string keyword, int page, int size)
        {
            var res = new SingleRsp();

            var m = _rep.Cau1A_getOrderByEmployeeNameWithPaging(keyword, page, size);
            res.Data = m;

            return res;
        }

        // Câu 2 cho 1B
        public object cau1B_findOrderByCustomerNameWithPaging(string keyword, int page, int size)
        {
            var res = new SingleRsp();

            var m = _rep.cau1B_findOrderByCustomerNameWithPaging(keyword, page, size);
            res.Data = m;

            return res;
        }

        // Câu 2 cho 1C
        public object cau1C_findOrderByProductNameWithPaging(string keyword, int page, int size)
        {
            var res = new SingleRsp();

            var m = _rep.cau1C_findOrderByProductNameWithPaging(keyword, page, size);
            res.Data = m;

            return res;
        }

        // Câu 3A
        public object cau3A_findOrderByProductNameWithPaging_LinQ(string keyword, int page, int size)
        {
            var res = new SingleRsp();

            var m = _rep.Cau3A_findOrderByProductNameWithPaging_LinQ(keyword, page, size);
            res.Data = m;

            return res;
        }

        // Câu 3B
        public object Cau3B_findProductWithoutOrderWithPaging_LinQ(DateTime date, int page, int size)
        {
            var res = new SingleRsp();

            var m = _rep.Cau3B_findProductWithoutOrderWithPaging_LinQ(date, page, size);
            res.Data = m;

            return res;
        }


        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public De7Svc() { }
      

        #endregion
    }
}
