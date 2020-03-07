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
    public class Config
    {
        /// <summary>
        /// Имя
        /// </summary>
        public String new_name;

        /// <summary>
        /// Количество запросов
        /// </summary>
        public int new_count;

        /// <summary>
        /// Текущее значение запросов
        /// </summary>
        public int new_current_amount;
        
        /// <summary>
        /// Дата последнего запроса
        /// </summary>
        public String new_period;


        Logger logger = LogManager.GetCurrentClassLogger();


        public String CreateConfig(Guid new_config_allid, Config config)
        {
            Guid configid = new_config_allid;

            try
            {
                DynamicEntity conf = new DynamicEntity("new_reestr");
                conf.Name = "new_reestr";

                CrmConnection crmc = new CrmConnection("Crm");
                CrmService crmService = crmc.CreateCrmService();

                if (new_config_allid == new Guid("{00000000-0000-0000-0000-000000000000}"))
                    configid = crmService.Create(conf);

                // Создаем экземпляр динамческого объекта и указываем его имя
                DynamicEntity myDEUpdate = new DynamicEntity();
                myDEUpdate.Name = "new_config_allid";


                // Создаем KeyProperty для хранения GUID’а обновляемой записи
                KeyProperty myConfigGuid = new KeyProperty();
                myConfigGuid.Name = "new_config_allid";

                // Указываем GUID обновляемой записи
                Key myConfigKey = new Key();
                myConfigKey.Value = configid;
                myConfigGuid.Value = myConfigKey;
                myDEUpdate.Properties.Add(myConfigGuid);


                //if (conf.new_count != 0)
                //    myDEUpdate.Properties.Add(new CrmNumberProperty("new_count", new CrmNumber(conf.new_count)));


                ////Кем выдан
                //if (conf.new_giveoutby != null)
                //    myDEUpdate.Properties.Add(new StringProperty("new_giveoutby", contact.new_giveoutby));



                ////День рождения
                //if (contact.birthdate != null)
                //    myDEUpdate.Properties.Add(new CrmDateTimeProperty("birthdate", CrmDateTime.FromUser(DateTime.ParseExact(contact.birthdate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));

                crmService.Update(myDEUpdate);


                //поиск контакта для переназначения ответственного, если таковой меняется
                Owner ownerID = new Owner();
                if (new_config_allid != new Guid("{00000000-0000-0000-0000-000000000000}"))
                {
                    try
                    {
                        string ln = ""; //фамилия
                        BusinessEntityCollection fcontact = searchContact(new_config_allid.ToString());
                        foreach (DynamicEntity cont1 in fcontact.BusinessEntities)
                        {
                            ln = cont1["lastname"].ToString();
                            if (cont1.Properties.Contains("ownerid"))
                                ownerID = (Owner)cont1["ownerid"];
                        }

                        logger.Info($"Нашли контакт {ln}. ownerid={ownerID.Value.ToString()}");

                    }
                    catch (Exception ex)
                    {
                        logger.Error($"Ошибка: {ex.ToString()}");
                    }

                }
                
                return configid.ToString();
            }
            catch (SoapException ex)
            {
                logger.Error($"Ошибка: {ex.Detail.InnerText}");
                return ex.Detail.InnerText;
            }
        }

        public BusinessEntityCollection searchContact(string new_config_allid)
        {

            try
            {
                CrmConnection crmc = new CrmConnection("Crm");
                CrmService crmService = crmc.CreateCrmService();

                QueryExpression qe = new QueryExpression("new_config_all")
                {
                    ColumnSet = new ColumnSet(new String[] {
                    "new_config_allid", "new_name", "new_count", "new_current_amount", "new_period", "new_period"
                        
                    }),
                    Criteria = new FilterExpression()
                    {
                        FilterOperator = LogicalOperator.And,
                        Conditions =
                            {
                            new ConditionExpression("new_config_allid", ConditionOperator.Equal, new_config_allid),
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
            catch (SoapException ex)
            {
                logger.Error($"Не удалось осуществить поиск конфига с id {new_config_allid}. Ошибка: {ex.Message}");

                throw new System.ArgumentException($"Не удалось осуществить поиск конфига с id {new_config_allid}. Ошибка: {ex.Message}", "original");

            }

        }

    }
}