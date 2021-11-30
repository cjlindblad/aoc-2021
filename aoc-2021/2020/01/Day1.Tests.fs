module Day1_Tests

open Xunit
open InputReader
open Day1

[<Fact>]
let ``Solves part 1 with sample input`` () =
    let testInput = [ 1721; 979; 366; 299; 675; 1456 ]
    let result = part1 testInput
    Assert.Equal(514579, result)

[<Fact>]
let ``Solves part 1 with real input`` () =
    let input = readNumberLines "./2020/01/input"
    let result = part1 input
    Assert.Equal(955584, result)

[<Fact>]
let ``Solves part 2 with real input`` () =
    let input = readNumberLines "./2020/01/input"
    let result = part2 input
    Assert.Equal(287503934, result)