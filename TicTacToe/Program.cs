using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static Tuple<int, Position> MiniMax(Game game, Boolean isHuman) {
            if (game.GameWon || !game.MovesAreLeft) {
                return new Tuple<int, Position>(game.Score(), Position.Undefined);
            }
            var remainingPositions = game.RemainingPositions;
            if (isHuman) {
                int bestValue = int.MinValue;
                Position bestPosition = Position.Undefined;
                foreach (var remainingPosition in remainingPositions) {
                    var gameCopy = game.DeepCopy();
                    gameCopy.AddMove(remainingPosition, Player.Human);
                    var result = MiniMax(gameCopy, !isHuman);
                    if (result.Item1 > bestValue) {
                        bestValue = result.Item1;
                        bestPosition = remainingPosition;
                    }
                }
                return new Tuple<int, Position>(bestValue, bestPosition);
            } else {
                int bestValue = int.MaxValue;
                Position bestPosition = Position.Undefined;
                foreach (var remainingPosition in remainingPositions) {
                    var gameCopy = game.DeepCopy();
                    gameCopy.AddMove(remainingPosition, Player.CPU);
                    var result = MiniMax(gameCopy, !isHuman);
                    if (result.Item1 < bestValue) {
                        bestValue = result.Item1;
                        bestPosition = remainingPosition;
                    }
                }
                return new Tuple<int, Position>(bestValue, bestPosition);
            }
        }

        static Position CpuCalcPos(Game game) {
            var calc = MiniMax(game, false);
            Console.WriteLine("CPU chooses {0}", calc.Item2.ToString());
            return calc.Item2;
        }

        static void Main(string[] args) {
            Game game = new Game();
            int turnCounter = 1;
            while (game.MovesAreLeft) {
                if (turnCounter % 2 == 1) {
                    Console.Write("Human, What position[1-9]? ");
                    Position position = (Position)int.Parse(Console.ReadLine());
                    game.AddMove(position, Player.Human);
                    game.PrintBoard();
                } else {
                    Position cpuPosition = CpuCalcPos(game);
                    game.AddMove(cpuPosition, Player.CPU);
                    game.PrintBoard();
                }
                turnCounter++;
            }

            int finalScore = game.Score();

            if (finalScore == 1) {
                Console.WriteLine("Human wins - IMPOSSIBLE!");
            }
            if (finalScore == 0) {
                Console.WriteLine("Draw!");
            }
            if (finalScore == -1) {
                Console.WriteLine("CPU wins!");
            }
        }
    }
}
