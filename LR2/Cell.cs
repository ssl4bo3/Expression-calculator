using System;

namespace LR2
{
    public class Cell
    {
        public int line;
        public int column;
        public double value;

        public Cell() { }
        public Cell(int line, int column, double value)
        {
            if (line < 0 || column < 0)
            {
                throw new ArgumentNullException("Index must be >= 0");
            }
            this.line = line;
            this.column = column;
            this.value = value;
        }

        public int Length { get; internal set; }

        public Cell GetCopy()
        {
            return new Cell(this.line, this.column, this.value);
        }
    }
}
