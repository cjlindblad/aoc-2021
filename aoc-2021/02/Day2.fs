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

let applyInstructionPart2 ((horizontal, depth, aim): int * int * int) ((direction, distance): string * int) =
    match direction with
    | "forward" -> (horizontal + distance, depth + (aim * distance), aim)
    | "up" -> (horizontal, depth, aim - distance)
    | "down" -> (horizontal, depth, aim + distance)
    | _ -> (horizontal, depth, aim)

let part1 input =
    input
    |> Seq.map parseLine
    |> Seq.fold applyInstructionPart1 (0, 0)
    |> (fun (a, b) -> a * b)

let part2 input =
    input
    |> Seq.map parseLine
    |> Seq.fold applyInstructionPart2 (0, 0, 0)
    |> (fun (a, b, _) -> a * b)
