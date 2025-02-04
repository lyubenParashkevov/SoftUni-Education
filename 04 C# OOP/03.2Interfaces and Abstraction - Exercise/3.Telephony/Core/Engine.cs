using _3.Telephony.Core.Interfaces;
using _3.Telephony.IO.Interfaces;
using _3.Telephony.Models;
using _3.Telephony.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] urls = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ICallable phone;
            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    phone = new Smartphone();
                }
                else
                {
                    phone = new StationaryPhone();
                }
                try
                {
                    writer.WriteLine(phone.Call(phoneNumber));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }

            }

            IBrowseble browseble = new Smartphone();

            foreach (string url in urls)
            {
                try
                {
                    writer.WriteLine(browseble.Browse(url));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }

            }
        }
    }
}
