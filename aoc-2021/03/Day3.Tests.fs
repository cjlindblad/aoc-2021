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

[<Fact>]
let ``Oxygen generator rating`` () =
    let input = readLines "./03/test-input"
    let result = oxygenGeneratorRating input
    Assert.Equal(23, result)

[<Fact>]
let ``CO2 scrubber rating`` () =
    let input = readLines "./03/test-input"
    let result = co2ScrubberRating input
    Assert.Equal(10, result)

[<Fact>]
let ``Solves part 2 with test input`` () =
    let input = readLines "./03/test-input"
    let result = part2 input
    Assert.Equal(230, result)

[<Fact>]
let ``Solves part 2`` () =
    let input = readLines "./03/input"
    let result = part2 input
    Assert.Equal(2795310, result)
    