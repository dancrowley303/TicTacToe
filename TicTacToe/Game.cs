using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        private Dictionary<Position, Player> moves;
        private List<Position> remainingPositions;

        public Game() : this(new Dictionary<Position, Player>(),
                                new List<Position> {
                                    Position.TopLeft, Position.TopMid, Position.TopRight,
                                    Position.CenterLeft, Position.CenterMid, Position.CenterRight,
                                    Position.BottomLeft, Position.BottomMid, Position.BottomRight
                                }) { }

        private Game(Dictionary<Position, Player> moves, List<Position> remainingPositions) {
            this.moves = moves;
            this.remainingPositions = remainingPositions;
        }

        public ReadOnlyCollection<Position> RemainingPositions {
            get {
                return new ReadOnlyCollection<Position>(remainingPositions);
            }
        }

        public Boolean GameWon { get; private set; }

        public int MovesLeft {
            get {
                return remainingPositions.Count;
            }
        }

        public bool MovesAreLeft {
            get {
                return !GameWon && MovesLeft > 0;
            }
        }

        public Game DeepCopy() {
            return new Game(new Dictionary<Position, Player>(moves), new List<Position>(remainingPositions));
        }

        public void AddMove(Position position, Player player) {
            moves.Add(position, player);
            remainingPositions.Remove(position);
            Score();
        }

        public void PrintBoard() {
            for (int i = 1; i <= 9; i++) {
                if (moves.ContainsKey((Position)i)) {
                    Player player = moves[(Position)i];
                    if (player == Player.Human) Console.Write("X");
                    if (player == Player.CPU) Console.Write("O");
                } else {
                    Console.Write(" ");
                }
                if (i % 3 == 0) Console.WriteLine();
            }
        }

        public int Score() {
            if (moves.ContainsKey(Position.TopLeft) && moves.ContainsKey(Position.TopMid) && moves.ContainsKey(Position.TopRight)) {
                if (moves[Position.TopLeft] == Player.Human && moves[Position.TopMid] == Player.Human && moves[Position.TopRight] == Player.Human) {
                    GameWon = true;
                    return 1;
                }
                if (moves[Position.TopLeft] == Player.CPU && moves[Position.TopMid] == Player.CPU && moves[Position.TopRight] == Player.CPU) {
                    GameWon = true;
                    return -1;
                }
            }
            if (moves.ContainsKey(Position.CenterLeft) && moves.ContainsKey(Position.CenterMid) && moves.ContainsKey(Position.CenterRight)) {
                if (moves[Position.CenterLeft] == Player.Human && moves[Position.CenterMid] == Player.Human && moves[Position.CenterRight] == Player.Human) {
                    GameWon = true;
                    return 1;
                }
                if (moves[Position.CenterLeft] == Player.CPU && moves[Position.CenterMid] == Player.CPU && moves[Position.CenterRight] == Player.CPU) {
                    GameWon = true;
                    return -1;
                }
            }
            if (moves.ContainsKey(Position.BottomLeft) && moves.ContainsKey(Position.BottomMid) && moves.ContainsKey(Position.BottomRight)) {
                if (moves[Position.BottomLeft] == Player.Human && moves[Position.BottomMid] == Player.Human && moves[Position.BottomRight] == Player.Human) {
                    GameWon = true;
                    return 1;
                }
                if (moves[Position.BottomLeft] == Player.CPU && moves[Position.BottomMid] == Player.CPU && moves[Position.BottomRight] == Player.CPU) {
                    GameWon = true;
                    return -1;
                }
            }
            if (moves.ContainsKey(Position.TopLeft) && moves.ContainsKey(Position.CenterLeft) && moves.ContainsKey(Position.BottomLeft)) {
                if (moves[Position.TopLeft] == Player.Human && moves[Position.CenterLeft] == Player.Human && moves[Position.BottomLeft] == Player.Human) {
                    GameWon = true;
                    return 1;
                }
                if (moves[Position.TopLeft] == Player.CPU && moves[Position.CenterLeft] == Player.CPU && moves[Position.BottomLeft] == Player.CPU) {
                    GameWon = true;
                    return -1;
                }
            }
            if (moves.ContainsKey(Position.TopMid) && moves.ContainsKey(Position.CenterMid) && moves.ContainsKey(Position.BottomMid)) {
                if (moves[Position.TopMid] == Player.Human && moves[Position.CenterMid] == Player.Human && moves[Position.BottomMid] == Player.Human) {
                    GameWon = true;
                    return 1;
                }
                if (moves[Position.TopMid] == Player.CPU && moves[Position.CenterMid] == Player.CPU && moves[Position.BottomMid] == Player.CPU) {
                    GameWon = true;
                    return -1;
                }
            }
            if (moves.ContainsKey(Position.TopRight) && moves.ContainsKey(Position.CenterRight) && moves.ContainsKey(Position.BottomRight)) {
                if (moves[Position.TopRight] == Player.Human && moves[Position.CenterRight] == Player.Human && moves[Position.BottomRight] == Player.Human) {
                    GameWon = true;
                    return 1;
                }
                if (moves[Position.TopRight] == Player.CPU && moves[Position.CenterRight] == Player.CPU && moves[Position.BottomRight] == Player.CPU) {
                    GameWon = true;
                    return -1;
                }
            }
            if (moves.ContainsKey(Position.TopLeft) && moves.ContainsKey(Position.CenterMid) && moves.ContainsKey(Position.BottomRight)) {
                if (moves[Position.TopLeft] == Player.Human && moves[Position.CenterMid] == Player.Human && moves[Position.BottomRight] == Player.Human) {
                    GameWon = true;
                    return 1;
                }
                if (moves[Position.TopLeft] == Player.CPU && moves[Position.CenterMid] == Player.CPU && moves[Position.BottomRight] == Player.CPU) {
                    GameWon = true;
                    return -1;
                }
            }
            if (moves.ContainsKey(Position.BottomLeft) && moves.ContainsKey(Position.CenterMid) && moves.ContainsKey(Position.TopRight)) {
                if (moves[Position.BottomLeft] == Player.Human && moves[Position.CenterMid] == Player.Human && moves[Position.TopRight] == Player.Human) {
                    GameWon = true;
                    return 1;
                }
                if (moves[Position.BottomLeft] == Player.CPU && moves[Position.CenterMid] == Player.CPU && moves[Position.TopRight] == Player.CPU) {
                    GameWon = true;
                    return -1;
                }
            }
            return 0;
        }
    }
}
