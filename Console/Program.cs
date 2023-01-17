// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Exercise 001");
//
// var fileDataAccess = new FileDataAccess();
// var elves = new Elves(fileDataAccess);
// Console.WriteLine(elves.GetMaxTotalCalories());
// Console.WriteLine(elves.GetSumCaloriesOfTopThreeElves());

using Ex_002.Models;

Console.WriteLine("Exercise 002");


var scores = GetScores();
var points = Battleground.CountPlayerPoints(scores);

Console.WriteLine(points);

// IEnumerable<Score> GetScores()
// {
//     var fileDataAccess = new FileDataAccess();
//     var moves = fileDataAccess.ReadDataAsS();
//     
//     for (var i = 0; i < moves.Item1.Moves.Count; i++)
//     {
//         yield return Battleground.Battle(moves.Item1.Moves.ElementAt(i), moves.Item2.Moves.ElementAt(i));
//     }
// }

IEnumerable<Score> GetScores()
{
    var fileDataAccess = new FileDataAccess();
    var moves = fileDataAccess.ReadDataAsScores();
    
    for (var i = 0; i < moves.Item1.Moves.Count; i++)
    {
        yield return Battleground.Battle(moves.Item1.Moves.ElementAt(i), moves.Item2.Moves.ElementAt(i));
    }
}