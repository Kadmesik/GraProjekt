
namespace SadConsoleGame.Tools
{
    public static class StatisticsDescription
    {
        public static void Strenght(ScreenSurface surface, int statistic)
        {
            surface.Fill(new Rectangle(41, 2, 36, 21), Color.White, Color.Black, 0, Mirror.None);
            surface.Print(52, 3, $"Punkty sily: {statistic}");
            surface.Print(43, 5, "Sila zwieksza obrazenia,");
            surface.Print(43, 6, "ktore zadajesz w walce.");
            surface.Print(43, 7, "Im wieksza sila, tym wiekszy");
            surface.Print(43, 8, "potencjal obrazen fizycznych.");
        }
        public static void Crit(ScreenSurface surface, int statistic)
        {
            surface.Fill(new Rectangle(41, 2, 36, 21), Color.White, Color.Black, 0, Mirror.None);
            surface.Print(42, 3, $"Szansa na obrazenie krytyczne: {statistic}%");
            surface.Print(43, 5, "Szansa na obrazenie krytyczne");
            surface.Print(43, 6, "okresla prawdopodobienstwo,");
            surface.Print(43, 7, "ze Twoje ataki zadaja");
            surface.Print(43, 8, "podwojne obrazenia.");
        }
        public static void Health(ScreenSurface surface, int statistic)
        {
            surface.Fill(new Rectangle(41, 2, 36, 21), Color.White, Color.Black, 0, Mirror.None);
            surface.Print(51, 3, $"Punkty zycia: {statistic}");
            surface.Print(43, 5, "Punkty zycia to ilosc obrazen,");
            surface.Print(43, 6, "jakie mozesz otrzymac przed");
            surface.Print(43, 7, "przegrana. Wysoki poziom");
            surface.Print(43, 8, "zdrowia pozwala przetrwac");
            surface.Print(43, 9, "dluzsze walki.");
        }
        public static void Armor(ScreenSurface surface, int statistic)
        {
            surface.Fill(new Rectangle(41, 2, 36, 21), Color.White, Color.Black, 0, Mirror.None);
            surface.Print(50, 3, $"Punkty Pancerza: {statistic}");
            surface.Print(43, 5, "Punkty pancerza redukuja");
            surface.Print(43, 6, "otrzymywane obrazenia.");
            surface.Print(43, 7, "Im wiecej pancerza, tym mniej");
            surface.Print(43, 8, "obrazen zadaja przeciwnicy.");
        }
        public static void Experience(ScreenSurface surface, int statistic)
        {
            surface.Fill(new Rectangle(41, 2, 36, 21), Color.White, Color.Black, 0, Mirror.None);
            surface.Print(46, 3, $"Punkty Doswiadczenia: {statistic}");
            surface.Print(43, 5, "Punkty doswiadczenia zdobywasz");
            surface.Print(43, 6, "za pokonywanie wrogow.");
            surface.Print(43, 7, "Zdobadz wystarczajaco duzo");
            surface.Print(43, 8, "i odowiedz medrca by,");
            surface.Print(43, 9, "awansowac na wyzszy poziom.");
        }
        public static void Gold(ScreenSurface surface, int statistic)
        {
            surface.Fill(new Rectangle(41, 2, 36, 21), Color.White, Color.Black, 0, Mirror.None);
            surface.Print(52, 3, $"Ilosc zlota: {statistic}");
            surface.Print(43, 5, "Zloto to waluta, ktorej");
            surface.Print(43, 6, "uzywasz do zakupu przedmiotow,");
            surface.Print(43, 7, "uzbrojenia lub leczenia.");
            surface.Print(43, 8, "Zbieraj je, aby zwiekszyc");
            surface.Print(43, 9, "swoje mozliwosci.");
        }
        public static void Agility(ScreenSurface surface, int statistic)
        {
            surface.Fill(new Rectangle(41, 2, 36, 21), Color.White, Color.Black, 0, Mirror.None);
            surface.Print(50, 3, $"Punkty zwinnosci: {statistic}");
            surface.Print(43, 5, "Zwinnosc poprawia szanse");
            surface.Print(43, 6, "na ucieczke. Im wyzsza");
            surface.Print(43, 7, "zwinnosc, tym wieksze szanse");
            surface.Print(43, 8, "na uciekniecie z pelnym.");
            surface.Print(43, 9, "ekwipunkiem z areny.");
        }
        public static void Level(ScreenSurface surface, int statistic)
        {
            surface.Fill(new Rectangle(41, 2, 36, 21), Color.White, Color.Black, 0, Mirror.None);
            surface.Print(56, 3, $"Poziom: {statistic}");
            surface.Print(43, 5, "Poziom odzwierciedla ogolny");
            surface.Print(43, 6, "postep Twojej postaci.");
            surface.Print(43, 7, "Awansujac, zyskujesz");
            surface.Print(43, 8, "nowe umiejetnosci i punkty");
            surface.Print(43, 9, "do rozdzielenia.");
        }
        public static void Block(ScreenSurface surface, int statistic)
        {
            surface.Fill(new Rectangle(41, 2, 36, 21), Color.White, Color.Black, 0, Mirror.None);
            surface.Print(42, 3, $"Procent zablokowanych obrazen: {statistic}%");
            surface.Print(43, 5, "Procent zablokowanych obrazen");
            surface.Print(43, 6, "okresla ilosc redukowanych");
            surface.Print(43, 7, "obrazen w trakcie walki.");
            surface.Print(43, 8, "Wysoka blokada znaczaco");
            surface.Print(43, 9, "zwieksza przezywalnosc.");
        }
    }
}