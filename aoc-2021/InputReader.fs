module InputReader

let readLines filePath =
    System.IO.File.ReadLines(filePath) |> List.ofSeq

let readText filePath =
    System.IO.File.ReadAllText(filePath)

let readNumberLines filePath =
    readLines filePath |> List.map int