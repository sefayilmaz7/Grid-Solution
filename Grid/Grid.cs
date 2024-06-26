using System;
using System.Collections.Generic;

namespace AliceGames.Core
{
    [Serializable]
    public class Grid
    {
        public List<Row> RowList;

        public int Width;
        public int Height;
        public float CellSize;

        public Grid(int w, int h, float cellSize = 1f)
        {
            RowList = new List<Row>();
            Width = w;
            Height = h;
            CellSize = cellSize;

            Initialize();
        }

        public void Initialize()
        {
            for (int y = 0; y < Height; y++)
            {
                Row newRow = new Row(y);
                RowList.Add(newRow);

                for (int x = 0; x < Width; x++)
                {
                    Cell newCell = new Cell(x, y);
                    newRow.CellList.Add(newCell);
                }
            }
        }

        public List<Cell> GetAllCells()
        {
            List<Cell> allCells = new List<Cell>();

            foreach(Row row in RowList)
            {
                allCells.AddRange(row.CellList);
            }

            return allCells;
        }

        public List<Cell> GetAllNeighbours(Cell cell, bool includeCrossNeighbours = true)
        {
            List<Cell> neighbours = new List<Cell>();

            int up = cell.Y + 1;
            int left = cell.X - 1;
            int down = cell.Y - 1;
            int right = cell.X + 1;

            if(up < RowList.Count) neighbours.Add(RowList[up].CellList[cell.X]);
            if(left >= 0) neighbours.Add(RowList[cell.Y].CellList[left]);
            if(down >= 0) neighbours.Add(RowList[down].CellList[cell.X]);
            if(right < Width) neighbours.Add(RowList[cell.Y].CellList[right]);

            if(includeCrossNeighbours)
            {
                if(up < RowList.Count && right < Width) neighbours.Add(RowList[up].CellList[right]);
                if(up < RowList.Count && left >= 0) neighbours.Add(RowList[up].CellList[left]);
                if(down >= 0 && left >= 0) neighbours.Add(RowList[down].CellList[left]);
                if(down >= 0 && right < Width) neighbours.Add(RowList[down].CellList[right]);
            }

            return neighbours;
        }

        public Row AddNewRow()
        {
            int currentCount = RowList.Count;
            Row newRow = new Row(currentCount);
            RowList.Add(newRow);

            for (int x = 0; x < Width; x++)
            {
                Cell newCell = new Cell(x, currentCount);
                newRow.CellList.Add(newCell);
            }

            return newRow;
        }

        public Cell GetCellByItem(ItemBase item)
        {
            if(UninitializedOrEmptyRowOrColumnList() || CoordinateIsOutsideGrid(item.X, item.Y))
                return null;

            return RowList[item.Y].CellList[item.X];
        }

        public Cell GetCellByCoordinates(int x, int y)
        {
            if(UninitializedOrEmptyRowOrColumnList() || CoordinateIsOutsideGrid(x, y))
                return null;
            
            return RowList[y].CellList[x];
        }

        public Cell GetCellByIndex(int index)
        {
            if(UninitializedOrEmptyRowOrColumnList())
                return null;

            int widthOfFirstRow = RowList[0].CellList.Count;
            int allCellsCount = RowList.Count * widthOfFirstRow;

            if(index < 0 || index >= allCellsCount)
                return null;

            int x = index % widthOfFirstRow;
            int y = index / widthOfFirstRow;

            if(CoordinateIsOutsideGrid(x, y))
                return null;

            return RowList[y].CellList[x];
        }

        public int GetIndexByCell(Cell cell)
        {
            if(UninitializedOrEmptyRowOrColumnList() || CoordinateIsOutsideGrid(cell.X, cell.Y))
                return -1;

            int index = RowList[0].CellList.Count * cell.Y + cell.X;
            return index;
        }

        public bool UninitializedOrEmptyRowOrColumnList()
        {
            return GridIsUninitializedOrEmpty() || RowList[0].CellListIsUninitializedOrEmpty();
        }

        public bool CoordinateIsOutsideGrid(int x, int y)
        {
            return y >= RowList.Count || y < 0 || x >= Width || x < 0;
        }

        public bool GridIsUninitializedOrEmpty()
        {
            return RowList == null || RowList.Count <= 0;
        }
    }
}
