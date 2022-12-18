namespace Caller

type Gender =
    | Male
    | Female

type CommandLineOptions =
    { Name: string option
      Day: int option
      Month: int option
      Year: int option
      Gender: Gender option }
