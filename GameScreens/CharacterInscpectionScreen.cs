using SadConsole.Input;
using SadConsoleGame.Tools;
namespace SadConsoleGame.Scenes;

class CharacterInspectionScreen : ScreenObject
{
    private ScreenSurface _mainSurface;

    int firstOption =5;
    int lastOption =23;
    int selectedOption=5;

    public CharacterInspectionScreen()
    {
        PlayerStats playerStats = PlayerStats.LoadFromJson("./Data/playerstats.json");
        IsFocused = true;
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);

        _mainSurface.Print(3, 2, "Statystyki bohatera!", Color.Violet);

        _mainSurface.Print(2, firstOption, $"> Zycie: {playerStats.Health}");

        _mainSurface.Print(4, 7, $"Sila: {playerStats.Strenght}");

        _mainSurface.Print(4, 9, $"Pancerz: {playerStats.Armor}");

        _mainSurface.Print(4, 11, $"Zwinnosc: {playerStats.Agility}");

        _mainSurface.Print(4, 13, $"Szansa na obrazenia krytyczne: {playerStats.Crit}%");

        _mainSurface.Print(4, 15, $"sila bloku: {playerStats.Block}%");

        _mainSurface.Print(4, 17, $"Zloto: {playerStats.Gold}");

        _mainSurface.Print(4, 19, $"Doswiadczenie: {playerStats.Experience}");

        _mainSurface.Print(4, 21, $"Level: {playerStats.Level}");

        _mainSurface.Print(4, lastOption, "Wyjdz do menu gry ", Color.Red);

        _mainSurface.DrawBox(new Rectangle(40, 1, 38, 23), ShapeParameters.CreateStyledBox(ICellSurface.ConnectedLineThin, new ColoredGlyph(Color.Violet, Color.Black)));



        Children.Add(_mainSurface);
    }

    public override bool ProcessKeyboard(Keyboard keyboard)
    {
    bool handled = false;
    PlayerStats playerStats = PlayerStats.LoadFromJson("./Data/playerstats.json");

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
                case 5:
                    StatisticsDescription.Health(_mainSurface, playerStats.Health);
                    break;
                case 7:
                    StatisticsDescription.Strenght(_mainSurface, playerStats.Strenght);
                    break;
                case 9:
                    StatisticsDescription.Armor(_mainSurface, playerStats.Armor);
                    break;
                case 11:
                    StatisticsDescription.Agility(_mainSurface, playerStats.Agility);
                    break;
                case 13:
                    StatisticsDescription.Crit(_mainSurface, playerStats.Crit);
                    break;
                case 15:
                    StatisticsDescription.Block(_mainSurface, playerStats.Block);
                    break;
                case 17:
                    StatisticsDescription.Gold(_mainSurface, playerStats.Gold);
                    break;
                case 19:
                    StatisticsDescription.Experience(_mainSurface, playerStats.Experience);
                    break;
                case 21:
                    StatisticsDescription.Level(_mainSurface, playerStats.Level);
                    break;
                case 23:
                    _mainSurface.Fill(new Rectangle(41, 2, 36, 21), Color.Black, Color.Black, 0, Mirror.None);
                break;
        }
        if(keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter) && selectedOption == 23)
        {
            SadConsole.Game.Instance.Screen = new DefaultViewScreen();
        }
        return handled;
    }
}