module Day4_Tests

open Day4
open InputReader
open Xunit

[<Fact>]
let ``Update a bingo board`` () =
    let input = seq [
        seq [ (1, false); (2, false) ]
        seq [ (3, false); (4, true) ]
    ]
    let result = markNumber 2 input
    let expected = seq [
        seq [ (1, false); (2, true) ]
        seq [ (3, false); (4, true) ]
    ]
    Assert.Equal<seq<seq<int * bool>>>(expected, result)

[<Fact>]
let ``Horizontal bingo`` () =
    let input = seq [
        seq [ (1, false); (2, false) ]
        seq [ (3, true); (4, true) ]
    ]
    let result = isBingo input
    Assert.True(result)

[<Fact>]
let ``Vertical bingo`` () =
    let input = seq [
        seq [ (1, false); (2, true) ]
        seq [ (3, false); (4, true) ]
    ]
    let result = isBingo input
    Assert.True(result)

[<Fact>]
let ``Get unmarked numbers`` () =
    let input = seq [
        seq [ (1, true); (2, false) ]
        seq [ (3, false); (4, true) ]
    ]
    let result = unmarkedNumbers input
    let expected = seq [ 2; 3 ]
    Assert.Equal<seq<int>>(expected, result)

[<Fact>]
let ``Parses numbers`` () =
    let input = "1,2,3,4,5\n\n1  2\n3  4"
    let result = parseNumbers input
    let expected = seq [ 1; 2; 3; 4; 5 ]
    Assert.Equal<seq<int>>(expected, result)

[<Fact>]
let ``Parses bingo cards`` () =
    let input = "1,2\n\n1  2\n 3  4\n\n4  3\n2 1"
    let result = parseBingoCards input
    let expected = seq [
        seq [
            seq [ (1, false); (2, false) ]
            seq [ (3, false); (4, false) ]
        ]
        seq [
            seq [ (4, false); (3, false) ]
            seq [ (2, false); (1, false) ]
        ]
    ]
    Assert.Equal<seq<seq<int * bool>>>(expected, result)

[<Fact>]
let ``Solves part 1 with test input`` () =
    let input = readText "./04/test-input"
    let result = part1 input
    Assert.Equal(4512, result)

[<Fact>]
let ``Solves part 1`` () =
    let input = readText "./04/input"
    let result = part1 input
    Assert.Equal(0, result)