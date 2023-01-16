// See https://aka.ms/new-console-template for more information

using Ex_001.Models;

Console.WriteLine("Exercise 001");

var fileDataAccess = new FileDataAccess();
var elves = new Elves(fileDataAccess);
Console.WriteLine(elves.GetMaxTotalCalories());
Console.WriteLine(elves.GetSumCaloriesOfTopThreeElves());