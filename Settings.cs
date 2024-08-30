namespace guia_practica_three
{
    public enum Direction
    {
        NONE,
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    internal class Settings
    {
        public static int Width { get; set; } = 20;
        public static int Height { get; set; } = 20;
        public static Direction direction { get; set; }
        public static bool gameOver { get; set; }
    }
}
