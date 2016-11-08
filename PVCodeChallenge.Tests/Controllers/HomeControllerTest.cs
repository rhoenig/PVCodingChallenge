using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PVCodeChallenge;
using PVCodeChallenge.Controllers;
using PVCodeChallenge.Models;

namespace PVCodeChallenge.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IList<string> lteventTypes = new List<string>();

        [TestMethod]
        public void IndexRegisterIsNull()
        {
            // Arrange
            EventTypeController controller = new EventTypeController();

            // Act
            ViewResult result = controller.EventTypePost("register") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexDiagnoseIsNull()
        {
            // Arrange
            EventTypeController controller = new EventTypeController();

            // Act
            ViewResult result = controller.EventTypePost("diagnose") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexRegisterCount()
        {
            // Arrange
            EventTypeController controller = new EventTypeController();

            // Act
            ViewResult result = controller.EventTypePost("register") as ViewResult;
            RegisterEvent("register");

            // Assert
            Assert.AreEqual(((PVCodeChallenge.Models.EventTypeModel)result.Model).eventTypes.Count(), lteventTypes.Count());
        }

        [TestMethod]
        public void IndexDiagnoseCount()
        {
            // Arrange
            EventTypeController controller = new EventTypeController();

            // Act
            ViewResult result = controller.EventTypePost("diagnose") as ViewResult;
            DiagnoseEvent("diagnose");

            // Assert
            Assert.AreEqual(((PVCodeChallenge.Models.EventTypeModel)result.Model).eventTypes.Count(), lteventTypes.Count());
        }

        [TestMethod]
        public void IndexDiagnoseCompare()
        {
            // Arrange
            EventTypeController controller = new EventTypeController();

            // Act
            ViewResult result = controller.EventTypePost("diagnose") as ViewResult;

            string strResult = "";
            string strTstResult = "";

            foreach (string evt in ((PVCodeChallenge.Models.EventTypeModel)result.Model).eventTypes)
            {
                strResult += evt.ToLower();
            }

            DiagnoseEvent("diagnose");

            foreach (string evt in (lteventTypes))
            {
                strTstResult += evt.ToLower();
            }

            // Assert
            Assert.AreEqual(strResult, strTstResult);
        }

        [TestMethod]
        public void IndexRegisterCompare()
        {
            // Arrange
            EventTypeController controller = new EventTypeController();

            // Act
            ViewResult result = controller.EventTypePost("register") as ViewResult;

            string strResult = "";
            string strTstResult = "";

            foreach (string evt in ((PVCodeChallenge.Models.EventTypeModel)result.Model).eventTypes)
            {
                strResult += evt.ToLower();
            }

            RegisterEvent("register");

            foreach (string evt in (lteventTypes))
            {
                strTstResult += evt.ToLower();
            }

            // Assert
            Assert.AreEqual(strResult, strTstResult);
        }

        private void RegisterEvent(string eventType)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
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
