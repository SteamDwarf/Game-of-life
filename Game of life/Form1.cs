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

        //Настройка графической части: настройка pictureBox и graphics
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

            gameEngine = new GameEngine(
                pictureBox.Width / resolution,
                pictureBox.Height / resolution,
                (int)density);          
        }

        //Отрисовка клеток с значение true
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

        //Отрисовка клеток с значением true, и муравьев
        private void AntDrawing()
        {
            SetGraphics();

            bool[,] generation = gameEngine.GetGeneration();
            Ant[,] ants = gameEngine.GetAnts();

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

            for (int x = 0; x < ants.GetLength(0); x++)
            {
                for (int y = 0; y < ants.GetLength(1); y++)
                {
                    Ant ant = ants[x, y];
                    int[] antCordinates = ant.GetAntCordinates();
                    int xAnt = antCordinates[0];
                    int yAnt = antCordinates[1];

                    graphics.FillRectangle(antColor, xAnt * resolution, yAnt * resolution, resolution, resolution);
 
                }
            }

            pictureBox.Refresh();
        }

        //Метод запускающий игру "Жизнь" со случайной генерацией клеток
        public void StartGame()
        {
            timerAnt.Stop();
            
            nudDensity.Enabled = false;
            nudResolution.Enabled = false;
            butStop.Enabled = true;
            butStopAnt.Enabled = false;
            pictureBox.Enabled = true;

            SetProperties();
            gameEngine.FieldFooling();

            timer.Start();
            timer1.Start();
            
        }

        //Метод перехода в режим редактирования для игры "Жизнь"
        public void ManualMode()
        {
            timerAnt.Stop();
            timer.Stop();

            butStop.Enabled = true;
            butManualStart.Enabled = true;
            butStopAnt.Enabled = false;
            pictureBox.Enabled = true;

            SetProperties();

            timer1.Start();
        }

        //Метод запускающий муравья Лэнгтона
        private void AntMode()
        {
            timer.Stop();
            timer1.Stop();

            int density = (int)nudDensity.Value;

            nudDensity.Enabled = false;
            nudResolution.Enabled = false;
            butStopAnt.Enabled = true;
            butManualStart.Enabled = false;
            butStop.Enabled = false;
            pictureBox.Enabled = true;

            SetProperties();
            gameEngine.AntCreating(density);
            timerAnt.Start();
        }

        //Остановка таймеров игры "Жизнь"
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

        //Изменение интервалов таймеров для всех режимов
        private void TimerSpeedChange()
        {
            if (timer.Interval == 1 && timer1.Interval == 1 && timerAnt.Interval == 1)
            {
                timer.Interval = 20;
                timer1.Interval = 20;
                timerAnt.Interval = 20;
                butTimerSpeedChange.Text = "Быстрая скорость";

            } else if (timer.Interval == 20 && timer1.Interval == 20 && timerAnt.Interval == 20)
            {
                timer.Interval = 50;
                timer1.Interval = 50;
                timerAnt.Interval = 50;
                butTimerSpeedChange.Text = "Средняя скорость";
            }
            else if (timer.Interval == 50 && timer1.Interval == 50 && timerAnt.Interval == 50)
            {
                timer.Interval = 100;
                timer1.Interval = 100;
                timerAnt.Interval = 100;
                butTimerSpeedChange.Text = "Медленная скорость";

            } 
            else if (timer.Interval == 100 && timer1.Interval == 100 && timerAnt.Interval == 100) 
            {
                timer.Interval = 200;
                timer1.Interval = 200;
                timerAnt.Interval = 200;
                butTimerSpeedChange.Text = "Очень медленная скорость";

            } else
            {
                timer.Interval = 1;
                timer1.Interval = 1;
                timerAnt.Interval = 1;
                butTimerSpeedChange.Text = "Очень быстрая скорость";
            }
        }

        //Необходимые продосторожности при запуске приложения: отключение ненужных, на момент запуска, кнопок
        private void Form1_Load(object sender, EventArgs e)
        {
            butStop.Enabled = false;
            butManualStart.Enabled = false;
            butStopAnt.Enabled = false;
            pictureBox.Enabled = false;
        }

        //Кнопка запуска игры "Жизнь" со случайной генерацией клеток
        private void butStartClick(object sender, EventArgs e)
        {
            StartGame();
        }
        //Кнопка перехода в режим редактирования
        private void butManualModeClick(object sender, EventArgs e)
        {
            ManualMode();
        }
        //Кнопка запуска симуляции игры "Жизнь" в режиме редактирования
        private void butManualStartClick(object sender, EventArgs e)
        {
            timer.Start();
        }
        //Кнопка запускающая муравья Лэнгтона
        private void butAnt_Click(object sender, EventArgs e)
        {
            AntMode();
        }
        //Кнопка остановки симуляции для игры "Жизнь"
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
        //Кнопка остановки симуляции муравья Лэнгтона
        private void butStopAnt_Click(object sender, EventArgs e)
        {
            if (timerAnt.Enabled)
            {
                nudDensity.Enabled = true;
                nudResolution.Enabled = true;
                timerAnt.Stop();
            }
            else
            {
                timerAnt.Start();
            }
        }

        //Кнопка изменения интервалов таймеров
        private void butTimerSpeedChange_Click(object sender, EventArgs e)
        {
            TimerSpeedChange();
        }

        //Событие, позволяющее поменять цвет заднего фона для всех режимов
        private void pictureBoxBackColor_Click(object sender, EventArgs e)
        {
            DialogResult colorDialog = colorDialog1.ShowDialog();

            if (colorDialog == DialogResult.OK)
            {
                pictureBoxBackColor.BackColor = colorDialog1.Color;
                backColor = colorDialog1.Color;
            }
        }
        //Событие, позволяющее поменять цвет клеток со значением true для всех режимов
        private void pictureBoxCellFullColor_Click(object sender, EventArgs e)
        {
            DialogResult colorDialog = colorDialog1.ShowDialog();

            if (colorDialog == DialogResult.OK)
            {
                pictureBoxCellFullColor.BackColor = colorDialog1.Color;
                cellFullColor.Color = colorDialog1.Color;
            }
        }
        //Событие, позволяющее поменять цвет муравья
        private void pictureBoxAntColor_Click(object sender, EventArgs e)
        {
            DialogResult colorDialog = colorDialog1.ShowDialog();

            if (colorDialog == DialogResult.OK)
            {
                pictureBoxAntColor.BackColor = colorDialog1.Color;
                antColor.Color = colorDialog1.Color;
            }
        }

        //Событие добавления и удаления значения true для клетки, при проведении мышкой с зажатой кнопкой 
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
        //Событие добавления и удаления значения true для клетки, при нажатии кнопки мыши
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;

                gameEngine.AddCell(x, y);

            } else if (e.Button == MouseButtons.Right)
            {
                int x = e.Location.X / resolution;
                int y = e.Location.Y / resolution;

                gameEngine.RemoveCell(x, y);
            }
        }

        //Генерация нового поколения клеток, при каждом тике таймера
        private void timerTick(object sender, EventArgs e)
        {
            gameEngine.CellGeneration();
        }
        //Отрисовка клеток, при каждом тике таймера
        private void timer1Tick(object sender, EventArgs e)
        {
            CellDrawing();
        }
        //Симуляция и отрисовка муравья, при каждом тике таймера
        private void timerAnt_Tick(object sender, EventArgs e)
        {
            gameEngine.AntStart();
            AntDrawing();
        }
    }
}
