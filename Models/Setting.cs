using PustokApp.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace PustokApp.Models
{
    public class Setting
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
        //public string Email { get; set; }
        //public string SupportEmail { get; set; }
        //public string PhoneNumber { get; set; }
        //public string SupportPhoneNumber { get; set; }
        //public string Adress { get; set; }
        //public string LogoUrl { get; set; }
    }
}
