using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarcomSurvey.Models;

namespace MarcomSurvey.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tryFormPost()
        {
            return View();
        }

        public ActionResult postData(string brand, string surveyName)
        {
            var formData = new Dictionary<string, string>();
            
            foreach(string fieldname in Request.Form.Keys)
            {
                formData[fieldname] = Request.Form[fieldname].ToString();
            }
            MarcomSurveyModel eSurvey = new MarcomSurveyModel
            {
                Brand = brand,
                SurveyName = surveyName,
                FormData = formData,
                EmailTo = /*brand + */"donaldloo@amesunited.com",
                EmailFrom = "donaldloo@amesunited.com",
                EmailCc = null
            };

            eSurvey.sendMail();

            switch (brand.ToUpper())
            {
                case "IT":
                    return View((object)eSurvey);
                    
                case "YUNNAM":
                    return Redirect("http://www.yunnamhaircare.com/");

                case "LONDON":
                    return Redirect("http://www.londonweight.com/html/singapore/");
                    
                default:
                    return Content("<h2>Error: " + brand + " is invalid Brand Name!</h2>");
            }
            
        }

    }
}
