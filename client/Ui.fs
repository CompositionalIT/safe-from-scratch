module App

open Fable.SimpleHttp
open Browser.Dom
open Feliz
open Fable.Core

let private loadData () =
    async {
        let! code, data = Http.get "/api/data"
        console.log (code, data)
        window.alert $"Data received: Response code {code}, '{data}'"
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