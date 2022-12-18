module Caller.CommandLineParser

open System


let rec private parseCommandLineRec (args: string list) (options: CommandLineOptions) : CommandLineOptions =
    match args with
    // Empty list means all arguments have been parsed
    | [] -> options
    // Match the name option
    | "--name" :: name :: x
    | "-n" :: name :: x ->
        let newOptions =
            { options with Name = Some name }

        parseCommandLineRec x newOptions
    // Match the day option
    | "--day" :: day :: x
    | "-d" :: day :: x ->
        let newOptions =
            { options with Day = Some(Convert.ToInt32 day) }

        parseCommandLineRec x newOptions
    // Match the month option
    | "--month" :: month :: x
    | "-m" :: month :: x ->
        let newOptions =
            { options with Month = Some(Convert.ToInt32 month) }

        parseCommandLineRec x newOptions
    // Match the year option
    | "--year" :: year :: x
    | "-y" :: year :: x ->
        let newOptions =
            { options with Year = Some(Convert.ToInt32 year) }

        parseCommandLineRec x newOptions
    // Match the gender option
    | "--gender" :: gender :: x
    | "-g" :: gender :: x ->
        match gender with
        | "male" ->
            let newOptions =
                { options with Gender = Some Male }

            parseCommandLineRec x newOptions
        | "female" ->
            let newOptions =
                { options with Gender = Some Female }

            parseCommandLineRec x newOptions
        | _ -> failwith $"Gender option requires a second argument ('male' og 'female')!"
    // Unrecognized argument and keep parsing
    | head :: tail ->
        printfn $"Argument '{head}' is unrecognized!"
        parseCommandLineRec tail options

let parseCommandLine args =
    let defaultCommandLineOptions: CommandLineOptions =
        { Name = None
          Day = None
          Month = None
          Year = None
          Gender = None }

    let argsLength = List.length args

    if argsLength <> 10 then
        failwith $"Expected 5 arguments with 5 values, but received {argsLength} in total instead."

    let commandLineOptions =
        parseCommandLineRec args defaultCommandLineOptions

    if commandLineOptions.Name.IsNone then
        failwith $"Missing argument for {nameof (commandLineOptions.Name)}."

    if commandLineOptions.Day.IsNone then
        failwith $"Missing argument for {nameof (commandLineOptions.Day)}."

    if commandLineOptions.Month.IsNone then
        failwith $"Missing argument for {nameof (commandLineOptions.Month)}."

    if commandLineOptions.Year.IsNone then
        failwith $"Missing argument for {nameof (commandLineOptions.Year)}."

    if commandLineOptions.Gender.IsNone then
        failwith $"Missing argument for {nameof (commandLineOptions.Gender)}."

    commandLineOptions
