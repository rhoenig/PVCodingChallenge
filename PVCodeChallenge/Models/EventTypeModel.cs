using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PVCodeChallenge.Models
{
    public class EventTypeModel
    {
        public string eventType { get; set; }
        public IList<string> eventTypes { get; set; }
        public int totalEvents { get; set; }

    }
}