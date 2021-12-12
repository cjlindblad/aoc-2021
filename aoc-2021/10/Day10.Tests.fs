module Day10_Tests

open Xunit
open InputReader
open Day10

[<Fact>]
let ``Solves part 1 with test input`` () =
    let input = readLines "./10/test-input"
    let result = part1 input
    Assert.Equal(26397, result)

[<Fact>]
let ``Solves part 1`` () =
    let input = readLines "./10/input"
    let result = part1 input
    Assert.Equal(345441, result)