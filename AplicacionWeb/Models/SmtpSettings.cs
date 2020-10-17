using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class SmtpSettings: ISmtpSettings
    {
        public string Host { set; get; }
        public string Email { set; get; }
        public string Pasword { set; get; }
        public int Port { set; get; }
    
    }
    public interface ISmtpSettings
    {
        public string Host { set; get; }
        public string Email { set; get; }
        public string Pasword { set; get; }
        public int Port { set; get; }

    }
}
