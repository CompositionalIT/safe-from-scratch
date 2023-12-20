open Fable.SimpleHttp
open Browser.Dom
open Feliz

[<ReactComponent>]
let MyComponent () =
    Html.button [
        prop.id "btnFetch"
        prop.text "Fetch Data!"
        prop.onClick (fun _ ->
            (async {
                let! code, data = Http.get "/api/data"
                console.log (code, data)
                window.alert $"Data received: Response code {code}, '{data}'"
             }
             |> Async.StartImmediate))
    ]

let root = ReactDOM.createRoot (document.getElementById "root")
root.render (MyComponent())