using CRM4WebService.Models;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.SdkTypeProxy;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web.Http;

namespace CRM4WebService.Controllers
{
    public class OnlineContractsController : ApiController
    {

        Logger Online_log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Создание договора
        /// </summary>
        /// <param name="value">json договора</param>
        /// <returns>Возвращает GUID договора или ошибку</returns>
        [Authorize]
        // POST: api/OnlineContracts
        public HttpResponseMessage Post([FromBody] Opp value)
        {
            GlobalStore Proverka = new GlobalStore();
            HttpResponseMessage response;

            string json = JsonConvert.SerializeObject(value);
            Online_log.Info($"Try Post. Count: {GlobalStore.CurrentCount}. Contract: {json}");

            if (Proverka.Check())
            {
                Opp o = new Opp();
                Guid g = new Guid();
                var opportunityid = o.CreateOpp(new Guid("{00000000-0000-0000-0000-000000000000}"), value);

                if ((opportunityid == null))// || (opportunityid == new Guid("{00000000-0000-0000-0000-000000000000}")))
                    response = new HttpResponseMessage(HttpStatusCode.NotModified);
                else
                {
                    if (Guid.TryParse(opportunityid, out g))
                        response = Request.CreateResponse(HttpStatusCode.OK, opportunityid);
                    else
                        response = Request.CreateResponse(HttpStatusCode.Conflict, opportunityid);

                    response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(300));
                    Online_log.Info($"Ok Post  {response.StatusCode.ToString()}. Count: {GlobalStore.CurrentCount}. Contract: {opportunityid.ToString()}");

                }
            }
            else
            {
                string err = $"Много обращений! Count= {GlobalStore.CurrentCount}. Не более {Properties.Settings.Default.Count} в {Properties.Settings.Default.Interval} секунд";
                response = Request.CreateResponse(HttpStatusCode.Forbidden, err);
                Online_log.Error(err);
            }

            return response;
        }


        /// <summary>
        /// Обновление договора
        /// </summary>        
        /// <param name="id">GUID договора</param>
        /// <param name="value">json договора</param>
        /// <returns>Возвращает GUID договора или ошибку</returns>
        [Authorize]
        // PUT: api/OnlineContracts/5
        public HttpResponseMessage Put(Guid id, [FromBody] Opp value)
        {
            HttpResponseMessage response;
            GlobalStore Proverka = new GlobalStore();

            string json = JsonConvert.SerializeObject(value);
            Online_log.Info($"Try Put. Count= {GlobalStore.CurrentCount}. Contract: {id.ToString()} {json}");
            
            if (Proverka.Check())
            {


                Opp o = new Opp();
                Guid g = new Guid();
                var opportunityid = o.CreateOpp(id, value);

                if ((opportunityid == null))// || (opportunityid == new Guid("{00000000-0000-0000-0000-000000000000}")))
                    response = new HttpResponseMessage(HttpStatusCode.NotModified);
                else
                {
                    if (Guid.TryParse(opportunityid, out g))
                        response = Request.CreateResponse(HttpStatusCode.OK, id);
                    else
                        response = Request.CreateResponse(HttpStatusCode.Conflict, id);

                    //response = Request.CreateResponse(HttpStatusCode.OK, id);
                    response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(300));
                    Online_log.Info($"Ok Put {response.StatusCode.ToString()}. Count: {GlobalStore.CurrentCount}. Contract : {id.ToString()}");
                 }
            }
            else
            {
                string err = $"Много обращений! Count= {GlobalStore.CurrentCount}. Не более {Properties.Settings.Default.Count} в {Properties.Settings.Default.Interval} секунд";
                response = Request.CreateResponse(HttpStatusCode.Forbidden, err);
                Online_log.Error(err);
            }

            return response;
        }

        /// <summary>
        /// Проверяет существование договора по id
        /// </summary>
        /// <param name="id">id договора</param>
        /// <returns>Возвращает наименование договора</returns>
        [Authorize]
        // GET: api/OnlineContracts/5
        public HttpResponseMessage Get(string id)
        {
            Online_log.Info($"Get Opportunity {id.ToString()}");

            HttpResponseMessage response;

            Opp c = new Opp();

            String ln = "";
            BusinessEntityCollection fcontact = c.searchOpportunity(id);
            foreach (DynamicEntity cont1 in fcontact.BusinessEntities)
            {
                ln = cont1["name"].ToString();
            }

            if ((ln != ""))
                response = Request.CreateResponse(HttpStatusCode.OK, ln);
            else
                response = Request.CreateResponse(HttpStatusCode.NoContent, ln);

            return response;

        }

    }
}
