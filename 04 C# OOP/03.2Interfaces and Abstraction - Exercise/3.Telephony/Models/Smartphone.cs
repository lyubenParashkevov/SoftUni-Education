using _3.Telephony.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Telephony.Models

{
    public class Smartphone : ICallable, IBrowseble
    {
        public string Call(string phoneNumber)
        {
            if (!ValidateNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number");
            }
            return $"Calling... {phoneNumber}";
        }
        public string Browse(string url)
        {
            if (!ValidateUrl(url))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        private bool ValidateNumber(string phoneNumber)
        {
            return phoneNumber.All(c => char.IsDigit(c));
        }

        private bool ValidateUrl(string url)
        {
            return url.All(c => !char.IsDigit(c));
        }
    }
}
