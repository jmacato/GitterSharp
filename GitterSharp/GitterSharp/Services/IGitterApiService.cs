﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitterSharp.Model;

namespace GitterSharp.Services
{
    public interface IGitterApiService
    {
        #region Authentication
        
        /// <summary>
        /// Once authenticated, set the token provided by auth
        /// </summary>
        /// <param name="token">Token retrieved from authentication</param>
        void TryAuthenticate(string token);

        #endregion

        #region User

        /// <summary>
        /// Returns the current user logged
        /// </summary>
        /// <returns></returns>
        Task<User> GetCurrentUserAsync();

        /// <summary>
        /// Send a query that informs messages was read by the user
        /// </summary>
        /// <param name="userId">Id of the user who read the messages</param>
        /// <param name="roomId">Id of the room that contains the messages</param>
        /// <param name="messageIds">List of Id of messages read</param>
        /// <returns></returns>
        Task ReadChatMessagesAsync(string userId, string roomId, IEnumerable<string> messageIds);

        #endregion

        #region Rooms

        /// <summary>
        /// Returns list of rooms of the user logged
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Room>> GetRoomsAsync();

        /// <summary>
        /// Join and retrieve the room the user ask using the URI of the room
        /// </summary>
        /// <param name="uri">URI of the room targeted</param>
        /// <returns></returns>
        Task<Room> JoinRoomAsync(string uri);

        #endregion

        #region Messages

        /// <summary>
        /// Retrieve messages of a specific room - in realtime
        /// </summary>
        /// <param name="roomId">Id of the room that contains messages</param>
        /// <returns></returns>
        IObservable<Message> GetRealtimeMessages(string roomId);

        /// <summary>
        /// Retrieve messages of a specific room
        /// </summary>
        /// <param name="roomId">Id of the room that contains messages</param>
        /// <param name="limit">The limit of messages returned by the request</param>
        /// <param name="beforeId">Id of a message (used to truncate messages after this message id)</param>
        /// <param name="afterId">Id of a message (used to truncate messages before this message id)</param>
        /// <param name="skip">The number of messages to skip in the request</param>
        /// <returns></returns>
        Task<IEnumerable<Message>> GetRoomMessagesAsync(string roomId, int limit = 50, string beforeId = null, string afterId = null, int skip = 0);

        /// <summary>
        /// Send a new message
        /// </summary>
        /// <param name="roomId">Id of the room that will contain this message</param>
        /// <param name="message">Content of the message</param>
        /// <returns></returns>
        Task<Message> SendMessageAsync(string roomId, string message);

        /// <summary>
        /// Update an existing message
        /// </summary>
        /// <param name="roomId">Id of the room that contains this message</param>
        /// <param name="messageId">Id of the existing message</param>
        /// <param name="message">Content of the message</param>
        /// <returns></returns>
        Task<Message> UpdateMessageAsync(string roomId, string messageId, string message);

        #endregion
    }
}