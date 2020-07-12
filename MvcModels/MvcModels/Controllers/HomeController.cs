using MvcModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private Person[] personData =
        {
            new Person {PersonId = 1, FirstName = "Adam", LastName ="Freeman",  Role = Role.Admin},
            new Person {PersonId = 2, FirstName = "Jacqui", LastName ="Griffyth", Role = Role.User},
            new Person {PersonId = 3, FirstName = "John", LastName ="Smith", Role = Role.User},
            new Person {PersonId = 4, FirstName = "Anne", LastName ="Jones", Role = Role.Guest}
        };

        
        public ActionResult Index(int id)
        {
            Person dataItem = personData.Where(p => p.PersonId == id).First();
            return View(dataItem);
            
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return View("Index", model);
        }

        public ActionResult DisplaySummary([Bind(Prefix ="HomeAddress", Exclude ="Country")]AddressSummary summary)
        {
            return View(summary);
        }

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];
            return View(names);
        }


        public ActionResult Address(IList<AddressSummary> addresses)
        {
            addresses = addresses ?? new List<AddressSummary>();
            return View(addresses);
        }

        public ActionResult Address()
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            //采用标准的绑定过程来获取参数
            UpdateModel(addresses);
            //限定从表单数据中获取参数绑定模型
            UpdateModel(addresses, new FormValueProvider(ControllerContext));

            return View(addresses);
        }

        //限定从表单数据中获取参数绑定模型
        public ActionResult Address(FormCollection formData)
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            try
            {
                UpdateModel(addresses, formData);
            }
            catch(InvalidOperationException ex)
            {
                //模型绑定失败会抛出invalidOperationException
                //错误信息放在 ModelState 中
            }
            return View(addresses);
        }
    }
}