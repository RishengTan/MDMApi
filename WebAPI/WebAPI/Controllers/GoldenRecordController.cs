using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MDMDataAccess;

namespace WebAPI.Controllers
{
    public class GoldenRecordController : ApiController
    {
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public IEnumerable<vw_MDMGoldenRecord> GetAllRecords()
        {
            using (PVDR_MDMEntities entities = new PVDR_MDMEntities())
            {
                return entities.vw_MDMGoldenRecord.ToList();
            }
        }
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetRecordByNPI(string NPI)
        {
            using (PVDR_MDMEntities entities = new PVDR_MDMEntities())
            {
                if (NPI == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "NPI is empty");
                }
                else
                {
                    var searchResponse = entities.vw_MDMGoldenRecord.Where(e => e.NPI.ToLower() == NPI).ToList();
                    if (searchResponse.Count() > 0)
                        return Request.CreateResponse(HttpStatusCode.OK, searchResponse);
                    else
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The NPI " + NPI + " not found in database");
                }

            }
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage searchRecordByNPI(string LastName)
        {
            using (PVDR_MDMEntities entities = new PVDR_MDMEntities())
            {
                if (LastName == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "".ToArray());
                }
                else
                {
                    var searchResponse = entities.vw_MDMGoldenRecord.Where(e => e.LastName.Contains(LastName)).ToList();
                    if (searchResponse.Count() > 0)
                        return Request.CreateResponse(HttpStatusCode.OK, searchResponse);
                    else
                        return Request.CreateResponse(HttpStatusCode.OK,"".ToArray());
                }

            }
        }
    }
}
