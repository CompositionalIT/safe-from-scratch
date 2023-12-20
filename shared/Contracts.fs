namespace global

type IApi = { Greet: unit -> Async<string> }

module Route =
    let builder = sprintf "/api/%s/%s"