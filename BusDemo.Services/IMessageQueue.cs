using System;

namespace Sixeyed.MessagingPoweredFrontEnd.Core.Messaging
{
    public interface IMessageQueue
    {
        string ReplyQueueName { get; }
        void Publish<TMessage>(TMessage message);
        void Reply<TMessage>(TMessage message);
        void Listen<TMessage>(string queueName, Action<TMessage> action);
        void Dispose();
    }
}