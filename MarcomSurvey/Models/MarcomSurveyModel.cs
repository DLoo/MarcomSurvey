using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MarcomSurvey.Models
{
    public class MarcomSurveyModel
    {
        public string Brand { get; set; }
        public string SurveyName { get; set; }
        public string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public string EmailCc { get; set; }

        private EFESurvey_Context db = new EFESurvey_Context();

        public Dictionary<string, string> FormData { get; set; }

        public void sendMail()
        {
            try {
                //save the survey data first
                 saveSurveyData();

	             WebMail.SmtpServer = "mailsvr.eurogrp.com";
	             WebMail.SmtpPort = 25;
	             WebMail.EnableSsl = false;
	             WebMail.UserName = "";
	             WebMail.Password = "";
	             
	             WebMail.Send(EmailTo, "Survey Notification: " + Brand + " > " + SurveyName,
                    getFormDataHTML(), EmailFrom, EmailCc, null, true);
	        } catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
                throw (ex);
	        }
        }

        // To save Survey Data received into DB repository
        private void saveSurveyData()
        {
            SurveyLog surveyLog = new SurveyLog
            {
                AddDate = DateTime.Now,
                SurveyName = this.SurveyName,
                Brand = this.Brand,
                EmailFrom = EmailFrom,
                EmailTo = EmailTo,
                EmailCc = EmailCc
            };

            int i = 1;
            foreach(var field in FormData)
            {
                //surveyLog["Field" + i.ToString("D2")] = FormData[field.Key];
                var prop = surveyLog.GetType().GetProperty("Field" + i.ToString("D2"));
                prop.SetValue(surveyLog, Convert.ChangeType(FormData[field.Key], prop.PropertyType), null);
                i++;
            }
            db.SurveyLogs.Add(surveyLog);
            db.SaveChanges();

        }


        public string getFormDataHTML()
        {
            string body = "<DIV style=\"color:#333333 !important; font-size:20px; font-family: Arial, Verdana, sans-serif; padding-left:10px; margin:20px;\">" + 
                "<h3 style=\"font-weight:normal; margin: 20px 0; text-decoration:underline;\">" + Brand + " - " + SurveyName + "</h3>";

            foreach (string key in FormData.Keys)
            {
                body +=
                "<DIV style=\"font-weight:bold; font-size:14px; line-height:18px;\">" + key + ":</DIV>" +
                "<DIV style=\"font-size:14px; line-height:18px;\">" + FormData[key] + "</DIV><br> ";
                   
            }
            body += "</DIV>";
            return (body);

        }
    }
}