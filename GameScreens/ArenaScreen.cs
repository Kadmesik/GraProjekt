using System;
using System.Threading;
using System.Threading.Tasks;
using SadConsole.Input;
using SadConsoleGame.Tools;
namespace SadConsoleGame.Scenes;

class ArenaScreen : ScreenObject
{
    private ScreenSurface _mainSurface;
    private int Slider = 22;
    private static Random _random = new Random();
    private int BattleHp = 0;
    private int BattleExperience = 0;
    private int BattleGold = 0;
    private int Turn = 0;
    private bool HeroAlive = true;
    private bool MonsterAlive = false;
    private bool UsedBlock = false;
    private static Monster CurrentMonster;
        

    public ArenaScreen()
    {
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);


        PlayerStats playerStats = PlayerStats.LoadFromJson(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json");
        int[] rgb = playerStats.CarnationRGBcode;
        Color color = new Color(rgb[0], rgb[1], rgb[2]);
        BattleHp = playerStats.Health;

        _mainSurface.DrawBox(new Rectangle(20, 20, 40, 5), ShapeParameters.CreateStyledBox(ICellSurface.ConnectedLineThin, new ColoredGlyph(Color.White, Color.Black)));
        _mainSurface.Print(23, 22, "atak");
        _mainSurface.Print(36, 22, "blok");
        _mainSurface.Print(49, 22, "ucieczka");
        _mainSurface.Print(22, 22, ">", Color.Yellow);

        DrawingTools.DrawHero(_mainSurface, color, 50, 8);
        DrawingTools.DrawHero(_mainSurface, Color.RoyalBlue, 20, 8);

        Monster monster = new Monster(Turn);

        Children.Add(_mainSurface);
    }

    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        PlayerStats playerStats = PlayerStats.LoadFromJson(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json");
        bool handled = false;

            if(MonsterAlive == false)
                {
                    CurrentMonster = new Monster(++Turn);
                    MonsterAlive = true;
                    BattleGold += ArenaIncomes.Gold(Turn-1,  CurrentMonster.Health, CurrentMonster.Armor, CurrentMonster.Strength);
                    BattleExperience += ArenaIncomes.Experience(Turn-1,  CurrentMonster.Health, CurrentMonster.Armor, CurrentMonster.Strength);
                }
            if(BattleHp <= 0) // smierc jezeli mniej niz 0 hp
                {
                    PrintMainMessage(_mainSurface,$"Zostales pokonany, odrodzisz sie juz niebawem...");
                    _mainSurface.Print(13, 4,$"Wcisnij tabulator aby kontynuowac");
                    HeroAlive = false;
                }
            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Tab) && BattleHp <= 0)
            {
                SadConsole.Game.Instance.Screen = new AfterArenaScreen(BattleGold, BattleExperience, Turn, HeroAlive);
            }

            _mainSurface.Fill(new Rectangle(7, 0, 3, 6), Color.Black, Color.Black, 0, Mirror.None);
            _mainSurface.DrawBox(new Rectangle(0, 0, 11, 6), ShapeParameters.CreateStyledBox(ICellSurface.ConnectedLineThin, new ColoredGlyph(Color.White, Color.Black)));
            _mainSurface.Print(1, 1, $"HP:   {CurrentMonster.Health}",Color.White);
            _mainSurface.Print(1, 2, $"DMG:  {CurrentMonster.Strength}",Color.White);
            _mainSurface.Print(1, 3, $"ARM:  {CurrentMonster.Armor}",Color.White);
            _mainSurface.Print(1, 4, "CRIT: 0",Color.White);

            _mainSurface.Fill(new Rectangle(75, 0, 3, 6), Color.Black, Color.Black, 0, Mirror.None);
            _mainSurface.DrawBox(new Rectangle(68, 0, 11, 6), ShapeParameters.CreateStyledBox(ICellSurface.ConnectedLineThin, new ColoredGlyph(Color.White, Color.Black)));
            _mainSurface.Print(69, 1, $"HP:   {BattleHp}",Color.White);
            _mainSurface.Print(69, 2, $"DMG:  {playerStats.Strenght}",Color.White);
            _mainSurface.Print(69, 3, $"ARM:  {playerStats.Armor}",Color.White);
            _mainSurface.Print(69, 4, $"CRIT: {playerStats.Crit}",Color.White);

            _mainSurface.DrawBox(new Rectangle(12, 0, 55, 6), ShapeParameters.CreateStyledBox(ICellSurface.ConnectedLineThin, new ColoredGlyph(Color.White, Color.Black)));
            _mainSurface.Print(13, 1, "Tura:");
            _mainSurface.Print(19, 1, $"{Turn}", Color.AnsiCyan);
            _mainSurface.Print(26, 1, "Zdobycze:");
            _mainSurface.Print(37, 1, "Zloto");
            _mainSurface.Print(43, 1, $"{BattleGold}", Color.Yellow);
            _mainSurface.Print(48, 1, $"Doswiadczenie");
            _mainSurface.Print(62, 1, $"{BattleExperience}", Color.LimeGreen);

            
            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Right) && BattleHp > 0)
            {
                if (Slider != 48 )
                {
                    _mainSurface.Print(22, 22, " ");
                    _mainSurface.Print(35, 22, " ");
                    _mainSurface.Print(48, 22, " ");
                    Slider = Slider + 13;
                    _mainSurface.Print(Slider, 22, ">", Color.Yellow);
                }
            }

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Left) && BattleHp > 0 )
            {
                if (Slider != 22)
                {
                    _mainSurface.Print(22, 22, " ");
                    _mainSurface.Print(35, 22, " ");
                    _mainSurface.Print(48, 22, " ");
                    Slider = Slider - 13;
                    _mainSurface.Print(Slider, 22, ">", Color.Yellow);
                }
            }

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter) && BattleHp > 0)
            {
            
                switch(Slider)
                {
                    case 22: // Atak
                        if(_random.Next(1, 100) <= playerStats.Crit) //Atak z krytem
                        {
                            if((playerStats.Strenght*2-CurrentMonster.Armor) > 0)
                            {
                            CurrentMonster.Health = CurrentMonster.Health - (playerStats.Strenght*2-CurrentMonster.Armor);
                            PrintMainMessage(_mainSurface,$"Obrazenie Krytyczne! {playerStats.Strenght*2-CurrentMonster.Armor} punktow zycia");
                            }
                            else
                            {
                            CurrentMonster.Health--;
                            PrintMainMessage(_mainSurface,$"Zadales atak za 1 punkt zycia");
                            }
                        }
                        else //atak bez kryta
                        {
                            if((playerStats.Strenght-CurrentMonster.Armor) > 0)
                            {
                            CurrentMonster.Health = CurrentMonster.Health - (playerStats.Strenght-CurrentMonster.Armor);
                            PrintMainMessage(_mainSurface,$"Zadales atak za {playerStats.Strenght-CurrentMonster.Armor} punktow zycia");
                            }
                            else
                            {
                            CurrentMonster.Health--;
                            PrintMainMessage(_mainSurface,$"Zadales atak za 1 punkt zycia");
                            }
                        }
                        if( CurrentMonster.Health <= 0)
                        {
                            MonsterAlive = false;
                        }
                    break;

                    case 35: //blok
                        UsedBlock = true;
                    break;

                    case 48: //ucieczka
                        if(_random.Next(1, 100) <= playerStats.Agility) //udalo sie uciec
                        {
                            PrintMainMessage(_mainSurface,$"Z sukcesem uciekasz z areny!");
                            SadConsole.Game.Instance.Screen = new AfterArenaScreen(BattleGold, BattleExperience, Turn, HeroAlive);
                        }
                        else // nie udalo sie uciec
                        {
                            PrintMainMessage(_mainSurface,$"Nie udalo ci sie uciec, przeciwnik to wykorzystal");
                        }
                    break;
                }
                
                // tura przeciwnika
                if(UsedBlock == true && MonsterAlive == true) //uzyto bloka
                {
                    if(CurrentMonster.Strength - playerStats.Armor > 0) 
                        {
                        BattleHp = BattleHp - ((int)Math.Ceiling( CurrentMonster.Strength / 10.0)); //zredukowanie dmg opponenta do 10%, jezeli po przecinku zaokraglam w gore
                        PrintMainMessage(_mainSurface,$"Zablokowales atak przeciwnika, i otrzymales {(int)Math.Ceiling( CurrentMonster.Strength / 10.0)} obrazen");
                        }
                        UsedBlock = false;
                }
                else if(UsedBlock == false && MonsterAlive == true) //nie uzyto bloka
                {
                    if(CurrentMonster.Strength - playerStats.Armor > 0)
                    {
                        BattleHp = BattleHp - (CurrentMonster.Strength - playerStats.Armor); 
                        PrintMainMessage(_mainSurface,$"Przeciwnik zadal ci {CurrentMonster.Strength - playerStats.Armor} obrazen");

                    }
                    else
                    {
                        BattleHp--;
                        PrintMainMessage(_mainSurface,$"Przeciwnik zadal ci tylko 1 punkt obrazen");

                    }
                }
            }
        return handled;
    }
    public static void PrintMainMessage(ScreenSurface surface, string wiadomosc) // PrintMainMessage(_mainSurface,$"");
    {
        surface.Fill(new Rectangle(13, 3, 54, 1), Color.White, Color.Black, 0, Mirror.None);
        surface.Print(13, 3, wiadomosc);
    }
}