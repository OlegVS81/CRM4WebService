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
    public class OnlineContactController : ApiController
    {
        Logger Online_log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Создание контакта
        /// </summary>
        /// <param name="value">json контакта</param>
        /// <returns>Возвращает GUID договора или ошибку</returns>
        [Authorize]
        // POST: api/OnlineContact
        public HttpResponseMessage Post([FromBody] Contact value)
        {
            GlobalStore Proverka = new GlobalStore();
            HttpResponseMessage response;

            string json = JsonConvert.SerializeObject(value);
            Online_log.Info($"Try Post. Count: {GlobalStore.CurrentCount}. Contact: {json}");

            if (Proverka.Check())
            {

                Contact c = new Contact();
                Guid g = new Guid();
                var contactid = c.CreateContact(new Guid("{00000000-0000-0000-0000-000000000000}"), value);

                if ((contactid == null))
                    response = new HttpResponseMessage(HttpStatusCode.NotModified);
                else
                {
                    if (Guid.TryParse(contactid, out g))
                        response = Request.CreateResponse(HttpStatusCode.OK, contactid);
                    else
                        response = Request.CreateResponse(HttpStatusCode.Conflict, contactid);

                    response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(300));
                    Online_log.Info($"Ok Post  {response.StatusCode.ToString()}. Count: {GlobalStore.CurrentCount}. Contact: {contactid.ToString()}");
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
        /// Обновление контакта
        /// </summary>
        /// <param name="id">id контакта</param>
        /// <param name="value">json контакта</param>
        /// <returns></returns>
        [Authorize]
        // PUT: api/OnlineContact/5
        public HttpResponseMessage Put(Guid id, [FromBody] Contact value)
        {

            HttpResponseMessage response;
            GlobalStore Proverka = new GlobalStore();

            string json = JsonConvert.SerializeObject(value);
            Online_log.Info($"Try Put. Count= {GlobalStore.CurrentCount}. Contact: {id.ToString()} {json}");


            if (Proverka.Check())
            {

                Contact c = new Contact();
                Guid g = new Guid();
                var contactid = c.CreateContact(id, value);

                if ((contactid == null))
                    response = new HttpResponseMessage(HttpStatusCode.NotModified);
                else
                {
                    if (Guid.TryParse(contactid, out g))
                        response = Request.CreateResponse(HttpStatusCode.OK, id);
                    else
                        response = Request.CreateResponse(HttpStatusCode.Conflict, id);

                    //response = Request.CreateResponse(HttpStatusCode.OK, id);
                    response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(300));
                    Online_log.Info($"Ok Put {response.StatusCode.ToString()}. Count: {GlobalStore.CurrentCount}. Contact : {id.ToString()}");
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
        /// Проверяет существование контакта по id
        /// </summary>
        /// <param name="id">id контакта</param>
        /// <returns></returns>
        // GET: api/OnlineContact/5
        [Authorize]
        public HttpResponseMessage Get(string id)
        {
            Online_log.Info($"Get Contact {id.ToString()}");

            HttpResponseMessage response;

            Contact c = new Contact();

            String ln ="";
            BusinessEntityCollection fcontact = c.searchContact(id);
            foreach (DynamicEntity cont1 in fcontact.BusinessEntities)
            {
                ln = cont1["lastname"].ToString();
            }

            if ((ln != ""))
                response = Request.CreateResponse(HttpStatusCode.OK, ln);
            else
                response = Request.CreateResponse(HttpStatusCode.NoContent, ln);
            
            return response;

        }


        }
}
