using SadConsoleGame.Tools;

namespace SadConsoleGame.Scenes;

class CharacterCreatorScreen2 : ScreenObject
{
    private ScreenSurface _mainSurface;
    private int Slider = 5;
    public CharacterCreatorScreen2()
    {
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        DrawingTools.DrawBlankAvatarPlace(_mainSurface);

        PlayerStats playerStats = PlayerStats.LoadFromJson(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json");
        int[] rgb = playerStats.CarnationRGBcode;
        Color color = new Color(rgb[0], rgb[1], rgb[2]);
        DrawingTools.DrawAvatar(_mainSurface, color);

        _mainSurface.Print(40, 3, $"{playerStats.Carnation}", Color.Violet);
        _mainSurface.Fill(new Rectangle(20, 20, 20, 2), Color.White, Color.Gray, 0, Mirror.None);
        _mainSurface.Fill(new Rectangle(40, 20, 20, 2), Color.White, Color.White, 0, Mirror.None);

        Children.Add(_mainSurface);
    }

    public override bool ProcessKeyboard(SadConsole.Input.Keyboard keyboard)
        {

            _mainSurface.Print(20, 19, $"Kryt: {Slider}");
            _mainSurface.Print(52, 19, $"Zycie: {10 - Slider}");
            bool handled = false;

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Right))
            {
                if (Slider < 9)
                {
                    _mainSurface.Fill(new Rectangle(20 + (Slider * 4), 20, 4, 2), Color.White, Color.Gray, 0, Mirror.None);
                    Slider++;
                }
            }

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Left))
            {
                if (Slider > 1)
                {
                    _mainSurface.Fill(new Rectangle(16 + (Slider * 4), 20, 4, 2), Color.White, Color.White, 0, Mirror.None);
                    Slider--;
                }
            }

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter))
            {

                _mainSurface.Print(30, 22, $"Zatwierdzono! Kryt: {Slider}, Zycie: {10-Slider}");

                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Crit", Slider);
                PlayerStats.UpdateStat(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json", "Health", 10-Slider);

                SadConsole.Game.Instance.Screen = new CharacterCreatorScreen3();

            }

            return handled;
        }
}