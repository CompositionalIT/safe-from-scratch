open Giraffe
open Microsoft.AspNetCore.Builder
open Fable.Remoting.Server

let api = {
    Greet = fun () -> async { return "Hello World!" }
}

let webApp =
    Remoting.createApi ()
    |> Remoting.withRouteBuilder Route.builder
    |> Remoting.fromValue api
    |> Fable.Remoting.Giraffe.Remoting.buildHttpHandler

let b = WebApplication.CreateBuilder()
b.Services.AddGiraffe() |> ignore
let app = b.Build()
app.UseGiraffe webApp
app.Run()