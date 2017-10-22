using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using CLientApp.Models;
using Contracts;

namespace CLientApp.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var personListVM = new PersonListViewModel();
            personListVM.People = new List<Contracts.Person>();
            List<Person> peopleList = new List<Person>();
            using (var factory = new ChannelFactory<IPersonService>("clientConf"))
            {
                var personProxy = factory.CreateChannel();
                peopleList = personProxy.GetAll();
                personListVM.People.AddRange(peopleList);
            }            
            
            return View(personListVM);
        }
    }
}