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
    let numbers = testLine.Split " " |> Seq.map Set
    
    let one = numbers |> Seq.find (fun x -> x.Count = 2)
    let four = numbers |> Seq.find (fun x -> x.Count = 4)
    let seven = numbers |> Seq.find (fun x -> x.Count = 3)
    let eight = numbers |> Seq.find (fun x -> x.Count = 7)
    let nine = numbers |> Seq.find (fun x -> x.Count = 6 && (x - four - seven).Count = 1)
    let six = numbers |> Seq.find (fun x -> x.Count = 6 && (x - one).Count = 5)
    let three = numbers |> Seq.find (fun x -> x.Count = 5 && (x - one).Count = 3)
    let two = numbers |> Seq.find (fun x -> x.Count = 5 && (x - nine).Count = 1)
    let five = numbers |> Seq.find (fun x -> x.Count = 5 && (x - six).Count = 0)
    let zero = numbers |> Seq.find (fun x -> x.Count = 6 && (x - five).Count = 2)

    let output =
        (input.Split " | ")[1]
        |> (fun x -> x.Split " ")
        |> Seq.map Set

    let valueString =
        output
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
        
    int valueString

let part2 input =
    input
    |> Seq.map valueForLine
    |> Seq.sum
    