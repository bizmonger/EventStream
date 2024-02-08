namespace EventStream.DataGateway

open System.Text
open Newtonsoft.Json
open Azure.Messaging.EventHubs;
open Azure.Messaging.EventHubs.Producer
open EventStream
open EventStream.Language

// https://learn.microsoft.com/en-us/azure/event-hubs/event-hubs-dotnet-standard-getstarted-send?tabs=passwordless%2Croles-azure-portal#send-events-to-the-event-hub

module Publish =

    let status : Operations.Publish<Connection> = 

        fun order settings -> task {

            try

                let  client = EventHubProducerClient(settings.HubConnectionString, settings.HubName)
                let! batch  = client.CreateBatchAsync()

                let json  = JsonConvert.SerializeObject(order)
                let bytes = Encoding.UTF8.GetBytes(json)
                let data  = EventData(bytes)

                if batch.TryAdd(data) then

                    do! client.SendAsync(batch)
                    return Ok ()

                else return Error $"Failed to dispatch event: {order}"

            with ex -> return Error <| ex.GetBaseException().Message
        }