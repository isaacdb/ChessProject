using ChessProject.Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessProject.Chess
{
    class Queen:Piece
    {
        public Queen(ChessBoard chessBoard, Color color) : base(color, chessBoard)
        {
        }
        private bool CanMove(Position pos)
        {
            Piece p = ChessBoard.PiecePosition(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[ChessBoard.Lines, ChessBoard.Columns];

            Position pos = new Position(0, 0);

            //NO
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column - 1);
            }
            //NE
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column + 1);
            }
            //SO
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column - 1);
            }
            //SE
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column + 1);
            }

            //acima
            pos.DefineValues(Position.Line - 1, Position.Column);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }
            //abaixo
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            //direita
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            //esquerda
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (ChessBoard.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (ChessBoard.PiecePosition(pos) != null && ChessBoard.PiecePosition(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return mat;
        }
        public override string ToString()
        {
            return "Q";
        }
    }
}
