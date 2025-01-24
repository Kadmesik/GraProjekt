using SadConsoleGame.Tools;

namespace SadConsoleGame.Scenes;

class CharacterCreatorSummary : ScreenObject
{
    private ScreenSurface _mainSurface;
    public CharacterCreatorSummary()
    {
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        DrawingTools.DrawBlankAvatarPlace(_mainSurface);

        PlayerStats playerStats = PlayerStats.LoadFromJson(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json");
        _mainSurface.Fill(new Rectangle(30, 1, 20, 1), Color.Black, Color.Black, 0, Mirror.None);
        _mainSurface.Fill(new Rectangle(10, 16, 70, 2), Color.Black, Color.Black, 0, Mirror.None);
        _mainSurface.Print(40, 3, $"{playerStats.Carnation}", Color.Violet);
        _mainSurface.Print(63, 5, $"{playerStats.Crit}", Color.Violet);
        _mainSurface.Print(44, 7, $"{playerStats.Health}", Color.Violet);
        _mainSurface.Print(43, 9, $"{playerStats.Strenght}", Color.Violet);
        _mainSurface.Print(47, 11, $"{playerStats.Armor}", Color.Violet);
        PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Block", 50);
        PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Agility", 25);
        _mainSurface.Print(13, 18, "Postac gotowa do gry, wcisnij enter aby kontynuowac!");

        int[] rgb = playerStats.CarnationRGBcode;
        Color color = new Color(rgb[0], rgb[1], rgb[2]);
        DrawingTools.DrawAvatar(_mainSurface, color);


        Children.Add(_mainSurface);
    }
    public override bool ProcessKeyboard(SadConsole.Input.Keyboard keyboard)
    {
        bool handled = false;

        if(keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter))
        {

            SadConsole.Game.Instance.Screen = new DefaultViewScreen();

        }
        return handled;
    }
}