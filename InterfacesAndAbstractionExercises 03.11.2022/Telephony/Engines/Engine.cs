

namespace Telephony.Engines
{
    using System;

    using Telephony.Engine.Interfaces;
    using Telephony.Exeptions;
    using Telephony.IO.Inteefaces;
    using Telephony.Models;
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private StationaryPhone statioanryPhone;
        private SmartPhone smartPhone;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            statioanryPhone = new StationaryPhone();
            smartPhone = new SmartPhone();
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Calling(phoneNumbers);
            string[] urls = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Browsing(urls);
        }

        private void Calling(string[] phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        writer.WriteLine(statioanryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        writer.WriteLine(smartPhone.Call(number));
                    }
                }
                catch(InvalidPhoneNumberException ex)
                {
                    writer.WriteLine(ex.Message);
                    continue;
                }
            }
        }
        private void Browsing(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    writer.WriteLine(smartPhone.Browse(url));
                }
                catch (InvalidURLException ex)
                {
                    writer.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
