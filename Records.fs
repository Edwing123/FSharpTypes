module FsharpTypes.Records

// Labeled tuples... more or less.

type ProductStatus =
    | Active
    | Inactive

type CardProduct =
    { Id: uint8
      Name: string
      Descripcion: string
      Status: ProductStatus }

let products =
    [ { Id = uint8 1
        Name = "Platinium"
        Descripcion = "Platinium Card"
        Status = Active }
      { Id = uint8 2
        Name = "Gold"
        Descripcion = "Gold card"
        Status = Inactive } ]

products
|> List.iter (fun p ->
    let { Name = name; Status = status } = p
    printfn $"Name: {name}, status: {status}")


// Name conflicts
// F# infers the p binding to have a type of `Person2` since it's
// the type that was defined later in the type definitions, like shadowing
// the `Person1` type.

// type Person1 = {First:string; Last:string}
// type Person2 = {First:string; Last:string}
// let p = {First="Alice"; Last="Jones"} //

// Creating records from other records.

[<RequireQualifiedAccess>]
type PlayerKind =
    | Wizzard
    | Knight
    | Witch
    | Warrior

type Player =
    { Name: string
      Level: uint8
      Kind: PlayerKind
      Location: int * int }

let me =
    { Name = "Edwing123"
      Level = uint8 1
      Kind = PlayerKind.Knight
      Location = (0, 0) }

// Level up
// with: a copy-and-update record expression.
let newMe = { me with Level = me.Level + uint8 1 }

open System

Console.WriteLine $"me: {me.GetHashCode()}, newMe: {newMe.GetHashCode()}"
