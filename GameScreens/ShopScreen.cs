using SadConsole.Input;
namespace SadConsoleGame.Scenes;

class ShopScreen : ScreenObject
{
    private ScreenSurface _mainSurface;

    int firstOption = 1;
    int selectedOption = 1;
    int lastOption = 24;

    public ShopScreen()
    {
        PlayerStats playerStats = PlayerStats.LoadFromJson(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json");
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);


        Children.Add(_mainSurface);
    }
    public override bool ProcessKeyboard(Keyboard keyboard)
        {
        bool handled = false;
        PlayerStats playerStats = PlayerStats.LoadFromJson(@"F:\Informatyka\C#\GraProjekt\Data\playerstats.json");

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Down))
            {
                _mainSurface.Fill(new Rectangle(2, 0, 1, lastOption - firstOption + 7), Color.White, Color.Black, 0, Mirror.None);
                if(selectedOption == lastOption)
                {
                    selectedOption = firstOption;
                    _mainSurface.Print(2, selectedOption, ">");
                }
                else
                {
                    selectedOption += 2;
                    _mainSurface.Print(2, selectedOption, ">");  
                }
            }
            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Up))
            {
                _mainSurface.Fill(new Rectangle(2, 0, 1, lastOption-firstOption+10), Color.White, Color.Black, 0, Mirror.None);
                if(selectedOption == firstOption)
                {
                    selectedOption = lastOption;
                    _mainSurface.Print(2, selectedOption, ">");
                }
                else
                {
                    selectedOption -= 2;
                    _mainSurface.Print(2, selectedOption, ">");  
                }
            }
                switch(selectedOption)
                {
                    case 1:
                        
                    break;
                    case 3:
                        
                    break;
                    case 5:
                        
                    break;
                    case 7:
                        
                    break;
                    case 9:
                        
                    break;
                    case 11:
                        
                    break;
                    case 13:
                        
                    break;
                    case 15:
                        
                    break;
                    case 17:
                        
                    break;
                    case 19:
                        
                    break;
                    case 21:
                        
                    break;
                    case 23:
                        
                    break;
            }
            if(keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter) && selectedOption == 23)
            {
                SadConsole.Game.Instance.Screen = new DefaultViewScreen();
            }
            return handled;
        }
}