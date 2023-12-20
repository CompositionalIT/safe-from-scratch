open Feliz
open Browser
open Feliz.JSX.React

let private root = document.getElementById "root" |> ReactDOM.createRoot

[ App.MyComponent() |> toReact ] |> React.strictMode |> root.render