public class PlanetCatalogue2
{
    List<Planet> _planets;
    public int methodCounter { get; set; }
    public PlanetCatalogue2()
    {
        var _venus = new Planet("Venus", 2, 12_104, null);
        var _earth = new Planet("Earth", 3, 12_742, _venus);
        var _mars = new Planet("Mars", 4, 6_794, _earth);

        _planets = new List<Planet>()
        {
            _venus,
            _earth,
            _mars
        };
    }



    public (int fromSun, int equatorial_d, string? error) GetPlanet(string name, Func<string, string> PlanetValidator)
    {
        var foundPlanet = _planets.Where(planet => planet.Name == name).FirstOrDefault();
        var validatorResult = PlanetValidator(name);

        if (validatorResult != null)
            return (0, 0, validatorResult);

        if (foundPlanet == null)
            return (0, 0, "Не удалось найти планету");

        return (foundPlanet.FromSun, foundPlanet.Equatorial_d, validatorResult);
    }
}