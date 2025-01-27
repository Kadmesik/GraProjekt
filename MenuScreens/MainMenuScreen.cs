using SadConsole.Input;
namespace SadConsoleGame.Scenes;

class MenuScreen : ScreenObject
{
    private ScreenSurface _mainSurface;
    private int firstOption = 6;
    private int lastOption = 12;
    private int selectedOption = 6;

    public MenuScreen()
    {
        IsFocused = true;

        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        _mainSurface.Print(31, 2, "Witaj w WarForge!", Color.Gold);

        _mainSurface.Print(29, firstOption, "> Zacznij nowa gre");

        _mainSurface.Print(31, 8, "Wczytaj stan gry");

        _mainSurface.Print(31, 10, "Instrukcja");

        _mainSurface.Print(31, lastOption, "Wyjdz");

        

        Children.Add(_mainSurface);
    }

    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;

        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Down))
        {
            _mainSurface.Fill(new Rectangle(29, 6, 1, lastOption - firstOption + 1), Color.White, Color.Black, 0, Mirror.None);
            if(selectedOption == lastOption)
            {
                selectedOption = firstOption;
                _mainSurface.Print(29, selectedOption, ">");
            }
            else
            {
                selectedOption += 2;
                _mainSurface.Print(29, selectedOption, ">");  
            }
        }
        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Up))
        {
            _mainSurface.Fill(new Rectangle(29, 6, 1, lastOption-firstOption+1), Color.White, Color.Black, 0, Mirror.None);
            if(selectedOption == firstOption)
            {
                selectedOption = lastOption;
                _mainSurface.Print(29, selectedOption, ">");
            }
            else
            {
                selectedOption -= 2;
                _mainSurface.Print(29, selectedOption, ">");  
            }
        }
        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter))
        {
            switch(selectedOption)
            {
                case 6:
                    SadConsole.Game.Instance.Screen = new CharacterCreatorScreen1();
                    break;
                case 8:
                    SadConsole.Game.Instance.Screen = new LoadGameScreen();
                    break;
                case 10:
                    SadConsole.Game.Instance.Screen = new InstructionScreen();
                    break;
                case 12:
                    Environment.Exit(0);
                    break;
            }

        }
        return handled;
    }
}