using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PVCodeChallenge.Models;
using System.Threading.Tasks;

namespace PVCodeChallenge.Controllers
{
    public class EventTypeController : Controller
    {
        public ActionResult EventType()
        {
            return View();
        }

        private IList<string> lteventTypes = new List<string>();

        // GET: EventType
        [HttpPost, ActionName("EventType")]
        public ActionResult EventTypePost(string btnEventType)
        {

            string strEventType = "";

            if (btnEventType.ToLower() == "register")
            {
                strEventType = "Register";
                RegisterEvent(strEventType);
            }
            else
            {
                strEventType = "Diagnose";
                DiagnoseEvent(strEventType);
            }

            EventTypeModel model = new EventTypeModel { eventTypes = lteventTypes };

            ViewBag.Events = lteventTypes;
            ViewBag.EventChosen = strEventType;
            ViewBag.TotalEvents = lteventTypes.Count();
            return View(model);
        }

        private void RegisterEvent(string eventType)
        {
            for (int i = 1; i <= 100; i++)
            {
                //if your number is divisible by 5 then display message 
                if (((i % 3) == 0) && ((i % 5) == 0))
                {
                    lteventTypes.Add(eventType + " Patient");

                }
                else if ((i % 3) == 0)
                {
                    lteventTypes.Add(eventType);
                }
                else if ((i % 5) == 0)
                {
                    lteventTypes.Add("Patient");
                }
                else
                {
                    lteventTypes.Add(i.ToString());
                }
            }
        }

        private void DiagnoseEvent(string eventType)
        {
            for (int i = 1; i <= 100; i++)
            {
                //if your number is divisible by 5 then display message 
                if (((i % 2) == 0) && ((i % 7) == 0))
                {
                    lteventTypes.Add(eventType + " Patient");
                }
                else if ((i % 2) == 0)
                {
                    lteventTypes.Add(eventType);
                }
                else if ((i % 7) == 0)
                {
                    lteventTypes.Add("Patient");
                }
                else
                {
                    lteventTypes.Add(i.ToString());
                }
            }
        }

    }
}