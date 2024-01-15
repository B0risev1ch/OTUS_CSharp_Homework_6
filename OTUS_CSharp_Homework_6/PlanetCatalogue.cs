public class PlanetCatalogue
{
    List<Planet> _planets;
    int _methodCounter = 0;
    public PlanetCatalogue()
    {
        var _venus  = new Planet("Venus", 2, 12_104, null);
        var _earth  = new Planet("Earth", 3, 12_742, _venus);
        var _mars   = new Planet("Mars", 4, 6_794, _earth);

        _planets = new List<Planet>()
        {
            _venus,
            _earth,
            _mars
        };
    }

    public (int fromSun, int equatorial_d, string? error) GetPlanet(string name)
    {
        var foundPlanet = _planets.Where(planet => planet.Name == name).FirstOrDefault();
        _methodCounter++;

        if (_methodCounter % 3 == 0) return (0, 0, "Вы спрашиваете слишком часто");

        if (foundPlanet == null)
            return (0, 0, "Не удалось найти планету");
        else 
            return (foundPlanet.FromSun, foundPlanet.Equatorial_d, null);
    }
}