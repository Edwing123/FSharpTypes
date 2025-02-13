module FSharpTypes.BigPicture

(*

Syntax for defining new types:

type [name]<generic-params-list> = definition

*)

// Examples

[<RequireQualifiedAccess>]
type AccountStatus = Active | Inactive

type Account = {
    Id: int
    Status: AccountStatus
}

[<RequireQualifiedAccess>]
type Response<'TData> =
    | Ok of data: 'TData
    | Error of msg: string

// Class types!

open Microsoft.Extensions.Logging

type Controller(logger: ILogger) =
    let name = ""

    member _.displayName () =
        logger.LogInformation "Starting"
        ()

// After types are created, instances of the type are created
// using a "constructor" expression.

let accountStatus = AccountStatus.Active

let account = {
    Id = 1
    Status = accountStatus
}

let OK = Response<string>.Ok "Hello World"

let loggerFactory = LoggerFactory.Create (fun builder -> builder.AddConsole() |> ignore)

let logger = loggerFactory.CreateLogger "FsharpTypes"

logger.LogInformation "Hello World"

let controller = Controller(logger)

