module InputReader

let readLines filePath =
    System.IO.File.ReadLines(filePath) |> List.ofSeq

let readNumberLines filePath =
    readLines filePath |> List.map int