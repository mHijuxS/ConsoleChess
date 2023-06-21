using System.Xml;

namespace board
{
    internal class Position
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public override string ToString()
        {
            return $"({this.Row},{this.Column})";
        }

        public void DefineValues(int row, int column)
        {
            this.Column = column;
            this.Row = row;
        }
    }
}
