module FsharpTypes.DiscriminatedUnion

module Inqueries =
    type DirectionType =
        | Email
        | Address
        | WorkAddress

    type DirectionChange =
        { Kind: DirectionType
          OldValue: string
          NewValue: string }

    type InqueryStatus =
        | Pending
        | Completed

    type Inquery =
        { Status: InqueryStatus
          CreatedAt: System.DateTime
          CreatedBy: int
          ResolvedBy: int option
          ResolutionDate: System.DateTime option }


// Optional vertical bar for the first union case.

type OptionalVerticalBar =
    | A
    | B

// The first letter of the tag/label name must be capitalized.
type DirectionKind =
    | Email
    | HomeAddress
    | WorkAddress
// | others

// They are allowed only if the RequireQualifiedAccess attribute is used.
[<RequireQualifiedAccess>]
type ProductKind =
    | visa
    | masterCard

// Creating values.

let product = ProductKind.visa
let directionKind = Email

// Pattern match to find the active union case.

let msg =
    match product with
    | ProductKind.visa -> "Visa"
    | ProductKind.masterCard -> "MasterCard"

printfn "The product is %s." msg

let notification =
    match directionKind with
    | Email -> "Email"
    | HomeAddress -> "Home Address"
    | WorkAddress -> "Work Address"

printfn "The notification is %s." notification

// Single case union types.

// Useful for enforcing type safety.

type AccountId = AccountId of int

type ClientId = ClientId of int

type AccountKind =
    | Personal
    | Business

type Account =
    { AccountId: AccountId
      ClientId: ClientId
      Kind: AccountKind }

let myAccount =
    { AccountId = AccountId 1
      ClientId = ClientId 1
      Kind = Personal }

let getAccountKind account =
    match account.Kind with
    | Personal -> "Personal"
    | Business -> "Business"

printfn "The account kind is %s." (getAccountKind myAccount)

// Pattern matching on single case unions.

let client1 = ClientId 1

// We can desconstruct it.

let (ClientId id) = client1

printfn "%A" client1

// Union type members.

type FundsSourceKind =
    | Credit
    | Debit
    | Prepaid

let creditFunds = Credit

if creditFunds.IsCredit then
    printfn "It is a credit funds source."
else if creditFunds.IsDebit then
    printfn "It is a debit funds source."
else if creditFunds.IsPrepaid then
    printfn "It is a prepaid funds source."

match creditFunds with
| Credit -> printfn "It is a credit funds source."
| Debit -> printfn "It is a debit funds source."
| Prepaid -> printfn "It is a prepaid funds source."
