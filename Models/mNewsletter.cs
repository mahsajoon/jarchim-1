using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jarchim.Models
{
    public class mNewsletter
    {
        public long newsletter_id { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [Remote("DupEmail", "Home", HttpMethod = "POST", ErrorMessage = "This Email Used")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email =>> 10 to 100")]
        public string newsletter_email { get; set; }
    }
}