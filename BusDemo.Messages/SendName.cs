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

        private String Name { get; set; }
    }
}
