open Elmish
open Elmish.React

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram Ui.init Ui.update Ui.view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "root"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run