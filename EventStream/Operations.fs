namespace EventStream

open System.Threading.Tasks
open Language

module Operations =

    type Publish<'context> = Order -> 'context -> Task<Result<unit, string>>