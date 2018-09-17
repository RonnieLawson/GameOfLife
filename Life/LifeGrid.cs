using System.Collections.Generic;

namespace GameofLifeDojo
{
    public class LifeGrid
    {
        private int GetCellLiveNeighboursCount(int x, int y)
        {
            var count = 0;

            if (x > 0)
            {
                if (y > 0 && _grid[x - 1, y - 1])
                    count++;

                if (_grid[x - 1, y])
                    count++;

                if (y < _rowsCount - 1 && _grid[x - 1, y + 1])
                    count++;
            }


            if (y > 0 && _grid[x, y - 1])
                count++;



            if (y < _rowsCount - 1 && _grid[x, y + 1])
                count++;


            if (x < _columnsCount - 1)
            {
                if (y > 0 && _grid[x + 1, y - 1])
                    count++;

                if (_grid[x + 1, y])
                    count++;

                if (y < _rowsCount - 1 && _grid[x + 1, y + 1])
                    count++;
            }

            return count;
        }

        private readonly int _columnsCount;
        private readonly int _rowsCount;
        private static bool[,] _grid;

        public LifeGrid(int columnsCount, int rowsCount)
        {
            _columnsCount = columnsCount;
            _rowsCount = rowsCount;
            _grid = new bool[_columnsCount, _rowsCount];
        }

        public void Seed(int x, int y)
        {
            _grid[x, y] = true;
        }

        public bool[,] Generate()
        {
            var newGrid = new bool[_columnsCount, _rowsCount];

            for(int i = 0; i < _columnsCount; i++)
            {
                for (int j = 0; j < _columnsCount; j++)
                {
                    var neighboursCount = GetCellLiveNeighboursCount(i, j);
                    newGrid[i, j] = _grid[i, j] ? neighboursCount > 1 && neighboursCount < 4 : neighboursCount == 3;
                }
            }

            _grid = newGrid;
            return _grid;
        }

        public IEnumerable<string> GetRows(char truechar, char falsechar)
        {
            List<string> rows = new List<string>();
            for (var i = 0; i < _rowsCount; i++)
            {
                string row = "";
                for (var j = 0; j < _columnsCount; j++)
                {
                    row = row +( _grid[j, i] ? truechar : falsechar);
                }
                rows.Add(row);
            }

            return rows;
        }

        public bool GetCell(int x, int y)
        {
            return _grid[x, y];
        }
    }
}