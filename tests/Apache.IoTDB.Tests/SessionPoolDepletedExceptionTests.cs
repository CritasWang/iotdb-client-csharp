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
using NUnit.Framework;

namespace Apache.IoTDB.Tests
{
    [TestFixture]
    public class SessionPoolDepletedExceptionTests
    {
        [Test]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var depletionReason = "Pool timeout";
            var availableClients = 0;
            var totalPoolSize = 4;
            var failedReconnections = 2;

            // Act
            var exception = new SessionPoolDepletedException(
                depletionReason,
                availableClients,
                totalPoolSize,
                failedReconnections);

            // Assert
            Assert.That(exception.DepletionReason, Is.EqualTo(depletionReason));
            Assert.That(exception.AvailableClients, Is.EqualTo(availableClients));
            Assert.That(exception.TotalPoolSize, Is.EqualTo(totalPoolSize));
            Assert.That(exception.FailedReconnections, Is.EqualTo(failedReconnections));
        }

        [Test]
        public void Constructor_GeneratesCorrectMessage()
        {
            // Arrange
            var depletionReason = "Pool timeout";
            var availableClients = 0;
            var totalPoolSize = 4;
            var failedReconnections = 2;

            // Act
            var exception = new SessionPoolDepletedException(
                depletionReason,
                availableClients,
                totalPoolSize,
                failedReconnections);

            // Assert
            Assert.That(exception.Message, Does.Contain("SessionPool depleted"));
            Assert.That(exception.Message, Does.Contain(depletionReason));
            Assert.That(exception.Message, Does.Contain($"{availableClients}/{totalPoolSize}"));
            Assert.That(exception.Message, Does.Contain($"{failedReconnections}"));
        }

        [Test]
        public void Constructor_WithInnerException_PreservesInnerException()
        {
            // Arrange
            var depletionReason = "Reconnection failed";
            var innerException = new InvalidOperationException("Server unreachable");

            // Act
            var exception = new SessionPoolDepletedException(
                depletionReason,
                0,
                4,
                3,
                innerException);

            // Assert
            Assert.That(exception.InnerException, Is.EqualTo(innerException));
            Assert.That(exception.InnerException.Message, Is.EqualTo("Server unreachable"));
        }

        [Test]
        public void Exception_CanBeThrown()
        {
            // Arrange & Act & Assert
            Assert.Throws<SessionPoolDepletedException>(() =>
            {
                throw new SessionPoolDepletedException(
                    "Test depletion",
                    0,
                    8,
                    1);
            });
        }

        [Test]
        public void Exception_MessageFormat_MatchesExpectedPattern()
        {
            // Arrange
            var exception = new SessionPoolDepletedException(
                "Connection pool is empty and wait time out(50s)",
                0,
                8,
                5);

            // Act
            var message = exception.Message;

            // Assert
            Assert.That(message, Is.EqualTo(
                "SessionPool depleted: Connection pool is empty and wait time out(50s). " +
                "Available clients: 0/8, " +
                "Failed reconnections: 5"));
        }
    }
}
