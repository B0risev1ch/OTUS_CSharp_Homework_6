

//Solution 1. Anonymous types: 
var venus = new
{
    name = "venus",
    fromSun = 2,
    equatorial_d = 12_104
    };

var earth = new
{
    name = "earth",
    fromSun = 3,
    equatorial_d = 12_742,
    previous_planet = venus
};

var mars = new
{
    name = "mars",
    fromSun = 4,
    equatorial_d = 6_794,
    previous_planet = earth
};

var venus2 = new
{
    name = "venus",
    fromSun = 2,
    equatorial_d = 12_104
};
Console.WriteLine($"{venus}, is Equals to venus? {venus.Equals(venus)}");
Console.WriteLine($"{earth}, is Equals to venus? {earth.Equals(venus)}");
Console.WriteLine($"{mars}, is Equals to venus ? {mars.Equals(venus)}");
Console.WriteLine($"{venus2}, is Equals to venus? {venus2.Equals(venus)}");


//Solution 2. Class

PlanetCatalogue pc = new PlanetCatalogue();

var listOfPlanetsFromCatalogue = new List<(int fromSun, int equatorial_d, string? error)> {
pc.GetPlanet("Earth"),
pc.GetPlanet("Лимония"),
pc.GetPlanet("Mars")
};
foreach (var planetInfoTuple in listOfPlanetsFromCatalogue)
    Console.WriteLine(planetInfoTuple.error is null ?(planetInfoTuple.fromSun, planetInfoTuple.equatorial_d ): planetInfoTuple.error);

//solution3. Class + Delegate

PlanetCatalogue2 pc2 = new PlanetCatalogue2();

var listOfPlanetsFromCatalogue2 = new List<(int fromSun, int equatorial_d, string? error)> {
pc2.GetPlanet("Earth", (a =>
{
    pc2.methodCounter++;
    if ( pc2.methodCounter % 3 == 0 ) return ("Вы спрашиваете слишком часто");
    else return null;
})),

pc2.GetPlanet("Лимония", (a =>
{
    pc2.methodCounter++;
    return "Это - запретная планета";
})),
pc2.GetPlanet("Mars",(a =>
{
    pc2.methodCounter++;
    if (pc2.methodCounter % 3 == 0) return ("Вы спрашиваете слишком часто");
    else return null;
})),
};
foreach (var planetInfoTuple in listOfPlanetsFromCatalogue2)
    Console.WriteLine(planetInfoTuple.error is null ? (planetInfoTuple.fromSun, planetInfoTuple.equatorial_d) : planetInfoTuple.error);
