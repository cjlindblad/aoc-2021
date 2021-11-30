module aoc_2020.Day1

let part1 entries =
    [ for x in entries do
          for y in entries do
              if x + y = 2020 then yield x * y ]
    |> Seq.head

let part2 entries =
    [ for x in entries do
          for y in entries do
              for z in entries do
                  if x + y + z = 2020 then yield x * y * z ]
    |> Seq.head
