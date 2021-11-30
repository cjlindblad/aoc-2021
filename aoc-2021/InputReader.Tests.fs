module InputReader_Tests

open Xunit
open InputReader

[<Fact>]
let ``Can read input lines from file`` () =
    let result = readLines "./sample-text-input"
    let expected = ["one line"; "two line"; "three line"]
    Assert.Equal<string list>(expected, result)

[<Fact>]
let ``Can read lines of numbers from file`` () =
    let result = readNumberLines "./sample-number-input"
    let expected = [1;3;3;7]
    Assert.Equal<int list>(expected, result)