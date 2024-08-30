using System.Runtime;

namespace guia_practica_three
{
    public partial class Form1 : Form
    {
        private int x;
        private int y;

        private int score;
        private int maxWidth;
        private int maxHeight;
        private int gameSpeed = 100;

        private Circle food = new Circle();
        private List<Circle> Snake = new List<Circle>();


        public Form1()
        {
            InitializeComponent();

            new Settings();

            maxWidth = this.ClientSize.Width / Settings.Width;
            maxHeight = this.ClientSize.Height / Settings.Height;

            StartGame();
        }

        private void StartGame() {
            lblGameOver.Visible = false;
            lblScore.Visible = true;
            lblScore.Text = "Puntuación: 0";
            label1.Visible = true;

            timermov.Interval = gameSpeed;
            timermov.Tick += UpdateScreen;
            timermov.Start();

            Snake.Clear();
            Circle head = new Circle { X = maxWidth / 2, Y = maxHeight / 2 };
            Snake.Add(head);

            Settings.direction = Direction.NONE;

            GenerateFood();
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (Settings.gameOver)
            {
                timermov.Stop();
                lblGameOver.Visible = true;
                lblGameOver.Text = "¡Has perdido! Presiona Enter para reiniciar.";
            }
            else {
                if(Settings.direction != Direction.NONE)
                {
                    MovePlayer();
                }

                this.Invalidate();
            }
        }

        private void MovePlayer()
        {
            int count = Snake.Count - 1;

            for (int i = count; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.RIGHT: Snake[i].X++; break;
                        case Direction.LEFT: Snake[i].X--; break;
                        case Direction.UP: Snake[i].Y--; break;
                        case Direction.DOWN: Snake[i].Y++; break;
                    }

                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X >= maxWidth || Snake[i].Y >= maxHeight)
                    {
                        Settings.gameOver = true;
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            Settings.gameOver = true;
                        }
                    }

                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        Eat();
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void Eat()
        {
            Circle circle = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(circle);
            score += 10;
            lblScore.Text = "Puntuación: " + score;
            GenerateFood();
        }

        private void GenerateFood() {
            int x = new Random().Next(0, maxWidth);
            int y = new Random().Next(0, maxHeight);

            food = new Circle { X = x, Y = y };

            // Asegurarse de que la comida no aparezca sobre la serpiente
            foreach (var part in Snake)
            {
                if (part.X == food.X && part.Y == food.Y)
                {
                    GenerateFood();
                    break;
                }
            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColor;

            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColor = Brushes.Black;
                }
                else
                {
                    snakeColor = Brushes.Green;
                }

                canvas.FillEllipse(snakeColor, new Rectangle(Snake[i].X * Settings.Width, Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));
                canvas.FillEllipse(Brushes.Red, new Rectangle(food.X * Settings.Width, food.Y * Settings.Height, Settings.Width, Settings.Height));
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right: 
                    if(Settings.direction != Direction.LEFT)
                    {
                        Settings.direction = Direction.RIGHT;
                    }
                    break;
                case Keys.Left:
                    if (Settings.direction != Direction.RIGHT)
                    {
                        Settings.direction = Direction.LEFT;
                    }
                    break;
                case Keys.Up:
                    if (Settings.direction != Direction.DOWN)
                    {
                        Settings.direction = Direction.UP;
                    }
                    break;
                case Keys.Down:
                    if (Settings.direction != Direction.UP)
                    {
                        Settings.direction = Direction.DOWN;
                    }
                    break;
                case Keys.Enter:
                    label1.Visible = false;
                    if (Settings.gameOver)
                    {
                        StartGame();
                        score = 0;                        
                        Settings.gameOver = false;
                    }
                    break;
            }
        }
    }
}
