namespace EventStream

open System.Threading.Tasks
open Language

module Operations =

    type Receive<'context> = Order -> 'context -> Task<Result<unit, string>>
    type Send<'context>    = Order -> 'context -> Task<Result<unit, string>>