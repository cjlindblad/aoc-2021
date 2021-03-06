module Day5_Tests

open Xunit
open Day5
open InputReader

[<Fact>]
let ``Solves part 1 with test input`` () =
    let input = readLines "./05/test-input"
    let result = part1 input
    Assert.Equal(5, result)

[<Fact>]
let ``Solves part 1`` () =
    let input = readLines "./05/input"
    let result = part1 input
    Assert.Equal(5442, result)

[<Fact>]
let ``Solves part 2 with test input`` () =
    let input = readLines "./05/test-input"
    let result = part2 input
    Assert.Equal(12, result)

[<Fact>]
let ``Solves part 2`` () =
    let input = readLines "./05/input"
    let result = part2 input
    Assert.Equal(19571, result)
