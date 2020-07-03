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
    public class CategoriesController : ControllerBase
    {
        public CategoriesController()
        {
            _svc = new CategoriesSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("get-employee-and-total-by-time")]
        public IActionResult getEmployeeAndToTalByTime(string dateFrom, string dateTo)
        {
            var res = new SingleRsp();
            res.Data = _svc.getEmployeeAndToTalByTime(dateFrom, dateTo);
            return Ok(res);
        }

        [HttpPost("nhap-thang-nam-xuat-doanh-thu")]
        public IActionResult nhapThangVaNamXuatDoanhThuTheoQuocGia(int month, int year)
        {
            var res = new SingleRsp();
            res.Data = _svc.nhapThangVaNamXuatDoanhThuTheoQuocGia(month, year);
            return Ok(res);
        }

        private readonly CategoriesSvc _svc;
    }
}