// See https://aka.ms/new-console-template for more information

using Common.Interfaces;
using Common.Models;

IDataAccess dataAccess = new FileDataAccess();

var dataLines = dataAccess.ReadFile(@"./assets/data.txt");

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