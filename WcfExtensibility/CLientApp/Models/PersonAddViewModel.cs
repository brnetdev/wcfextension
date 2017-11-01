using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contracts;
using System.ComponentModel.DataAnnotations;

namespace CLientApp.Models
{
    public class PersonAddViewModel
    {
        [MaxLength(50, ErrorMessageResourceType = typeof(CLientApp.Resources.Add), ErrorMessageResourceName = nameof(CLientApp.Resources.Add.FirstNameLength))]
        [Display(ResourceType = typeof(CLientApp.Resources.Add), Name = nameof(CLientApp.Resources.Add.FirstNameLabel))]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(CLientApp.Resources.Add), ErrorMessageResourceName = "LastNameLength")]
        [Display(ResourceType = typeof(CLientApp.Resources.Add), Name = nameof(CLientApp.Resources.Add.LastNameLabel))]
        public string LastName { get; set; }

        [Range(0, 150, ErrorMessageResourceType = typeof(CLientApp.Resources.Add), ErrorMessageResourceName = "AgeRange")]
        [Display(ResourceType = typeof(CLientApp.Resources.Add), Name = nameof(CLientApp.Resources.Add.AgeLabel))]
        public int Age { get; set; }
        
    }
}