module Day5

open System.Text.RegularExpressions

let parseLine input =
    let matches =
        Regex.Match(input, @"(\d+),(\d+) -> (\d+),(\d+)")

    let x1 = matches.Groups[ 1 ].Value |> int
    let y1 = matches.Groups[ 2 ].Value |> int
    let x2 = matches.Groups[ 3 ].Value |> int
    let y2 = matches.Groups[ 4 ].Value |> int

    ((x1, y1), (x2, y2))

let makeLinesPart1 ((x1, y1), (x2, y2)) =
    if x1 = x2 then
        seq { for i in Seq.min [ y1; y2 ] .. Seq.max [ y1; y2 ] -> (x1, i) }
    elif y1 = y2 then
        seq { for i in Seq.min [ x1; x2 ] .. Seq.max [ x1; x2 ] -> (i, y1) }
    else
        Seq.empty

let makeLinesPart2 ((x1, y1), (x2, y2)) =
    if x1 = x2 then
        seq { for i in Seq.min [ y1; y2 ] .. Seq.max [ y1; y2 ] -> (x1, i) }
    elif y1 = y2 then
        seq { for i in Seq.min [ x1; x2 ] .. Seq.max [ x1; x2 ] -> (i, y1) }
    else
        Seq.zip [x1 .. (if x1 < x2 then 1 else -1) .. x2] [y1 .. (if y1 < y2 then 1 else -1) .. y2]

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

let part1: (seq<string> -> int) = solver makeLinesPart1

let part2: (seq<string> -> int) = solver makeLinesPart2