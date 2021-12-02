module Day2_Tests

open Xunit
open Day2
open InputReader

[<Fact>]
let ``Applies forward instruction`` () =
    let result = applyInstruction (0, 0) ("forward", 5)
    Assert.Equal((5, 0), result)

[<Fact>]
let ``Applies up instruction`` () =
    let result = applyInstruction (0, 0) ("up", 5)
    Assert.Equal((0, -5), result)

[<Fact>]
let ``Applies down instruction`` () =
    let result = applyInstruction (0, 0) ("down", 5)
    Assert.Equal((0, 5), result)

[<Fact>]
let ``Applies list of instructions`` () =
    let instructions = [
        ("down", 5)
        ("up", 1)
        ("forward", 3)
    ]
    let result = applyInstructions instructions
    Assert.Equal((3, 4), result)

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