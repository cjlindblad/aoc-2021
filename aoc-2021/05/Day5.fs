module Day5

open System.Text.RegularExpressions

let parseLine input =
    let matches =
        Regex.Match(input, @"(\d+),(\d+) -> (\d+),(\d+)")

    let x1 = matches.Groups[1].Value |> int
    let y1 = matches.Groups[2].Value |> int
    let x2 = matches.Groups[3].Value |> int
    let y2 = matches.Groups[4].Value |> int

    ((x1, y1), (x2, y2))

let step n m = if n < m then 1 else - 1

let makeLines withDiagonals ((x1, y1), (x2, y2)) =
    match (x1, y1) with
    | x, _ when x = x2 -> seq { for i in Seq.min [ y1; y2 ] .. Seq.max [ y1; y2 ] -> (x, i) }
    | _, y when y = y2 -> seq { for i in Seq.min [ x1; x2 ] .. Seq.max [ x1; x2 ] -> (i, y) }
    | _ when withDiagonals = true ->
        Seq.zip [ x1 .. step x1 x2 .. x2 ] [ y1 .. step y1 y2 .. y2 ]
    | _ -> Seq.empty

let overlappingPoints lines =
    lines
    |> Seq.concat
    |> Seq.countBy id
    |> Seq.filter (fun x -> snd x >= 2)
    |> Seq.map fst

let solver lineMaker input =
    input
    |> Seq.map parseLine
    |> Seq.map lineMaker
    |> overlappingPoints
    |> Seq.length

let part1: (seq<string> -> int) = solver (makeLines false)

let part2: (seq<string> -> int) = solver (makeLines true)