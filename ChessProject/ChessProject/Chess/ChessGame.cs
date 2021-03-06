﻿using ChessProject.Board;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;

namespace ChessProject.Chess
{
    class ChessGame
    {
        public ChessBoard ChessBoard { get; set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        public HashSet<Piece> FreePieces { get; private set; }
        public HashSet<Piece> CapturedPieces { get; set; }

        public bool GameInCheck { get; set; }
        public Piece VulnerableForEnPassant { get; private set; }

        public ChessGame()
        {
            ChessBoard = new ChessBoard(8, 8);
            Shift = 1;
            CurrentPlayer = Color.Branca;
            Finished = false;
            FreePieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            VulnerableForEnPassant = null;
            PutPieces();
        }
        public void PerformsMove(Position origin, Position destiny)
        {
            Piece captPiece = RunMoviment(origin, destiny);
            if (OnCheck(CurrentPlayer))
            {
                UndoMoviment(origin, destiny, captPiece);
                throw new BoardException("You can't put yourself in check");
            }
            Piece p = ChessBoard.PiecePosition(destiny);
            //#jogada especial promocao
            if(p is Pawn)
            {
                if((p.Color == Color.Branca && destiny.Line == 0) || (p.Color == Color.Preta && destiny.Line == 8))
                {
                    p = ChessBoard.RemovePiece(destiny);
                    FreePieces.Remove(p);
                    Piece queen = new Queen(ChessBoard, p.Color);
                    ChessBoard.InsertPiece(queen, destiny);
                    FreePieces.Add(queen);

                }
            }
            //

            if (OnCheck(adversary(CurrentPlayer)))
                GameInCheck = true;
            else
                GameInCheck = false;

            if (TestCheckMate(adversary(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Shift++;
                ChangePlayer();
            }
            //#jogada especial EnPassant
            if (p is Pawn && (destiny.Line == origin.Line - 2 || destiny.Line == origin.Line + 2))
                VulnerableForEnPassant = p;
            else
                VulnerableForEnPassant = null;
        }
        private Color adversary(Color color)
        {
            if (color == Color.Branca)
                return Color.Preta;
            else
                return Color.Branca;
        }
        public void ValidateOriginPosition(Position pos)
        {
            if (ChessBoard.PiecePosition(pos) == null)
            {
                throw new BoardException("Dont have piece in the chosed position");
            }
            if (CurrentPlayer != ChessBoard.PiecePosition(pos).Color)
            {
                throw new BoardException("The origin piece chosed is'nt your");
            }
            if (!ChessBoard.PiecePosition(pos).ExistPossibleMovies())
            {
                throw new BoardException("Dont have possible moviments for piece chosed");
            }
        }
        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!ChessBoard.PiecePosition(origin).CanMoveFor(destiny))
                throw new BoardException("Chose a valid position for destiny!");
        }
        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.Branca)
                CurrentPlayer = Color.Preta;
            else
                CurrentPlayer = Color.Branca;
        }
        public void UndoMoviment(Position origin, Position destiny, Piece captPiece)
        {
            Piece p = ChessBoard.RemovePiece(destiny);
            p.DecrementQnttMovies();
            if (captPiece != null)
            {
                ChessBoard.InsertPiece(captPiece, destiny);
                CapturedPieces.Remove(captPiece);
            }
            ChessBoard.InsertPiece(p, origin);

            //#jogada especial roque pequeno
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = ChessBoard.RemovePiece(destinyT);
                T.DecrementQnttMovies();
                ChessBoard.InsertPiece(T, originT);
            }
            //#jogada especial roque pequeno
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = ChessBoard.RemovePiece(destinyT);
                T.DecrementQnttMovies();
                ChessBoard.InsertPiece(T, originT);
            }
            //#jogada especial EnPassant
            if (p is Pawn)
            {
                if (origin.Column != destiny.Column && captPiece == VulnerableForEnPassant)
                {
                    Piece pawn = ChessBoard.RemovePiece(destiny);
                    Position posP;
                    if (p.Color == Color.Branca)
                        posP = new Position(3, destiny.Column);
                    else
                        posP = new Position(4, destiny.Column);
                }
            }

        }
        public Piece RunMoviment(Position origin, Position destiny)
        {
            Piece p = ChessBoard.RemovePiece(origin);
            p.IncrementQnttMovies();
            Piece CapturedPiece = ChessBoard.RemovePiece(destiny);
            ChessBoard.InsertPiece(p, destiny);
            if (CapturedPiece != null)
                CapturedPieces.Add(CapturedPiece);

            //#jogada especial roque pequeno
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = ChessBoard.RemovePiece(originT);
                T.IncrementQnttMovies();
                ChessBoard.InsertPiece(T, destinyT);
            }
            //#jogada especial roque Grande
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = ChessBoard.RemovePiece(originT);
                T.IncrementQnttMovies();
                ChessBoard.InsertPiece(T, destinyT);
            }
            //#jogada especial EnPassant
            if (p is Pawn)
            {
                if (origin.Column != destiny.Column && CapturedPiece == null)
                {
                    Position posP;
                    if (p.Color == Color.Branca)
                        posP = new Position(destiny.Line + 1, destiny.Column);
                    else
                        posP = new Position(destiny.Line - 1, destiny.Column);

                    CapturedPiece = ChessBoard.RemovePiece(posP);
                    CapturedPieces.Add(CapturedPiece);
                }
            }

            return CapturedPiece;
        }
        public HashSet<Piece> PieceCaptureds(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in CapturedPieces)
            {
                if (x.Color == color)
                    aux.Add(x);
            }
            return aux;
        }
        public HashSet<Piece> PiecesOnGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in FreePieces)
            {
                if (x.Color == color)
                    aux.Add(x);
            }
            aux.ExceptWith(PieceCaptureds(color));
            return aux;

        }
        public void PutNewPiece(char column, int line, Piece piec)
        {
            ChessBoard.InsertPiece(piec, new ChessPosition(column, line).toPosition());
            FreePieces.Add(piec);
        }
        public void PutPieces()
        {
            PutNewPiece('a', 1, new Tower(ChessBoard, Color.Branca));
            PutNewPiece('b', 1, new Horse(ChessBoard, Color.Branca));
            PutNewPiece('c', 1, new Bishop(ChessBoard, Color.Branca));
            PutNewPiece('d', 1, new Queen(ChessBoard, Color.Branca));
            PutNewPiece('e', 1, new King(ChessBoard, Color.Branca,this));
            PutNewPiece('f', 1, new Bishop(ChessBoard, Color.Branca));
            PutNewPiece('g', 1, new Horse(ChessBoard, Color.Branca));
            PutNewPiece('h', 1, new Tower(ChessBoard, Color.Branca));

            PutNewPiece('a', 2, new Pawn(ChessBoard, Color.Branca, this));
            PutNewPiece('b', 2, new Pawn(ChessBoard, Color.Branca, this));
            PutNewPiece('c', 2, new Pawn(ChessBoard, Color.Branca, this));
            PutNewPiece('d', 2, new Pawn(ChessBoard, Color.Branca, this));
            PutNewPiece('e', 2, new Pawn(ChessBoard, Color.Branca, this));
            PutNewPiece('f', 2, new Pawn(ChessBoard, Color.Branca, this));
            PutNewPiece('g', 2, new Pawn(ChessBoard, Color.Branca, this));
            PutNewPiece('h', 2, new Pawn(ChessBoard, Color.Branca, this));

            PutNewPiece('a', 7, new Pawn(ChessBoard, Color.Preta, this));
            PutNewPiece('b', 7, new Pawn(ChessBoard, Color.Preta, this));
            PutNewPiece('c', 7, new Pawn(ChessBoard, Color.Preta, this));
            PutNewPiece('d', 7, new Pawn(ChessBoard, Color.Preta, this));
            PutNewPiece('e', 7, new Pawn(ChessBoard, Color.Preta, this));
            PutNewPiece('f', 7, new Pawn(ChessBoard, Color.Preta, this));
            PutNewPiece('g', 7, new Pawn(ChessBoard, Color.Preta, this));
            PutNewPiece('h', 7, new Pawn(ChessBoard, Color.Preta, this));

            PutNewPiece('a', 8, new Tower(ChessBoard, Color.Preta));
            PutNewPiece('b', 8, new Horse(ChessBoard, Color.Preta));
            PutNewPiece('c', 8, new Bishop(ChessBoard, Color.Preta));
            PutNewPiece('d', 8, new Queen(ChessBoard, Color.Preta));
            PutNewPiece('e', 8, new King(ChessBoard, Color.Preta, this));
            PutNewPiece('f', 8, new Bishop(ChessBoard, Color.Preta));
            PutNewPiece('g', 8, new Horse(ChessBoard, Color.Preta));
            PutNewPiece('h', 8, new Tower(ChessBoard, Color.Preta));

        }
        private Piece King(Color color)
        {
            foreach (Piece x in PiecesOnGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }
        public bool TestCheckMate(Color color)
        {
            if (!OnCheck(color))
                return false;

            foreach (Piece x in PiecesOnGame(color))
            {
                bool[,] mat = x.PossibleMoviments();
                for (int i = 0; i < ChessBoard.Lines; i++)
                {
                    for (int j = 0; j < ChessBoard.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destino = new Position(i, j);
                            Piece pieceCpt = RunMoviment(origin, destino);
                            bool testCheck = OnCheck(color);
                            UndoMoviment(origin, destino, pieceCpt);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public bool OnCheck(Color color)
        {
            Piece k = King(color);
            if (k == null)
                throw new BoardException("Dont have a " + color + " king on the board!");
            foreach (Piece x in PiecesOnGame(adversary(color)))
            {
                bool[,] mat = x.PossibleMoviments();
                if (mat[k.Position.Line, k.Position.Column])
                    return true;
            }
            return false;
        }
    }
}
