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
    using LTCSDL.Common.BLL;

    [Route("api/[controller]")]
    [ApiController]
    public class De5Controller : ControllerBase
    {
        private readonly De5Svc _svc;
        public De5Controller()
        {
            _svc = new De5Svc();
        }

        [HttpPost("Cau1C_searchemployeebykeyword")]
        public IActionResult Cau1C_searchemployeebykeyword([FromBody] SearchEmployeeReq req)
     
        {
            var res = new SingleRsp();
            res.Data = _svc.Cau1C_searchemployeebykeyword(req.keyword, req.page, req.size);
            return Ok(res);
        }
    }
    }