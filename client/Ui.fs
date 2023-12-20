module App

open Browser.Dom
open Feliz
open Fable.Core
open Fable.Remoting.Client

let private loadData () =
    let api =
        Remoting.createApi ()
        |> Remoting.withRouteBuilder Route.builder
        |> Remoting.buildProxy<IApi>

    async {
        let! data = api.Greet()
        console.log data
        window.alert $"Data received: '{data}'"
    }
    |> Async.StartImmediate

[<JSX.Component>]
let MyComponent () =
    JSX.jsx
        $"""
    <button id="btnFetch" onClick={fun _ -> loadData ()}>
        Fetch Data!
    </button>
"""