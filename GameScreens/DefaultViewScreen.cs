using SadConsole.Input;
namespace SadConsoleGame.Scenes;

class DefaultViewScreen : ScreenObject
{
    private ScreenSurface _mainSurface;
    private int firstOption = 6;
    private int lastOption = 14;
    private int selectedOption = 6;

    public DefaultViewScreen()
    {
        IsFocused = true;

        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        _mainSurface.Print(23, firstOption, "> Zawalcz z przeciwnikami na arenie");

        _mainSurface.Print(25, 8, "Pojdz do sklepu");

        _mainSurface.Print(25, 10, "Odwiedz medrca");

        _mainSurface.Print(25, 12, "Sprawdz ekwipunek oraz statystyki");

        _mainSurface.Print(25, lastOption, "Wroc do glownego menu");

        

        Children.Add(_mainSurface);
    }

    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;

        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Down))
        {
            _mainSurface.Fill(new Rectangle(23, 6, 1, lastOption - firstOption + 1), Color.White, Color.Black, 0, Mirror.None);
            if(selectedOption == lastOption)
            {
                selectedOption = firstOption;
                _mainSurface.Print(23, selectedOption, ">");
            }
            else
            {
                selectedOption += 2;
                _mainSurface.Print(23, selectedOption, ">");  
            }
        }
        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Up))
        {
            _mainSurface.Fill(new Rectangle(23, 6, 1, lastOption-firstOption+1), Color.White, Color.Black, 0, Mirror.None);
            if(selectedOption == firstOption)
            {
                selectedOption = lastOption;
                _mainSurface.Print(23, selectedOption, ">");
            }
            else
            {
                selectedOption -= 2;
                _mainSurface.Print(23, selectedOption, ">");  
            }
        }
        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter))
        {
            switch(selectedOption)
            {
                case 6:
                    SadConsole.Game.Instance.Screen = new ArenaScreen();
                    break;
                case 8:

                    break;
                case 10:

                    break;
                case 12:
                    SadConsole.Game.Instance.Screen = new CharacterInspectionScreen();
                    break;
                case 14:
                    SadConsole.Game.Instance.Screen = new MenuScreen();
                    break;
            }

        }
        return handled;
    }

    
}