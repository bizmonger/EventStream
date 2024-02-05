namespace EventStream.DataGateway

open Newtonsoft.Json
open Azure.Messaging.EventHubs;
open Azure.Messaging.EventHubs.Producer
open EventStream
open EventStream.Language

module Receive =

    let status : Operations.Receive<Connection> = 

        fun order cfg -> task {

            return Error "TODO"
        }