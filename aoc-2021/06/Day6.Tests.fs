module Day6_Tests

open Xunit
open InputReader
open Day6

[<Theory>]
[<InlineData("3,4,3,1,2", "2,3,2,0,1")>]
[<InlineData("2,3,2,0,1", "1,2,1,6,0,8")>]
[<InlineData("0,1,0,5,6,7,8", "6,0,6,4,5,6,7,8,8")>]
[<InlineData("0,1,0,5,6,0,1,2,2,3,0,1,2,2,2,3,3,4,4,5,7,8", "6,0,6,4,5,6,0,1,1,2,6,0,1,1,1,2,2,3,3,4,6,7,8,8,8,8")>]
let ``Gets next day for input`` (input, expected) =
    let result = nextDay (parseInput input)
    let expected = parseInput expected
    Assert.Equal<seq<int>>(expected, result)

[<Fact>]
let ``Solves part 1 with test input`` () =
    let input = readLines "./06/test-input" |> Seq.head
    let result = part1 input
    Assert.Equal(5934, result)

[<Fact>]
let ``Solves part 1 with input`` () =
    let input = readLines "./06/input" |> Seq.head
    let result = part1 input
    Assert.Equal(352195, result)
