using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPF.Analysis
{
    public class GridMethod
    {
        /// <summary>
        /// перечислить все параметры методом сеток
        /// </summary>
        public int NLowSize;
        public double eps;
        public double dx, dy;
        public int J, I, H1, H2, H3, W1, W2, D, T1, T2, T3, T4, T5, T6, T7;
        public StripStructure strip;
        public List<List<double>> field;

        public GridMethod(StripStructure strip) 
        {
            this.strip = strip;
        }
        
        public void Calculation(double leftU, double rightU, bool isAir)
        {
            Discretization();

            field = new List<List<double>>();
            
            // Создание двумерной матрицы, заполненой нулями
            for (int j = 0; j < J; j++)
            {
                field.Add(new List<double>());
                for (int i = 0; i < I; i++)
                {
                    field[j].Add(0);
                }
            }

            for (int j = 0; j < J; j++)
            {
                for (int i = 0; i < I; i++)
                {
                    if (j >= H1 + H2 && j <= H1 + H2 + W2 )
                    {
                        field[j][T2] = leftU;
                    }
                }
            }

        }

        public void Discretization()
        {
            dx = Math.Floor(strip.minSize / NLowSize * 10) / 10;
            dy = dx;
            J = (int)Math.Floor((strip.h1 + strip.h2 + strip.h4) / dx);
            I = (int)Math.Floor(strip.a / dx);
            H1 = (int)Math.Floor(strip.h1 / dx);
            H2 = (int)Math.Floor(strip.h2 / dx);
            H3 = (int)Math.Floor(strip.h3 / dx);
            W1 = (int)Math.Floor(strip.w1 / dx);
            W2 = (int)Math.Floor(strip.w2 / dx);
            D = (int)Math.Floor(strip.d / dx);
            T3 = (int)Math.Floor((double)I / 2);
            T1 = T3 -  (int)Math.Floor((double)H3 / 2) - W1;
            T2 = T1 + W1;
            T4 = T3 + (int)Math.Floor((double)H3 / 2);
            T5 = T4 + W1;
            T6 = (int)Math.Floor((double)I / 2 - (double)D / 2);
            T7 = (int)Math.Floor((double)I / 2 - (double)D / 2);


        }
    }
}
