using CRM4WebService.Models;
using Microsoft.Crm.Sdk;
using Microsoft.Crm.SdkTypeProxy;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRM4WebService.Controllers
{

    public class MyModel
    {
        public string Key { get; set; }
    }
    public class OnlineController : ApiController
    {
        Logger Online_log = LogManager.GetCurrentClassLogger();
        // GET: api/Online
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Online/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Online
        public void Post([FromBody] MyModel value)
        {

            opportunity opport = new opportunity();
            opport.name = "qwe";
            Customer customer = new Customer("contact", new Guid("{3D176494-D498-E911-8934-005056BAC107}"));
            opport.customerid = customer;// new Key(new Guid("{3D176494-D498-E911-8934-005056BAC107}"));
            //opport.customerid

            Owner own = new Owner("systemuser", new Guid("{0E850BC1-AC63-E611-B994-0026181D291A}"));
            opport.ownerid = own;
            



            DynamicEntity myDEUpdate = new DynamicEntity();
            myDEUpdate.Name = "opportunity";

            myDEUpdate.Properties.Add(new StringProperty("name", "qwe2"));
            myDEUpdate.Properties.Add(new LookupProperty("customerid", new Lookup("contact", new Guid("{3D176494-D498-E911-8934-005056BAC107}"))));
            myDEUpdate.Properties.Add(new LookupProperty("ownerid", new Lookup("systemuser", new Guid("{FADE863C-25DE-E911-80D0-005056BAC107}"))));

            Opp o = new Opp();
            o.CreateOpp(opport);


            //opport.createdby = new Lookup("systemuser", new Guid("{A2111C5B-E35C-E711-A7FD-0026181D291A}"));
            //new Key(new Guid("{FADE863C-25DE-E911-80D0-005056BAC107}"));

            //DynamicEntity opp = new DynamicEntity("opportunity");
            //opp.Name = "opportunity";
            //opp.Properties.Add(new StringProperty("name", "123"));
            //opp.Properties.Add(new StringProperty("customerid", "3efcff"));

            //Lookup ll = new Lookup();
            //ll.name = "contactid";
            //ll.type = "contact";
            //ll.Value = new Guid("{3D176494-D498-E911-8934-005056BAC107}");


            //Customer customer = (Customer)oo["customerid"];
            //opp.Properties.Add(new LookupProperty("customerid", new Lookup(customer.type, customer.Value)));

            //opp.Properties.Add(new LookupProperty("customerid", ll));

            //opp.Properties.Add(new LookupProperty("ownerid", new Lookup("systemuser", new Guid("{FADE863C-25DE-E911-80D0-005056BAC107}"))));

            //opp.Properties.Add(new CrmEntityReference("customer", customer.Value));

            //Online_log.Info(value.Key.ToString());



        }

        // PUT: api/Online/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Online/5
        public void Delete(int id)
        {
        }
    }
}
