using System;
using MassTransit;
using Ninject;

namespace BusDemo.Services
{
    public class BusService
    {
        private readonly IKernel _kernel;
        private readonly string _busAddress;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;
        private IBusControl _bus;

        public BusService(IKernel kernel, string busAddress, string queueName, string username, string password)
        {
            _kernel = kernel;
            _busAddress = busAddress;
            _queueName = queueName;
            _username = username;
            _password = password;
        }
        public void Start(string connectionName)
        {
            _bus = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri(_busAddress), connectionName, h => {
                    h.Username(_username); h.Password(_password);
                    h.PublisherConfirmation = true;
                });
                x.ReceiveEndpoint(host, _queueName, e =>
                {
                    //  e.LoadFrom(_kernel);
                });
                x.Durable = true;
                x.OverrideDefaultBusEndpointQueueName($"Local_{connectionName}");
            });

            _bus.Start();
        }


        public void Stop()
        {
            _bus.Stop();
        }


    }

    public interface IService
    {
        void Start();

        void Stop();
    }
}