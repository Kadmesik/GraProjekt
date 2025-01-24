using SadConsole.Input;
namespace SadConsoleGame.Scenes;

class InstructionScreen : ScreenObject
{
    private ScreenSurface _mainSurface;

    public InstructionScreen()
    {
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        _mainSurface.Print(35, 2, "INSTRUKCJA", Color.Yellow);
        _mainSurface.Print(15, 5, "1. By zmieniac dostepne opcje wystarczy uzyc strzalek.");
        _mainSurface.Print(15, 7, "2. Enter zatwierdza wybrana opcje.");
        _mainSurface.Print(15, 9, "3. info dotyczace statystyk znajdziesz w grze.");
        _mainSurface.Print(15, 11, " Nacisnij Enter, aby wrocic do menu.");


        Children.Add(_mainSurface);
    }

    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;

        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter))
        {

        SadConsole.Game.Instance.Screen = new MenuScreen();

        }
        return handled;
    }
}