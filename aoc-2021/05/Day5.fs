module Day5

open System.Text.RegularExpressions

let wat =
    [ [ (1, 2); (1, 3); (1, 4); (1, 5) ]
      [ (1, 3); (1, 4) ] ]

let parseLine input =
    let matches =
        Regex.Match(input, @"(\d+),(\d+) -> (\d+),(\d+)")

    let x1 = matches.Groups[ 1 ].Value |> int
    let y1 = matches.Groups[ 2 ].Value |> int
    let x2 = matches.Groups[ 3 ].Value |> int
    let y2 = matches.Groups[ 4 ].Value |> int

    if x1 = x2 then
        seq { for i in Seq.min [ y1; y2 ] .. Seq.max [ y1; y2 ] -> (x1, i) }
    elif y1 = y2 then
        seq { for i in Seq.min [ x1; x2 ] .. Seq.max [ x1; x2 ] -> (i, y1) }
    else
        Seq.empty

let overlappingPoints lines =
    lines
    |> Seq.concat
    |> Seq.countBy id
    |> Seq.filter (fun x -> snd x >= 2)
    |> Seq.map fst

let part1 input =
    input
    |> Seq.map parseLine
    |> overlappingPoints
    |> Seq.length