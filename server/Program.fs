open Microsoft.Extensions.Configuration
open Giraffe
open Microsoft.AspNetCore.Builder

let b = WebApplication.CreateBuilder()
b.Services.AddGiraffe() |> ignore
let app = b.Build()
app.UseGiraffe(text "Hello world")
app.Run()