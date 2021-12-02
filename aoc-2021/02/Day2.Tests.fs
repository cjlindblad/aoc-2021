module Day2_Tests

open Xunit
open Day2
open InputReader

[<Fact>]
let ``Applies forward instruction part 1`` () =
    let result = applyInstructionPart1 (0, 0) ("forward", 5)
    Assert.Equal((5, 0), result)

[<Fact>]
let ``Applies up instruction part 1`` () =
    let result = applyInstructionPart1 (0, 0) ("up", 5)
    Assert.Equal((0, -5), result)

[<Fact>]
let ``Applies down instruction part 1`` () =
    let result = applyInstructionPart1 (0, 0) ("down", 5)
    Assert.Equal((0, 5), result)

[<Fact>]
let ``Solves part 1 with test input`` () =
    let input = readLines "./02/test-input"
    let result = part1 input
    Assert.Equal(150, result)

[<Fact>]
let ``Solves part 1`` () =
    let input = readLines "./02/input"
    let result = part1 input
    Assert.Equal(1694130, result)

[<Fact>]
let ``Solves part 2 with test input`` () =
    let input = readLines "./02/test-input"
    let result = part2 input
    Assert.Equal(900, result)

[<Fact>]
let ``Solved part 2`` () =
    let input = readLines "./02/input"
    let result = part2 input
    Assert.Equal(1698850445, result) 