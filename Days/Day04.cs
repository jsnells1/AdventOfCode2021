using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days;

class Day04 : Day
{
    string[] raw;
    string[] numbers;

    public Day04()
    {
        raw = SplitInput("\r\n\r\n");

        numbers = raw[0].Split(',').ToArray();
    }

    public override string Solve_1()
    {
        List<Board> boards = raw[1..].Select(x => new Board(x)).ToList();

        foreach (string num in numbers)
        {
            boards.ForEach(x => x.Mark(num));

            var winningBoard = boards.FirstOrDefault(x => x.HasWon);

            if (winningBoard != null)
            {
                return (winningBoard.Score() * int.Parse(num)).ToString();
            }
        }

        return "";
    }

    public override string Solve_2()
    {
        List<Board> boards = raw[1..].Select(x => new Board(x)).ToList();

        foreach (string num in numbers)
        {
            boards.ForEach(x => x.Mark(num));

            if (boards.Count == 1)
            {
                if (boards.First().HasWon)
                {
                    return (boards.First().Score() * int.Parse(num)).ToString();
                }
            }
            else
            {
                boards.RemoveAll(x => x.HasWon);
            }
        }

        return "";
    }

    private class Board
    {
        private (string, bool)[][] board;

        public bool HasWon
        {
            get
            {
                var won = board.Any(x => x.All(y => y.Item2));

                if (won)
                    return won;

                for (int i = 0; i < board.Length; i++)
                {
                    won = board.All(x => x[i].Item2);
                    if (won)
                        return won;
                }

                return false;
            }
        }

        public Board(string input)
        {
            board = input.SplitRemoveEmptyEntries("\r\n").Select(x => x.SplitRemoveEmptyEntries(" ").Select(y => (y, false)).ToArray()).ToArray();
        }

        public void Mark(string num)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int y = 0; y < board[i].Length; y++)
                {
                    if (board[i][y].Item1 == num)
                    {
                        board[i][y] = (num, true);
                        return;
                    }
                }
            }
        }

        public int Score()
        {
            return board.SelectMany(x => x).Where(x => !x.Item2).Sum(x => int.Parse(x.Item1));
        }
    }
}
