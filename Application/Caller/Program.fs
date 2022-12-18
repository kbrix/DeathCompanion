module Program

open System
open System.Diagnostics
open Caller
open Functions

[<EntryPoint>]
let main args =
    printfn $"Arguments passed to function: \n%A{args}"
    printfn ""

    let sw = Stopwatch()
    sw.Start()

    let parsedCommandLineOptions =
        CommandLineParser.parseCommandLine (Array.toList args)

    sw.Stop()
    printfn $"Parsed command line options: \n%A{parsedCommandLineOptions}."
    printfn $"Parsed command line options in {sw.ElapsedMilliseconds} ms."
    printfn ""

    let day = parsedCommandLineOptions.Day.Value

    let month =
        parsedCommandLineOptions.Month.Value

    let year =
        parsedCommandLineOptions.Year.Value

    let birthDate = DateTime(year, month, day)

    sw.Restart()

    let intensity =
        DanishFinancialSupervisoryAuthorityDeathIntensityMan2021 birthDate

    let now = DateTime.Now

    let currentAge =
        Utility.computeExactCurrentAge birthDate

    let remainingLifeTime =
        ContinuousOneDimensionalRandomVariable()
            .WithHazardFunction(intensity, currentAge, (intensity.XMin, intensity.XMax))

    let expectedRemainingLifeTime =
        remainingLifeTime.ComputeExpectation()

    let expectedDeathDate =
        Utility.addYears now expectedRemainingLifeTime

    let dateStringFormat = "dd.MM.yyyy, H:mm:ss"
    let numberStringFormat = "0.000000000000"

    sw.Stop()
    printfn $"The current date is................... {now.ToString(dateStringFormat)}."
    printfn $"The current age is.................... {currentAge.ToString(numberStringFormat)} (years)."
    printfn $"The expected remaining life-time is... {expectedRemainingLifeTime.ToString(numberStringFormat)} (years)."
    printfn $"The expected time of death is......... {expectedDeathDate.ToString(dateStringFormat)}."
    printfn $"Computation completed in {sw.ElapsedMilliseconds} ms."

    // Return 0. This indicates success.
    0
