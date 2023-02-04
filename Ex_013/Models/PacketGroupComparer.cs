namespace Ex_013.Models;

public class PacketGroupComparer : IComparer<PacketGroup>
{
    public int Compare(PacketGroup x, PacketGroup y)
    {
        var result = x!.CompareGroup(y);

        switch (result)
        {
            case null:
            case true:
                return 1;
            default:
                return -1;
        }
    }
}