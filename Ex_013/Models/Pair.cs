namespace Ex_013.Models;

public class Pair
{
   public PacketGroup FirstGroup { get; }
   public PacketGroup SecondGroup { get; }
   public bool IsRightOrder => CompareGroups();
    public Pair(string[] dataLines)
    {
        FirstGroup = new PacketGroup(ref dataLines[0]);
        SecondGroup = new PacketGroup(ref dataLines[1]);
    }

    private bool CompareGroups()
    {
        return FirstGroup > SecondGroup;
    }
}