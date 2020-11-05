using ChessProject.Board;

namespace ChessProject.Chess
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }
        public Position toPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }
        public override string ToString()
        {
            return "" + Line + Column;
        }
    }
}
