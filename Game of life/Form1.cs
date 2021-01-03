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
        private GameEngine gameEngine;

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

            gameEngine = new GameEngine
            (pictureBox.Width / resolution, 
             pictureBox.Width / resolution, 
             (int)nudDensity.Value
            );

            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);
            timer.Start();
        }

        private void CellDrawing()
        {
            graphics.Clear(Color.LemonChiffon);

            bool[,] generation = gameEngine.GetGeneration();

            for (int x = 0; x < generation.GetLength(0); x++)
            {
                for (int y = 0; y < generation.GetLength(1); y++)
                { 
                    bool hasLife = generation[x, y];

                    if (hasLife)
                    {
                        graphics.FillRectangle(Brushes.YellowGreen, x * resolution, y * resolution, resolution, resolution);
                    }
                }
            }

            pictureBox.Refresh();
            gameEngine.CellGeneration();
        }

        public void StopGame()
        {
            if (!timer.Enabled)
                return;
            timer.Stop();
            nudDensity.Enabled = true;
            nudResolution.Enabled = true;
        }


        /*public void ManualChanging(int x, int y)
        {

        }*/

        private void butStartClick(object sender, EventArgs e)
        {
            StartGame();
        }

        private void timerTick(object sender, EventArgs e)
        {
            CellDrawing();
        }

        private void butStopClick(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                StopGame();  
            } else
            {
                timer.Start();
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;

                gameEngine.AddCell(x, y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;

                gameEngine.RemoveCell(x, y);
            }
        }
    }
}
