using SadConsoleGame.Tools;

namespace SadConsoleGame.Scenes;

class CharacterCreatorScreen1 : ScreenObject
{
    private ScreenSurface _mainSurface;

    private int Slider = 5;
    int race = 5;

    List<Color> selectedColor = new List<Color> {new Color(54, 29, 17),  new Color(78, 42, 24),  new Color(102, 51, 26), new Color(128, 64, 32), new Color(153, 76, 38), new Color(179, 102, 51), new Color(204, 153, 102), new Color(230, 184, 138), new Color(240, 210, 170), new Color(250, 224, 196)};
    List<String> CarnationName = new List<String> {"Ciemny braz","Braz","Jasny braz","Ciemny karmel","Karmel","Jasny karmel","Ciemny bez","Bez","Jasny bez","Bardzo jasny bez"};

    public CharacterCreatorScreen1()
    {
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        DrawingTools.DrawBlankAvatarPlace(_mainSurface);

        Children.Add(_mainSurface);
        _mainSurface.Fill(new Rectangle(20, 20, 20, 2), Color.White, Color.Gray, 0, Mirror.None);
        _mainSurface.Fill(new Rectangle(40, 20, 20, 2), Color.White, Color.White, 0, Mirror.None);
    }

    public override bool ProcessKeyboard(SadConsole.Input.Keyboard keyboard)
        {
            bool handled = false;

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Right))
            {
                if (Slider < 9)
                {
                    _mainSurface.Fill(new Rectangle(20 + (Slider * 4), 20, 4, 2), Color.White, Color.Gray, 0, Mirror.None);
                    Slider++;
                    race++;
                    DrawingTools.DrawAvatar(_mainSurface, selectedColor[race]);
                }
            }

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Left))
            {
                if (Slider > 1)
                {
                    _mainSurface.Fill(new Rectangle(16 + (Slider * 4), 20, 4, 2), Color.White, Color.White, 0, Mirror.None);
                    Slider--;
                    race--;
                    DrawingTools.DrawAvatar(_mainSurface, selectedColor[race]);
                }
            }

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter))
            {

                _mainSurface.Print(30, 22, $"Zatwierdzono! Karnacja to: {CarnationName[race]}");

                PlayerStats player = new PlayerStats
                {
                Carnation = CarnationName[race],
                };

                if (player.Carnation != null && player.Carnation != "")
                {
                    player.SaveToJson("./Data/playerstats.json");
                }
                else
                {
                    DrawingTools.DrawBlankAvatarPlace(_mainSurface);
                }
                PlayerStats.UpdateStat("./Data/playerstats.json", "CarnationRGBcode", selectedColor[race] );

                SadConsole.Game.Instance.Screen = new CharacterCreatorScreen2();

            }

            return handled;
        }
}