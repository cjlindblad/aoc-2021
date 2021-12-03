module Day3_Tests

open Xunit
open InputReader
open Day3


[<Fact>]
let ``Solves part 1 with test input`` () =
    let input = readLines "./03/test-input"
    let result = part1 input
    Assert.Equal(198, result)

[<Fact>]
let ``Solves part 1`` () =
    let input = readLines "./03/input"
    let result = part1 input
    Assert.Equal(3148794, result)