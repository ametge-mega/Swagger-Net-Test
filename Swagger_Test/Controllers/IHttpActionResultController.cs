﻿using Swagger.Net.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace Swagger_Test.Controllers
{
    public class IHttpActionResultController : ApiController
    {
        // GET: api/IHttpActionResult
        [ResponseType(typeof(IEnumerable<string>))]
        public IHttpActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET: api/IHttpActionResult/{id}
        [SwaggerResponse(HttpStatusCode.OK, "List of customers", typeof(IEnumerable<int>))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(BadRequestErrorMessageResult))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        //[SwaggerResponse(HttpStatusCode.TooManyRequests, Type = typeof(NotFoundResult))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(InternalServerErrorResult))]
        [SwaggerResponse(HttpStatusCode.Forbidden, "Forbidden", typeof(void))]
        [SwaggerExample("id", "123456")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                if (id == 400)
                    return BadRequest();
                else if (id == 401)
                    return Unauthorized();
                else if (id == 404)
                    return NotFound();
                else if (id == 429)
                    return NotFound();//TooManyRequests();
                else if (id == 500)
                    return InternalServerError();
                else if (id > 0)
                    return Ok(new int[] { 1, 2 });
                else if (id == 0)
                    return NotFound();
                else
                    return BadRequest("id must be greater than 0");
            }
            catch
            {
                return InternalServerError();
            }
        }

        [SwaggerResponse(HttpStatusCode.OK, "List of customers", typeof(IEnumerable<int>))]
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        public IHttpActionResult Post(MyData data)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>My super duper data</summary>
    public class MyData
    {
        /// <summary>The unique identifier</summary>
        public int id { get; set; }

        /// <summary>Everyone needs a name</summary>
        public string name { get; set; }

        /// <summary>Details - testing anchor: <a href="?filter=TestPost">TestPost</a></summary>
        public string details { get; set; }
    }
}
