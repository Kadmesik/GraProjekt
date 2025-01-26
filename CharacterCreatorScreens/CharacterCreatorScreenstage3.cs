using SadConsoleGame.Tools;

namespace SadConsoleGame.Scenes;

class CharacterCreatorScreen3 : ScreenObject
{
    private ScreenSurface _mainSurface;
    private int Slider = 5;
    public CharacterCreatorScreen3()
    {
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        DrawingTools.DrawBlankAvatarPlace(_mainSurface);

        PlayerStats playerStats = PlayerStats.LoadFromJson("./Data/playerstats.json");
        _mainSurface.Print(40, 3, $"{playerStats.Carnation}", Color.Violet);
        _mainSurface.Print(63, 5, $"{playerStats.Crit}", Color.Violet);
        _mainSurface.Print(44, 7, $"{playerStats.Health}", Color.Violet);

        int[] rgb = playerStats.CarnationRGBcode;
        Color color = new Color(rgb[0], rgb[1], rgb[2]);
        DrawingTools.DrawAvatar(_mainSurface, color);


        Children.Add(_mainSurface);
        _mainSurface.Fill(new Rectangle(20, 20, 20, 2), Color.White, Color.Gray, 0, Mirror.None);
        _mainSurface.Fill(new Rectangle(40, 20, 20, 2), Color.White, Color.White, 0, Mirror.None);
    }

    public override bool ProcessKeyboard(SadConsole.Input.Keyboard keyboard)
        {

            _mainSurface.Print(20, 19, $"Sila: {Slider}");
            _mainSurface.Print(50, 19, $"Pancerz: {10 - Slider}");
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

                _mainSurface.Print(27, 22, $"Zatwierdzono! Sila: {Slider}, Pancerz: {10-Slider}");

                PlayerStats.UpdateStat("./Data/playerstats.json", "Strenght", Slider);
                PlayerStats.UpdateStat("./Data/playerstats.json", "Armor", 10-Slider);

                SadConsole.Game.Instance.Screen = new CharacterCreatorSummary();

            }

            return handled;
        }
}