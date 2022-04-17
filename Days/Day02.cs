namespace AdventOfCode.Days
{
    class Day02 : Day
    {
        string[] input;

        public Day02()
        {
            input = SplitInput();
        }

        public override string Solve_1()
        {
            int x = 0;
            int y = 0;

            foreach (string line in input)
            {
                var split = line.Split(" ");

                if (split[0] == "forward")
                {
                    x += int.Parse(split[1]);
                }
                else
                {
                    y += (split[0] == "down") ? int.Parse(split[1]) : -int.Parse(split[1]);
                }
            }

            return (x * y).ToString();
        }

        public override string Solve_2()
        {
            int x = 0;
            int y = 0;
            int aim = 0;

            foreach (string line in input)
            {
                var split = line.Split(" ");

                if (split[0] == "forward")
                {
                    var val = int.Parse(split[1]);
                    x += val;
                    y += (aim * val);
                }
                else
                {
                    aim += (split[0] == "down") ? int.Parse(split[1]) : -int.Parse(split[1]);
                }
            }

            return (x * y).ToString();
        }
    }
}
