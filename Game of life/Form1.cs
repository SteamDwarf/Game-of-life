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
        private Color backColor = Color.LemonChiffon;
        private SolidBrush cellFullColor = new SolidBrush(Color.YellowGreen);
        private SolidBrush antColor = new SolidBrush(Color.Brown);

        public Form1()
        {
            InitializeComponent();
        }

        private void SetGraphics()
        {
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);
            graphics.Clear(backColor);
        }

        private void SetProperties()
        {
            resolution = (int)nudResolution.Value;
            decimal density = nudDensity.Maximum + nudDensity.Minimum - nudDensity.Value;

            gameEngine = new GameEngine
           (pictureBox.Width / resolution,
            pictureBox.Width / resolution,
            (int)density
           );
        }

        private void CellDrawing()
        {
            SetGraphics();
            
            bool[,] generation = gameEngine.GetGeneration();

            for (int x = 0; x < generation.GetLength(0); x++)
            {
                for (int y = 0; y < generation.GetLength(1); y++)
                { 
                    bool hasLife = generation[x, y];

                    if (hasLife)
                    {
                        graphics.FillRectangle(cellFullColor, x * resolution, y * resolution, resolution, resolution);
                    }
                }
            }

            pictureBox.Refresh();
        }

        private void AntDrawing()
        {
            SetGraphics();

            bool[,] generation = gameEngine.GetGeneration();
            int[] antCoordinates = gameEngine.GetAntCoordinates();
            int xAnt = antCoordinates[0];
            int yAnt = antCoordinates[1];

            for (int x = 0; x < generation.GetLength(0); x++)
            {
                for (int y = 0; y < generation.GetLength(1); y++)
                {
                    bool hasLife = generation[x, y];

                    if (hasLife)
                    {
                        graphics.FillRectangle(cellFullColor, x * resolution, y * resolution, resolution, resolution);

                    }
                    else if (x == xAnt && y == yAnt)
                    {
                        graphics.FillRectangle(antColor, x * resolution, y * resolution, resolution, resolution);
                    }

                }
            }

            pictureBox.Refresh();
        }

        public void StartGame()
        {
            timerAnt.Stop();
            if (timer.Enabled)
                return;

            nudDensity.Enabled = false;
            nudResolution.Enabled = false;
            butStop.Enabled = true;
            butStopAnt.Enabled = false;

            SetProperties();
            gameEngine.FieldFooling();

            timer.Start();
            timer1.Start();
            
        }

        public void ManualMode()
        {
            timerAnt.Stop();
            timer.Stop();

            butStop.Enabled = true;
            butManualStart.Enabled = true;
            butStopAnt.Enabled = false;

            SetProperties();

            timer1.Start();
        }

        private void AntMode()
        {
            timer.Stop();
            timer1.Stop();

            butStopAnt.Enabled = true;
            butManualStart.Enabled = false;

            SetProperties();
            timerAnt.Start();
        }

        public void StopGame()
        {
            if (timer.Enabled)
            {
                timer.Stop();

            } else if (timerAnt.Enabled)
            {
                timerAnt.Stop();
            } 
            
            nudDensity.Enabled = true;
            nudResolution.Enabled = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            butStop.Enabled = false;
            butManualStart.Enabled = false;
            butStopAnt.Enabled = false;
        }

        private void butStartClick(object sender, EventArgs e)
        {
            StartGame();
        }
        private void butManualModeClick(object sender, EventArgs e)
        {
            ManualMode();
        }
        private void butManualStartClick(object sender, EventArgs e)
        {
            timer.Start();
        }
        private void butAnt_Click(object sender, EventArgs e)
        {
            AntMode();
        }
        private void butStopClick(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                StopGame();
            }
            else
            {
                timer.Start();
            }
        }
        private void butStopAnt_Click(object sender, EventArgs e)
        {
            if (timerAnt.Enabled)
            {
                timerAnt.Stop();
            }
            else
            {
                timerAnt.Start();
            }
        }


        private void pictureBoxBackColor_Click(object sender, EventArgs e)
        {
            DialogResult colorDialog = colorDialog1.ShowDialog();

            if (colorDialog == DialogResult.OK)
            {
                pictureBoxBackColor.BackColor = colorDialog1.Color;
                backColor = colorDialog1.Color;
            }
        }
        private void pictureBoxCellFullColor_Click(object sender, EventArgs e)
        {
            DialogResult colorDialog = colorDialog1.ShowDialog();

            if (colorDialog == DialogResult.OK)
            {
                pictureBoxCellFullColor.BackColor = colorDialog1.Color;
                cellFullColor.Color = colorDialog1.Color;
            }
        }
        private void pictureBoxAntColor_Click(object sender, EventArgs e)
        {
            DialogResult colorDialog = colorDialog1.ShowDialog();

            if (colorDialog == DialogResult.OK)
            {
                pictureBoxAntColor.BackColor = colorDialog1.Color;
                antColor.Color = colorDialog1.Color;
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


        private void timerTick(object sender, EventArgs e)
        {
            gameEngine.CellGeneration();
        }
        private void timer1Tick(object sender, EventArgs e)
        {
            CellDrawing();
        }
        private void timerAnt_Tick(object sender, EventArgs e)
        {
            gameEngine.AntStart();
            AntDrawing();
        }

        
    }
}
