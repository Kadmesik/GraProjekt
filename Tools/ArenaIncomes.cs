
namespace SadConsoleGame.Tools
{
    public static class ArenaIncomes
    {
        public static int Gold(int Turn, int EnemyHP, int EnemyARM, int EnemyDMG) // w tym miejscu mozna zmieniac ilosc dostawanych pieniedzy za runde
        {
            int Gains = 0; 
            if(Turn != 0)
            {
                Gains = 5*Turn + (EnemyHP+EnemyARM)* 2 + EnemyDMG * 3;
            }
            return Gains;
        }
        public static int Experience(int Turn, int EnemyHP, int EnemyARM, int EnemyDMG) // tutaj natomiast expa
        {
            int Gains = 0; 
            if(Turn != 0)
            {
                Gains = (int)(EnemyHP + EnemyARM + EnemyDMG)/5;
            }
            return Gains;
        }
    }
}