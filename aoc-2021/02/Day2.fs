module Day2

let parseLine (line: string) =
    line.Split()
    |> (fun line -> (line[0], int line[1]))

let applyInstruction ((horizontal, depth): (int * int)) ((direction, distance): (string * int)) =
    match direction with
    | "forward" -> (horizontal + distance, depth)
    | "up" -> (horizontal, depth - distance)
    | "down" -> (horizontal, depth + distance)
    | _ -> (horizontal, depth)

let applyInstructions (instructions: (string * int) seq) =
    Seq.fold applyInstruction (0, 0) instructions

let part1 input =
    input
    |> Seq.map parseLine
    |> applyInstructions
    |> (fun (a, b) -> a * b)