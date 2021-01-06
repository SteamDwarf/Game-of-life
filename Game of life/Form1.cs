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
            butStop.Enabled = true;

            resolution = (int)nudResolution.Value;
            decimal density = nudDensity.Maximum + nudDensity.Minimum - nudDensity.Value;

            gameEngine = new GameEngine
            (pictureBox.Width / resolution, 
             pictureBox.Width / resolution, 
             (int)density
            );
            gameEngine.FieldFooling();

            timer.Start();
            timer1.Start();
        }

        private void CellDrawing()
        {
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);
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
        }

        public void StopGame()
        {
            if (!timer.Enabled)
                return;
            timer.Stop();
            nudDensity.Enabled = true;
            nudResolution.Enabled = true;
        }


        public void ManualMode()
        {
            timer.Stop();

            resolution = (int)nudResolution.Value;
            butStop.Enabled = true;
            butManualStart.Enabled = true;

            gameEngine = new GameEngine
            (pictureBox.Width / resolution,
             pictureBox.Width / resolution,
             (int)nudDensity.Value
            );

            //pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            //graphics = Graphics.FromImage(pictureBox.Image);
            //graphics.Clear(Color.LemonChiffon);

            timer1.Start();
        }

        private void AntMode()
        {
            resolution = (int)nudResolution.Value;

            gameEngine = new GameEngine
           (pictureBox.Width / resolution,
            pictureBox.Width / resolution,
            (int)nudDensity.Value
           );

            timerAnt.Start();
        }

        private void AntDrawing()
        {
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);
            graphics.Clear(Color.LemonChiffon);

            bool[,] generation = gameEngine.GetGeneration();
            int[] antCoordinates = gameEngine.GetAntCoordinates();

            for (int x = 0; x < generation.GetLength(0); x++)
            {
                for (int y = 0; y < generation.GetLength(1); y++)
                {
                    bool hasLife = generation[x, y];

                    if (hasLife)
                    {
                        graphics.FillRectangle(Brushes.YellowGreen, x * resolution, y * resolution, resolution, resolution);

                    } else if (generation[antCoordinates[0], antCoordinates[1]])
                    {
                        graphics.FillRectangle(Brushes.Brown, x * resolution, y * resolution, resolution, resolution);
                    }

                }
            }

            pictureBox.Refresh();
        }

        private void butStartClick(object sender, EventArgs e)
        {
            StartGame();
        }

        private void timerTick(object sender, EventArgs e)
        {
            gameEngine.CellGeneration();
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

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;

                gameEngine.AddCell(x, y);
            }
        }

        private void butManualModeClick(object sender, EventArgs e)
        {
            ManualMode();
        }

        private void butManualStartClick(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer1Tick(object sender, EventArgs e)
        {
            CellDrawing();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            butStop.Enabled = false;
            butManualStart.Enabled = false;
        }

        private void timerAnt_Tick(object sender, EventArgs e)
        {
            gameEngine.AntStart();
            CellDrawing();
        }

        private void butAnt_Click(object sender, EventArgs e)
        {
            AntMode();
        }
    }
}
