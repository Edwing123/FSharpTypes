module FSharpTypes.Option

// The option type.

let o = Some 42
printfn "%A" o // nice
printfn "%O" o // nice

let v = defaultArg o 0

printfn "%i" v

// Option vs null vs nullable

// They are not the same.
// F# has a null keyword, but it's meant to be used to
// interop with .NET libraries and external code.

// F# pure types cannot be set to null.

// type Options =
//     | Deposit
//     | Withdrawal

// let option: Options = null

// type Card = { Number: string; Expiry: string }

// let myCard: Card = null

// But .NET types can be.
let gfName: string = null

// Nullable are kind of similar, but weaker.

let n: System.Nullable<int> = System.Nullable 100

if n.HasValue then
    printfn "%i" n.Value
else
    printfn "No value"
