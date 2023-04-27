using _3_en_raya.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_en_raya
{
    public partial class Form1 : Form
    {
        private enum fichas { VACIO, X, O };
        private int turno;
        private _3_en_raya.Form1.fichas[,] tablero;
        private bool finPartida;
        private Button celda;
        private int x;
        private int y;
        private int[] index;


        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            Reset();
            fichas Winner = Ganador();
        }

        private void Reset()
        {
            tablero = new fichas[3, 3];
            lblJugador.Text = String.Empty;
            foreach (Control x in this.Controls)
                if (x is Button)
                    ((Button)x).Image = null;
            finPartida = false;
        }

        private int filaCelda()
        {
            int numCelda = Convert.ToInt32(celda.Name.Substring(3, 1));
            return (numCelda - 1) / 3;
        }

        private int colCelda()
        {
            int numCelda = Convert.ToInt32(celda.Name.Substring(3, 1));
            return (numCelda - 1) % 3;
        }

        private void efectuarTirada()
        {
            if (celda.Image == null && !finPartida)
            {
                if (turno % 2 == 0)
                {
                    celda.Image = Resources.Imagen0;
                    tablero[filaCelda(), colCelda()] = fichas.O;
                    lblJugador.Text = ("Jugador X");
                    pictureBox5.Image = Properties.Resources.Imagenx;

                }
                else
                {
                    celda.Image = Resources.Imagenx;
                    tablero[filaCelda(), colCelda()] = fichas.X;
                    lblJugador.Text = ("Jugador 0");
                    pictureBox5.Image = Properties.Resources.Imagen0;

                }
                fichas ganador = Ganador();
                if (ganador != fichas.VACIO)
                {
                    lblJugador.Text = ganador.ToString();
                    finPartida = true;
                    pictureBox5.Image = null;
                    lblJugador.Text = " ";
                }
                turno++;
            }
        }
        private fichas comprobarFila(int x)
        {
            fichas Player = tablero[x, 0];
            int j = 1;
            for (; j < 3 && tablero[x, j] == Player; j++) ;
            return (j == 3) ? Player : fichas.VACIO;
        }

        private fichas comprobarFilas()
        {
            int i = 0;
            fichas Winner = fichas.VACIO;
            for (; i < 3 && (Winner = comprobarFila(i)) == fichas.VACIO; i++) ;
            return Winner;
        }

        private fichas comprobarCol(int y)
        {
            fichas Player = tablero[0, y];
            int i = 1;
            for (; i < 3 && tablero[i, y] == Player; i++) ;
            return (i == 3) ? Player : fichas.VACIO;
        }

        private fichas comprobarCols()
        {
            int j = 0;
            fichas Winner = fichas.VACIO;
            for (; j < 3 && (Winner = comprobarCol(j)) == fichas.VACIO; j++) ;
            return Winner;
        }

        private fichas comprobarDiagonales()
        {
            int i = 0;
            fichas Player = tablero[0, 0];
            for (; i < 3 && tablero[i, i] == Player; i++) ;
            if (i == 3) return Player;
            i = 0;
            Player = tablero[0, 2];
            for (; i < 3 && tablero[i, 2 - i] == Player; i++) ;
            if (i == 3) return Player;
            return fichas.VACIO;
        }

        private fichas Ganador()
        {
            fichas Winner = Winner = comprobarFilas();
            if (Winner == fichas.VACIO);
                Winner = comprobarCols();
            if (Winner == fichas.VACIO)
                Winner = comprobarDiagonales();


            if (Winner is fichas.X)
            {
                MessageBox.Show("Gana el jugador X.");
            }
            if (Winner is fichas.O)
            {
                MessageBox.Show("Gana el jugador 0.");
            }
            else if (tablero[0, 0] != 0)
            { 
                MessageBox.Show("Tablas. ");
            }
            
            return Winner;
        }

        private void repintar()
        {
            efectuarTirada();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            celda = (Button)sender;
            repintar();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            celda = (Button)sender;
            repintar();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            celda = (Button)sender;
            repintar();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            celda = (Button)sender;
            repintar();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            celda = (Button)sender;
            repintar();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            celda = (Button)sender;
            repintar();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            celda = (Button)sender;
            repintar();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            celda = (Button)sender;
            repintar();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            celda = (Button)sender;
            repintar();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Reset();
            MessageBox.Show("¡Comienza la partida!");
        }
    }
}
    
