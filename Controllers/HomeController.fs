namespace MvcApp.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc

type HomeController () =
    inherit Controller()

    let getDescription () = async {
        do! Async.Sleep(500)
        return "My F# application description page."
        }

    member this.About () = async {
        let! msg = getDescription ()
        this.ViewData.["Message"] <- msg
        return this.View()
        }

    member this.About2 () = Async.StartAsTask(async {
        let! msg = getDescription ()
        this.ViewData.["Message"] <- msg
        return this.View("About")
        })

    member this.Index () =
        this.View()

    member this.Contact () =
        this.ViewData.["Message"] <- "Your contact page."
        this.View()

    member this.Error () =
        this.View();
