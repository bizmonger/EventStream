namespace EventStream.DataGateway

open Newtonsoft.Json
open Azure.Messaging.EventHubs;
open Azure.Messaging.EventHubs.Producer
open EventStream
open EventStream.Language

// https://learn.microsoft.com/en-us/azure/event-hubs/event-hubs-dotnet-standard-getstarted-send?tabs=passwordless%2Croles-azure-portal#send-events-to-the-event-hub

module Send =

    let status : Operations.Receive<Connection> = 

        fun order cfg -> task {

            let  client = EventHubProducerClient(cfg.ConnectionString, cfg.HubName)
            let! batch  = client.CreateBatchAsync()

            let json = JsonConvert.SerializeObject(order)
            let data = EventData(json)

            if batch.TryAdd(data)
            then 
                 do! client.SendAsync batch
                 return Ok ()

            else return Error $"Failed to dispatch event: {order}"
        }