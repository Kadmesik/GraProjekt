using SadConsole.Input;
namespace SadConsoleGame.Scenes;

class WiseManScreen : ScreenObject
{
    private ScreenSurface _mainSurface;

    public WiseManScreen()
    {
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);


        Children.Add(_mainSurface);
    }

    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;


        return handled;
    }
}