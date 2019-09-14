using Microsoft.Crm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;


using CRM4WebService.Models;
using NLog;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Web;

using Microsoft.Crm.Sdk.Query;
using Microsoft.Crm.SdkTypeProxy;
using Microsoft.Xrm.Client;

namespace CRM4WebService.Controllers
{
    public class Integration1CController : ApiController
    {

        private Logger logger;

        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is: " + DateTime.Now.ToString());
        }


        [Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        }


        /// <summary>
        /// По id договора возвращает массив значений
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Integration1C/5
        public HttpResponseMessage Get(string id)
        {
            //595CC35C-30D2-E911-80CC-005056BAC107
            BusinessEntityCollection opportunity;
            Opp o = new Opp();
            Lookup new_regionid = new Lookup();
            string nameopp = "";
            opportunity = o.searchOpportunity(id);
            foreach (Microsoft.Crm.Sdk.DynamicEntity opp in opportunity.BusinessEntities)
            {
                if (opp.Properties.Contains("new_regionid"))
                {
                    new_regionid = (Lookup)opp["new_regionid"];
                    nameopp = opp["name"].ToString();
                    //return String.Format("<name>{0}</name><new_regionid>{1}</new_regionid>", opp["name"].ToString(),customer.Value);


                }
                //else
                //{
                //    return new HttpResponseMessage()
                //    {
                //        Content = new StringContent("<report><error>Ошибка</error></report>", Encoding.UTF8, "application/xml")
                //    };
                //};





            }


            string XML = String.Format("<report><name>{0}</name><new_regionid>{1}</new_regionid></report>", nameopp, new_regionid.Value.ToString());
            return new HttpResponseMessage()
            {
                Content = new StringContent(XML, Encoding.UTF8, "application/xml")
            };

        }

        // POST: api/Integration1C
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Integration1C/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Integration1C/5
        public void Delete(int id)
        {
        }
    }
}
