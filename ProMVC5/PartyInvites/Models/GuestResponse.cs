using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage ="请输入姓名！")]
        public string Name { get; set; }

        [Required(ErrorMessage ="请输入email")]
        [RegularExpression(@"^[a-zA-Z\d]+@[a-z\d]+\.[a-z]+$",ErrorMessage ="不合法")]
        public string Email { get; set; }

        [Required(ErrorMessage ="别忘了手机号")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="别忘了选")]
        public bool? WillAttend { get; set; }
    }
}