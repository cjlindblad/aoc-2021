module Day10

let dropLast list = List.take ((List.length list) - 1) list

let parse (input: string) =
    input
    |> Seq.fold
        (fun stack cur ->
            if List.length stack <> 0 && List.last stack = 'X' then
                stack
            else
                match cur with
                | '{'
                | '['
                | '<'
                | '(' -> stack @ [ cur ]
                | '}' ->
                    if Seq.last stack = '{' then
                        dropLast stack
                    else
                        [ '}'; 'X' ]
                | ']' ->
                    if Seq.last stack = '[' then
                        dropLast stack
                    else
                        [ ']'; 'X' ]
                | '>' ->
                    if Seq.last stack = '<' then
                        dropLast stack
                    else
                        [ '>'; 'X' ]
                | ')' ->
                    if Seq.last stack = '(' then
                        dropLast stack
                    else
                        [ ')'; 'X' ]
                | _ -> stack)
        List.empty

let part1 input =
    input
    |> Seq.map parse
    |> Seq.filter (fun xs -> Seq.length xs > 0)
    |> Seq.map Seq.head
    |> Seq.map
        (fun x ->
            match x with
            | ')' -> 3
            | ']' -> 57
            | '}' -> 1197
            | '>' -> 25137
            | _ -> 0)
    |> Seq.sum
