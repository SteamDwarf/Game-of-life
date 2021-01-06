using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_life
{
    class GameEngine
    {
        private bool[,] field;
        private int columns;
        private int rows;
        private int density;
        private int[] antCoordinates = new int[2] {80, 35};
        private int antCount = 0;
        private int status = 0;
        Random random = new Random();
        Ant ant = new Ant();

        public GameEngine(int columns, int rows, int density)
        {
            this.columns = columns;
            this.rows = rows;
            this.density = density;

            field = new bool[columns, rows];
        }

         public void FieldFooling()
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next(density) == 0;
                }
            }
        }

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
                        newField[x, y] = false; ;
                    }
                }
            }

            field = newField;
        }


        public void AntStart()
        {
            int[] output = ant.AntRun(status, antCount, field, antCoordinates);
            int x = output[0];
            int y = output[1];
            status = output[2];

            antCoordinates[0] = x;
            antCoordinates[1] = y;
            antCount++;

            if (antCount > 3)
            {
                antCount = 0;
            }

        }

        public int[] GetAntCoordinates()
        {
            return antCoordinates;
        }

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

        public bool ValidationCoordinates(int x, int y)
        {
            return x >= 0 && y >= 0 && x < columns && y < rows;
        }

        private void ChangingCell(int x, int y, bool change)
        {
            if (ValidationCoordinates(x, y))
            {
                field[x, y] = change;
            }
        }

        public void AddCell(int x, int y)
        {
            ChangingCell(x, y, true);
        } 
        
        public void RemoveCell(int x, int y)
        {
            ChangingCell(x, y, false);
        }
    }
}
