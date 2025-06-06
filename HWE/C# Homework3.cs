using System.Reflection.Emit;

namespace Homework2
{
    interface IPlayer
    {
        int Guess(int x, int y);
    }


    class HumanPlayer : IPlayer
    {
            public int Guess(int x,int y)
            {
                Console.WriteLine("請猜數字?");
                int g;
                while (!int.TryParse(Console.ReadLine(), out g) || g < x || g > y)
                    {
                    Console.WriteLine("請玩家重新輸入");
                    }
                return g;
            }
        
        class Game
        {
            private int a;
            private int x = 0; //最小的
            private int y = 99; //最大的
            private IPlayer player;

            public Game(IPlayer player)
            {
                this.player = player;
                Random rng = new Random();
                a = rng.Next(100); //電腦隨機的答案
                Console.WriteLine($"答案是：{a}");
            }

            public void start()
            {
                Console.WriteLine("[{0},{1}]", x, y);
                int g = player.Guess(x,y); 

                while (g != a)
                {
                    if (g < a)
                    {
                        x = g + 1;
                    }
                    else if (g > a)
                    {
                        y = g - 1;
                    }

                    if (y - x == 0)
                    {
                        break;
                    }

                    Console.WriteLine("答錯了！，請繼續猜數字");
                    Console.WriteLine("[{0},{1}]", x, y);

                    g = player.Guess(x,y);

                    if ((g - a == 1 & a == x) || (a - g == 1 & a == y))
                    {
                        break;
                    }
                }

                if (g == a)
                {
                    Console.WriteLine("答對了！");
                }
                else
                {
                    Console.WriteLine("你輸了！");
                }
            }
        }

        class program
        {
            static void Main(string[] args)
            {
                IPlayer player = new HumanPlayer();
                Game game = new Game(player);
                game.start();
            }
        }
    }
}
