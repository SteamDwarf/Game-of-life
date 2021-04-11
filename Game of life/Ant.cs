using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_life
{
    interface IAnt
    {
        void Switch();
        void AntRun();
        int[] GetAntCordinates();
    }
    class Ant : IAnt
    {
        private int[,] stepsFalse = { { 1, 0, -1, 0 }, { 0, 1, 0, -1 } };
        private int[,] stepsTrue = { { -1, 0, 1, 0 }, { 0, -1, 0, 1 } };
        private int x;
        private int y; 
        private int status;
        private int count;
        private bool[,] field;

        public Ant(int x, int y, bool[,] field)
        {   
            this.x = x;
            this.y = y;
            this.field = field;
            status = 0;
            count = 0;
        }

        //Метод, отвечающий за расчет новых координат муравья
        public void Switch()
        {
            int columns = field.GetLength(0);
            int rows = field.GetLength(1);

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

        //Метод, отвечающий за смену состояния муравья и окрашивание клетки
        public void AntRun()
        {
            if (count > 3)
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

            Switch();
            count++;
        }


        //Получение текущих координат муравья
        public int[] GetAntCordinates()
        {
            int[] cordinates = new int[2];
            cordinates[0] = x;
            cordinates[1] = y;
            return cordinates;
        }

    }
}
