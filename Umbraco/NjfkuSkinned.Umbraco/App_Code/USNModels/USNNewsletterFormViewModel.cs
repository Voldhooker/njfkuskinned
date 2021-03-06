﻿using System.ComponentModel.DataAnnotations;

namespace USN.USNModels
{
    public class USNNewsletterFormViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string Email { get; set; }

        public int CurrentNodeID { get; set; }

        public int GlobalSettingsID { get; set;}

        public string CaptchaDataSize { get; set; }
    }

}