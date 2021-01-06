using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_life
{
    class Ant
    {
        //Лабиринт от муравья
        //private int[,] stepsFalse = { { 1, 0, -1, 0 }, { 0, -1, 0, 1 } };
        //private int[,] stepsTrue = { { -1, 0, 1, 0 }, { 0, 1, 0, -1 } };

        //Уже близко
        //private int[,] stepsFalse = { { 1, 0, -1, 0 }, { 0, -1, 0, 1 } };
        //private int[,] stepsTrue = { { -1, -1, 0, 1 }, { 0, 0, 1, 0 } };

        private int[,] stepsFalse = { { 1, 0, -1, 0 }, { 0, 1, 0, -1 } };
        private int[,] stepsTrue = { { -1, 0, 1, 0 }, { 0, -1, 0, 1 } };

        private int[] Switch(int x, int y, int count, int status, bool [,] field)
        {
            int columns = field.GetLength(0);
            int rows = field.GetLength(1);
            int[] output = new int[3];

            if (status == 0)
            {
                x = (x + stepsFalse[0, count] + columns) % columns;
                y = (y + stepsFalse[1, count] + rows) % rows;

            } else if (status == 1)
            {
                x = (x + stepsTrue[0, count] + columns) % columns;
                y = (y + stepsTrue[1, count] + rows) % rows;
            }

            output[0] = x;
            output[1] = y;
            output[2] = status;

            return output;

        }

        public int[] AntRun(int status, int count, bool[,] field, int[] coordinates)
        {

            int x = coordinates[0];
            int y = coordinates[1];
            int newStatus = status;

            if (!field[x, y] && newStatus == 0)
            {
                field[x, y] = true;
                newStatus = 0;
            } else if (!field[x, y] && status == 1)
            {
                field[x, y] = true;
                newStatus = 1;
            }
            else if (field[x, y] && status == 1)
            {
                field[x, y] = false;
                newStatus = 0;

            }
            else if (field[x, y] && status == 0)
            {
                field[x, y] = false;
                newStatus = 1;
            }

            int[] output = Switch(x, y, count, newStatus, field);
            return output;
        }
            

            /*
            if (!field[x, y])
            {
                field[x, y] = true;
                x = (x + stepsFalse[0, count] + columns) % columns;
                y = (y + stepsFalse[1, count] + rows) % rows;

            }
            else if (field[x, y])
            {
                field[x, y] = false;
                x = (x + stepsTrue[0, count] + columns) % columns;
                y = (y + stepsTrue[1, count] + rows) % rows;

            }

            newCoordinates[0] = x;
            newCoordinates[1] = y;

            return newCoordinates;
        }*/

        /*
        private int AntSwitch(int x, int y, int count, bool[,] field)
        {
            int newCount = count;

            if (!field[x, y])
            {
                newCount -= 1;
            }
            else
            {
                newCount += 1;
            }

            if (newCount > 3)
            {
                newCount = 0;
            }
            if (newCount < 0)
            {
                newCount = 3;
            }

            return newCount;
        }

        public int[] AntRun(int count, bool[,] field, int[] coordinates)
        {
            int x = coordinates[0];
            int y = coordinates[1];

            int[] newCoordinates = new int[3];

            int newCount = AntSwitch(x, y, count, field);

            switch (newCount)
            {
                case 0:
                    {
                        y -= 1;
                    }
                    break;
                case 1:
                    {
                        x -= 1;
                    }
                    break;
                case 2:
                    {
                        y += 1;
                    }
                    break;
                case 3:
                    {
                        x += 1;
                    }
                    break;

            }

            newCoordinates[0] = x;
            newCoordinates[1] = y;
            newCoordinates[2] = newCount;

            return newCoordinates;
        }
        */
    }
}
