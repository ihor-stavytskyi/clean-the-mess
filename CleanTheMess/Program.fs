open System
open System.IO
open System.Collections.Generic

let getPhrase file countToKeep =
    let text = File.ReadAllText(file)
    let countBySymbol = new Dictionary<char, int>()
    text
        |> Seq.iter (fun symbol -> 
            let existingCount = countBySymbol.GetValueOrDefault(symbol, 0)
            countBySymbol.[symbol] <- existingCount + 1)
    text
        |> Seq.filter (fun symbol -> countBySymbol.[symbol] < countToKeep)
        |> String.Concat

[<EntryPoint>]
let main argv =
    getPhrase "mess.txt" 10 |> printfn "%s" 
    0
