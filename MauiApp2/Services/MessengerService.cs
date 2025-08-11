using CommunityToolkit.Mvvm.Messaging;
using MauiApp2.Services.Contracts;


namespace MauiApp2.Services
{
    public class MessengerService : IMessengerService
    {
        StrongReferenceMessenger _messenger;

        public MessengerService(IMessenger messenger)
        {
            _messenger = (StrongReferenceMessenger)messenger;
        }

        /// <summary>
        /// Checks if the message is registered
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <typeparam name="TToken"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool IsRegistered<TMessage, TToken>(Object recipient, TToken token) where TMessage : class where TToken : IEquatable<TToken>
        {
            return StrongReferenceMessenger.Default.IsRegistered<TMessage, TToken>(recipient, token);
        }

        /// <summary>
        /// Checks if the message is registered
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public bool IsRegistered<TMessage>(Object recipient) where TMessage : class
        {
            return StrongReferenceMessenger.Default.IsRegistered<TMessage>(recipient);
        }

        /// <summary>
        /// Checks if the message is registered
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="handler"></param>
        public void Register<TMessage>(Object recipient, MessageHandler<object, TMessage> handler) where TMessage : class
        {
            StrongReferenceMessenger.Default.Register(recipient, handler);
        }

        /// <summary>
        /// Registers the message
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="token"></param>
        /// <param name="handler"></param>
        public void Register<TMessage>(Object recipient, string token, MessageHandler<object, TMessage> handler) where TMessage : class
        {
            StrongReferenceMessenger.Default.Register(recipient, token, handler);
        }

        /// <summary>
        /// Sends the message
        /// </summary>
        /// <typeparam name="TMessageType"></typeparam>
        /// <param name="message"></param>
        public void Send<TMessageType>(TMessageType message) where TMessageType : class
        {
            StrongReferenceMessenger.Default.Send(message);
        }

        /// <summary>
        /// Sends the message
        /// </summary>
        /// <typeparam name="TMessageType"></typeparam>
        /// <param name="message"></param>
        /// <param name="token"></param>
        public void Send<TMessageType>(TMessageType message, string token) where TMessageType : class
        {
            StrongReferenceMessenger.Default.Send(message, token);
        }

        /// <summary>
        /// Unregisters the message
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <typeparam name="TToken"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="token"></param>
        public void Unregister<TMessage, TToken>(Object recipient, TToken token) where TMessage : class where TToken : IEquatable<TToken>
        {
            StrongReferenceMessenger.Default.Unregister<TMessage, TToken>(recipient, token);
        }

        /// <summary>
        /// Unregisters the message
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="recipient"></param>
        public void Unregister<TMessage>(Object recipient) where TMessage : class
        {
            StrongReferenceMessenger.Default.Unregister<TMessage>(recipient);
        }

        /// <summary>
        /// Unregisters all messages
        /// </summary>
        /// <param name="recipient"></param>
        public void UnregisterAll(Object recipient)
        {
            StrongReferenceMessenger.Default.UnregisterAll(recipient);
        }
    }
}
