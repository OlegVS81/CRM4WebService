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

    public class Reestr
    {
        /// <summary>
        /// Номер реестра
        /// </summary>
        public String txn_id;

        /// <summary>
        /// Дата оплаты
        /// </summary>
        public String txn_date;

        /// <summary>
        /// GUID Договора на обучение
        /// </summary>
        public Guid opportunityID;

        /// <summary>
        /// Сумма оплаты
        /// </summary>
        public String sum;

        Logger logger = LogManager.GetCurrentClassLogger();

        public BusinessEntityCollection searchnew_reestr(string txn_id)
        {
            CrmConnection crmc = new CrmConnection("Crm");
            CrmService crmService = crmc.CreateCrmService();

            QueryExpression qe = new QueryExpression("new_reestr")
            {
                ColumnSet = new ColumnSet(new String[] { "new_txn_id", "new_reestrid", "new_name" }),
                Criteria = new FilterExpression()
                {
                    FilterOperator = LogicalOperator.And,
                    Conditions =
                        {
                            new ConditionExpression("new_txn_id", ConditionOperator.Equal, txn_id),
                            new ConditionExpression("statecode", ConditionOperator.Equal, 0),
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
            catch (SoapException ex)
            {
                logger.Error($"Не удалось осуществить поиск Реестра оплат txn_id = {txn_id}. Ошибка: {ex.Message}");
                throw;
            }

        }


        public string Pay(Reestr r)
        {
            logger.Info("_______pay______");
            logger.Info(r.txn_id);
            logger.Info(r.txn_date);
            logger.Info(r.opportunityID);
            logger.Info(r.sum);
            logger.Info("_______pay______");

            String errormsg = "";

            BusinessEntityCollection opportunity;
            BusinessEntityCollection existing_reestr;
            try
            {
                existing_reestr = searchnew_reestr(r.txn_id);
                foreach (Microsoft.Crm.Sdk.DynamicEntity reestr in existing_reestr.BusinessEntities)
                {
                    errormsg = $"Реестра оплат с именем {r.txn_id} уже существует. new_reestrid: {((Microsoft.Crm.Sdk.Key)((reestr).Properties["new_reestrid"])).Value.ToString()}";
                    logger.Error(errormsg);
                    return errormsg;
                }
            }
            catch (Exception ex)
            {
                errormsg = $"Не удалось осуществить поиск Реестра оплат с txn_id={r.txn_id}. Ошибка: {ex.Message}";
                logger.Error(errormsg);
                return errormsg;
            }


            try
            {
                Opp opp = new Opp();
                opportunity = opp.searchOpportunity(r.opportunityID.ToString());
            }
            catch (Exception ex)
            {
                errormsg = $"Не удалось осуществить поиск договора № {r.opportunityID.ToString()}. Ошибка: {ex.Message}";
                logger.Error(errormsg);
                return errormsg;
            }


            CrmConnection crmc = new CrmConnection("Crm");
            CrmService crmService = crmc.CreateCrmService();

            DynamicEntity new_reestr = new DynamicEntity("new_reestr");
            new_reestr.Name = "new_reestr";

            
            foreach (Microsoft.Crm.Sdk.DynamicEntity opp in opportunity.BusinessEntities)
            {
                
                try
                {
                    // new_reestr.Properties.Add(new CrmDateTimeProperty("new_data", CrmTypes.CreateCrmDateTimeFromUser(DateTime.ParseExact(txn_date, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                    new_reestr.Properties.Add(new CrmDateTimeProperty("new_data", CrmDateTime.FromUser(DateTime.ParseExact(r.txn_date, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));

                }
                catch (Exception ex)
                {
                    errormsg = $"Не удалось конвертировать входное значение txn_date=[{r.txn_date}] в дату. Ошибка: {ex.Message}";
                    logger.Error(errormsg);
                    return errormsg;
                }
                try
                {
                    new_reestr.Properties.Add(new CrmMoneyProperty("new_summ", new CrmMoney(decimal.Parse(r.sum, CultureInfo.InvariantCulture))));
                }
                catch (Exception ex)
                {
                    errormsg = $"Не удалось конвертировать входное значение sum=[{r.sum}] в decimal. Ошибка: {ex.Message}";
                    logger.Error(errormsg);
                    return errormsg;
                }

                new_reestr.Properties.Add(new PicklistProperty("new_source", new Picklist(10)));//Интернет - эквайринг
                new_reestr.Properties.Add(new StringProperty("new_name", r.txn_id.ToString()));
                new_reestr.Properties.Add(new StringProperty("new_txn_id", r.txn_id.ToString()));
                new_reestr.Properties.Add(new LookupProperty("new_dogovor", new Lookup("opportunity", ((Microsoft.Crm.Sdk.Key)(((Microsoft.Crm.Sdk.DynamicEntity)opportunity.BusinessEntities[0]).Properties["opportunityid"])).Value)));
                if (opp.Properties.Contains("new_signdate"))
                    new_reestr.Properties.Add(new CrmDateTimeProperty("new_data_dogovor", (CrmDateTime)opp["new_signdate"]));
                if (opp.Properties.Contains("customerid"))
                {
                    Customer customer = (Customer)opp["customerid"];
                    new_reestr.Properties.Add(new LookupProperty("new_customerid", new Lookup(customer.type, customer.Value)));
                }

                if (opp.Properties.Contains("new_programsidcost"))
                {
                    Lookup lu = (Lookup)opp["new_programsidcost"];
                    new_reestr.Properties.Add(new LookupProperty("new_programsid", new Lookup(lu.type, lu.Value)));
                }

                if (opp.Properties.Contains("new_studyplaceid"))
                {
                    Lookup lu = (Lookup)opp["new_studyplaceid"];
                    new_reestr.Properties.Add(new LookupProperty("new_studyplaceid", new Lookup(lu.type, lu.Value)));
                }
                if (opp.Properties.Contains("new_placeofwriteid"))
                {
                    Lookup lu = (Lookup)opp["new_placeofwriteid"];
                    new_reestr.Properties.Add(new LookupProperty("new_placeofwriteid", new Lookup(lu.type, lu.Value)));
                }
                if (opp.Properties.Contains("ownerid"))
                {
                    Owner lu = (Owner)opp["ownerid"];
                    new_reestr.Properties.Add(new LookupProperty("new_ownerid", new Lookup(lu.type, lu.Value)));
                }
                DateTime new_month_income = DateTime.ParseExact(r.txn_date, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                new_month_income = new_month_income.AddDays((new_month_income.Day * -1) + 1);
                new_month_income = new_month_income.AddHours((new_month_income.Hour * -1) + 12);
                new_reestr.Properties.Add(new CrmDateTimeProperty("new_month_income", CrmDateTime.FromUser(new_month_income)));

            }
            Guid new_reestrID = Guid.Empty;
            try
            {
                new_reestrID = crmService.Create(new_reestr);
            }
            catch (Exception ex)
            {
                errormsg = $"Не удалось Создать запись реестра оплат для договора № {r.opportunityID.ToString()}. Ошибка: {ex.Message}";
                logger.Error(errormsg);
                return errormsg;
            }
            return new_reestrID.ToString();

        }


    }

}