module Caller.Utility

open System

/// Computes the exact age in years (while taking leaps years into account).
let computeExactCurrentAge (birthDate: DateTime) : double =
    let today = DateTime.Today
    // previous birth day
    let mutable years =
        today.Year - birthDate.Year

    let mutable previousBirthDay =
        birthDate.AddYears(years)

    if (previousBirthDay > today) then
        years <- years - 1
        previousBirthDay <- previousBirthDay.AddYears(-1)
    // next birthday
    let nextBirthDay =
        previousBirthDay.AddYears(1)
    // number of days between birth dates
    let daysBetweenBirthDates =
        (double) (nextBirthDay - previousBirthDay).Days
    // number of days since last birth date
    let elapsedDays =
        double ((today - previousBirthDay).Days)
    // exact age
    let age =
        (double) years
        + (elapsedDays / daysBetweenBirthDates)

    age

/// Adds a given number of years (represented by a floating point number) to a given date (while taking the number of
/// days in a month into account).
let addYears (date: DateTime) (years: double) : DateTime =
    let mutable resultDate = date
    // years
    let yearsFloored = Math.Floor years
    let yearsRemainder = years - yearsFloored
    resultDate <- resultDate.AddYears((int) yearsFloored)
    // months
    let months = yearsRemainder * 12.0
    let monthsFloored = Math.Floor months
    let monthsRemainder = months - monthsFloored
    resultDate <- resultDate.AddMonths((int) monthsFloored)
    // days
    let daysInMonth =
        DateTime.DaysInMonth(resultDate.Year, resultDate.Month)

    let days =
        monthsRemainder * (double) daysInMonth

    let daysFloored = Math.Floor days
    resultDate <- resultDate.AddDays((int) daysFloored)

    resultDate
