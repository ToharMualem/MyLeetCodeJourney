using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyLeetCodeJourney
{
    /*
     * Exercise 934:
     * You are given an n x n binary matrix grid where 1 represents land and 0 represents water.
     * 
     * An island is a 4-directionally connected group of 1's not connected to any other 1's. There are exactly two islands in grid.
     * 
     * You may change 0's to 1's to connect the two islands to form one island.
     * 
     * Return the smallest number of 0's you must flip to connect the two islands.
     */
    internal class ShortestBridge
    {
        private Queue<Tuple<int, int>> placesQueue = new Queue<Tuple<int, int>>();

        public ShortestBridge() { }

        public int ShortestBridgeSolution(int[][] grid)
        {
            placesQueue.Clear();

            //Iterate through grid until encountering an island
            int islandRow = 0;
            int islandCol = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < cols; col++)
                {
                    if (grid[col][row] == 1)
                    {
                        islandCol = col;
                        islandRow = row;
                        placesQueue.Enqueue(new Tuple<int, int>(islandCol, islandRow));
                        break;
                    }
                }
            }
            //Initialize a matrix of visited places
            bool[,] visited = new bool[cols, rows];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    visited[col, row] = false;
                }
            }
            visited[islandCol, islandRow] = true;

            //Initialize a matrix of distances from first island.
            int[,] distances = new int[cols, rows];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    distances[col, row] = -1;
                }
            }
            distances[islandCol, islandRow] = 0;


            //Insert all island points into placesQueue
            TraverseIsland(grid, islandRow, islandCol, distances, visited);

            //Breadth-First Scanning the grid.
            while(placesQueue.Count > 0)
            {
                Tuple<int, int> currentPlace = placesQueue.Dequeue();
                int currentPlaceValue = grid[currentPlace.Item1][currentPlace.Item2];
                int[] colMoves = { 1, 0, -1, 0 };
                int[] rowMoves = { 0, 1, 0, -1 };
                for (int moveIndex = 0; moveIndex < colMoves.Length; moveIndex++)
                {
                    int colNeighbor = currentPlace.Item1 + colMoves[moveIndex];
                    int rowNeighbor = currentPlace.Item2 + rowMoves[moveIndex];
                    if (colNeighbor < 0 || colNeighbor >= grid.Length || rowNeighbor < 0 || rowNeighbor >= grid.Length)
                    {
                        continue;
                    }

                    if (visited[colNeighbor, rowNeighbor])
                    { 
                        continue;
                    }
                    visited[colNeighbor, rowNeighbor] = true;

                    //It means that we met the second island, because we already traversed the first island
                    if (grid[colNeighbor][rowNeighbor] == 1)
                    {
                        return distances[currentPlace.Item1, currentPlace.Item2];
                    }
                    else
                    {
                        distances[colNeighbor, rowNeighbor] = distances[currentPlace.Item1, currentPlace.Item2] + 1;
                    }

                    placesQueue.Enqueue(new Tuple<int, int>(colNeighbor, rowNeighbor));
                }
            }
            
           
            //In case we have not encountered the second island.
            return -1;
        }

        /// <summary>
        /// Traversing through the first island and updating distances, visited, and placesQuaue with initial values.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        private void TraverseIsland(int[][] grid, int col, int row, int[,] distances, bool[,] visited)
        {
            int[] colMoves = { 1, 0, -1, 0 };
            int[] rowMoves = { 0, 1, 0, -1 };
            for (int moveIndex = 0; moveIndex < colMoves.Length; moveIndex++)
            {
                int colNeighbor = col + colMoves[moveIndex];
                int rowNeighbor = row + rowMoves[moveIndex];
                if (colNeighbor < 0 || colNeighbor >= grid.Length || rowNeighbor < 0 || rowNeighbor >= grid.Length)
                {
                    continue;
                }

                if (visited[colNeighbor, rowNeighbor])
                {
                    continue;
                }

                if (grid[colNeighbor][rowNeighbor] == 1)
                {
                    distances[colNeighbor, rowNeighbor] = 0;
                    visited[colNeighbor, rowNeighbor] = true;
                    placesQueue.Enqueue(new Tuple<int, int>(colNeighbor, rowNeighbor));
                    TraverseIsland(grid, colNeighbor, rowNeighbor, distances, visited);
                }
            }
        }
    }
}
