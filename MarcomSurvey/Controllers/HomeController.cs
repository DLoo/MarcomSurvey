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
                EmailTo = brand + "_" + "Survey@eurogrp.com", /*brand +"vhwong@eurogrp.com,cmchong@eurogrp.com", */ 
                EmailFrom = "Survey@eurogrp.com",
                EmailCc = null
            };

            eSurvey.sendMail();

            switch (brand.ToUpper())
            {
                case "IT":
                   // return View((object)eSurvey);

                case "YN":
                    return Content("<h2>Success: " + brand + " Survey is Successful!</h2>");
                    //return View((object)eSurvey);

                case "LWM":
                    return Content("<h2>Success: " + brand + " Survey is Successful!</h2>");
                  //  return View((object)eSurvey);

                case "NYSS":
                    return Content("<h2>Success: " + brand + " Survey is Successful!</h2>");
                //  return View((object)eSurvey);

                case "JS":
                    return Content("<h2>Success: " + brand + " Survey is Successful!</h2>");
                //  return View((object)eSurvey);


                case "DORRA":
                    return Content("<h2>Success: " + brand + " Survey is Successful!</h2>");
                //  return View((object)eSurvey);

                case "SKR":
                    return Content("<h2>Success: " + brand + " Survey is Successful!</h2>");
                //  return View((object)eSurvey);


                default:
                    return Content("<h2>Error: " + brand + " is invalid Brand Name!</h2>");
            }
           //return Content("Thank You!");
        }

    }
}
