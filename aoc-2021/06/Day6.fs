module Day6

let parseInput (input: string) =
    input.Split(",")
    |> Seq.map int
    |> Seq.toList

let shift list =
    let length = Seq.length list
    list |> List.permute (fun index -> (index + length - 1) % length)

let rank list =
    list
    |> List.countBy id
    |> Map.ofSeq

let solver input days =
    let parsedInput = parseInput input
    let rankedInput = rank parsedInput
    let initialState =
        List.replicate 9 0L
        |> List.mapi (fun index value ->
                     match rankedInput.ContainsKey index with
                     | true -> int64 rankedInput[index]
                     | _ -> value)
        
    [1..days]
    |> List.fold (fun acc _ ->
        let shiftedState = shift acc
        (shiftedState |> List.take 6)
            @ [ shiftedState[8] + shiftedState[6] ]
            @ (shiftedState |> List.skip 7)
        ) initialState
    |> List.sum
