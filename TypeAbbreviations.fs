module FSharpTypes.TypeAbbreviations

// They are are just aliases that reffer to an existing type

type PrimaryAccountNumber = string

// They can be useful for documentation or to have an alias
// for a complex type definition that will be used in a lot of
// places

type Event<'T> = {
    Type: string
    Data: 'T
}

// An event handler function.
type EventHandler<'T> = Event<'T> -> unit

let handler (event: Event<string>) =
    printfn "%s %A" event.Type event.Data


let handlers: EventHandler<string> list = [
    handler
]

handlers[0] { Type = "change"; Data = "" }
