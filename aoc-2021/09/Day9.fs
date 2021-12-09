module Day9

let part1 (input: string list) =
    let lineLength = input |> Seq.head |> Seq.length
    let inputNumbers =
        input
        |> Seq.concat
        |> Seq.map string
        |> Seq.map int
        |> Seq.toArray
    
    let inputLength = inputNumbers |> Seq.length
        
    let lowPoints =
        inputNumbers
        |> Array.indexed
        |> Array.filter (fun (index, n) ->
            let leftNeighbourIndex = index - 1
            let rightNeighbourIndex = index + 1
            let topNeighbourIndex = index - lineLength
            let bottomNeighbourIndex = index + lineLength
            
            let neighbourIndexes =
                match index % lineLength with
                | 0 -> [| topNeighbourIndex; rightNeighbourIndex; bottomNeighbourIndex |]
                | _ when index % lineLength = lineLength - 1 -> [| topNeighbourIndex; leftNeighbourIndex; bottomNeighbourIndex |]
                | _ -> [| leftNeighbourIndex; rightNeighbourIndex; topNeighbourIndex; bottomNeighbourIndex |]
                |> Array.filter (fun i -> i >= 0 && i < inputLength)
            let neighbours =
                neighbourIndexes
                |> Array.map (fun i -> inputNumbers |> Seq.item i)
            let isLowPoint = neighbours |> Array.forall (fun neighbour -> neighbour > n)
            isLowPoint)
            
        |> Array.map snd
    (lowPoints |> Array.map (fun x -> x + 1) |> Array.sum)
