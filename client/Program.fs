open Fable.SimpleHttp
open Browser.Types

let btnFetch = Browser.Dom.document.getElementById "btnFetch" :?> HTMLButtonElement

btnFetch.onclick <-
    fun _ ->
        async {
            let! code, data = Http.get "/api/data"
            Browser.Dom.console.log (code, data)
            Browser.Dom.window.alert $"Data received: Response code {code}, '{data}'"
        }
        |> Async.StartImmediate