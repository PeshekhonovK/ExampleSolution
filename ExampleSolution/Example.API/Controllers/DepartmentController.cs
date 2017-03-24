using Example.API.Filters;
using Example.BLL;
using Example.DTO;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Example.API.Controllers
{
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentBLL departmentBLL;

        public DepartmentController(IDepartmentBLL departmentBll)
        {
            this.departmentBLL = departmentBll;
        }

        [MethodDebugFilter]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse(this.departmentBLL.GetAll().Select(x => new DepartmentDTO().MapFromModel(x)).ToArray());
        }

        [HttpGet]
        public HttpResponseMessage Get(Guid id)
        {
            return this.Request.CreateResponse(new DepartmentDTO().MapFromModel(this.departmentBLL.GetById(id)));
        }
    }
}