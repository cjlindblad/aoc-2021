module Day6

open System.Collections.Generic

let parseInput (input: string) = input.Split(",") |> Array.map int

let memoize f =
    let cache = Dictionary<_, _>()

    fun c ->
        let exist, value = cache.TryGetValue(c)

        match exist with
        | true -> value
        | _ ->
            let value = f c
            cache.Add(c, value)
            value

let rec solve (day, timer, goal) =
    if goal - day < timer then
        1L
    else
        let nextDay = day + timer + 1

        (solve (nextDay, 6, goal))
        + (solve (nextDay, 8, goal))

let solver input days =
    let initialState = parseInput input
    let memoedSolve = memoize solve

    initialState
    |> Seq.map (fun x -> memoedSolve (0, x, (days - 1)))
    |> Seq.sum
