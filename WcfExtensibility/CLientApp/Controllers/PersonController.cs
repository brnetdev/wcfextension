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
            var addButtonText = Resources.Index.AddPersonLabel;
            ViewBag.AddButtonText = addButtonText;

            var personListVM = new PersonListViewModel();
            personListVM.People = new List<Contracts.Person>();
            List<Person> peopleList;
            using (var factory = new ChannelFactory<IPersonService>("clientConf"))
            {
                var personProxy = factory.CreateChannel();
                peopleList = personProxy.GetAll();
                personListVM.People.AddRange(peopleList);
            }

            return View(personListVM);
        }
                
        public ActionResult Add()
        {

            var person = new PersonAddViewModel();
            return View(person);
        }

        [HttpPost]
        public ActionResult Add(PersonAddViewModel vm)
        {
            if (!this.ModelState.IsValid)
            {
                return View(vm);
            }
            using (var factory = new ChannelFactory<IPersonService>("clientConf"))
            {
                var proxy = factory.CreateChannel();
                proxy.Add(new Person
                {
                    Age = vm.Age,
                    LastName = vm.LastName,
                    Name = vm.Name
                });
            }
            return RedirectToAction(nameof(PersonController.Index));
        }
    }
}