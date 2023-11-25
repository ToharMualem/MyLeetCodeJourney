using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney.Graph
{
    internal class NumberOfIslands
    {
        public NumberOfIslands() { }

        public int NumIslands(char[][] grid)
        {
            int numberOfIslands = 0;

            bool[,] scannedLand = new bool[grid.Length, grid[0].Length];
            for(int i=0; i<scannedLand.GetLength(0);  i++)
            {
                for(int j=0; j<scannedLand.GetLength(1); j++)
                {
                    scannedLand[i, j] = false;
                }
            }

            for(int i=0; i<grid.Length; i++)
            {
                for(int j=0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1' && !scannedLand[i,j])
                    {
                        numberOfIslands++;
                        scannedLand[i,j] = true;
                        ScanLand(grid, i, j, scannedLand);
                    }
                }

            }

            return numberOfIslands;
        }


        public void ScanLand(char[][] grid, int i, int j, bool[,] scanned)
        {
            // Area variables
            int[,] nearPoints = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

            for(int nearIterate=0; nearIterate<nearPoints.GetLength(0); nearIterate++)
            {
                int xVal = i + nearPoints[nearIterate, 0];
                int yVal = j + nearPoints[nearIterate, 1];

                if ((xVal >= 0 && yVal >= 0) && (xVal < grid.Length && yVal < grid[0].Length))
                {
                    if (grid[xVal][yVal] == '1' && !scanned[xVal, yVal])
                    {
                        scanned[xVal, yVal] = true;
                        ScanLand(grid, xVal, yVal, scanned);
                    }
                }
            }
        }


    }
}
