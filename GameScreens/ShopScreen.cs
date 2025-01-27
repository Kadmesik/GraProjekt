using SadConsole.Input;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SadConsoleGame.Scenes
{
    class ShopScreen : ScreenObject
    {
        private ScreenSurface _mainSurface;

        int selectedOption = 5;
        const int maxOptions = 23;

        public class Item
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int Crit { get; set; }
            public int Strength { get; set; }
            public int Health { get; set; }
            public int Armor { get; set; }
            public int Agility { get; set; }
            public int Block { get; set; }
            public bool IsBought { get; set; }
            public Item(string name, int price, int crit, int strength, int health, int armor, int agility, int block, bool isBought)
            {
                Name = name;
                Price = price;
                Crit = crit;
                Strength = strength;
                Health = health;
                Armor = armor;
                Agility = agility;
                Block = block;
                IsBought = isBought;
            }
        }

        private List<Item> items;
        private string filePath = "./Data/shop_items.json";
        public ShopScreen()
        {
            items = LoadItems();
            PlayerStats playerStats = PlayerStats.LoadFromJson("./Data/playerstats.json");
            LoadItems();
            IsFocused = true;
            _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);
            Children.Add(_mainSurface);
            _mainSurface.Print(11, 1, "Witaj w sklepie!", Color.Violet);
            _mainSurface.Print(3, 2, "Wcisnij enter by zakupic przedmiot.", Color.Violet);

            _mainSurface.DrawBox(new Rectangle(40, 1, 38, 23), ShapeParameters.CreateStyledBox(ICellSurface.ConnectedLineThin, new ColoredGlyph(Color.Violet, Color.Black)));
            
            _mainSurface.Print(4, 23, "Wroc do menu gry", Color.White);

            for(int i = 0; i<9; i++)
            {
                if(items[i].IsBought == false)
                {
                    _mainSurface.Print(4, 5+(i*2), items[i].Name, Color.White);
                }
                else
                {
                    _mainSurface.Print(4, 5+(i*2), items[i].Name, Color.Gray);
                }

            }
        }

        public override bool ProcessKeyboard(Keyboard keyboard)
        {
            bool handled = false;
            PlayerStats playerStats = PlayerStats.LoadFromJson("./Data/playerstats.json");
            LoadItems();

            _mainSurface.Print(11, 3, $"Ilosc zlota: {playerStats.Gold} ", Color.Yellow);

            if(items[0].IsBought == true)
                {
                    _mainSurface.Print(4, 5, items[0].Name, Color.Gray);
                }
            if(items[1].IsBought == true)
                {
                    _mainSurface.Print(4, 7, items[1].Name, Color.Gray);
                }
            if(items[2].IsBought == true)
                {
                    _mainSurface.Print(4, 9, items[2].Name, Color.Gray);
                }
            if(items[3].IsBought == true)
                {
                    _mainSurface.Print(4, 11, items[3].Name, Color.Gray);
                }
            if(items[4].IsBought == true)
                {
                    _mainSurface.Print(4, 13, items[4].Name, Color.Gray);
                }
            if(items[5].IsBought == true)
                {
                    _mainSurface.Print(4, 15, items[5].Name, Color.Gray);
                }
            if(items[6].IsBought == true)
                {
                    _mainSurface.Print(4, 17, items[6].Name, Color.Gray);
                }
            if(items[7].IsBought == true)
                {
                    _mainSurface.Print(4, 19, items[7].Name, Color.Gray);
                }
            if(items[8].IsBought == true)
                {
                    _mainSurface.Print(4, 21, items[8].Name, Color.Gray);
                }


           int itemIndex = (selectedOption-5)/2;

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Down))
            {
                ChangeSelection(1);
            }
            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Up))
            {
                ChangeSelection(-1);
            }

            if(selectedOption != 23) {DisplayItemDescription(itemIndex); }

            if(selectedOption == 23)
            {
                _mainSurface.Fill(new Rectangle(41, 2, 36, 21), Color.Black, Color.Black, 0, Mirror.None);

            }

            if (keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter) && selectedOption != 23)
            {
                if(playerStats.Gold >= items[itemIndex].Price && items[itemIndex].IsBought == false)
                {
                    playerStats.Gold -= items[itemIndex].Price;
                    items[itemIndex].IsBought = true;
                    if(items[itemIndex].Crit > 0){playerStats.Crit += items[itemIndex].Crit;}
                    if(items[itemIndex].Strength > 0){playerStats.Strenght += items[itemIndex].Strength;}
                    if(items[itemIndex].Health > 0){playerStats.Health += items[itemIndex].Health;}
                    if(items[itemIndex].Armor > 0){playerStats.Armor += items[itemIndex].Armor;}
                    if(items[itemIndex].Agility > 0){playerStats.Agility += items[itemIndex].Agility;}
                    if(items[itemIndex].Block > 0){playerStats.Block += items[itemIndex].Block;}

                    PlayerStats.UpdateStat("./Data/playerstats.json", "Strenght", playerStats.Strenght);
                    PlayerStats.UpdateStat("./Data/playerstats.json", "Armor", playerStats.Armor);
                    PlayerStats.UpdateStat("./Data/playerstats.json", "Crit", playerStats.Crit);
                    PlayerStats.UpdateStat("./Data/playerstats.json", "Health", playerStats.Health);
                    PlayerStats.UpdateStat("./Data/playerstats.json", "Gold", playerStats.Gold);
                    PlayerStats.UpdateStat("./Data/playerstats.json", "Agility", playerStats.Agility);
                    PlayerStats.UpdateStat("./Data/playerstats.json", "Block", playerStats.Block);

                    UpdateItem(itemIndex);
                }
            }
            if(selectedOption == 23 && keyboard.IsKeyPressed(SadConsole.Input.Keys.Enter))
            {
                SadConsole.Game.Instance.Screen = new DefaultViewScreen();
            }

            return handled;
        }
        private void ChangeSelection(int direction)
        {
            selectedOption += direction * 2;
            if (selectedOption > maxOptions) selectedOption = 5;
            if (selectedOption < 5) selectedOption = maxOptions;

            _mainSurface.Fill(new Rectangle(2, 0, 1, maxOptions+10), Color.White, Color.Black, 0, Mirror.None);
            _mainSurface.Print(2, selectedOption, ">");
        }
        private void DisplayItemDescription(int itemIndex)
        {
            _mainSurface.Fill(new Rectangle(41, 2, 36, 21), Color.Black, Color.Black, 0, Mirror.None);
            int position = 2;
            if(items[itemIndex].Crit > 0){ _mainSurface.Print(41, position, $"Dodatkowy kryt: {items[itemIndex].Crit}", Color.White); position += 2; }
            if(items[itemIndex].Strength > 0){ _mainSurface.Print(41, position, $"Dodatkowa sila: {items[itemIndex].Strength}", Color.White); position += 2; }
            if(items[itemIndex].Health > 0){ _mainSurface.Print(41, position, $"Dodatkowe zycie: {items[itemIndex].Health}", Color.White); position += 2; }
            if(items[itemIndex].Armor > 0){ _mainSurface.Print(41, position, $"Dodatkowy pancerz: {items[itemIndex].Armor}", Color.White); position += 2; }
            if(items[itemIndex].Agility > 0){ _mainSurface.Print(41, position, $"Dodatkowa zwinnosc: {items[itemIndex].Agility}", Color.White); position += 2; }
            if(items[itemIndex].Block > 0){ _mainSurface.Print(41, position, $"Dodatkowy blok: {items[itemIndex].Block}", Color.White); position += 2;}
            _mainSurface.Print(41, position, $"Cena przedmiotu: ", Color.White);
            _mainSurface.Print(58, position, $"{items[itemIndex].Price}", Color.Yellow);
            position = 2;
        }

        public List<Item> LoadItems()
        {
        if (File.Exists(filePath))
        {
            // Wczytujemy dane z pliku JSON
            string json = File.ReadAllText(filePath);
            items = JsonConvert.DeserializeObject<List<Item>>(json) ?? new List<Item>();
        }
        else
        {
            // Tworzymy domyślną listę przedmiotów, jeśli plik nie istnieje
            // 1nazwa, 2cena, 3kryt, 4sila, 5zycie, 6pancerz, 7zwinnosc, 8blok
            items = new List<Item>
            {
                new Item("Ciern", 4000, 0, 0, 25, 35, 0, 0, false),
                new Item("Ostrze Nieskonczonosci", 2000, 30, 25, 0, 0, 0, 0, false),
                new Item("Laczki Judasza", 1000, 0, 0, 4, 0, 35, 0, false),
                new Item("Stalowe Serce", 1400, 0, 0, 0, 0, 30, 0, false),
                new Item("Plaszcz Negacji", 2300, 0, 0, 10, 0, 0, 10, false),
                new Item("Ostrze zniszczonego krola", 1800, 10, 20, 0, 0, 0, 0, false),
                new Item("obsydianowy tasak", 3200, 10, 0, 10, 0, 10, 0, false),
                new Item("helm wojownika", 1000, 0, 5, 10, 0, 0, 0, false),
                new Item("nagolenniki", 500, 5, 5, 5, 5, 5, 5, false),
                new Item("nwm", 0, 0, 0, 0, 0, 0, 0, false), // Notka dla przyszłego mnie: nie usuwaj bo się psuje XD
            };
            // Tworzymy plik z domyślnymi danymi
            SaveItemsToFile();
        }

        return items;
    }

    private void SaveItemsToFile()
    {
        string json = JsonConvert.SerializeObject(items, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public void UpdateItem(int itemIndex)
    {
            items[itemIndex].IsBought = true;
            SaveItemsToFile();
    }
    }
}