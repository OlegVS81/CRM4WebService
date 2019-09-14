using Microsoft.Crm.Sdk;
using Microsoft.Crm.Sdk.Query;
using Microsoft.Crm.SdkTypeProxy;
using Microsoft.Xrm.Client;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM4WebService.Models
{
    public class Opp
    {
        private Logger logger;
        public string name { get; set; }
        public string customerid { get; set; }
        public string opportunityid { get; set; }

        public string new_signdate { get; set; }
        public string new_programsidcost { get; set; }
        public string new_studyplaceid { get; set; }
        public string new_placeofwriteid { get; set; }
        public string ownerid { get; set; }

        public BusinessEntityCollection searchOpportunity(string opportunityid)
        {
            CrmConnection crmc = new CrmConnection("Crm");
            CrmService crmService = crmc.CreateCrmService();

            QueryExpression qe = new QueryExpression("opportunity")
            {
                ColumnSet = new ColumnSet(new String[] { "opportunityid", "new_signdate", "new_programsidcost", "new_studyplaceid", "new_placeofwriteid", "ownerid", "customerid", "name", "new_regionid" }),
                Criteria = new FilterExpression()
                {
                    FilterOperator = LogicalOperator.And,
                    Conditions =
                        {
                        new ConditionExpression("opportunityid", ConditionOperator.Equal, opportunityid),
                        }
                }
            };
            try
            {
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
                throw;
            }

        }
    }
}