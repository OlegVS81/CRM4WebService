using Microsoft.Crm.Sdk;
using Microsoft.Crm.Sdk.Query;
using Microsoft.Crm.SdkTypeProxy;
using Microsoft.Xrm.Client;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace CRM4WebService.Models
{
    public class Opp
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        public string name { get; set; }
        public string customerid { get; set; }
        public string opportunityid { get; set; }

        public string new_signdate { get; set; }
        public string new_programsidcost { get; set; }
        public string new_studyplaceid { get; set; }
        public string new_placeofwriteid { get; set; }
        public string ownerid { get; set; }

        public Guid CreateOpp(opportunity opp)
        {
            CrmConnection crmc = new CrmConnection("Crm");
            CrmService crmService = crmc.CreateCrmService();

           
            Guid opportunityid = Guid.Empty;
            try
            {
                //opportunityid = crmService.Create(opp);

                // Создаем экземпляр динамческого объекта и указываем его имя
                DynamicEntity myDEUpdate = new DynamicEntity();
                myDEUpdate.Name = "opportunity";
                // Создаем KeyProperty для хранения GUID’а обновляемой записи
                KeyProperty myOpportunityGuid = new KeyProperty();
                myOpportunityGuid.Name = "opportunityid";
        
                // Указываем GUID обновляемой записи
                Key myOpportunityKey = new Key();
                //myOpportunityKey.Value = opportunityid;
                myOpportunityKey.Value = new Guid("{C02C3DBE-0FEA-E911-AAF3-005056BAC107}");                
                myOpportunityGuid.Value = myOpportunityKey;
                myDEUpdate.Properties.Add(myOpportunityGuid);

                // Создаем StringProperty с новым обновленным значением

                myDEUpdate.Properties.Add(new LookupProperty("campaignid", new Lookup("campaign", new Guid("{87FC5467-7706-DF11-8373-0026181D2843}"))));
                myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan1", new CrmMoney(decimal.Parse("123", CultureInfo.InvariantCulture))));

                //myDEUpdate.Properties.Add(new LookupProperty("ownerid", new Lookup("systemuser", new Guid("{0E850BC1-AC63-E611-B994-0026181D291A}"))));
                //myDEUpdate.Properties.Add(new LookupProperty("customerid", new Lookup("contact", new Guid("{D82EB827-BB4B-E911-9489-005056BAC107}"))));
                myDEUpdate.Properties.Add(new StringProperty("name", "qwe5"));

                crmService.Update(myDEUpdate);

                    return opportunityid;
            }
            catch (SoapException ex)
            {
                logger.Error($"Ошибка: {ex.Detail.InnerText}");
                return opportunityid;
            }
        }

        public BusinessEntityCollection searchOpportunity(string opportunityid)
        {

            try
            {
                CrmConnection crmc = new CrmConnection("Crm");
                CrmService crmService = crmc.CreateCrmService();

                QueryExpression qe = new QueryExpression("opportunity")
                {
                    ColumnSet = new ColumnSet(new String[] { "new_discountpercent", "new_pay_installments", "opportunityid", "new_contact2id", "new_signdate", "new_programsidcost", "new_studyplaceid", "new_placeofwriteid", "ownerid", "customerid", "name","new_commission_amount", "new_totalsumcost" }),
                    Criteria = new FilterExpression()
                    {
                        FilterOperator = LogicalOperator.And,
                        Conditions =
                            {
                            new ConditionExpression("opportunityid", ConditionOperator.Equal, opportunityid),
                            }
                    }
                };
                RetrieveMultipleResponse retrived = new RetrieveMultipleResponse();

                RetrieveMultipleRequest retrive = new RetrieveMultipleRequest();
                retrive.Query = qe;
                retrive.ReturnDynamicEntities = true;

                BusinessEntityCollection results = ((RetrieveMultipleResponse)crmService.Execute(retrive)).BusinessEntityCollection;

                return results;
            }
            catch (Exception ex)
            {
                logger.Error($"Не удалось осуществить поиск договора с id {opportunityid}. Ошибка: {ex.Message}");

                throw new System.ArgumentException($"Не удалось осуществить поиск договора с id {opportunityid}. Ошибка: {ex.Message}", "original");
               
            }

        }



    }
}