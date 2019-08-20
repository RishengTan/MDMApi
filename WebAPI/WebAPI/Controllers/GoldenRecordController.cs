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
        //[HttpGet]
        //public IEnumerable<vw_MDMGoldenRecord> GetAllRecords()
        //{
        //    using (PVDR_MDMEntities entities = new PVDR_MDMEntities())
        //    {
        //        return entities.vw_MDMGoldenRecord.ToList();
        //    }
        //}

        [HttpGet]
        public IEnumerable<vw_MDMGoldenRecord> GeFilteredRecords(string lastName, string middleName, string firstName, string NPI, int? dob, int? speciality, string billingAddress, string zipCode)
        {
            using (PVDR_MDMEntities entities = new PVDR_MDMEntities())
            {
                bool isSearchCriteriaApplied = false;
                
                IQueryable<vw_MDMGoldenRecord> query = entities.vw_MDMGoldenRecord;
                if (lastName != null && lastName != "")
                {
                    query = query.Where(e => e.LastName.Contains(lastName));
                    isSearchCriteriaApplied = true;
                }
                if (middleName != null && middleName != "")
                {
                    query = query.Where(e => e.MiddleName == middleName);
                    isSearchCriteriaApplied = true;
                }

                if (firstName != null && firstName != "")
                {
                    query = query.Where(e => e.FirstName.Contains(firstName));
                    isSearchCriteriaApplied = true;
                }

                if (NPI != null && NPI != "")
                {
                    query = query.Where(e => e.NPI == NPI);
                    isSearchCriteriaApplied = true;
                }

                if (dob != null)
                {
                    query = query.Where(e => e.DOB == dob);
                    isSearchCriteriaApplied = true;
                }

                if (speciality != null)
                {
                    query = query.Where(e => e.Specialtycode == speciality);
                    isSearchCriteriaApplied = true;
                }

                if (billingAddress != null && billingAddress != "")
                {
                    query = query.Where(e => e.BillAddr.Contains(billingAddress));
                    isSearchCriteriaApplied = true;
                }

                if (zipCode != null && zipCode != "")
                {
                    query = query.Where(e => e.Zip == zipCode);
                    isSearchCriteriaApplied = true;
                }
                vw_MDMGoldenRecord[] goldenrecord;
                if (isSearchCriteriaApplied == true)
                {
                    goldenrecord = query.ToArray();
                    return goldenrecord.ToList();
                }
                else
                    return goldenrecord = null;
            }
        }


        //[HttpGet]
        //public HttpResponseMessage GetRecordByNPI(string NPI)
        //{
        //    using (PVDR_MDMEntities entities = new PVDR_MDMEntities())
        //    {
        //        if (NPI == null)
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "NPI is empty");
        //        }
        //        else
        //        {
        //            var searchResponse = entities.vw_MDMGoldenRecord.Where(e => e.NPI.ToLower() == NPI).ToList();
        //            if (searchResponse.Count() > 0)
        //                return Request.CreateResponse(HttpStatusCode.OK, searchResponse);
        //            else
        //                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The NPI " + NPI + " not found in database");
        //        }

        //    }
        //}

        //[HttpGet]
        //public HttpResponseMessage searchRecordByNPI(string LastName)
        //{
        //    using (PVDR_MDMEntities entities = new PVDR_MDMEntities())
        //    {
        //        if (LastName == null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, "".ToArray());
        //        }
        //        else
        //        {
        //            var searchResponse = entities.vw_MDMGoldenRecord.Where(e => e.LastName.Contains(LastName)).ToList();
        //            if (searchResponse.Count() > 0)
        //                return Request.CreateResponse(HttpStatusCode.OK, searchResponse);
        //            else
        //                return Request.CreateResponse(HttpStatusCode.OK,"".ToArray());
        //        }

        //    }
        //}
    }
}
