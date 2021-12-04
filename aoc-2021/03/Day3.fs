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
    |> Seq.map
        (fun c ->
            match c with
            | '0' -> "1"
            | _ -> "0")
    |> String.concat ""

let part1 (input: string seq) =
    let binary = binaryString input
    let flippedBinary = flip binary

    Convert.ToInt32(binary, 2)
    * Convert.ToInt32(flippedBinary, 2)

let oxygenGeneratorRating (input: string list) =
    let binaryString =
        input
        |> Seq.transpose
        |> Seq.fold (fun (remainingLines: seq<string>, index: int) _ ->
            match Seq.length remainingLines with
            | 1 -> (remainingLines, index + 1)
            | _ ->
                let currentColumn =
                    remainingLines
                    |> Seq.transpose
                    |> Seq.skip index
                    |> Seq.head
                let zeroes =
                    currentColumn
                    |> Seq.filter (fun c -> c = '0')
                    |> Seq.length
                let ones =
                    currentColumn
                    |> Seq.filter (fun c -> c = '1')
                    |> Seq.length
                let charToMatch = if ones >= zeroes then '1' else '0'
                let nextLines =
                    remainingLines
                    |> Seq.filter (fun line ->
                        line[index] = charToMatch)
                (nextLines, index + 1)) (input, 0)
        |> fst
        |> Seq.head
    
    Convert.ToInt32(binaryString, 2)

let co2ScrubberRating (input: string list) =
    let binaryString =
        input
        |> Seq.transpose
        |> Seq.fold (fun (remainingLines: seq<string>, index: int) _ ->
            match Seq.length remainingLines with
            | 1 -> (remainingLines, index + 1)
            | _ ->
                let currentColumn =
                    remainingLines
                    |> Seq.transpose
                    |> Seq.skip index
                    |> Seq.head
                let zeroes =
                    currentColumn
                    |> Seq.filter (fun c -> c = '0')
                    |> Seq.length
                let ones =
                    currentColumn
                    |> Seq.filter (fun c -> c = '1')
                    |> Seq.length
                let charToMatch = if zeroes <= ones then '0' else '1'
                let nextLines =
                    remainingLines
                    |> Seq.filter (fun line ->
                        line[index] = charToMatch)
                (nextLines, index + 1)) (input, 0)
        |> fst
        |> Seq.head
    
    Convert.ToInt32(binaryString, 2)

let part2 input =
    let oxygenRating = oxygenGeneratorRating input
    let co2rating = co2ScrubberRating input
    oxygenRating * co2rating