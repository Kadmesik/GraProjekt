using SadConsole;
using SadConsole.Input;
using SadConsoleGame.Tools;

namespace SadConsoleGame.Scenes;

class LoadGameScreen : ScreenObject
{
    private ScreenSurface _mainSurface;

    bool IsGameSave = false;

    public LoadGameScreen()
    {
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        PlayerStats playerStats = PlayerStats.LoadFromJson(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json");
        if(playerStats.Armor != 0)
        {
            IsGameSave = true;
        }
        
        if(playerStats.Armor == 0)
        {
            _mainSurface.Print(5, 5, "Aktualnie nie posiadasz zadnego zapisu gry...");
            _mainSurface.Print(5, 7, "Wcisnij ESC by wrocic do glownego menu");
        }
        else
        {
            _mainSurface.Print(42, 2, "WCZYTAJ STAN GRY", Color.Cyan);
            DrawingTools.DrawAvatarbg(_mainSurface);
            int[] rgb = playerStats.CarnationRGBcode;
            Color color = new Color(rgb[0], rgb[1], rgb[2]);
            DrawingTools.DrawAvatar(_mainSurface, color);
            _mainSurface.Print(30, 4, $"Karnacja: {playerStats.Carnation}");
            _mainSurface.Print(30, 6, $"Punkty szansy ciosu krytycznego: {playerStats.Crit}");
            _mainSurface.Print(30, 8, $"Punkty zycia: {playerStats.Health}");
            _mainSurface.Print(30, 10, $"Punkty sily: {playerStats.Strenght}");
            _mainSurface.Print(30, 12, $"Punkty pancerza: {playerStats.Armor}");
            _mainSurface.Print(2, 17, $"By usunac zapis wcisnij klawisz delete");
            _mainSurface.Print(2, 19, $"By wrocic do menu glownego wcisnij klawisz ESC");
            _mainSurface.Print(2, 21, $"By wczytac gre wcisnij enter");

        }

        Children.Add(_mainSurface);
    }

    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;

        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Escape))
        {

        SadConsole.Game.Instance.Screen = new MenuScreen();

        }
        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter))
        {

            if(IsGameSave == true)
            {
                SadConsole.Game.Instance.Screen = new DefaultViewScreen();
            }

        }
        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Delete))
        {
            if(IsGameSave != false)
            {
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Strenght", 0);
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Armor", 0);
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Crit", 0);
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Health", 0);
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Gold", 0);
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Experience", 0);
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Agility", 25);
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Carnation", "");
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Level", 0);
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Block", 50);
                SadConsole.Game.Instance.Screen = new MenuScreen();
            }

        }
        return handled;
    }
}