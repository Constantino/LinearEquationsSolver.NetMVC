using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montante
{
    public class Montante
    {
        /// <summary>
        /// Solves linear equations system by Montante's method
        /// </summary>
        /// <param name="input">Input matrix</param>
        /// <returns>Array of results</returns>
        public double[] SolveByMontante(double[,] input)
        {
            int order = 3;
            double[] results = new double[order];

            //Divide the first matrix iteration by 1
            double lastPivot = 1;
            //Iterates through rows, order times
            for (int x = 0; x < order; x++)
            {
                //Gets current pivot
                double pivot = input[x, x];
                //Iterates through rows to get the determinants
                for (int i = 0; i < order; i++)
                {
                    //Iterates through columns to get the determinants
                    for (int j = 0; j < order + 1; j++)
                    {
                        //If one element is equal to zero, it adds a 0.000001 value to avoid division by zero
                        if (input[i, j] == 0)
                        {
                            input[i, j] = 0.000001;
                        }

                        //Considers all elements different to the column and row of the pivot
                        if (i != x && j != x)
                        {
                            //Gets the determinant for each element based on the pivot
                            input[i, j] = (pivot * input[i, j] - input[x, j] * input[i, x]) / lastPivot;

                        }
                    }
                    //Makes elements in pivot's column equal to zero
                    if (i != x)
                    {
                        input[i, x] = 0;
                    }

                }
                //Current pivot becomes the last pivot for the next iteration
                lastPivot = pivot;

            }

            //Gets the value for each variable
            for (int i = 0; i < order; i++)
            {
                results[i] = Math.Round(input[i, order] / input[i, i],2);
            }

            return results;
        }

        /// <summary>
        /// Prints the matrix provided in console
        /// </summary>
        /// <param name="input">Input matrix</param>
        /// <param name="order">Matrix order</param>
        public void printMatrix(double[,] input, int order)
        {
            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order + 1; j++)
                {
                    double value = input[i, j];
                    Console.Write(" | " + value);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
