using System;

namespace BusDemo.Messages
{
    public class SendName
    {
        public SendName()
        {
        }

        public SendName(string name)
        {
            Name = name;
        }

        public String Name { get; set; }
    }
}
