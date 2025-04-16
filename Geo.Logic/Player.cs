namespace Geo.Logic;

public class Player
{
    public string Name { get; }
    public List<VanillaLocation> StartingHand { get; }

    public Player(string name, List<VanillaLocation> startingHand)
    {
        {
            Name = name;
            StartingHand = startingHand;
        }
    }
}
