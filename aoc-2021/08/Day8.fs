module Day8

let part1 (input: string list) =
    input
    |> Seq.map (fun x -> (x.Split " | ")[1] |> (fun y -> y.Split " "))
    |> Seq.map
        (Seq.filter
             (fun y ->
                 match Seq.length y with
                 | 2
                 | 3
                 | 4
                 | 7 -> true
                 | _ -> false))
    |> Seq.concat
    |> Seq.length

let valueForLine (input: string) =
    let testLine = (input.Split " | ")[0]
    let parts = testLine.Split " " |> Seq.map Set
    let one = parts |> Seq.find (fun x -> Seq.length x = 2)
    let four = parts |> Seq.find (fun x -> Seq.length x = 4)
    let seven = parts |> Seq.find (fun x -> Seq.length x = 3)
    let eight = parts |> Seq.find (fun x -> Seq.length x = 7)
    let nine = (parts |> Seq.find (fun part -> part.Count = 6 && (part - four - seven).Count = 1))
    let six = (parts |> Seq.find (fun part -> part.Count = 6 && (part - one).Count = 5))
    let three = (parts |> Seq.find (fun part -> part.Count = 5 && (part - one).Count = 3))
    let two = (parts |> Seq.find (fun part -> part.Count = 5 && (part - nine).Count = 1))
    let five = (parts |> Seq.find (fun part -> part.Count = 5 && (part - six).Count = 0))
    let zero = (parts |> Seq.find (fun part -> part.Count = 6 && (part - five).Count = 2))

    let target =
        (input.Split " | ")[1]
        |> (fun x -> x.Split " ")
        |> Seq.map Set

    let value =
        target
        |> Seq.map (fun x ->
            match x with
            | _ when x = zero -> "0"
            | _ when x = one -> "1"
            | _ when x = two -> "2"
            | _ when x = three -> "3"
            | _ when x = four -> "4"
            | _ when x = five -> "5"
            | _ when x = six -> "6"
            | _ when x = seven -> "7"
            | _ when x = eight -> "8"
            | _ when x = nine -> "9"
            | _ -> "")
        |> Seq.map string
        |> String.concat ""
        
    int value

let part2 input =
    input
    |> Seq.map valueForLine
    |> Seq.sum
    