
namespace SadConsoleGame.Tools
{
    public static class DrawingTools
    {
        public static void DrawFilledCircle(int centerX, int centerY, int radius, Color fillColor, ScreenSurface surface)
        {
            for (int x = centerX - radius; x <= centerX + radius; x++)
            {
                for (int y = centerY - radius; y <= centerY + radius; y++)
                {
                    if ((x - centerX) * (x - centerX) + (y - centerY) * (y - centerY) <= radius * radius)
                    {
                        surface.Print(x, y, " ", fillColor, fillColor);
                    }
                }
            }
        }

        public static void DrawAvatar(ScreenSurface surface, Color selectedColor)
        {
            surface.Fill(new Rectangle(0, 0, 25, 15), Color.White, Color.White, 0, Mirror.None);
            surface.Fill(new Rectangle(4, 10, 17, 5), selectedColor, selectedColor, 0, Mirror.None);
            surface.Fill(new Rectangle(9, 9, 7, 1), selectedColor, selectedColor, 0, Mirror.None);
            
            DrawFilledCircle(12, 5, 5, selectedColor, surface);
            
            surface.Fill(new Rectangle(14, 4, 2, 1), Color.Black, Color.Black, 0, Mirror.None);
            surface.Fill(new Rectangle(9, 4, 2, 1), Color.Black, Color.Black, 0, Mirror.None);
        }

        public static void DrawBlankAvatarPlace(ScreenSurface surface)
        {
            //_mainSurface.Fill(new Rectangle(10, 16, 30, 2), Color.Black, Color.Black, 0, Mirror.None);
            surface.Fill(new Rectangle(0, 0, 25, 15), Color.White, Color.White, 0, Mirror.None);
            surface.Print(30, 1, "Stworz swoja postac! ");
            surface.Print(30, 3, "Karnacja: ");
            surface.Print(30, 5, "Punkty szansy ciosu krytycznego: ");
            surface.Print(30, 7, "Punkty zycia: ");
            surface.Print(30, 9, "Punkty sily: ");
            surface.Print(30, 11, "Punkty pancerza: ");
            surface.Print(10, 16, "Uzywaj prawej i lewej strzalki by zmieniac parametry statystyk!");
            surface.Print(25, 17, "Wcisnij enter aby zatwierdzic zmiany");

        }
        public static void DrawAvatarbg(ScreenSurface surface)
        {
            surface.Fill(new Rectangle(0, 0, 25, 15), Color.White, Color.White, 0, Mirror.None);
        }
        public static void DrawMonster(ScreenSurface surface, Color color, int posx, int posy)
        {

        }
        public static void DrawHero(ScreenSurface surface, Color color, int posx, int posy)
        {
            surface.Fill(new Rectangle(6+posx, 0+posy, 3, 1), Color.Black, color, 0, Mirror.None);
            surface.Fill(new Rectangle(8+posx, 0+posy, 1, 9), Color.Black, color, 0, Mirror.None);
            surface.Fill(new Rectangle(7+posx, 3+posy, 3, 1), Color.Black, color, 0, Mirror.None);
            surface.Fill(new Rectangle(6+posx, 8+posy, 1, 3), Color.Black, color, 0, Mirror.None);
            surface.Fill(new Rectangle(9+posx, 4+posy, 1, 3), Color.Black, color, 0, Mirror.None);
            surface.Fill(new Rectangle(8+posx, 8+posy, 1, 2), Color.Black, color, 0, Mirror.None);
            surface.Fill(new Rectangle(9+posx, 9+posy, 1, 2), Color.Black, color, 0, Mirror.None);
            surface.Fill(new Rectangle(5+posx, 4+posy, 1, 2), Color.Black, color, 0, Mirror.None);
        }
    }
}