using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_life
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private int resolution;
        private bool[,] field;
        private int rows;
        private int columns;

        public Form1()
        {
            InitializeComponent();
        }

        public void StartGame()
        {
            if (timer.Enabled)
                return;

            nudDensity.Enabled = false;
            nudResolution.Enabled = false;

            resolution = (int)nudResolution.Value;
            rows = pictureBox.Height / resolution;
            columns = pictureBox.Width / resolution;
            field = new bool[columns, rows];

            Random random = new Random();
            for (int x = 0; x < columns; x++ )
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next((int)nudDensity.Value) == 0;
                }
            }

            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);
            timer.Start();
        }

        private void CellGeneration()
        {
            graphics.Clear(Color.AliceBlue);

            var newField = new bool[columns, rows];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    int neighbours = CountNeighbours(x, y);
                    bool hasLife = field[x, y];

                    if (!hasLife && neighbours == 3)
                    {
                        newField[x, y] = true;

                    } else if (hasLife && neighbours < 4 && neighbours > 1)
                    {
                        newField[x, y] = true;

                    } else
                    {
                        newField[x, y] = false; ;
                    }

                    if (hasLife)
                    {
                        graphics.FillRectangle(Brushes.YellowGreen, x * resolution, y * resolution, resolution, resolution);
                    }
                }
            }

            field = newField;
            pictureBox.Refresh();
        }

        public void StopGame()
        {
            if (!timer.Enabled)
                return;
            timer.Stop();
            nudDensity.Enabled = true;
            nudResolution.Enabled = true;
        }

        public int CountNeighbours(int x, int y)
        {
            int neighbours = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (x + i + columns) % columns;
                    int row = (y + j + rows) % rows;

                    bool hasLife = field[col, row];
                    bool selfChecking = col == x && row == y;

                    if (hasLife && !selfChecking)
                    {
                        neighbours++;
                    }
                }
            }

            return neighbours;
        }

        private void butStartClick(object sender, EventArgs e)
        {
            StartGame();
        }

        private void timerTick(object sender, EventArgs e)
        {
            CellGeneration();
        }

        private void butStopClick(object sender, EventArgs e)
        {
            StopGame();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
