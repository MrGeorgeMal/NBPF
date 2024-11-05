using NBPF.Blueprint;
using NBPF.NBPFClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPF.Calculation
{
    public class GridMethod
    {

        private List<List<Cell>> _matrix = new List<List<Cell>>();
        
        private List<BPObject> _elements;
        public GridMethod(List<BPObject> elements)
        {
            _elements = elements;
        }
        public float _stepX = 0.1f;
        public float _stepY = 0.1f;

        




        public void SplitIntoAreas()//Переименовать в дискретизацию
        {
            BPScreen screen = new BPScreen();
            Debug.WriteLine("SplitIntoAreas_Done");
            //foreach (BPObject element in _elements)
            //{
            //    Debug.WriteLine(element);
            //}

            foreach (BPObject element in _elements)
            {
                if (element is BPScreen )
                {
                    screen = (BPScreen)element;
                }
            }
            int cols = (int)Math.Round((double)(screen.ActualWidth/_stepX));
            int rows = (int)Math.Round((double)(screen.ActualHeight / _stepY));

           
            for (int i = 0; i < rows; i++)
            {
               _matrix.Add(new List<Cell>());
                for (int j = 0; j < cols; j++)
                {
                    Cell temp = new Cell(); // Элементы которыми заполнена матрица
                    _matrix[i].Add(temp);
                }
            }

            // Вывод матрицы в коносль
            //for (int i = 0; i < rows; i++)
            //{
               
            //    for (int j = 0; j < cols; j++)
            //    {
            //        Debug.Write(_matrix[i][j]+ " ");
                    
            //    }
            //    Debug.WriteLine(" ");
            }

            //foreach (BPObject element in _elements)



        }




    }
}
