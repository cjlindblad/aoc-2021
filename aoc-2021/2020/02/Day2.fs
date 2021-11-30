module Day2

open System.Text.RegularExpressions

type InputLine = {
    firstNumber: int
    secondNumber: int
    letter: char
    password: string
}

let parseLine line =
    let matches = Regex.Match(line, @"(\d+)-(\d+) (\w): (\w+)")
    {
        firstNumber = matches.Groups[1].Value |> int
        secondNumber = matches.Groups[2].Value |> int
        letter = matches.Groups[3].Value |> char
        password = matches.Groups[4].Value
    }

let isValidPart1 inputLine =
    let letterOccurences =
        inputLine.password
        |> Seq.filter (fun e -> e = inputLine.letter)
        |> Seq.length
    letterOccurences >= inputLine.firstNumber && letterOccurences <= inputLine.secondNumber

let isValidPart2 inputLine =
    let matchesFirstPosition =
        inputLine.password[inputLine.firstNumber - 1] = inputLine.letter
    let matchesSecondPosition =
        inputLine.password[inputLine.secondNumber - 1] = inputLine.letter
    matchesFirstPosition <> matchesSecondPosition

let solver isValid input =
    input
    |> List.map parseLine
    |> List.filter isValid
    |> List.length

let part1 = solver isValidPart1

let part2 = solver isValidPart2