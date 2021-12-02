module Day2

let parseCommand (commandString: string) =
    commandString.Split()
    |> (fun commandParts -> (commandParts[0], int commandParts[1]))

let applyCommandPart1 (horizontal, depth) (direction, value) =
    match direction with
    | "forward" -> (horizontal + value, depth)
    | "up" -> (horizontal, depth - value)
    | "down" -> (horizontal, depth + value)
    | _ -> (horizontal, depth)

let applyCommandPart2 (horizontal, depth, aim) (direction, value) =
    match direction with
    | "forward" -> (horizontal + value, depth + (aim * value), aim)
    | "up" -> (horizontal, depth, aim - value)
    | "down" -> (horizontal, depth, aim + value)
    | _ -> (horizontal, depth, aim)

let part1 input =
    input
    |> Seq.map parseCommand
    |> Seq.fold applyCommandPart1 (0, 0)
    |> (fun (horizontal, depth) -> horizontal * depth)

let part2 input =
    input
    |> Seq.map parseCommand
    |> Seq.fold applyCommandPart2 (0, 0, 0)
    |> (fun (horizontal, depth, _) -> horizontal * depth)
