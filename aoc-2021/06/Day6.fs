module Day6

let parseInput (input: string) =
    input.Split(",") |> Array.map int

let nextDay fish =
    let newFish =
        fish
        |> Array.filter (fun x -> x = 0)
        |> Array.map (fun _ -> 8)
    let nextFish =
        fish
        |> Array.map (fun x -> if x = 0 then 6 else x - 1)
    
    Array.append nextFish newFish

let part1 input =
    let initialState = parseInput input
    [|1 .. 80|]
    |> Array.fold (fun acc _ ->
        nextDay acc) initialState
    |> Array.length