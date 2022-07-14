using System;

namespace LR2
{
    public class Dictionary
    {
        const int initialSize = 16;
        private int currId = 0;
        public Cell[] cells = new Cell[initialSize];
        public void Append(int line, int column, double Appender)
        {
            Cell cell = SearchForCell(line, column);
            if (cell != null)
            {
                cell.value += Appender;
            }
        }
        public Dictionary CopyArray()
        {
            Dictionary newDictionary = new Dictionary
            {
                currId = this.currId
            };
            int a = this.cells.Length;
            Cell[] cellsNew = new Cell[a];
            Array.Copy(cells, cellsNew, a);
            newDictionary.cells = cellsNew;
            return newDictionary;
        }

        public void ModifyValue(int line, int column, double newValue)
        {
            Cell cell = SearchForCell(line, column);
            if (cell != null)
            {
                cell.value = newValue;
            }
            else throw new NullReferenceException("Empty Cell.");
        }
        public Boolean ContainsValueAtPos(int line, int column)
        {
            foreach (Cell cell in cells)
            {
                if (cell == null)
                {
                    continue;
                }
                if (cell.line == line && cell.column == column)
                {
                    return true;
                }
            }
            return false;
        }
        private Cell SearchForCell(int line, int column)
        {
            foreach (Cell cell in cells)
            {
                if (cell == null)
                {
                    continue;
                }
                if (cell.line == line && cell.column == column)
                {
                    return cell;
                }
            }
            return null;
        }
        public void CopyValueAt(int fromLine, int fromColumn, int toLine, int toColumn)
        {
            Cell cell = SearchForCell(fromLine, fromColumn);
            if (cell == null)
            {
                throw new NullReferenceException("Empty cell.");
            }
            Cell copiedCell = cell.GetCopy();
            if (toLine == fromLine || toColumn==fromColumn)
            {
                throw new NotImplementedException();
            }
            copiedCell.line = toLine;
            copiedCell.column = toColumn;
            AddCell(copiedCell);
        }
        public double GetAtPos(int line, int column)
        {
            Cell cell = SearchForCell(line, column);
            if (cell == null)
            {
                throw new NullReferenceException("Empty cell.");
            }
            return cell.value;
        }
        public Cell GetCellCopy(int line, int column)
        {
            Cell cell = SearchForCell(line, column);
            if (cell == null)
                throw new NullReferenceException("Empty cell.");
            return cell.GetCopy();
        }
        public void AddCell(Cell newCell)
        {
            if (currId == cells.Length)
            {
                Array.Resize(ref cells, cells.Length + 1);
            }
            cells[currId] = newCell;
            currId++;
        }
        public void AddCell(int line, int column, double value)
        {
            AddCell(new Cell(line, column, value));
        }
        public Cell[] GetCells()
        {
            return this.cells;
        }
    }


}
