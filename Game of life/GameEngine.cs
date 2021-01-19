using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game_of_life
{
    class GameEngine
    {
        private bool[,] field;
        private int columns;
        private int rows;
        private int density;
        private Ant[,] ants;
        private Random random = new Random();

        public GameEngine(int columns, int rows, int density)
        {
            this.columns = columns;
            this.rows = rows;
            this.density = density;

            field = new bool[columns, rows];
        }

        //Заполнение матрицы поля значениями true и false
         public void FieldFooling()
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x , y] = random.Next(density) == 0;

                    /*if ((x *y) % 22 != 0)
                    {
                        field[1, y] = true;

                    } else
                    {
                        field[0, y] = true;
                    }*/

                    /*field[x, (rows / 2)] = true;
                    field[columns / 2, y] = true;*/

                    /*if ((4 * x + y) != 0)
                    {
                        field[1, y] = true;
                    } else
                    {
                        field[0, y] = true;
                    }*/

                }
            }
        }

        //Подсчет количества соседей для каждой клетки
        private int CountNeighbours(int x, int y)
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

        //Расчет следующего поколения клеток: расчет новой матриц, с учетом подсчета соседей клеток
        public void CellGeneration()
        {
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

                    }
                    else if (hasLife && neighbours < 4 && neighbours > 1)
                    {
                        newField[x, y] = true;

                    }
                    else
                    {
                        newField[x, y] = false; 
                    }
                }
            }

            field = newField;
        }

        //Получение матрицы следующего поколения клеток
        public bool[,] GetGeneration()
        {
            bool[,] newGeneration = new bool[columns, rows];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    newGeneration[x, y] = field[x, y];
                }
            }

            return newGeneration;
        }

        //Заполнение матрицы, содержащую объекты класса Ant
        public void AntCreating(int density)
        {
            ants = new Ant[density, density];

            for (int x = 0; x < ants.GetLength(0); x++)
            {
                for (int y = 0; y < ants.GetLength(1); y++)
                {
                    int xAnt = (random.Next(columns) + columns) % columns;
                    int yAnt = (random.Next(rows) + rows) % rows;

                    Ant ant = new Ant(xAnt, yAnt, field);

                    ants[x, y] = ant;
                }
            }
        }

        //Запуск действий муравья
        public void AntStart()
        {
            for (int x = 0; x < ants.GetLength(0); x++)
            {
                for (int y = 0; y < ants.GetLength(1); y++)
                {
                    Ant ant = ants[x, y];
                    ant.AntRun();
                }
            }
        }

        //Получение матрицы, содержащую объекты Ant
        public Ant[,] GetAnts()
        {
            int columns = ants.GetLength(0);
            int rows = ants.GetLength(1);

            Ant[,] antsCopy = new Ant[columns, rows];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    antsCopy[x, y] = ants[x, y];
                }
            }
            return antsCopy;
        }

        //Проверка координат, не выходят ли они за диапазон индексов матрицыы
        public bool ValidationCordinates(int x, int y)
        {
            return x >= 0 && y >= 0 && x < columns && y < rows;
        }

        //Метод, меняющий значения клетки
        private void ChangingCell(int x, int y, bool change)
        {
            if (ValidationCordinates(x, y))
            {
                field[x, y] = change;
            }
        }
        //Метод, отвечающий за добавление клетке значения true
        public void AddCell(int x, int y)
        {
            ChangingCell(x, y, true);
        }

        //Метод, отвечающий за добавление клетке значения false
        public void RemoveCell(int x, int y)
        {
            ChangingCell(x, y, false);
        }
    }
}
