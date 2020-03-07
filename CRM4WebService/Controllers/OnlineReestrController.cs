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
    public class OnlineReestrController : ApiController
    {
        Logger Online_log = LogManager.GetCurrentClassLogger();
        //// GET: api/OnlineReestr/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/OnlineReestr

        /// <summary>
        /// Ввод реестра оплат
        /// </summary>
        /// <param name="value">json Реестра оплат</param>
        /// <returns>Возращает id реестра оплат или ошибку</returns>
        [Authorize]
        public HttpResponseMessage Post([FromBody]Reestr value)
        {
            GlobalStore Proverka = new GlobalStore();
            HttpResponseMessage response;

            string json = JsonConvert.SerializeObject(value);
            Online_log.Info($"Try Post. Count: {GlobalStore.CurrentCount}. Reestr: {json}");

            if (Proverka.Check())
            {

                Reestr r = new Reestr();
                Guid g = new Guid();
                string reestrid = r.Pay(value);




                if ((reestrid == null))
                    response = new HttpResponseMessage(HttpStatusCode.NotModified);
                else
                {
                    if (Guid.TryParse(reestrid, out g))
                        response = Request.CreateResponse(HttpStatusCode.OK, reestrid);
                    else
                        response = Request.CreateResponse(HttpStatusCode.Conflict, reestrid);

                    response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(300));
                    Online_log.Info($"Ok Post  {response.StatusCode.ToString()}. Count: {GlobalStore.CurrentCount}. ReestrPay: {reestrid.ToString()}");
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
        /// Проверяет существование Реестра оплат по id
        /// </summary>
        /// <param name="id">id Реестра оплат</param>
        /// <returns></returns>
        // GET: api/OnlineReestr/5
        public HttpResponseMessage Get(string id)
        {
            Online_log.Info($"Get реестра оплат {0}", id.ToString());

            HttpResponseMessage response;

            Reestr c = new Reestr();

            String ln = "";
            BusinessEntityCollection fcontact = c.searchnew_reestr(id);
            foreach (DynamicEntity cont1 in fcontact.BusinessEntities)
            {
                ln = cont1["new_txn_id"].ToString();
            }

            if ((ln != ""))
                response = Request.CreateResponse(HttpStatusCode.OK, ln);
            else
                response = Request.CreateResponse(HttpStatusCode.NoContent, ln);

            return response;

        }


    }
}
