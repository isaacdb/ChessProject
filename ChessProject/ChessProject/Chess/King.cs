using ChessProject.Board;


namespace ChessProject.Chess
{
    class King:Piece
    {
        public ChessGame Game { get; private set; }
        public King(ChessBoard chessBoard, Color color, ChessGame game) : base(color, chessBoard)
        {
            Game = game;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[ChessBoard.Lines, ChessBoard.Columns];

            Position pos = new Position(0, 0);

            //acima
            pos.DefineValues(Position.Line - 1, Position.Column);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //abaixo
            pos.DefineValues(Position.Line + 1, Position.Column);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //esquerda
            pos.DefineValues(Position.Line, Position.Column + 1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //direita
            pos.DefineValues(Position.Line, Position.Column-1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //nordeste
            pos.DefineValues(Position.Line - 1, Position.Column-1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //noroeste
            pos.DefineValues(Position.Line - 1, Position.Column+1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //sudeste
            pos.DefineValues(Position.Line + 1, Position.Column-1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //sudoeste
            pos.DefineValues(Position.Line + 1, Position.Column+1);
            if (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //#jogada especial roque
            if(QnttMovies == 0 && !Game.GameInCheck)
            {
                //#Jogada roque pequeno
                Position posT1 = new Position(Position.Line, Position.Column + 3);
                if (TestTowerForRoque(posT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if(ChessBoard.PiecePosition(p1)==null && ChessBoard.PiecePosition(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }

                //#Jogada roque grande
                Position posT2 = new Position(Position.Line, Position.Column - 4);
                if (TestTowerForRoque(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column -1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (ChessBoard.PiecePosition(p1) == null 
                        && ChessBoard.PiecePosition(p2) == null
                        && ChessBoard.PiecePosition(p3) == null)
                    {
                        mat[Position.Line, Position.Column -2] = true;
                    }
                }

            }

            return mat;
        }
        private bool TestTowerForRoque(Position pos)
        {
            Piece p = ChessBoard.PiecePosition(pos);
            return p != null && p is Tower && p.Color == Color & p.QnttMovies == 0;
        }
        private bool CanMove(Position pos)
        {
            Piece p = ChessBoard.PiecePosition(pos);
            return p == null || p.Color != Color;
        }

        public override string ToString()
        {
            return "K";
        }

    }
}
