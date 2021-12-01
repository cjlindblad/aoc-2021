module Day1

let findIncreasingNumbers numbers =
    numbers
    |> Seq.pairwise
    |> Seq.filter (fun (a, b) -> b > a)
    |> Seq.map snd
    |> Seq.toList

let part1 input =
    input
    |> findIncreasingNumbers
    |> Seq.length