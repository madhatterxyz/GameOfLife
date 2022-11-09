namespace GameOfLife
{
    public class GridManager
    {
        private const int NB_NEIGHBOURS_FOR_CELL_TO_BE_ALIVE = 3;
        private const int NB_NEIGHBOURS_FOR_CELL_TO_SURVIVE = 2;
        public Cell[,] Grid { get; set; }
        public GridManager(int height, int width)
        {
            InitializeGrid(height,width);
        }
        public Cell[,] GetNewState()
        {
            var newGrid = new Cell[Grid.GetLength(0), Grid.GetLength(1)];
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    newGrid[i, j] = new Cell(false);
                }
            }

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    int nbNeighbours = CountNeighbours( i, j);
                    if (nbNeighbours == NB_NEIGHBOURS_FOR_CELL_TO_SURVIVE)
                    {
                        newGrid[i, j].IsAlive = Grid[i, j].IsAlive;
                    }
                    else if (nbNeighbours == NB_NEIGHBOURS_FOR_CELL_TO_BE_ALIVE)
                    {
                        newGrid[i, j].IsAlive = true;
                    }
                }
            }
            return newGrid;
        }

        public int CountNeighbours(int i, int j)
        {
            int nbNeighbours = 0;
            for (int verticalIndex = -1; verticalIndex <= 1; verticalIndex++)
            {
                for (int horizontalIndex = -1; horizontalIndex <= 1; horizontalIndex++)
                {
                    if (!(verticalIndex == 0 && horizontalIndex == 0) &&
                        IsAliveNeighbour( i + verticalIndex, j + horizontalIndex))
                    {
                        nbNeighbours++;
                    }

                }
            }
            return nbNeighbours;
        }

        private bool IsAliveNeighbour(int i, int j)
        {
            return j >= 0 &&
                j < Grid.GetLength(1) &&
                i >= 0 &&
                i < Grid.GetLength(0) &&
                Grid[i, j].IsAlive;
        }
        private void InitializeGrid(int height, int width)
        {
            Grid = new Cell[height, width];
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = new Cell(false);
                }
            }
        }
    }
}