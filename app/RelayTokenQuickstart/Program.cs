using System;
using Azure.Communication.Identity;
using Azure;
using System.Collections.Generic;
using Azure.Communication.NetworkTraversal;

namespace RelayTokenQuickstart {

    class Program {

        static async Task Main(string[] args) {

            Console.WriteLine("Azure Communication Services - User Relay Token Quickstart");

            // This code demonstrates how to fetch your connection string
            // from an environment variable.
            var client = new CommunicationRelayClient("endpoint=https://cdw-commsvcs-20201007.communication.azure.com/;accesskey=B1JzRrKVF7p+U7ckLoijDiO+Dg0krhHT3OlU5cXuKTUSEIdiK3mpypkssDpeAy5b7d2NbcpIuT1QTC7C8NLQ6A==");

            Response<CommunicationRelayConfiguration> relayConfiguration = await client.GetRelayConfigurationAsync();
            DateTimeOffset turnTokenExpiresOn = relayConfiguration.Value.ExpiresOn;
            IReadOnlyList<CommunicationIceServer> iceServers = relayConfiguration.Value.IceServers;

            Console.WriteLine($"Expires On: {turnTokenExpiresOn}");

            foreach (CommunicationIceServer iceServer in iceServers) {
                foreach (string url in iceServer.Urls) {
                    Console.WriteLine($"ICE Server Url: {url}");
                }

                Console.WriteLine($"ICE Server Username: {iceServer.Username}");
                Console.WriteLine($"ICE Server Credential: {iceServer.Credential}");
                Console.WriteLine($"ICE Server RouteType: {iceServer.RouteType}");
            }
        }
    }
}