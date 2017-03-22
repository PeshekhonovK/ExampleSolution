using Example.API.Filters;
using Example.BLL;
using Example.DTO;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Example.API.Controllers
{
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentBLL departmentBLL;
        private readonly IEmployeeBLL employeeBLL;

        public DepartmentController(IDepartmentBLL departmentBll, IEmployeeBLL employeeBll)
        {
            this.departmentBLL = departmentBll;
            employeeBLL = employeeBll;
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