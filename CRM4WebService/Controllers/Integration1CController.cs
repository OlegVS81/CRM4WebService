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
        Logger Integration1C_log = LogManager.GetCurrentClassLogger();

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("api/data/forall")]
        //public IHttpActionResult Get()
        //{
        //    return Ok("Now server time is: " + DateTime.Now.ToString());
        //}


        //[Authorize]
        //[HttpGet]
        //[Route("api/data/authenticate")]
        //public IHttpActionResult GetForAuthenticate()
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    return Ok("Hello " + identity.Name);
        //}

        //[Authorize(Roles = "admin")]
        //[HttpGet]
        //[Route("api/data/authorize")]
        //public IHttpActionResult GetForAdmin()
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    var roles = identity.Claims
        //                .Where(c => c.Type == ClaimTypes.Role)
        //                .Select(c => c.Value);
        //    return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        //}


        /// <summary>
        /// По id договора возвращает массив значений
        /// </summary>
        /// <param name="id">Должен быть в формате GUID. Присмер: 3C5C73AC-DDD6-E911-80CD-005056BAC107</param>
        /// <returns>возвращает xml в тэге report с
        /// , где 
        /// opportunityid - id договра;
        /// name - номер договора;
        /// new_contact2id - Законный представитель ФЛ/ Подписант ЮЛ;
        /// new_pay_installments - рассрочка в банке;
        /// new_discountpercent - % комиссии банка;
        /// new_commission_amount - Сумма комиссии банка;
        /// new_totalsumcost - Общая стоимость обучения с учетом пособий.
        /// 
        ///</returns>
        [Authorize]
        [HttpGet]
        [Route("api/Integration1C")]
        public HttpResponseMessage Get(string id)
        {
            string XML = "";
            Integration1C_log.Info($"Integration1C. Get id='{id}'");
            //595CC35C-30D2-E911-80CC-005056BAC107
            BusinessEntityCollection opportunity;
            Opp o = new Opp();
            string nameopp = ""; //номер договора
            Lookup new_contact2id = new Lookup(); //Законный представитель ФЛ/ Подписант ЮЛ
            CrmBoolean new_pay_installments = new CrmBoolean(); //рассрочка в банке
            CrmFloat new_discountpercent = new CrmFloat(); //% комиссии банка
            CrmMoney new_commission_amount = new CrmMoney();//Сумма комиссии банка
            CrmMoney new_totalsumcost = new CrmMoney();//Общая стоимость обучения с учетом пособий

            try
            {
                opportunity = o.searchOpportunity(id);
                foreach (DynamicEntity opp in opportunity.BusinessEntities)
                {
                    nameopp = opp["name"].ToString();

                    if (opp.Properties.Contains("new_contact2id"))
                        new_contact2id = (Lookup)opp["new_contact2id"];

                    if (opp.Properties.Contains("new_pay_installments"))
                        new_pay_installments = (CrmBoolean)opp["new_pay_installments"];

                    if (opp.Properties.Contains("new_discountpercent"))
                        new_discountpercent = (CrmFloat)opp["new_discountpercent"];

                    if (opp.Properties.Contains("new_commission_amount"))
                        new_commission_amount = (CrmMoney)opp["new_commission_amount"];

                    if (opp.Properties.Contains("new_totalsumcost"))
                        new_totalsumcost = (CrmMoney)opp["new_totalsumcost"];

                }

            
                XML = String.Format("<report><opportunityid>{0}</opportunityid><name>{1}</name><new_contact2id>{2}</new_contact2id><new_pay_installments>{3}</new_pay_installments><new_discountpercent>{4}</new_discountpercent><new_commission_amount>{5}</new_commission_amount><new_totalsumcost>{6}</new_totalsumcost></report>", id, nameopp, new_contact2id.Value.ToString(), new_pay_installments.Value, new_discountpercent.Value, new_commission_amount.Value, new_totalsumcost.Value);
                Integration1C_log.Info($"Integration1C. Response xml='{XML}'");
                return new HttpResponseMessage()
                {
                    Content = new StringContent(XML, Encoding.UTF8, "application/xml")
                };
            }
            catch (Exception ex)
            {
                XML = String.Format("<report><error>{0}</error></report>", ex.ToString());

                return new HttpResponseMessage()
                {
                    Content = new StringContent(XML, Encoding.UTF8, "application/xml")
                };
            }

        }


        //// POST: api/Integration1C
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Integration1C/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Integration1C/5
        //public void Delete(int id)
        //{
        //}
    }
}
