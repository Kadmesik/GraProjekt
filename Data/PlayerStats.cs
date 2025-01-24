using System;
using System.IO;
using System.Text.Json;

namespace SadConsoleGame.Scenes;
public class PlayerStats
    {
        
        public string Carnation { get; set; }
        public int Crit { get; set; }
        public int Strenght { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int[] CarnationRGBcode { get; set; }
        public int Experience { get; set; }
        public int Gold { get; set; }
        public int Agility { get; set;}
        public int Level { get; set;}
        public int Block { get; set;}

        public void SaveToJson(string filePath)
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static PlayerStats LoadFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new PlayerStats();
            }

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<PlayerStats>(json);
        }
            public static void UpdateStat(string filePath, string statName, object newValue)
            {
                PlayerStats stats;

                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    stats = JsonSerializer.Deserialize<PlayerStats>(json) ?? new PlayerStats();
                }
                else
                {
                    stats = new PlayerStats(); 
                }

                switch (statName)
                {
                    case "Gold":
                        stats.Gold = Convert.ToInt32(newValue);
                        break;
                    case "Block":
                        stats.Block = Convert.ToInt32(newValue);
                        break;
                    case "Level":
                        stats.Level = Convert.ToInt32(newValue);
                        break;
                    case "Agility":
                        stats.Agility = Convert.ToInt32(newValue);
                        break;
                    case "Crit":
                        stats.Crit = Convert.ToInt32(newValue);
                        break;
                    case "Strenght":
                        stats.Strenght = Convert.ToInt32(newValue);
                        break;
                    case "Health":
                        stats.Health = Convert.ToInt32(newValue);
                        break;
                    case "Armor":
                        stats.Armor = Convert.ToInt32(newValue);
                        break;
                    case "Experience":
                        stats.Experience = Convert.ToInt32(newValue);
                        break;
                    case "Carnation":
                        stats.Carnation = newValue.ToString();
                        break;
                    case "CarnationRGBcode":
                    if (newValue is Color color)
                    {
                        stats.CarnationRGBcode = new int[] { color.R, color.G, color.B };
                    }
                    break;
                    default:
                        throw new ArgumentException($"Nieznana statystyka: {statName}");
                }

                stats.SaveToJson(filePath);
        }
    }