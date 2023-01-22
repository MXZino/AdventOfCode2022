using Common.Models;
using Ex_008.Interfaces;
using Ex_008.Models;

namespace Ex_008;

public class Ex008Facade : IEx008Facade
{
    private int _rows;
    private int _columns;
    private readonly List<Tree> _trees;

    public Ex008Facade(string filePath)
    {
        var dataLines = FileDataAccess.ReadFile(filePath);
        _trees = new List<Tree>();

        foreach (var dataLine in dataLines)
            ParseData(dataLine);
    }

    private void ParseData(string dataLine)
    {
        var sizes = dataLine.Trim().ToArray().Select(x => byte.Parse(x.ToString())).ToArray();

        int counter;
        for (counter = 0; counter < sizes.Length; counter++)
        {
            _trees.Add(new Tree(sizes[counter], _rows, counter));
        }

        if (_columns < counter)
            _columns = counter;

        _rows += 1;
    }

    public int CountVisibleTrees() => _trees.Count(IsTreeVisible);

    public int GetHighestScenicScore() => _trees.Max(GetScenicScore);

    private int GetScenicScore(Tree tree)
    {
        var topScore = GetTopScore(tree);

        if (topScore == 0)
            return 0;
        
        var bottomScore = GetBottomScore(tree);

        if (bottomScore == 0)
            return 0;
        
        var leftScore = GetLeftScore(tree);

        if (leftScore == 0)
            return 0;
        
        var rightScore = GetRightScore(tree);

        if (rightScore == 0)
            return 0;

        return topScore * bottomScore * leftScore * rightScore;
    }
    
    private bool IsTreeVisible(Tree tree) =>
        IsVisibleFromTop(tree)
        || IsVisibleFromBottom(tree)
        || IsVisibleFromLeft(tree)
        || IsVisibleFromRight(tree);

    private bool IsVisibleFromTop(Tree tree)
    {
        if (tree.Row == 0)
            return true;

        var treesOnTop = _trees.Where(x => x.Row < tree.Row && x.Column == tree.Column);
        return !treesOnTop.Any(x => x.Size >= tree.Size);
    }

    private bool IsVisibleFromBottom(Tree tree)
    {
        if (tree.Row == _rows - 1)
            return true;

        var treesOnBottom = _trees.Where(x => x.Row > tree.Row && x.Column == tree.Column);
        return !treesOnBottom.Any(x => x.Size >= tree.Size);
    }

    private bool IsVisibleFromLeft(Tree tree)
    {
        if (tree.Column == 0)
            return true;

        var treesOnLeft = _trees.Where(x => x.Column < tree.Column && x.Row == tree.Row);
        return !treesOnLeft.Any(x => x.Size >= tree.Size);
    }

    private bool IsVisibleFromRight(Tree tree)
    {
        if (tree.Column == _columns - 1)
            return true;

        var treesOnRight = _trees.Where(x => x.Column > tree.Column && x.Row == tree.Row);
        return !treesOnRight.Any(x => x.Size >= tree.Size);
    }

    private int GetTopScore(Tree tree)
    {
        if (tree.Row == 0)
            return 0;

        var treesOnTop = _trees
            .Where(x => 
                x.Row < tree.Row && 
                x.Column == tree.Column)
            .OrderByDescending(x=> x.Row)
            .ToArray();

        return GetNotBlockedDistance(tree, treesOnTop);
    }
    
    private int GetBottomScore(Tree tree)
    {
        if (tree.Row == _rows - 1)
            return 0;

        var treesOnBottom = _trees
            .Where(x => 
                x.Row > tree.Row && 
                x.Column == tree.Column)
            .OrderBy(x=> x.Row)
            .ToArray();

        return GetNotBlockedDistance(tree, treesOnBottom);
    }
    
    private int GetLeftScore(Tree tree)
    {
        if (tree.Column == 0)
            return 0;
        
        var treesOnLeft = _trees
            .Where(x => 
                x.Column < tree.Column && 
                x.Row == tree.Row)
            .OrderByDescending(x=> x.Column)
            .ToArray();

        return GetNotBlockedDistance(tree, treesOnLeft);
    }
    
    private int GetRightScore(Tree tree)
    {
        if (tree.Column == _columns - 1)
            return 0;
        
        var treesOnRight = _trees
            .Where(x => 
                x.Column > tree.Column && 
                x.Row == tree.Row)
            .OrderBy(x=> x.Column)
            .ToArray();

        return GetNotBlockedDistance(tree, treesOnRight);
    }
    
    private static int GetNotBlockedDistance(Tree tree, IEnumerable<Tree> treesOnSide)
    {
        var counter = 0;

        foreach (var treeOnTop in treesOnSide)
        {
            counter += 1;
            
            if (treeOnTop.Size >= tree.Size)
                return counter;
        }

        return counter;
    }
}