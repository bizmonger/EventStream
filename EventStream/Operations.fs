namespace EventStream

open System.Threading.Tasks
open Language

module Operations =

    type Send<'context>    = Order -> 'context -> Task<Result<unit, string>>