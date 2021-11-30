module aoc_2020.Day3_Test

open Xunit
open InputReader
open aoc_2020.Day3

[<Fact>]
let ``Gets rows and columns for some input`` () =
    let input = [ "xxx"; "xxx"; "xxx"; "xxx" ]
    let result = parseRowsAndColumns input
    Assert.Equal((4, 3), result)

[<Fact>]
let ``Calculates slope`` () =
    let result = slopeFor (3, 1) (4, 2) 
    let expected = [ (0, 0); (1, 1); (2, 0); (3, 1) ]
    Assert.Equal<(int * int) list>(expected, result)

[<Fact>]
let ``Calculates more complex slope`` () =
    let result = slopeFor (1, 2) (7, 2)
    let expected = [ (0, 0); (2, 1); (4, 0); (6, 1) ]
    Assert.Equal<(int * int) list>(expected, result)

[<Fact>]
let ``Find the number of trees for a slope`` () =
    let map = [
        "#..."
        ".#.."
        "...."
        "...#"
    ]
    let slope = [ (0, 0); (1, 1); (2, 2); (3, 3) ]
    let trees = findTrees map slope
    Assert.Equal(3, trees)
    
[<Fact>]
let ``Solves part 1`` () =
    let result =
        readLines "./2020/03/input"
        |> part1
    Assert.Equal(153, result)
    
[<Fact>]
let ``Solves part 2`` () =
    let result =
        readLines "./2020/03/input"
        |> part2
    Assert.Equal<int64>(2421944712L, result)
