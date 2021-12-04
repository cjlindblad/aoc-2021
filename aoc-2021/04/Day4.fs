module Day4

open System.Text.RegularExpressions

type BingoCard = seq<seq<int * bool>>

let updateRow nextNumber row =
    row
    |> Seq.map
        (fun (number, marked) ->
            (number,
             if nextNumber = number then
                 true
             else
                 marked))

let markNumber nextNumber (bingoCard: BingoCard) : BingoCard =
    bingoCard |> Seq.map (updateRow nextNumber)

let isBingo (bingoCard: BingoCard) =
    let hasBingoRow bingoCard =
        bingoCard
        |> Seq.map (fun row -> row |> Seq.forall snd)
        |> Seq.exists id

    hasBingoRow bingoCard
    || Seq.transpose bingoCard |> hasBingoRow

let unmarkedNumbers (bingoCard: BingoCard) =
    bingoCard
    |> Seq.collect id
    |> Seq.filter (fun (_, marked) -> not marked)
    |> Seq.map fst

let parseNumbers (input: string) =
    input.Split "\n\n"
    |> Seq.head
    |> (fun nums -> nums.Split ",")
    |> Seq.map int

let parseBingoCard (input: string) : BingoCard =
    input.Split "\n"
    |> Seq.map
        (fun line ->
            Regex.Split(line, "\s+")
            |> Seq.filter (fun c -> c.Length > 0)
            |> Seq.map (fun c -> (int c, false)))

let parseBingoCards (input: string) =
    input.Split "\n\n"
    |> Seq.tail
    |> Seq.map parseBingoCard

let part1 input : int =
    let numbers = parseNumbers input
    let bingoCards = parseBingoCards input

    let winningBingoCardWithDrawnNumber =
        numbers
        |> Seq.fold
            (fun (bingoCards, currentNumber, foundWinner) cur ->
                match foundWinner with
                | true -> (bingoCards, currentNumber, foundWinner)
                | false ->
                    let nextBingoCards = bingoCards |> Seq.map (markNumber cur)
                    let foundWinner = nextBingoCards |> Seq.exists isBingo
                    (nextBingoCards, cur, foundWinner))
            (bingoCards, numbers |> Seq.head, false)

    let bingoCards, winningNumber, _ = winningBingoCardWithDrawnNumber

    let winningBingoCard =
        bingoCards |> Seq.filter isBingo |> Seq.head

    winningNumber
    * (unmarkedNumbers winningBingoCard |> Seq.sum)

let part2 input =
    let numbers = parseNumbers input
    let bingoCards = parseBingoCards input

    let winningBingoCardWithDrawnNumber =
        numbers
        |> Seq.fold
            (fun (remainingBingoCards, currentNumber, foundLastWinner) cur ->
                match foundLastWinner with
                | true -> (remainingBingoCards, currentNumber, foundLastWinner)
                | false ->
                    let markedBingoCards =
                        remainingBingoCards |> Seq.map (markNumber cur)

                    let foundLastWinner = markedBingoCards |> Seq.forall isBingo

                    let nextBingoCards =
                        match foundLastWinner with
                        | false ->
                            markedBingoCards
                            |> Seq.filter (fun card -> not (isBingo card))
                        | true -> markedBingoCards

                    (nextBingoCards, cur, foundLastWinner))
            (bingoCards, numbers |> Seq.head, false)

    let bingoCards, winningNumber, _ = winningBingoCardWithDrawnNumber

    let winningBingoCard =
        bingoCards |> Seq.filter isBingo |> Seq.head

    winningNumber
    * (unmarkedNumbers winningBingoCard |> Seq.sum)
