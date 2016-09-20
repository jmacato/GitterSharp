﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitterSharp.Model
{
    public class MessageRequest
    {
        /// <summary>
        /// The limit of messages returned by the request
        /// </summary>
        public int Limit { get; set; } = 50;

        /// <summary>
        /// Id of a message (used to truncate messages after this message id)
        /// </summary>
        public string BeforeId { get; set; }

        /// <summary>
        /// Id of a message (used to truncate messages before this message id)
        /// </summary>
        public string AfterId { get; set; }

        /// <summary>
        /// Id of a message (used to truncate messages around this message id)
        /// </summary>
        public string AroundId { get; set; }

        /// <summary>
        /// The number of messages to skip in the request
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Query to search specific topic on messages
        /// </summary>
        public string Query { get; set; }
    }
}
