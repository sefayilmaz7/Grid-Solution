using System;
using System.Collections.Generic;

namespace AliceGames.Core
{
    [Serializable]
    public class Row
    {
        public List<Cell> CellList;
        public int Index;

        public Row(int index)
        {
            CellList = new List<Cell>();
            Index = index;
        }

        public bool CellListIsUninitializedOrEmpty()
        {
            return CellList == null || CellList.Count <= 0;
        }
    }
}
