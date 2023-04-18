using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using BLL.Services;

namespace _12_04_23_Lab_task.Controllers
{
    public class ProjectController : ApiController
    {
        [HttpGet]
        [Route("api/projects")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ProjectService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/projects/{status}")]
        public HttpResponseMessage GetStatusBased(string status)
        {
            try
            {
                var data = ProjectService.GetStatusBased(status);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/projects/{status}/{startdate}")]
        public HttpResponseMessage GetDateBased(string status, string startdate)
        {
            try
            {
                var data = ProjectService.GetDateBased(status, Convert.ToDateTime(startdate));
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
    }
}