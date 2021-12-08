module Day8_Tests

open Xunit
open InputReader
open Day8

[<Fact>]
let ``Solves part 1 with test input`` () =
    let input = readLines "./08/test-input"
    let result = part1 input
    Assert.Equal(26, result)

[<Fact>]
let ``Solves part 1`` () =
    let input = readLines "./08/input"
    let result = part1 input
    Assert.Equal(397, result)

[<Fact>]
let ``Solves part 2 with test input`` () =
    let input = readLines "./08/test-input"
    let result = part2 input
    Assert.Equal(61229, result)


[<Fact>]
let ``Solves part 2 with input`` () =
    let input = readLines "./08/input"
    let result = part2 input
    Assert.Equal(1027422, result)