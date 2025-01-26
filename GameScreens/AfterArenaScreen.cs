using SadConsole.Input;
using SadConsoleGame.Tools;

namespace SadConsoleGame.Scenes;
    class AfterArenaScreen : ScreenObject
{
    private ScreenSurface _mainSurface;

    public AfterArenaScreen(int gold, int experience, int turn, bool heroalive)
    {
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        if(heroalive == true)
        {
            _mainSurface.Print(10, 1, "Udalo ci sie uciec z areny i wracasz z wszystkim co zgromadziles!", Color.Green);
        }
        else
        {
            _mainSurface.Print(10, 1, "Polegles na arenie i zostala ci niestety polowa zebranego lupu", Color.Red);
            gold = (int)gold/2;
            experience = (int)experience/2;
        }
        _mainSurface.Print(20, 3, $"Ostatnia tura byla tura {turn}");
        _mainSurface.Print(20, 5, $"Zgromadziles {gold} sztuk zlota");
        _mainSurface.Print(20, 7, $"Zdobyles rowniez {experience} punktow doswiadczenia");
        _mainSurface.Print(20, 9, $"Wcisnij enter aby kontynuowac...");

        PlayerStats playerStats = PlayerStats.LoadFromJson("./Data/playerstats.json");

        playerStats.Gold = playerStats.Gold + gold;

        if(playerStats.Experience + experience >= 100)
        {
            playerStats.Experience = 100;
        }
        else
        {
        playerStats.Experience = playerStats.Experience + experience;
        }

        PlayerStats.UpdateStat("./Data/playerstats.json", "Gold", playerStats.Gold);
        PlayerStats.UpdateStat("./Data/playerstats.json", "Experience", playerStats.Experience);



        Children.Add(_mainSurface);
    }
    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;
            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter))
            {
                SadConsole.Game.Instance.Screen = new DefaultViewScreen();
            }

        return handled;
    }
}