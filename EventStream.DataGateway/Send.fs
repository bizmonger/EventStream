namespace EventStream.DataGateway

open Newtonsoft.Json
open Azure.Messaging.EventHubs;
open Azure.Messaging.EventHubs.Producer
open EventStream
open EventStream.Language

module Send =

    let status : Operations.Receive<Connection> = 

        fun order cfg -> task {

            let  client = EventHubProducerClient(cfg.ConnectionString, cfg.HubName)
            let! batch  = client.CreateBatchAsync()

            let json = JsonConvert.SerializeObject(order)
            let data = EventData(json)

            if batch.TryAdd(data)
            then return Ok ()
            else return Error $"Failed to dispatch event: {order}"
        }