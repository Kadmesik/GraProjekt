using SadConsole.Input;
namespace SadConsoleGame.Scenes;

class WiseManScreen : ScreenObject
{
    private ScreenSurface _mainSurface;

    public WiseManScreen()
    {
        PlayerStats playerStats = PlayerStats.LoadFromJson("./Data/playerstats.json");
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        _mainSurface.Print(10, 19, "Postep doswiadczenia do kolejnego poziomu:");
        _mainSurface.Print(30, 23, "Obecny poziom: ", Color.LimeGreen);
        _mainSurface.Fill(new Rectangle(10, 20, 60, 2), Color.Green, Color.White, 0, Mirror.None);

        int ExperienceBar =  playerStats.Experience/10;
        _mainSurface.Fill(new Rectangle(10, 20, ExperienceBar*6, 2), Color.Green, Color.LimeGreen, 0, Mirror.None); 

        _mainSurface.Print(10, 4, "Gdy zbierzesz 100 punktow doswiadczenia, mozesz ulepczyc ");
        _mainSurface.Print(10, 5, "swoja postac by dodac swojej postaci 5 zycia");
        _mainSurface.Print(10, 6, "i zblizyc sie do konca gry!");
        if(playerStats.Experience == 100)
        {
        _mainSurface.Print(10, 9, "Masz wystarczajaco doswiadczenia by ulepszyc postac!", Color.Violet); 
        _mainSurface.Print(10, 10, "Wcisnij enter by ulepszyc poziom!", Color.Violet); 
        }

        _mainSurface.Print(10, 15, "Wcisnij Escape wy wrocic do menu gry", Color.White); 


        Children.Add(_mainSurface);
    }

    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;
        PlayerStats playerStats = PlayerStats.LoadFromJson("./Data/playerstats.json"); 
        _mainSurface.Print(45, 23, $"{playerStats.Level}", Color.LimeGreen);

        

        if(playerStats.Experience == 100 && keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter))
        {
            playerStats.Level ++ ;
            playerStats.Experience = 0 ;
            playerStats.Health += 5;
            PlayerStats.UpdateStat("./Data/playerstats.json", "Experience", playerStats.Experience);
            PlayerStats.UpdateStat("./Data/playerstats.json", "Level", playerStats.Level);
            PlayerStats.UpdateStat("./Data/playerstats.json", "Health", playerStats.Health);
            _mainSurface.Fill(new Rectangle(10, 20, 60, 2), Color.Green, Color.White, 0, Mirror.None);
            _mainSurface.Fill(new Rectangle(10, 9, 70, 2), Color.Green, Color.Black, 0, Mirror.None); 
            _mainSurface.Print(30, 23, "Obecny poziom: ", Color.LimeGreen);
            _mainSurface.Fill(new Rectangle(45, 23, 10, 1), Color.Green, Color.Black, 0, Mirror.None); 
            
        }
        if(keyboard.IsKeyPressed(SadConsole.Input.Keys.Escape))
        {
        SadConsole.Game.Instance.Screen = new DefaultViewScreen();
        }

        return handled;
    }
}