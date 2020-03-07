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
    public class Contact
    {
        /// <summary>
        /// Приветствие
        /// </summary>
        public String salutation;

        /// <summary>
        /// Фамилия
        /// </summary>
        public String lastname;

        /// <summary>
        /// Имя
        /// </summary>
        public String firstname;

        /// <summary>
        /// Мобильный телефон
        /// </summary>
        public String mobilephone;

        /// <summary>
        /// Электронная почта
        /// </summary>
        public String emailaddress1;

        /// <summary>
        /// Отчество
        /// </summary>
        public String middlename;        

        /// <summary>
        /// Название
        /// </summary>
        public String address1_name;

        /// <summary>
        /// Улица, дом
        /// </summary>
        public String address1_line1;

        /// <summary>
        /// Город
        /// </summary>
        public String address1_city;

        /// <summary>
        /// Область, край, республика
        /// </summary>
        public String address1_stateorprovince;

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public String address1_postalcode;

        /// <summary>
        /// Страна
        /// </summary>
        public String address1_country;

        /// <summary>
        /// Серия
        /// </summary>
        public String new_seria;

        /// <summary>
        /// Номер
        /// </summary>
        public String new_nomer;

        /// <summary>
        /// Кем выдан
        /// </summary>
        public String new_giveoutby;

        /// <summary>
        /// Пол
        /// </summary>
        public int gendercode;

        /// <summary>
        /// Гражданство
        /// </summary>
        public int new_nationality;

        /// <summary>
        /// Тип ФЛ
        /// </summary>
        public int new_type;

        /// <summary>
        /// Семейное положение
        /// </summary>
        public int familystatuscode;

        /// <summary>
        /// День рождения
        /// </summary>
        public String birthdate;

        /// <summary>
        /// Посетил открытый урок
        /// </summary>
        public String new_openles;

        /// <summary>
        /// Дата выдачи
        /// </summary>
        public String new_dategiveout;

        /// <summary>
        /// Ответственный
        /// </summary>
        public Guid ownerid;




        Logger logger = LogManager.GetCurrentClassLogger();


        public String CreateContact(Guid contact_ID, Contact contact)
        {
            Guid contactid = contact_ID;

            try
            {
                contact cont = new contact();


                CrmConnection crmc = new CrmConnection("Crm");
                CrmService crmService = crmc.CreateCrmService();

                if (contact_ID == new Guid("{00000000-0000-0000-0000-000000000000}"))
                contactid = crmService.Create(cont);

                // Создаем экземпляр динамческого объекта и указываем его имя
                DynamicEntity myDEUpdate = new DynamicEntity();
                myDEUpdate.Name = "contact";

                
                    // Создаем KeyProperty для хранения GUID’а обновляемой записи
                    KeyProperty myContactGuid = new KeyProperty();
                    myContactGuid.Name = "contactid";

                    // Указываем GUID обновляемой записи
                    Key myContactKey = new Key();
                    myContactKey.Value = contactid;
                    myContactGuid.Value = myContactKey;
                    myDEUpdate.Properties.Add(myContactGuid);
                


                if (contact.address1_city != null)
                    myDEUpdate.Properties.Add(new StringProperty("address1_city", contact.address1_city)); 

                if (contact.address1_country != null)
                    myDEUpdate.Properties.Add(new StringProperty("address1_country", contact.address1_country)); 

                if (contact.address1_line1 != null)
                    myDEUpdate.Properties.Add(new StringProperty("address1_line1", contact.address1_line1)); 

                if (contact.address1_name != null)
                    myDEUpdate.Properties.Add(new StringProperty("address1_name", contact.address1_name)); 

                if (contact.address1_postalcode != null)
                    myDEUpdate.Properties.Add(new StringProperty("address1_postalcode", contact.address1_postalcode)); 

                if (contact.emailaddress1 != null)
                    myDEUpdate.Properties.Add(new StringProperty("emailaddress1", contact.emailaddress1)); 

                if (contact.firstname != null)
                    myDEUpdate.Properties.Add(new StringProperty("firstname", contact.firstname)); 

                if (contact.lastname != null)
                    myDEUpdate.Properties.Add(new StringProperty("lastname", contact.lastname)); 

                if (contact.middlename != null)
                    myDEUpdate.Properties.Add(new StringProperty("middlename", contact.middlename)); 
                
                if (contact.mobilephone != null)
                    myDEUpdate.Properties.Add(new StringProperty("mobilephone", contact.mobilephone)); 

                if (contact.salutation != null)
                    myDEUpdate.Properties.Add(new StringProperty("salutation", contact.salutation)); 

                //Кем выдан
                if (contact.new_giveoutby != null)
                    myDEUpdate.Properties.Add(new StringProperty("new_giveoutby", contact.new_giveoutby));

                //Номер
                if (contact.new_nomer != null)
                    myDEUpdate.Properties.Add(new StringProperty("new_nomer", contact.new_nomer));

                //Серия
                if (contact.new_seria != null)
                    myDEUpdate.Properties.Add(new StringProperty("new_seria", contact.new_seria));




                //Пол
                if (contact.gendercode != 0)
                    myDEUpdate.Properties.Add(new PicklistProperty("gendercode", new Picklist(contact.gendercode)));

                //Гражданство
                if (contact.new_nationality != 0)
                    myDEUpdate.Properties.Add(new PicklistProperty("new_nationality", new Picklist(contact.new_nationality)));

                //Тип ФЛ
                if (contact.new_type != 0)
                    myDEUpdate.Properties.Add(new PicklistProperty("new_type", new Picklist(contact.new_type)));

                //Семейное положение
                if (contact.familystatuscode != 0)
                    myDEUpdate.Properties.Add(new PicklistProperty("familystatuscode", new Picklist(contact.familystatuscode)));

                
                //День рождения
                if (contact.birthdate != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("birthdate", CrmDateTime.FromUser(DateTime.ParseExact(contact.birthdate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));

                //Посетил открытый урок
                if (contact.new_openles != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_openles", CrmDateTime.FromUser(DateTime.ParseExact(contact.new_openles, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));

                //Дата выдачи
                if (contact.new_dategiveout != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dategiveout", CrmDateTime.FromUser(DateTime.ParseExact(contact.new_dategiveout, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));

                
                    crmService.Update(myDEUpdate);


                //поиск контакта для переназначения ответственного, если таковой меняется
                Owner ownerID = new Owner();
                if (contact_ID != new Guid("{00000000-0000-0000-0000-000000000000}"))
                {   
                    try
                    {
                        string ln = ""; //фамилия
                        BusinessEntityCollection fcontact = searchContact(contact_ID.ToString());
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

                if (contact.ownerid != new Guid("{00000000-0000-0000-0000-000000000000}"))
                {
                    if (ownerID.Value != contact.ownerid)
                    {
                        TargetOwnedContact target = new TargetOwnedContact();
                        SecurityPrincipal assignee = new SecurityPrincipal();
                        assignee.Type = SecurityPrincipalType.User;
                        assignee.PrincipalId = contact.ownerid; 
                        target.EntityId = contactid;

                        AssignRequest assign = new AssignRequest();
                        assign.Assignee = assignee;
                        assign.Target = target;
                        AssignResponse res = (AssignResponse)crmService.Execute(assign);
                    }
                }
                return contactid.ToString();
            }
            catch (SoapException ex)
            {
                logger.Error($"Ошибка: {ex.Detail.InnerText}");
                return ex.Detail.InnerText;
            }
        }

        public BusinessEntityCollection searchContact(string contactid)
        {

            try
            {
                CrmConnection crmc = new CrmConnection("Crm");
                CrmService crmService = crmc.CreateCrmService();

                QueryExpression qe = new QueryExpression("contact")
                {
                    ColumnSet = new ColumnSet(new String[] {
                    "contactid", "salutation", "lastname", "firstname", "middlename", "mobilephone", "emailaddress1", "address1_name", "address1_line1", "address1_city", "address1_stateorprovince", "address1_country", "new_seria", "new_nomer", "new_giveoutby", "gendercode", "new_nationality", "new_type", "familystatuscode", "birthdate", "new_openles", "new_dategiveout", "ownerid" //" address1_postalcode" //
                        
                    }),
                    Criteria = new FilterExpression()
                    {
                        FilterOperator = LogicalOperator.And,
                        Conditions =
                            {
                            new ConditionExpression("contactid", ConditionOperator.Equal, contactid),
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
                logger.Error($"Не удалось осуществить поиск контакта с id {contactid}. Ошибка: {ex.Message}");

                throw new System.ArgumentException($"Не удалось осуществить поиск контакта с id {contactid}. Ошибка: {ex.Message}", "original");

            }

        }


    }
}