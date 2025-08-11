using CommunityToolkit.Mvvm.Messaging;

namespace MauiApp2.Services.Contracts
{
    public interface IMessengerService
    {
        /// <summary>
        /// Checks if the message is registered
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <typeparam name="TToken"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        bool IsRegistered<TMessage, TToken>(Object recipient, TToken token) where TMessage : class where TToken : IEquatable<TToken>;

        /// <summary>
        /// Checks if the message is registered
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="recipient"></param>
        /// <returns></returns>
        bool IsRegistered<TMessage>(Object recipient) where TMessage : class;

        /// <summary>
        /// Registers the message
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="handler"></param>
        void Register<TMessage>(Object recipient, MessageHandler<object, TMessage> handler) where TMessage : class;

        /// <summary>
        /// Registers the message
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="token"></param>
        /// <param name="handler"></param>
        void Register<TMessage>(Object recipient, string token, MessageHandler<object, TMessage> handler) where TMessage : class;

        /// <summary>
        /// Sends the message
        /// </summary>
        /// <typeparam name="TMessageType"></typeparam>
        /// <param name="testMessage"></param>
        void Send<TMessageType>(TMessageType testMessage) where TMessageType : class;

        /// <summary>
        /// Sends the message
        /// </summary>
        /// <typeparam name="TMessageType"></typeparam>
        /// <param name="testMessage"></param>
        /// <param name="token"></param>
        void Send<TMessageType>(TMessageType testMessage, string token) where TMessageType : class;

        /// <summary>
        /// Unregisters the message
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <typeparam name="TToken"></typeparam>
        /// <param name="recipient"></param>
        /// <param name="token"></param>
        void Unregister<TMessage, TToken>(Object recipient, TToken token) where TMessage : class where TToken : IEquatable<TToken>;

        /// <summary>
        /// Unregisters the message
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="recipient"></param>
        void Unregister<TMessage>(Object recipient) where TMessage : class;

        /// <summary>
        /// Unregisters all messages
        /// </summary>
        /// <param name="recipient"></param>
        void UnregisterAll(Object recipient);
    }
}
