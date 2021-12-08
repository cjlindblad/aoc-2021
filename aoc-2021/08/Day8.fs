module Day8

let part1 (input: string list) =
    input
    |> Seq.map (fun x -> (x.Split " | ")[1] |> (fun y -> y.Split " "))
    |> Seq.map
        (fun x ->
            Seq.filter
                (fun y ->
                    match Seq.length y with
                    | 2
                    | 3
                    | 4
                    | 7 -> true
                    | _ -> false) x)
    |> Seq.concat
    |> Seq.length
