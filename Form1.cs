namespace guia_practica_three
{
    public partial class Form1 : Form
    {
        enum Posicion
        {
            Arriba,
            Abajo,
            Izquierda,
            Derecha
        }

        private int x;
        private int y;
        private Posicion posicion;


        public Form1()
        {
            InitializeComponent();

            x = 50;
            y = 50;

            posicion = Posicion.Abajo;
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(new Bitmap("birrete.png"), x, y, 65, 65);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                posicion = Posicion.Derecha;
            }
            else if (e.KeyCode == Keys.Left)
            {
                posicion = Posicion.Izquierda;
            }
            else if (e.KeyCode == Keys.Up)
            {
                posicion = Posicion.Arriba;
            }
            else if (e.KeyCode == Keys.Down)
            {
                posicion = Posicion.Abajo;
            }
        }

        private void timermov_Tick(object sender, EventArgs e)
        {
            if(posicion == Posicion.Derecha) {
                x += 10;
            }
            else if (posicion == Posicion.Izquierda)
            {
                x -= 10;
            }
            else if (posicion == Posicion.Arriba)
            {
                y -= 10;
            }
            else if (posicion == Posicion.Abajo)
            {
                y += 10;
            }

            Invalidate();
        }
    }
}
