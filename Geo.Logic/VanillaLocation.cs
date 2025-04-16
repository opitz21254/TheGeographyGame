namespace Geo.Logic;

public class VanillaLocation
{
    public string Location { get; }
    public int DistFromJerusalem { get; }
    public int Elevation { get; }
    public int XMapCoordinate { get; }

    public VanillaLocation(string location, int dist, int elev, int x)
    {
        Location = location;
        DistFromJerusalem = dist;
        Elevation = elev;
        XMapCoordinate = x;
    }
}
