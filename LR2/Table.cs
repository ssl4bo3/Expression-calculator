
namespace LR2
{
    public class Table
    { 
        public Table ()
        { }
        private Table(Dictionary storage)
        {
            this.storage = storage;
        }
        private Dictionary storage = new Dictionary();
        public void Modify(int line, int coloumn, double newValue)
        {
            storage.ModifyValue(line, coloumn, newValue);
        }
        public void Add(int line, int column, double value)
        {
            storage.AddCell(line, column, value);
        }
        public Table CopyTable()
        {
            Table newTable = new Table
            {
                storage = this.storage.CopyArray()
            };
            return newTable;
        }
        public void Add(Cell cell)
        {
            storage.AddCell(cell);
        }
        public double Get(int line, int column)
        {
            return storage.GetAtPos(line, column);
        }
        public Cell GetCellCopy(int line, int column)
        {
            return storage.GetCellCopy(line, column);
        }
        public void CopyValue(int fromLine, int fromColumn, int toLine, int toColumn)
        {
            storage.CopyValueAt(fromLine, fromColumn, toLine, toColumn);
        }
        public static Table Merge(Table first, Table second)
        {
            Dictionary mergedStorage = new Dictionary();
            foreach (Cell cell in first.storage.GetCells())
            {
                if (cell == null)
                {
                    continue;
                }
                mergedStorage.AddCell(cell.GetCopy());
            }
            foreach (Cell cell in second.storage.GetCells())
            {
                if (cell == null)
                {
                    continue;
                }
                if (mergedStorage.ContainsValueAtPos(cell.line, cell.column))
                {
                    mergedStorage.Append(cell.line, cell.column, cell.value);
                }
                else
                {
                    mergedStorage.AddCell(cell.GetCopy());
                }
            }
            return new Table(mergedStorage);
        }
    }
}
