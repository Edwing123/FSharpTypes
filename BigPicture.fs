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

let loggerFactory = LoggerFactory.Create (fun builder -> builder.AddJsonConsole() |> ignore)

let logger = loggerFactory.CreateLogger "FsharpTypes"

logger.LogInformation "Hello World"

let controller = Controller logger

do controller.displayName ()

// We can use the same "constructor" syntax to "deconstruct" the values
// through pattern matching.

// Constructing and deconstructing tuples.

let coords = (1, 1)

let (x, y) = coords

ignore <| (x, y)

type Transaction = {
    RetrievalReferenceNumber: string
    PrimaryAccountNumber: string
    Amount: decimal
    DateTime: System.DateTime
    ProcessingCode: string
    MessageTypeIdentifier: string
    ExpireDate: string
    MerchantCategory: string
    CardAceptorName: string
    AcquiringInstitutionIdentifier: string
}

// 5072

let trx = {
    RetrievalReferenceNumber = "5044123456"
    PrimaryAccountNumber = "4249201234567896"
    Amount = 34.99m
    DateTime = System.DateTime.Now
    ProcessingCode = "00000000"
    MessageTypeIdentifier = "0100"
    ExpireDate = "3008"
    MerchantCategory = "5072"
    CardAceptorName = "Sinsa S.A."
    AcquiringInstitutionIdentifier = "1234"
}

// Extra needed values.

let maskPAN (pan: string) =
    pan.Substring(0, 6) + "xxxxxx" + pan.Substring(12)

let { PrimaryAccountNumber = pan; Amount = amount } = trx

System.Console.WriteLine $"pan: {maskPAN(pan)}, amount: {amount}"

