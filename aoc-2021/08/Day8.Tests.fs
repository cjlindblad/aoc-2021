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
    Assert.Equal(0, result)