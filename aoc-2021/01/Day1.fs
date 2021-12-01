module Day1

let findIncreasingNumbers numbers =
    numbers
    |> Seq.pairwise
    |> Seq.filter (fun (a, b) -> b > a)
    |> Seq.map snd

let findIncreasingSlidingWindowSums (numbers: int list) =
    numbers
    |> Seq.windowed 3
    |> Seq.map Seq.sum
    |> findIncreasingNumbers

let part1 input =
    input
    |> findIncreasingNumbers
    |> Seq.length

let part2 input =
    input
    |> findIncreasingSlidingWindowSums
    |> Seq.length