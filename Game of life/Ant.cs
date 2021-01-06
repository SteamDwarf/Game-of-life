using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_life
{
    class Ant
    {
        private int[,] stepsFalse = { { 1, 0, -1, 0 }, { 0, 1, 0, -1 } };
        private int[,] stepsTrue = { { -1, 0, 1, 0 }, { 0, -1, 0, 1 } };
        
        private int x;
        private int y; 
        private int count;
        private int status;

        public Ant(int x, int y)
        {
            this.x = x;
            this.y = y;
            count = 0;
            status = 0;

        }

        private void Switch(bool [,] field)
        {
            int columns = field.GetLength(0);
            int rows = field.GetLength(1);
            int[] output = new int[2];

            if (status == 0)
            {
                x = (x + stepsFalse[0, count] + columns) % columns;
                y = (y + stepsFalse[1, count] + rows) % rows;

            } else if (status == 1)
            {
                x = (x + stepsTrue[0, count] + columns) % columns;
                y = (y + stepsTrue[1, count] + rows) % rows;
            }

        }

        public void AntRun(bool[,] field)
        {

            if(count > 3)
            {
                count = 0;
            }

            if (!field[x, y] && status == 0)
            {
                field[x, y] = true;
                status = 0;

            } else if (!field[x, y] && status == 1)
            {
                field[x, y] = true;
                status = 1;
            }
            else if (field[x, y] && status == 1)
            {
                field[x, y] = false;
                status = 0;

            }
            else if (field[x, y] && status == 0)
            {
                field[x, y] = false;
                status = 1;
            }

            Switch(field);

            count++;

        }

        public int[] GetAntCordinates()
        {
            int[] cordinates = new int[2];
            cordinates[0] = x;
            cordinates[1] = y;
            return cordinates;
        }

    }
}
