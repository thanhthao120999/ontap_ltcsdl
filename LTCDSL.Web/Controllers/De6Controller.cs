using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTCSDL.BLL;
using LTCSDL.Common.Req;
using LTCSDL.Common.Rsp;
using Microsoft.AspNetCore.Mvc;

namespace LTCSDL.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class De6Controller : ControllerBase
    {
        private readonly De6SVC _svc;
        public De6Controller()
        {
            _svc = new De6SVC();
        }

        [HttpPost("cau1a-getproductbykeyword")]
        public IActionResult cau1A_getOrderByEmployeeNameWithPaging([FromBody] SearchProductReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.cau1A_getproductbykeyword(req.keyword, req.page, req.size);
            return Ok(res);
        }

        [HttpPost("Cau1b_getProductbyCategoryID")]
        public IActionResult Cau1b_getProductbyCategoryID([FromBody] SearchProductReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.Cau1b_getProductbyCategoryID(req.CategoryID, req.page, req.size);
            return Ok(res);
        }
        [HttpPost("Cau1c_getProductbyPriceMinMax")]
        public IActionResult Cau1c_getProductbyPriceMinMax([FromBody] SearchProductReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.Cau1c_getProductbyPriceMinMax(req.MinPrice,req.MaxPrice, req.page, req.size);
            return Ok(res);
        }

    }
}