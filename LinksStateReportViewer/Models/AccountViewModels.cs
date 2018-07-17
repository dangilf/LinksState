using System;
using System.Collections.Generic;

namespace LinksStateReportViewer.Models
{
    // Models returned by AccountController actions.

    public class LoginViewModel
    {
        
        public string Email { get; set; }
       
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
    public class RegisterViewModel
    {
        public string Email { get; set; }
        
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

}
