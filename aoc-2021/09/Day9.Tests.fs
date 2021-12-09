module Day9_Tests

open InputReader
open Xunit
open Day9

[<Fact>]
let ``Solves part 1 with test input`` () =
    let input = readLines "./09/test-input"
    let result = part1 input
    Assert.Equal(15, result)

[<Fact>]
let ``Solves part 1`` () =
    let input = readLines "./09/input"
    let result = part1 input
    Assert.Equal(496, result)