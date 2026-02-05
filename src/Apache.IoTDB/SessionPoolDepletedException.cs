/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System;

namespace Apache.IoTDB
{
    /// <summary>
    /// Exception thrown when the SessionPool is depleted and cannot provide a client connection.
    /// This exception indicates that all clients in the pool are either in use or have failed,
    /// and the pool cannot recover or provide a healthy client within the timeout period.
    /// </summary>
    public class SessionPoolDepletedException : Exception
    {
        /// <summary>
        /// Gets the number of currently available clients in the pool at the time of exception.
        /// </summary>
        public int AvailableClients { get; }

        /// <summary>
        /// Gets the total configured size of the session pool.
        /// </summary>
        public int TotalPoolSize { get; }

        /// <summary>
        /// Gets the number of failed reconnection attempts since the pool was opened.
        /// </summary>
        public int FailedReconnections { get; }

        /// <summary>
        /// Gets a description of why the pool was depleted.
        /// </summary>
        public string DepletionReason { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionPoolDepletedException"/> class.
        /// </summary>
        /// <param name="depletionReason">The reason why the pool was depleted.</param>
        /// <param name="availableClients">The number of currently available clients.</param>
        /// <param name="totalPoolSize">The total configured pool size.</param>
        /// <param name="failedReconnections">The number of failed reconnection attempts.</param>
        public SessionPoolDepletedException(
            string depletionReason,
            int availableClients,
            int totalPoolSize,
            int failedReconnections)
            : base(FormatMessage(depletionReason, availableClients, totalPoolSize, failedReconnections))
        {
            DepletionReason = depletionReason;
            AvailableClients = availableClients;
            TotalPoolSize = totalPoolSize;
            FailedReconnections = failedReconnections;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionPoolDepletedException"/> class with an inner exception.
        /// </summary>
        /// <param name="depletionReason">The reason why the pool was depleted.</param>
        /// <param name="availableClients">The number of currently available clients.</param>
        /// <param name="totalPoolSize">The total configured pool size.</param>
        /// <param name="failedReconnections">The number of failed reconnection attempts.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public SessionPoolDepletedException(
            string depletionReason,
            int availableClients,
            int totalPoolSize,
            int failedReconnections,
            Exception innerException)
            : base(FormatMessage(depletionReason, availableClients, totalPoolSize, failedReconnections), innerException)
        {
            DepletionReason = depletionReason;
            AvailableClients = availableClients;
            TotalPoolSize = totalPoolSize;
            FailedReconnections = failedReconnections;
        }

        private static string FormatMessage(
            string depletionReason,
            int availableClients,
            int totalPoolSize,
            int failedReconnections)
        {
            return $"SessionPool depleted: {depletionReason}. " +
                   $"Available clients: {availableClients}/{totalPoolSize}, " +
                   $"Failed reconnections: {failedReconnections}";
        }
    }
}
