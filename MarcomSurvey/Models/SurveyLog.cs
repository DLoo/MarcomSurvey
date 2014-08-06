using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MarcomSurvey.Models
{
    //[Table("SurveyLog")]
    public class SurveyLog
    {
        [Key]
        public int ID { get; set; }

        public DateTime? AddDate { get; set; }
        public string Brand { get; set; }
        public string SurveyName { get; set; }
        public string EmailTo { get; set; }
        public string EmailFrom { get; set; }
        public string EmailCc { get; set; }

        public string Field01 { get; set; }
        public string Field02 { get; set; }
        public string Field03 { get; set; }
        public string Field04 { get; set; }
        public string Field05 { get; set; }
        public string Field06 { get; set; }
        public string Field07 { get; set; }
        public string Field08 { get; set; }
        public string Field09 { get; set; }
        public string Field10 { get; set; }

        public string Field11 { get; set; }
        public string Field12 { get; set; }
        public string Field13 { get; set; }
        public string Field14 { get; set; }
        public string Field15 { get; set; }
        public string Field16 { get; set; }
        public string Field17 { get; set; }
        public string Field18 { get; set; }
        public string Field19 { get; set; }
        public string Field20 { get; set; }
        
    }
}