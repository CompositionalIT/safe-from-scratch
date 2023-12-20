module Ui

open Browser.Dom
open Feliz
open Fable.Core
open Fable.Remoting.Client
open Elmish
open Feliz.JSX.React

type Model = string option

type Message =
    | GetData
    | GotData of string

let api =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.buildProxy<IApi>

let init () = None, Cmd.none

let update msg model =
    match msg with
    | GetData -> None, Cmd.OfAsync.perform api.Greet () GotData
    | GotData data -> Some data, Cmd.none

[<JSX.Component>]
let MyComponent model dispatch =
    match model with
    | Some model -> window.alert model
    | None -> ()

    JSX.jsx
        $"""
    <button class="bg-white hover:bg-gray-100 text-gray-800 font-semibold py-2 px-4 border border-gray-400 rounded shadow m-5" onClick={fun _ -> dispatch GetData}>
        Fetch Data!
    </button>
"""
    |> toReact

let view model dispatch = MyComponent model dispatch