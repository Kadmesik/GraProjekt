
namespace SadConsoleGame.Tools;
public class Monster
{
    public int Health { get; set; }
    public int Armor { get; set; }
    public int Strength { get; set; }
    public int Level { get; set; }

    private static Random _random = new Random();
    //+ _random.Next(0, level)

    public Monster(int level)
    {
        Level = level;
        Health = 0 + (level * 4 + _random.Next(0, level) );
        Armor = 0 + (level * 2 + _random.Next(0, level) );
        Strength = 0 + (level * 1 + _random.Next(0, level) ); 
    }
}
