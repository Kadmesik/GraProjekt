using SadConsole.Input;

namespace SadConsoleGame.Scenes;

class AchievementsScreen : ScreenObject
{
    private ScreenSurface _mainSurface;

    public AchievementsScreen()
    {
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        _mainSurface.Print(5, 3, "OSIAGNIECIA", Color.Yellow);
        _mainSurface.Print(5, 5, "1. Pierwsze uruchomienie gry");
        _mainSurface.Print(5, 6, "2. Pokonanie pierwszego przeciwnika");
        _mainSurface.Print(5, 7, "3. Ukończenie pierwszego zadania");
        _mainSurface.Print(5, 9, "Nacisnij ESC, aby wrocic do menu.");

        Children.Add(_mainSurface);
    }

    public override bool ProcessKeyboard(Keyboard keyboard)
    {
        bool handled = false;

        if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Escape))
        {

        SadConsole.Game.Instance.Screen = new MenuScreen();

        }
        return handled;
    }
}