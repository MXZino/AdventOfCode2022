// See https://aka.ms/new-console-template for more information

using Ex_004;
using Ex_004.Interfaces;
using Ex_005;
using Ex_005.Interfaces;
using Ex_006;
using Ex_006.Interfaces;
using Ex_007;
using Ex_007.Interfaces;
using Ex_008;
using Ex_008.Interfaces;
using Ex_009;
using Ex_009.Interfaces;
using Ex_010;
using Ex_010.Interfaces;
using Ex_011;
using Ex_011.Helpers;
using Ex_011.Interfaces;
using Ex_012;
using Ex_012.Interfaces;

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

#region Ex006

Console.WriteLine();
Console.WriteLine("Exercise 6");
Console.WriteLine();

IEx006Facade ex006Facade = new Ex006Facade(@"./assets/006_data.txt");
Console.WriteLine($"Begin packet position: {ex006Facade.GetBeginPacketPosition()}");
Console.WriteLine($"Begin message position: {ex006Facade.GetStartOfMessagePosition()}");

#endregion

#region Ex007

Console.WriteLine();
Console.WriteLine("Exercise 7");
Console.WriteLine();

IEx007Facade ex007Facade = new Ex007Facade(@"./assets/007_data.txt");
Console.WriteLine($"Sum of the total sizes directories with size at most 100000: {ex007Facade.RootDirectory.GetSize(100000)}");
Console.WriteLine($"Size of directory to delete: {ex007Facade.GetSizeOfDirectoryToDelete()}");
#endregion

#region Ex008

Console.WriteLine();
Console.WriteLine("Exercise 8");
Console.WriteLine();

IEx008Facade ex008Facade = new Ex008Facade(@"./assets/008_data.txt");
Console.WriteLine($"Sum of visible trees: {ex008Facade.CountVisibleTrees()}");
Console.WriteLine($"Possible highest scenic score: {ex008Facade.GetHighestScenicScore()}");
#endregion

#region Ex009

Console.WriteLine();
Console.WriteLine("Exercise 9");
Console.WriteLine();

IEx009Facade ex009Facade = new Ex009Facade(@"./assets/009_data.txt", 2);
ex009Facade.PerformMoves();
Console.WriteLine($"Count of unique positions with 2 knots: {ex009Facade.CountTailUniquePositions()}");

ex009Facade = new Ex009Facade(@"./assets/009_data.txt", 10);
ex009Facade.PerformMoves();
Console.WriteLine($"Count of unique positions with 10 knots: {ex009Facade.CountTailUniquePositions()}");

#endregion

#region Ex010

Console.WriteLine();
Console.WriteLine("Exercise 10");
Console.WriteLine();

IEx010Facade ex010Facade = new Ex010Facade(@"./assets/010_data.txt");
Console.WriteLine($"Sum of signal strength: {ex010Facade.GetSumOfSignalStrength(new[] {20, 60, 100, 140, 180, 220})}");

ex010Facade = new Ex010Facade(@"./assets/010_data.txt");
var pixels = ex010Facade.ProduceImage().ToArray();

Console.WriteLine("CRT:");

Console.WriteLine(new string(pixels.Take(40).ToArray()));
Console.WriteLine(new string(pixels.Skip(40).Take(40).ToArray()));
Console.WriteLine(new string(pixels.Skip(80).Take(40).ToArray()));
Console.WriteLine(new string(pixels.Skip(120).Take(40).ToArray()));
Console.WriteLine(new string(pixels.Skip(160).Take(40).ToArray()));
Console.WriteLine(new string(pixels.Skip(200).Take(40).ToArray()));

#endregion

#region Ex011

Console.WriteLine();
Console.WriteLine("Exercise 11");
Console.WriteLine();

IEx011Facade ex011Facade = new Ex011Facade(MonkeysInitializer.Initialize(), true);
ex011Facade.PerformRounds(20);
Console.WriteLine($"Level of monkey business: {ex011Facade.GetLevelOfMonkeyBusiness()}");
ex011Facade = new Ex011Facade(MonkeysInitializer.Initialize(), false);
ex011Facade.PerformRounds(10000);
Console.WriteLine($"Level of monkey business: {ex011Facade.GetLevelOfMonkeyBusiness()}");

#endregion

#region Ex012

Console.WriteLine();
Console.WriteLine("Exercise 12");
Console.WriteLine();

IEx012Facade ex012Facade = new Ex012Facade(@"./assets/012_data.txt");
ex012Facade.FindShortestWay();
Console.WriteLine($"Lowest number of steps: {ex012Facade.GetSteps()}");

#endregion