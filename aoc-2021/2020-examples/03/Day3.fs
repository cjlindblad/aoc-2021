module aoc_2020.Day3

let parseRowsAndColumns input =
    (List.length input, Seq.length input.Head)

let slopeFor (right, down) (rows, cols)  =
    let rowCoords = 0 :: [ for n in down .. down .. rows - 1 -> n ]
    let slope =
        rowCoords
        |> List.mapi (fun index row -> (row, index * right % cols))
    slope

let findTrees (map: string list) slope =
    slope
    |> Seq.map (fun coords -> map[fst coords][snd coords])
    |> Seq.filter (fun wat -> wat = '#')
    |> Seq.length

let part1 input =
    input
    |> parseRowsAndColumns
    |> slopeFor (3, 1)
    |> findTrees input

let part2 input =
    let rowsAndCols = input |> parseRowsAndColumns
    let result =
        [(1, 1); (3, 1); (5, 1); (7, 1); (1, 2)]
        |> Seq.map (fun course -> slopeFor course rowsAndCols)
        |> Seq.map (findTrees input)
        |> Seq.map int64
        |> Seq.reduce (fun acc cur -> acc * cur)
    result