open Fable.SimpleHttp
open Browser.Types
open Browser.Dom

let btnFetch = document.getElementById "btnFetch" :?> HTMLButtonElement

btnFetch.onclick <-
    fun _ ->
        async {
            let! code, data = Http.get "/api/data"
            console.log (code, data)
            window.alert $"Data received: Response code {code}, '{data}'"
        }
        |> Async.StartImmediate