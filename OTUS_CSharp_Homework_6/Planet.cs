class Planet
{
    public Planet(string name, int fromSun, int equatorial_d, Planet ? previuous_planet)
    {
        Name = name;
        FromSun = fromSun;
        Equatorial_d = equatorial_d;
        Previous_planet = previuous_planet;
    }
    public string Name { get; set; }
    public int FromSun { get; set; }
    public int Equatorial_d { get; set; }
    public Planet? Previous_planet { get; set; }
}
