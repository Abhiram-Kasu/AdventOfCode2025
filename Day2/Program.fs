// For more information see https://aka.ms/fsharp-console-apps


open System
open FSharp.Collections.ParallelSeq

open System.Linq

[<EntryPoint>]
let main argv =
    let isInvalid (str: string) =
        let n = str.Length / 2
        let firstHalf  = str[0..n-1]
        let secondHalf = str[n..]
        let res = firstHalf = secondHalf
        if res then
            Console.WriteLine $"Invalid: {str}"
        res

        
    let mapToInvalids inputs =
        let s, e = inputs
        seq { for i in s .. e -> i } |> Seq.map string |> Seq.filter isInvalid |> Seq.map int64

    
    
    let input = Console.ReadLine().Split(',') |> Seq.map (fun s ->
        match s.Split('-') with
        | [|a; b|] -> (a |> int64, b |> int64)
        | _ -> raise (Exception("Invalid input"))) |> PSeq.map mapToInvalids |> Seq.concat |> Seq.fold (fun acc x -> acc + x) 0L
    Console.WriteLine input

    
    0
