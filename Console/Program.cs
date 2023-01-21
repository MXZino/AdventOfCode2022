﻿// See https://aka.ms/new-console-template for more information

using Ex_004;
using Ex_004.Interfaces;
using Ex_005;
using Ex_005.Interfaces;

#region Ex001

// Console.WriteLine("Exercise 001");
//
// var fileDataAccess = new FileDataAccess();
// var elves = new Elves(fileDataAccess);
// Console.WriteLine(elves.GetMaxTotalCalories());
// Console.WriteLine(elves.GetSumCaloriesOfTopThreeElves());

#endregion

#region Ex002

// Console.WriteLine("Exercise 002");
//
//
// var scores = GetScores();
// var points = Battleground.CountPlayerPoints(scores);
//
// Console.WriteLine(points);
//
// // IEnumerable<Score> GetScores()
// // {
// //     var fileDataAccess = new FileDataAccess();
// //     var moves = fileDataAccess.ReadDataAsS();
// //     
// //     for (var i = 0; i < moves.Item1.Moves.Count; i++)
// //     {
// //         yield return Battleground.Battle(moves.Item1.Moves.ElementAt(i), moves.Item2.Moves.ElementAt(i));
// //     }
// // }
//
// IEnumerable<Score> GetScores()
// {
//     var fileDataAccess = new FileDataAccess();
//     var moves = fileDataAccess.ReadDataAsScores();
//     
//     for (var i = 0; i < moves.Item1.Moves.Count; i++)
//     {
//         yield return Battleground.Battle(moves.Item1.Moves.ElementAt(i), moves.Item2.Moves.ElementAt(i));
//     }
// }

#endregion

#region Ex003

// IFacade facade = new Facade();
//
// var rucksacks = dataLines.Select(x => facade.InitRucksack(x)).ToList();
//
// var repeatedItems = rucksacks.Select(x => facade.FindRepeatedItem(x));
//
// var values = repeatedItems.Select(x => facade.GetValue(x));
//
// var total = values.Sum();
//
// var groups = facade.CreateGroups(rucksacks);
//
// var groupsRepeatedItems = groups.Select(x => facade.FindRepeatedItem(x));
//
// var groupsValues = groupsRepeatedItems.Select(x => facade.GetValue(x));
//
// var groupsRepeatedItemsTotal = groupsValues.Sum();
//
// Console.WriteLine(total);
// Console.WriteLine(groupsRepeatedItemsTotal);

#endregion

#region Ex004

IEx004Facade ex004Facade = new Ex004Facade(@"./assets/exercise_004_data.txt");

Console.WriteLine($"Fully contained sectors: {ex004Facade.CountFullyContainedSectors()}");
Console.WriteLine($"Overlapping assignments: {ex004Facade.CountOverlappingAssignments()}");

#endregion

#region Ex005

IEx005Facade ex005Facade = new Ex005Facade(@"./assets/exercise_005_data.txt");
Console.WriteLine($"Top values of ship: {ex005Facade.GetValuesFromTopOfShip()}");

ex005Facade = new Ex005Facade(@"./assets/exercise_005_data.txt");
Console.WriteLine($"Top values of ship: {ex005Facade.GetValuesFromTopOfShipWithAdvancedMove()}");

#endregion