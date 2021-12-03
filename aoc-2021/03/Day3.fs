module Day3

open System

let binaryString (input: string seq) =
    input
    |> Seq.transpose
    |> Seq.map (Seq.countBy id)
    |> Seq.map (Seq.sortByDescending snd)
    |> Seq.map Seq.head
    |> Seq.map fst
    |> Seq.map string
    |> String.concat ""

let flip (input: string) =
    input
    |> Seq.map (fun c -> if c = '0' then "1" else "0")
    |> String.concat ""

let part1 (input: string seq) =
    let binary = binaryString input
    let flippedBinary = flip binary
    Convert.ToInt32(binary, 2) * Convert.ToInt32(flippedBinary, 2)
