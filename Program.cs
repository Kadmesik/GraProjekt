using SadConsole.Configuration;

Settings.WindowTitle = "Gra RPG";

Builder gameStartup = new Builder()
    .SetScreenSize(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
    .SetStartingScreen<SadConsoleGame.Scenes.MenuScreen>()
    .IsStartingScreenFocused(true)
    .ConfigureFonts(true)
    ;

Game.Create(gameStartup);
Game.Instance.Run();
Game.Instance.Dispose();