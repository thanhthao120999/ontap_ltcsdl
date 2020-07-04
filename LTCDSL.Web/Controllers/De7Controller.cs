using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTCSDL.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using System.Collections.Generic;
    //using BLL.Req;
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class De7Controller : ControllerBase
    {
        public De7Controller()
        {
            _svc = new De7Svc();
        }

        [HttpPost("ca1A_get-order-by-employeeName-with-paging")]
        public IActionResult cau1A_getOrderByEmployeeNameWithPaging([FromBody] SearchOrderReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.cau1A_getOrderByEmployeeNameWithPaging(req.keyword, req.page, req.size);
            return Ok(res);
        }

        [HttpPost("ca1B_get-order-by-customerName-with-paging")]
        public IActionResult cau1B_findOrderByCustomerNameWithPaging([FromBody] SearchOrderReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.cau1B_findOrderByCustomerNameWithPaging(req.keyword, req.page, req.size);
            return Ok(res);
        }

        [HttpPost("ca1C_get-order-by-productName-with-paging")]
        public IActionResult cau1C_findOrderByProductNameWithPaging([FromBody] SearchOrderReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.cau1C_findOrderByProductNameWithPaging(req.keyword, req.page, req.size);
            return Ok(res);
        }

        [HttpPost("ca3A_get-order-by-productName-with-paging_linQ")]
        public IActionResult cau3A_findOrderByProductNameWithPaging_LinQ([FromBody] SearchOrderReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.cau3A_findOrderByProductNameWithPaging_LinQ(req.keyword, req.page, req.size);
            return Ok(res);
        }

        private readonly De7Svc _svc;
    }
}