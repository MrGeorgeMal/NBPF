using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon.Primitives;

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
        public double e1, e2, e3, e4;

        public GridMethod(StripStructure strip) 
        {
            this.strip = strip;
            eps = 1e-4;
        }
        
        public void Calculation(double leftU, double rightU, bool isAir)
        {
            Discretization();

            field = new List<List<double>>();
            
            // Создание двумерной матрицы, заполненой нулями
            for (int j = 0; j <= J; j++)
            {
                field.Add(new List<double>());
                for (int i = 0; i <= I; i++)
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
                    if (j >= H1 + H2 && j <= H1 + H2 + W2)
                    {
                        field[j][T4] = rightU;
                    }
                    if (i >= T1 && i <= T2 && j == H1 + H2)
                    {
                        field[H1 + H2][i] = leftU;
                    }
                    if (i >= T4 && i <= T5 && j == H1 + H2)
                    {
                        field[H1 + H2][i] = rightU;
                    }
                }
            }
            if (isAir = false)
            {
                e1 = strip.e1;
                e2 = strip.e2;
                e3 = strip.e3;
                e4 = strip.e4;
            }
            else
            {
                e1 = 1;
                e2 = 1;
                e3 = 1;
                e4 = 1;
            }
            while (true)
            {
                double buffer;
                // message - "расчет левой части" 
                buffer = field[H1 + H2 + 1][T2 - 1];
                for ( int j = H1 - 1; j <= 1; j++ )
                {
                    for ( int i = 1; i <= T3-1; i++)
                    {
                        field[j][i] = 0.25 * (field[j][i - 1] + field[j][i + 1] + field[j - 1][i] + field[j + 1][i]);
                    }
                }
                for (int j = H1 + H2 - 1; j <= H1 + 1; j++)
                {
                    for (int i = T3 - 1; i <= 1; i++)
                    {
                        field[j][i] = 0.25 * (field[j][i - 1] + field[j][i + 1] + field[j - 1][i] + field[j + 1][i]);
                    }
                }
                for (int j = H1 + H2 + 1; j <= H1 + H2 + W2; j++)
                {
                    for (int i = T2 - 1; i <= 1; i++)
                    {
                        field[j][i] = 0.25 * (field[j][i - 1] + field[j][i + 1] + field[j - 1][i] + field[j + 1][i]);
                    }
                }
                for (int j = H1 + H2 + 1; j <= H1 + H2 + W2; j++)
                {
                    for (int i = T2 + 1; i <= T3 - 1; i++)
                    {
                        field[j][i] = 0.25 * (field[j][i - 1] + field[j][i + 1] + field[j - 1][i] + field[j + 1][i]);
                    }
                }
                for (int j = H1 + H2 + W2 + 1; j <= J - 1; j++)
                {
                    for (int i = T3 - 1; i <= 1; i++)
                    {
                        field[j][i] = 0.25 * (field[j][i - 1] + field[j][i + 1] + field[j - 1][i] + field[j + 1][i]);
                    }
                }

                for (int i = T3-1; i<= T6; i++)
                {
                    if (T6 != T7)
                    {
                        field[H1][i] = 0.25 * (field[H1][i - 1] + field[H1][i + 1] + (2 * e1 / (e1 + e2)) * field[H1 - 1][i] + (2 * e2 / (e1 + e2)) * field[H1 + 1][i]);
                    }
                }
                for (int i = T1 - 1; i <= 1; i++)
                {
                    field[H1+H2][i] = 0.25 * (field[H1+H2][i - 1] + field[H1+H2][i + 1] + (2 * e2 / (e2 + e4)) * field[H1 + H2 -1][i] + (2 * e4 / (e2 + e4)) * field[H1 + H2 + 1][i]);
                }
                for (int i = T2 + 1; i <= T3 - 1; i++)
                {
                    field[H1 + H2][i] = 0.25 * (field[H1 + H2][i - 1] + field[H1 + H2][i + 1] + (2 * e2 / (e2 + e3)) * field[H1 + H2 - 1][i] + (2 * e3 / (e2 + e3)) * field[H1 + H2 + 1][i]);
                    field[H1 + H2 + W2][i] = 0.25 * (field[H1 + H2 +W2][i - 1] + field[H1 + H2 +W2][i + 1] + (2 * e3 / (e3 + e4)) * field[H1 + H2 +W2- 1][i] + (2 * e4 / (e3 + e4)) * field[H1 + H2 + W2 + 1][i]);
                }
                // message - "расчет правой части" 

                for (int j = H1 - 1; j <= 1; j++)
                {
                    for (int i = T3 + 1; i <= I - 1; i++)
                    {
                        field[j][i] = 0.25 * (field[j][i - 1] + field[j][i + 1] + field[j - 1][i] + field[j + 1][i]);
                    }
                }
                for (int j = H1 + H2 - 1; j <= H1 + 1; j++)
                {
                    for (int i = T3 + 1; i <= I - 1; i++)
                    {
                        field[j][i] = 0.25 * (field[j][i - 1] + field[j][i + 1] + field[j - 1][i] + field[j + 1][i]);
                    }
                }
                for (int j = H1 + H2 + 1; j <= H1 + H2 + W2; j++)
                {
                    for (int i = T4 + 1; i <= I - 1; i++)
                    {
                        field[j][i] = 0.25 * (field[j][i - 1] + field[j][i + 1] + field[j - 1][i] + field[j + 1][i]);
                    }
                }
                for (int j = H1 + H2 + 1; j <= H1 + H2 + W2; j++)
                {
                    for (int i = T4 - 1; i <= T3 + 1; i++)
                    {
                        field[j][i] = 0.25 * (field[j][i - 1] + field[j][i + 1] + field[j - 1][i] + field[j + 1][i]);
                    }
                }
                for (int j = H1 + H2 + W2 + 1; j <= J - 1; j++)
                {
                    for (int i = T3 + 1; i <= I - 1; i++)
                    {
                        field[j][i] = 0.25 * (field[j][i - 1] + field[j][i + 1] + field[j - 1][i] + field[j + 1][i]);
                    }
                }

                for (int i = T3 + 1; i <= T7; i++)
                {
                    if (T6 != T7)
                    {
                        field[H1][i] = 0.25 * (field[H1][i - 1] + field[H1][i + 1] + (2 * e1 / (e1 + e2)) * field[H1 - 1][i] + (2 * e2 / (e1 + e2)) * field[H1 + 1][i]);
                    }
                }
                for (int i = T5 + 1; i <= I - 1; i++)
                {
                    field[H1 + H2][i] = 0.25 * (field[H1 + H2][i - 1] + field[H1 + H2][i + 1] + (2 * e2 / (e2 + e4)) * field[H1 + H2 - 1][i] + (2 * e4 / (e2 + e4)) * field[H1 + H2 + 1][i]);
                }
                for (int i = T4 - 1; i <= T3 + 1; i++)
                {
                    field[H1 + H2][i] = 0.25 * (field[H1 + H2][i - 1] + field[H1 + H2][i + 1] + (2 * e2 / (e2 + e3)) * field[H1 + H2 - 1][i] + (2 * e3 / (e2 + e3)) * field[H1 + H2 + 1][i]);
                    field[H1 + H2 + W2][i] = 0.25 * (field[H1 + H2 + W2][i - 1] + field[H1 + H2 + W2][i + 1] + (2 * e3 / (e3 + e4)) * field[H1 + H2 + W2 - 1][i] + (2 * e4 / (e3 + e4)) * field[H1 + H2 + W2 + 1][i]);
                }

                // message - "расчет середины" 

                for (int j = 1; j <= J-1; j++)
                {
                    if (j != H1 &&  j != H1 +H2 && j != H1 + H2 + W2)
                    {
                        field[j][T3] = 0.25 * (field[j][T3 - 1] + field[j][T3 + 1] + field[j - 1][T3] + field[j + 1][T3]);
                    }
                    if (j == H1 && T6 != T7)
                    {
                        field[j][T3] = 0.25 * (field[j][T3 - 1] + field[j][T3 + 1] + (2 * e1 / (e1 + e2)) * field[j][T3] + (2 * e1 / (e1 + e2)) * field[j][T3]);
                    }
                    if (j == H1 + H2)
                    {
                        field[j][T3] = 0.25 * (field[j][T3 - 1] + field[j][T3 + 1] + (2 * e2 / (e2 + e3)) * field[j][T3] + (2 * e3 / (e2 + e3)) * field[j][T3]);
                    }
                    if (j == H1 + H2 +W2)
                    {
                        field[j][T3] = 0.25 * (field[j][T3 - 1] + field[j][T3 + 1] + (2 * e3 / (e3 + e4)) * field[j][T3] + (2 * e4 / (e3 + e4)) * field[j][T3]);
                    }
                }

                // message - "проверка на допустимую ошибкой" 
                if (Math.Abs(field[H1 + H2 + 1][T2 - 1] - buffer) < eps)
                {
                    break;
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
