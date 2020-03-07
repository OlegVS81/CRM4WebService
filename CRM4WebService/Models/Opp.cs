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
    public partial class Opp
    {

        /// <summary>
        /// Номер договора на обучение
        /// </summary>
        public String name;

        ///// <summary>
        ///// GUID Договора на обучение
        ///// </summary>
        //public Guid opportunityID;
        /// <summary>
        /// Исходная кампания
        /// </summary>
        public Guid campaignid;
        /// <summary>
        /// Подписант от Школы
        /// </summary>
        public Guid new_signatoryid;
        /// <summary>
        /// Место обучения
        /// </summary>
        public Guid new_studyplaceid;
        /// <summary>
        /// Место заключения договора
        /// </summary>
        public Guid new_placeofwriteid;
        /// <summary>
        /// Скидка по времени обучения
        /// </summary>
        public Guid new_discount1id;
        /// <summary>
        /// Скидка Кредит/рассрочка
        /// </summary>
        public Guid new_discount4id;
        /// <summary>
        /// Юридическое лицо организации
        /// </summary>
        public Guid new_regionid;
        /// <summary>
        /// Клиент
        /// </summary>
        public Guid customerid;
        /// <summary>
        /// Ответственный
        /// </summary>
        public Guid ownerid;
        /// <summary>
        /// Программа обучения
        /// </summary>
        public Guid new_programsidcost;
        /// <summary>
        /// Контактное лицо по договору
        /// </summary>
        public Guid new_contactid;
        /// <summary>
        /// Законный представитель ФЛ
        /// </summary>
        public Guid new_contact2id;


        /// <summary>
        /// Предполагаемый доход
        /// </summary>
        public String estimatedvalue;
        /// <summary>
        /// Курс обмена
        /// </summary>
        public String exchangerate;

        /// <summary>
        /// Сумма плановая1
        /// </summary>
        public String new_costplan1;
        /// <summary>
        /// Сумма плановая2
        /// </summary>
        public String new_costplan2;
        /// <summary>
        /// Сумма плановая3
        /// </summary>
        public String new_costplan3;
        /// <summary>
        /// Сумма плановая4
        /// </summary>
        public String new_costplan4;
        /// <summary>
        /// Сумма плановая5
        /// </summary>
        public String new_costplan5;
        /// <summary>
        /// Сумма плановая6
        /// </summary>
        public String new_costplan6;
        /// <summary>
        /// Сумма плановая7
        /// </summary>
        public String new_costplan7;
        /// <summary>
        /// Сумма плановая8
        /// </summary>
        public String new_costplan8;
        /// <summary>
        /// Сумма плановая9
        /// </summary>
        public String new_costplan9;
        /// <summary>
        /// Сумма плановая10
        /// </summary>
        public String new_costplan10;
        /// <summary>
        /// Сумма плановая11
        /// </summary>
        public String new_costplan11;
        /// <summary>
        /// Сумма плановая12
        /// </summary>
        public String new_costplan12;
        
        /// <summary>
        /// Сумма фактическая1
        /// </summary>
        public String new_costfact1;
        /// <summary>
        /// Сумма фактическая2
        /// </summary>
        public String new_costfact2;
        /// <summary>
        /// Сумма фактическая3
        /// </summary>
        public String new_costfact3;
        /// <summary>
        /// Сумма фактическая4
        /// </summary>
        public String new_costfact4;
        /// <summary>
        /// Сумма фактическая5
        /// </summary>
        public String new_costfact5;
        /// <summary>
        /// Сумма фактическая6
        /// </summary>
        public String new_costfact6;
        /// <summary>
        /// Сумма фактическая7
        /// </summary>
        public String new_costfact7;
        /// <summary>
        /// Сумма фактическая8
        /// </summary>
        public String new_costfact8;
        /// <summary>
        /// Сумма фактическая9
        /// </summary>
        public String new_costfact9;
        /// <summary>
        /// Сумма фактическая10
        /// </summary>
        public String new_costfact10;
        /// <summary>
        /// Сумма фактическая11
        /// </summary>
        public String new_costfact11;
        /// <summary>
        /// Сумма фактическая12
        /// </summary>
        public String new_costfact12;


        /// <summary>
        /// Количество академических часов в занятии
        /// </summary>
        public String new_lesduration;
        /// <summary>
        /// Стоимость программы
        /// </summary>
        public String new_summarycost;
        /// <summary>
        /// Общая стоимость обучения с учётом пособий
        /// </summary>
        public String new_totalsumcost;
        /// <summary>
        /// Стоимость одного академического часа
        /// </summary>
        public String new_hourcost;

        /// <summary>
        /// Доход
        /// </summary>
        public String isrevenuesystemcalculated;
        /// <summary>
        /// Применять скидку
        /// </summary>
        public String new_applydiscount;
        /// <summary>
        /// Пособие нужно
        /// </summary>
        public String new_bookisneeded;


        /// <summary>
        /// Возраст клиента
        /// </summary>
        public String new_age;
        /// <summary>
        /// Юридическое лицо
        /// </summary>
        public String new_legalentity;
        /// <summary>
        /// Вид договора
        /// </summary>
        public String new_sort;
        /// <summary>
        /// Слушатель приступает к обучению с занятия
        /// </summary>
        public String new_numfirstles;
        /// <summary>
        /// Статус договора на обучение
        /// </summary>
        public String new_status;
        /// <summary>
        /// Длительность одного занятия в минутах
        /// </summary>
        public String new_hourquantity;
        /// <summary>
        /// Допустимое количество приостановок
        /// </summary>
        public String new_stopquantity;
        /// <summary>
        /// Допустимое кол-во дней приостановок
        /// </summary>
        public String new_stopdayquantity;
        /// <summary>
        /// Выполненное кол-во дней приостановок
        /// </summary>
        public String new_stopdayquantityfact;
        /// <summary>
        /// Выполнено приостановок
        /// </summary>
        public String new_stopquantityfact;

        /// <summary>
        /// Дата плановая1
        /// </summary>
        public String new_dateplan1;
        /// <summary>
        /// Дата плановая2
        /// </summary>
        public String new_dateplan2;
        /// <summary>
        /// Дата плановая3
        /// </summary>
        public String new_dateplan3;
        /// <summary>
        /// Дата плановая4
        /// </summary>
        public String new_dateplan4;
        /// <summary>
        /// Дата плановая5
        /// </summary>
        public String new_dateplan5;
        /// <summary>
        /// Дата плановая6
        /// </summary>
        public String new_dateplan6;
        /// <summary>
        /// Дата плановая7
        /// </summary>
        public String new_dateplan7;
        /// <summary>
        /// Дата плановая8
        /// </summary>
        public String new_dateplan8;
        /// <summary>
        /// Дата плановая9
        /// </summary>
        public String new_dateplan9;
        /// <summary>
        /// Дата плановая10
        /// </summary>
        public String new_dateplan10;
        /// <summary>
        /// Дата плановая11
        /// </summary>
        public String new_dateplan11;
        /// <summary>
        /// Дата плановая12
        /// </summary>
        public String new_dateplan12;

        /// <summary>
        /// Дата фактическая1
        /// </summary>
        public String new_datefact1;
        /// <summary>
        /// Дата фактическая2
        /// </summary>
        public String new_datefact2;
        /// <summary>
        /// Дата фактическая3
        /// </summary>
        public String new_datefact3;
        /// <summary>
        /// Дата фактическая4
        /// </summary>
        public String new_datefact4;
        /// <summary>
        /// Дата фактическая5
        /// </summary>
        public String new_datefact5;
        /// <summary>
        /// Дата фактическая6
        /// </summary>
        public String new_datefact6;
        /// <summary>
        /// Дата фактическая7
        /// </summary>
        public String new_datefact7;
        /// <summary>
        /// Дата фактическая8
        /// </summary>
        public String new_datefact8;
        /// <summary>
        /// Дата фактическая9
        /// </summary>
        public String new_datefact9;
        /// <summary>
        /// Дата фактическая10
        /// </summary>
        public String new_datefact10;
        /// <summary>
        /// Дата фактическая11
        /// </summary>
        public String new_datefact11;
        /// <summary>
        /// Дата фактическая12
        /// </summary>
        public String new_datefact12;


        /// <summary>
        /// Дата и время подписания договора
        /// </summary>
        public String new_signdate;




    }

    /// <summary>
    /// Договор CRM
    /// </summary>
    public partial class Opp
    {
        Logger logger = LogManager.GetCurrentClassLogger();


        public String CreateOpp(Guid opportunity_ID, Opp opp)
        {
            Guid opportunityid = opportunity_ID;// opp.opportunityID;

            try
            {
                opportunity opport = new opportunity();
                if (opp.name != null)
                    opport.name = opp.name;
                Customer customer = new Customer("contact", opp.customerid);
                opport.customerid = customer;// new Key(new Guid("{3D176494-D498-E911-8934-005056BAC107}"));
                CrmConnection crmc = new CrmConnection("Crm");
                CrmService crmService = crmc.CreateCrmService();

                if (opportunity_ID == new Guid("{00000000-0000-0000-0000-000000000000}"))//opp.opportunityID == new Guid("{00000000-0000-0000-0000-000000000000}"))
                    opportunityid = crmService.Create(opport);

                // Создаем экземпляр динамческого объекта и указываем его имя
                DynamicEntity myDEUpdate = new DynamicEntity();
                myDEUpdate.Name = "opportunity";
                // Создаем KeyProperty для хранения GUID’а обновляемой записи
                KeyProperty myOpportunityGuid = new KeyProperty();
                myOpportunityGuid.Name = "opportunityid";
        
                // Указываем GUID обновляемой записи
                Key myOpportunityKey = new Key();
                myOpportunityKey.Value = opportunityid;// opportunityid;//myOpportunityKey.Value = new Guid("{C02C3DBE-0FEA-E911-AAF3-005056BAC107}");                
                myOpportunityGuid.Value = myOpportunityKey;
                myDEUpdate.Properties.Add(myOpportunityGuid);


                //Имя
                if (opp.name != null)
                    myDEUpdate.Properties.Add(new StringProperty("name", opp.name));

                //Клиент
                //if (opp.customerid != new Guid("{00000000-0000-0000-0000-000000000000}"))
                //    myDEUpdate.Properties.Add(new LookupProperty("customerid", new Lookup("contact", opp.customerid)));

                //Исходная кампания
                if (opp.campaignid != new Guid("{00000000-0000-0000-0000-000000000000}"))
                    myDEUpdate.Properties.Add(new LookupProperty("campaignid", new Lookup("campaign", opp.campaignid)));

                //Подписант от Школы
                if (opp.new_signatoryid != new Guid("{00000000-0000-0000-0000-000000000000}"))
                    myDEUpdate.Properties.Add(new LookupProperty("new_signatoryid", new Lookup("systemuser", opp.new_signatoryid)));

                //Место обучения
                if (opp.new_studyplaceid != new Guid("{00000000-0000-0000-0000-000000000000}"))
                    myDEUpdate.Properties.Add(new LookupProperty("new_studyplaceid", new Lookup("new_department", opp.new_studyplaceid)));

                //Место заключения договора
                if (opp.new_placeofwriteid != new Guid("{00000000-0000-0000-0000-000000000000}"))
                    myDEUpdate.Properties.Add(new LookupProperty("new_placeofwriteid", new Lookup("new_department", opp.new_placeofwriteid)));

                //Скидка по времени обучения
                if (opp.new_discount1id != new Guid("{00000000-0000-0000-0000-000000000000}"))
                    myDEUpdate.Properties.Add(new LookupProperty("new_discount1id", new Lookup("new_discount", opp.new_discount1id)));

                //Скидка Кредит/рассрочка
                if (opp.new_discount4id != new Guid("{00000000-0000-0000-0000-000000000000}"))
                    myDEUpdate.Properties.Add(new LookupProperty("new_discount4id", new Lookup("new_discount", opp.new_discount4id)));

                //Юридическое лицо организации
                if (opp.new_regionid != new Guid("{00000000-0000-0000-0000-000000000000}"))
                    myDEUpdate.Properties.Add(new LookupProperty("new_regionid", new Lookup("new_region", opp.new_regionid)));

                //Программа обучения
                if (opp.new_programsidcost != new Guid("{00000000-0000-0000-0000-000000000000}"))
                    myDEUpdate.Properties.Add(new LookupProperty("new_programsidcost", new Lookup("new_programs", opp.new_programsidcost)));

                //Контактное лицо по договору
                if (opp.new_contactid != new Guid("{00000000-0000-0000-0000-000000000000}"))
                    myDEUpdate.Properties.Add(new LookupProperty("new_contactid", new Lookup("contact", opp.new_contactid)));

                //Законный представитель ФЛ
                if (opp.new_contact2id != new Guid("{00000000-0000-0000-0000-000000000000}"))
                    myDEUpdate.Properties.Add(new LookupProperty("new_contact2id", new Lookup("contact", opp.new_contact2id)));




                //Предполагаемый доход
                if (opp.estimatedvalue != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("estimatedvalue", new CrmMoney(Convert.ToDecimal(opp.estimatedvalue.Replace(".", ",")))));

                //Курс обмена
                if (opp.exchangerate != null)
                    myDEUpdate.Properties.Add(new CrmDecimalProperty("exchangerate", new CrmDecimal(Convert.ToDecimal(opp.exchangerate.Replace(".", ",")))));//new CrmDecimal(decimal.Parse(opp.exchangerate))));

                //Сумма плановая1
                if (opp.new_costplan1 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan1", new CrmMoney(Convert.ToDecimal(opp.new_costplan1.Replace(".",",")))));
                //Сумма плановая2
                if (opp.new_costplan2 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan2", new CrmMoney(Convert.ToDecimal(opp.new_costplan2.Replace(".", ",")))));
                //Сумма плановая3
                if (opp.new_costplan3 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan3", new CrmMoney(Convert.ToDecimal(opp.new_costplan3.Replace(".", ",")))));
                //Сумма плановая4
                if (opp.new_costplan4 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan4", new CrmMoney(Convert.ToDecimal(opp.new_costplan4.Replace(".", ",")))));
                //Сумма плановая5
                if (opp.new_costplan5 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan5", new CrmMoney(Convert.ToDecimal(opp.new_costplan5.Replace(".", ",")))));
                //Сумма плановая6
                if (opp.new_costplan6 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan6", new CrmMoney(Convert.ToDecimal(opp.new_costplan6.Replace(".", ",")))));
                //Сумма плановая7
                if (opp.new_costplan7 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan7", new CrmMoney(Convert.ToDecimal(opp.new_costplan7.Replace(".", ",")))));
                //Сумма плановая8
                if (opp.new_costplan8 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan8", new CrmMoney(Convert.ToDecimal(opp.new_costplan8.Replace(".", ",")))));
                //Сумма плановая9
                if (opp.new_costplan9 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan9", new CrmMoney(Convert.ToDecimal(opp.new_costplan9.Replace(".", ",")))));
                //Сумма плановая10
                if (opp.new_costplan10 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan10", new CrmMoney(Convert.ToDecimal(opp.new_costplan10.Replace(".", ",")))));
                //Сумма плановая11
                if (opp.new_costplan11 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan11", new CrmMoney(Convert.ToDecimal(opp.new_costplan1.Replace(".", ",")))));
                //Сумма плановая12
                if (opp.new_costplan12 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costplan12", new CrmMoney(Convert.ToDecimal(opp.new_costplan12.Replace(".", ",")))));

                //Сумма фактическая1
                if (opp.new_costfact1 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact1", new CrmMoney(Convert.ToDecimal(opp.new_costfact1.Replace(".", ",")))));
                //Сумма фактическая2
                if (opp.new_costfact2 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact2", new CrmMoney(Convert.ToDecimal(opp.new_costfact2.Replace(".", ",")))));
                //Сумма фактическая3
                if (opp.new_costfact3 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact3", new CrmMoney(Convert.ToDecimal(opp.new_costfact3.Replace(".", ",")))));
                //Сумма фактическая4
                if (opp.new_costfact4 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact4", new CrmMoney(Convert.ToDecimal(opp.new_costfact4.Replace(".", ",")))));
                //Сумма фактическая5
                if (opp.new_costfact5 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact5", new CrmMoney(Convert.ToDecimal(opp.new_costfact5.Replace(".", ",")))));
                //Сумма фактическая6
                if (opp.new_costfact6 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact6", new CrmMoney(Convert.ToDecimal(opp.new_costfact6.Replace(".", ",")))));
                //Сумма фактическая7
                if (opp.new_costfact7 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact7", new CrmMoney(Convert.ToDecimal(opp.new_costfact7.Replace(".", ",")))));
                //Сумма фактическая8
                if (opp.new_costfact8 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact8", new CrmMoney(Convert.ToDecimal(opp.new_costfact8.Replace(".", ",")))));
                //Сумма фактическая9
                if (opp.new_costfact9 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact9", new CrmMoney(Convert.ToDecimal(opp.new_costfact9.Replace(".", ",")))));
                //Сумма фактическая10
                if (opp.new_costfact10 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact10", new CrmMoney(Convert.ToDecimal(opp.new_costfact10.Replace(".", ",")))));
                //Сумма фактическая11
                if (opp.new_costfact11 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact11", new CrmMoney(Convert.ToDecimal(opp.new_costfact11.Replace(".", ",")))));
                //Сумма фактическая12
                if (opp.new_costfact12 != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_costfact12", new CrmMoney(Convert.ToDecimal(opp.new_costfact12.Replace(".", ",")))));

                //Количество академических часов в занятии
                if (opp.new_lesduration != null)
                    myDEUpdate.Properties.Add(new CrmFloatProperty("new_lesduration", new CrmFloat(Convert.ToDouble(opp.new_lesduration.Replace(".", ",")))));

                //Стоимость программы
                if (opp.new_summarycost != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_summarycost", new CrmMoney(Convert.ToDecimal(opp.new_summarycost.Replace(".", ",")))));

                //Общая стоимость обучения с учётом пособий
                if (opp.new_totalsumcost != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_totalsumcost", new CrmMoney(Convert.ToDecimal(opp.new_totalsumcost.Replace(".", ",")))));

                //Стоимость одного академического часа
                if (opp.new_hourcost != null)
                    myDEUpdate.Properties.Add(new CrmMoneyProperty("new_hourcost", new CrmMoney(Convert.ToDecimal(opp.new_hourcost.Replace(".", ",")))));



                //Доход
                if (opp.isrevenuesystemcalculated != null)
                    myDEUpdate.Properties.Add(new CrmBooleanProperty("isrevenuesystemcalculated", new CrmBoolean(Convert.ToBoolean(opp.isrevenuesystemcalculated))));

                //Применять скидку
                if (opp.new_applydiscount != null)
                    myDEUpdate.Properties.Add(new CrmBooleanProperty("new_applydiscount", new CrmBoolean(Convert.ToBoolean(opp.new_applydiscount))));

                //Пособие нужно
                if (opp.new_bookisneeded != null)
                    myDEUpdate.Properties.Add(new CrmBooleanProperty("new_bookisneeded", new CrmBoolean(Convert.ToBoolean(opp.new_bookisneeded))));





                //Возраст клиента
                if (opp.new_age != null)
                    myDEUpdate.Properties.Add(new CrmNumberProperty("new_age", new CrmNumber(Convert.ToInt32(opp.new_age))));

                //Юридическое лицо
                if (opp.new_legalentity != null)
                    myDEUpdate.Properties.Add(new PicklistProperty("new_legalentity", new Picklist(Convert.ToInt32(opp.new_legalentity))));

                //Вид договора
                if (opp.new_sort != null)
                    myDEUpdate.Properties.Add(new PicklistProperty("new_sort", new Picklist(Convert.ToInt32(opp.new_sort))));

                //Статус договора
                if (opp.new_status != null)
                    myDEUpdate.Properties.Add(new PicklistProperty("new_status", new Picklist(2)));//2

                //Слушатель приступает к обучению с занятия
                if (opp.new_numfirstles != null)
                    myDEUpdate.Properties.Add(new CrmNumberProperty("new_numfirstles", new CrmNumber(Convert.ToInt32(opp.new_numfirstles))));

                //Длительность одного занятия в минутах
                if (opp.new_hourquantity != null)
                    myDEUpdate.Properties.Add(new CrmNumberProperty("new_hourquantity", new CrmNumber(Convert.ToInt32(opp.new_hourquantity))));

                //Допустимое количество приостановок
                if (opp.new_stopquantity != null)
                    myDEUpdate.Properties.Add(new CrmNumberProperty("new_stopquantity", new CrmNumber(Convert.ToInt32(opp.new_stopquantity))));

                //Допустимое кол-во дней приостановок
                if (opp.new_stopdayquantity != null)
                    myDEUpdate.Properties.Add(new CrmNumberProperty("new_stopdayquantity", new CrmNumber(Convert.ToInt32(opp.new_stopdayquantity))));

                //Выполненное кол-во дней приостановок
                if (opp.new_stopdayquantityfact != null)
                    myDEUpdate.Properties.Add(new CrmNumberProperty("new_stopdayquantityfact", new CrmNumber(Convert.ToInt32(opp.new_stopdayquantityfact))));

                //Выполнено приостановок
                if (opp.new_stopquantityfact != null)
                    myDEUpdate.Properties.Add(new CrmNumberProperty("new_stopquantityfact", new CrmNumber(Convert.ToInt32(opp.new_stopquantityfact))));



                //Дата плановая1
                if (opp.new_dateplan1 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan1", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan1, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая2
                if (opp.new_dateplan2 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan2", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan2, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая3
                if (opp.new_dateplan3 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan3", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan3, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая4
                if (opp.new_dateplan4 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan4", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan4, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая5
                if (opp.new_dateplan5 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan5", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan5, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая6
                if (opp.new_dateplan6 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan6", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan6, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая7
                if (opp.new_dateplan7 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan7", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan7, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая8
                if (opp.new_dateplan8 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan8", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan8, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая9
                if (opp.new_dateplan9 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan9", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan9, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая10
                if (opp.new_dateplan10 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan10", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan10, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая11
                if (opp.new_dateplan11 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan11", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan11, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата плановая12
                if (opp.new_dateplan12 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_dateplan12", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_dateplan12, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));

                //Дата фактическая1
                if (opp.new_datefact1 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact1", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact1, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая2
                if (opp.new_datefact2 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact2", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact2, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая3
                if (opp.new_datefact3 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact3", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact3, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая4
                if (opp.new_datefact4 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact4", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact4, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая5
                if (opp.new_datefact5 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact5", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact5, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая6
                if (opp.new_datefact6 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact6", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact6, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая7
                if (opp.new_datefact7 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact7", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact7, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая8
                if (opp.new_datefact8 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact8", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact8, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая9
                if (opp.new_datefact9 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact9", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact9, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая10
                if (opp.new_datefact10 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact10", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact10, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая11
                if (opp.new_datefact11 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact11", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact11, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));
                //Дата фактическая12
                if (opp.new_datefact12 != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_datefact12", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_datefact12, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));

                //Дата и время подписания договора
                if (opp.new_signdate != null)
                    myDEUpdate.Properties.Add(new CrmDateTimeProperty("new_signdate", CrmDateTime.FromUser(DateTime.ParseExact(opp.new_signdate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture))));

                
                crmService.Update(myDEUpdate);


                //поиск договора для переназначения ответственного, если таковой меняется
                Owner ownerID = new Owner();
                if (opportunity_ID != new Guid("{00000000-0000-0000-0000-000000000000}"))
                {
                    BusinessEntityCollection opportunity;
                    //Opp o = new Opp();
                    
                    string nameopp = ""; //номер договора
                    try
                    {
                        opportunity = searchOpportunity(opportunity_ID.ToString());
                        foreach (DynamicEntity oppM in opportunity.BusinessEntities)
                        {
                            nameopp = oppM["name"].ToString();
                            if (oppM.Properties.Contains("ownerid"))
                                ownerID = (Owner)oppM["ownerid"];
                        }

                        logger.Info($"Нашли договор {nameopp}. ownerid={ownerID.Value.ToString()}");

                    }
                    catch (Exception ex)
                    {
                        logger.Error($"Ошибка: {ex.ToString()}");
                    }

                }

                if (opp.ownerid != new Guid("{00000000-0000-0000-0000-000000000000}"))
                {
                    if (ownerID.Value != opp.ownerid)
                    {
                        TargetOwnedOpportunity target = new TargetOwnedOpportunity();
                        SecurityPrincipal assignee = new SecurityPrincipal();
                        assignee.Type = SecurityPrincipalType.User;
                        assignee.PrincipalId = opp.ownerid; //this is the GUID I am retrieving from the other lookup field
                        target.EntityId = opportunityid;// new Guid("{C02C3DBE-0FEA-E911-AAF3-005056BAC107}");

                        AssignRequest assign = new AssignRequest();
                        assign.Assignee = assignee;
                        assign.Target = target;
                        AssignResponse res = (AssignResponse)crmService.Execute(assign);
                    }
                }
                return opportunityid.ToString();
            }
            catch (SoapException ex)
            {
                logger.Error($"Ошибка: {ex.Detail.InnerText}");
                return ex.Detail.InnerText;
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