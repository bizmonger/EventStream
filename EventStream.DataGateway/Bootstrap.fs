namespace EventStream.DataGateway

open System.Text
open System.Threading.Tasks
open System.Diagnostics
open Azure.Messaging.EventHubs;
open Azure.Messaging.EventHubs.Consumer
open Azure.Storage.Blobs
open EventStream.Language

module Bootstrap =

    let eventHub (connection:Connection) = 

        task {

            let containerClient = BlobContainerClient(connection.StorageConnectionString, 
                                                      connection.StorageContainer)

            let processor = EventProcessorClient(containerClient, 
                                                 EventHubConsumerClient.DefaultConsumerGroupName, 
                                                 connection.HubConnectionString,
                                                 connection.HubName)

            processor.add_ProcessEventAsync(fun args ->

                let data  = args.Data.Body.ToArray()
                let event = Encoding.UTF8.GetString(data)

                Debug.WriteLine(event)
                Task.CompletedTask)

            processor.add_ProcessErrorAsync(fun args ->

                Debug.WriteLine(args)
                Task.CompletedTask)

            do! processor.StartProcessingAsync()

            return Ok()
        }