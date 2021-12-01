module Day1_Tests

open Xunit
open Day1
open InputReader

[<Fact>]
let ``Finds numbers in a list that is larger than the previous number`` () =
    let input = [ 199; 200; 208; 210; 200; 207; 240; 269; 260; 263 ]
    let result = findIncreasingNumbers input
    let expected = [ 200; 208; 210; 207; 240; 269; 263 ]
    Assert.Equal(expected, result)

[<Fact>]
let ``Solves part 1`` () =
    let input = readNumberLines "./01/input"
    let result = part1 input
    Assert.Equal(1715, result)