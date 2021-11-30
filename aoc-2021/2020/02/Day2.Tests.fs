module Day2_Tests

open Xunit
open Day2
open InputReader

[<Fact>]
let ``Can parse a line of input`` () =
    let exampleLine = "1-3 a: abcde"

    let expected =
        { firstNumber = 1
          secondNumber = 3
          letter = 'a'
          password = "abcde" }

    let result = parseLine exampleLine
    Assert.Equal(expected, result)

[<Fact>]
let ``Can determine if an input line contains a valid password according to part 1`` () =
    let inputLine =
        { firstNumber = 1
          secondNumber = 3
          letter = 'a'
          password = "abcde" }

    let result = isValidPart1 inputLine
    Assert.True(result)

[<Fact>]
let ``Solves part 1`` () =
    let result =
        readLines "./2020/02/input"
        |> part1

    Assert.Equal(396, result)

[<Fact>]
let ``Is valid part 2`` () =
    let inputLine =
        { firstNumber = 1
          secondNumber = 3
          letter = 'a'
          password = "abcde" }

    let result = isValidPart2 inputLine
    Assert.True(result)

[<Fact>]
let ``Solves part 2`` () =
    let result =
        readLines "./2020/02/input"
        |> part2

    Assert.Equal(428, result)
