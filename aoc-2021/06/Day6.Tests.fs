module Day6_Tests

open Xunit
open InputReader
open Day6

[<Fact>]
let ``Solves part 1 with test input`` () =
    let input = readLines "./06/test-input" |> Seq.head
    let result = solver input 80
    Assert.Equal(5934L, result)

[<Fact>]
let ``Solves part 1`` () =
    let input = readLines "./06/input" |> Seq.head
    let result = solver input 80
    Assert.Equal(352195L, result)

[<Fact>]
let ``Solves part 2`` () =
    let input = readLines "./06/input" |> Seq.head
    let result = solver input 256
    Assert.Equal(1600306001288L, result)
