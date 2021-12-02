module Day2

let parseLine (line: string) =
    line.Split()
    |> (fun line -> (line[0], int line[1]))

let applyInstructionPart1 ((horizontal, depth): int * int) ((direction, distance): string * int) =
    match direction with
    | "forward" -> (horizontal + distance, depth)
    | "up" -> (horizontal, depth - distance)
    | "down" -> (horizontal, depth + distance)
    | _ -> (horizontal, depth)

let part1 input =
    input
    |> Seq.map parseLine
    |> Seq.fold applyInstructionPart1 (0, 0)
    |> (fun (a, b) -> a * b)