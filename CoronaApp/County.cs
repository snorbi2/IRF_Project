namespace CoronaApp
{
    internal class County
    {
        public County()
        {
        }

        public County(string name, int allCases, int newCases, int weeklyCases, int perCapitaCases)
        {
            Name = name;
            AllCases = allCases;
            NewCases = newCases;
            WeeklyCases = weeklyCases;
            PerCapitaCases = perCapitaCases;
        }

        public string Name { get; set; }
        public int AllCases { get; set; }
        public int NewCases { get; set; }
        public int WeeklyCases { get; set; }
        public int PerCapitaCases { get; set; }
    }
}