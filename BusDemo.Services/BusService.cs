using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Ninject;

namespace BusDemo.Services
{
    public class BusService : IBusService
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
                x.OverrideDefaultBusEndpointQueueName($"SendOnly_{connectionName}");
            });

            _bus.Start();
        }

        public void Start()
        {
            _bus = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(new Uri(_busAddress), h => {
                    h.Username(_username); h.Password(_password);
                    h.PublisherConfirmation = true;
                });
                x.Durable = true;
            });

            _bus.Start();
        }



        public void Stop()
        {
            _bus.Stop();
        }

        public Task Send<T>(T message) where T : class
        {
            return _bus.Send<T>(message);
        }

        public void Subscribe<T>(MessageHandler<T> handler) where T : class
        {
            _bus.ConnectHandler<T>(handler);
        }
    }

    public interface IBusService
    {
        void Start();

        void Start(string connectionName);

        void Stop();

        Task Send<T>(T message)
            where T : class;

        void Subscribe<T>(MessageHandler<T> handler) 
            where T : class;
    }
}