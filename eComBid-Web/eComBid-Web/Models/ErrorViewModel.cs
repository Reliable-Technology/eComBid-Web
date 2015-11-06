using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eComBid_Web.Models
{
    public class ErrorViewModel
    {
        public string Title = string.Empty;
        public string Message = string.Empty;
        public string RedirectTo = string.Empty;
        public int RedirectToTimeout = 10; // seconds
        public bool MessageIsHtml = false;
    }
}