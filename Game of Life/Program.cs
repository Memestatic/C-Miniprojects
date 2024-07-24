using System.Collections.Concurrent;

namespace GameOfLife
{
    public class GameOfLife
    {
        private int boardWidth;
        private int boardHeight;
        private bool[,] board;

        public GameOfLife(int width, int height)
        {
            boardWidth = width;
            boardHeight = height;
            board = new bool[boardWidth, boardHeight];
        }

        public void Initialize()
        {
            Random rand = new();
            for(int x = 0; x < boardWidth; x++)
            {
                for(int y = 0; y < boardHeight; y++)
                {
                    board[x, y] = (rand.Next(0, 2) == 0);
                }
            }
        }

        public void DisplayBoard()
        {
            Console.Clear();

            for(int y = 0; y < boardHeight; y++)
            {
                for(int x = 0; x < boardWidth; x++)
                {
                    Console.Write(board[x, y] ? "O\t" : ".\t");
                }
                Console.WriteLine("\n");
            }
        }

        private bool CheckIfWithinTable(int x, int y)
        {
            return x >= 0 && x < boardWidth && y >= 0 && y < boardHeight;
        }

        public int CountLiveNeighbors(int x, int y)
        {
            int count = 0;
            for(int i  = -1; i <= 1; i++)
            {
                for(int j = -1; j <=1; j++)
                {
                    if(!(i == 0 && j == 0))
                    {
                        if(CheckIfWithinTable(x + i, y + j))
                        {
                            if(board[x + i, y + j] == true)
                            {
                                count++;
                            }
                        }
                        
                    }
                }
            }

            return count;
        }

        public void Update()
        {
            bool[,] newBoard = new bool[boardWidth, boardHeight];

            for(int x = 0; x < boardWidth; x++)
            {
                for(int y = 0; y < boardHeight; y++)
                {
                    int liveNeighbors = CountLiveNeighbors(x, y);
                    if(board[x, y])
                    {
                        if(liveNeighbors < 2 || liveNeighbors > 3)
                        {
                            newBoard[x, y] = false;
                        }
                        else
                        {
                            newBoard[x, y] = true;
                        
                        }
                    }
                    else
                    {
                        if(liveNeighbors == 3)
                        {
                            newBoard[x, y] = true;
                        }
                    }
                }
            }

            board = newBoard;
        }

        public bool AllAreDead()
        {
            for(int x = 0; x < boardWidth; x++)
            {
                for(int y = 0; y < boardHeight; y++)
                {
                    if(board[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStateStable()
        {
            bool[,] newBoard = new bool[boardWidth, boardHeight];

            for(int x = 0; x < boardWidth; x++)
            {
                for(int y = 0; y < boardHeight; y++)
                {
                    int liveNeighbors = CountLiveNeighbors(x, y);
                    if(board[x, y])
                    {
                        if(liveNeighbors < 2 || liveNeighbors > 3)
                        {
                            newBoard[x, y] = false;
                        }
                        else
                        {
                            newBoard[x, y] = true;
                        
                        }
                    }
                    else
                    {
                        if(liveNeighbors == 3)
                        {
                            newBoard[x, y] = true;
                        }
                    }
                }
            }

            for(int x = 0; x < boardWidth; x++)
            {
                for(int y = 0; y < boardHeight; y++)
                {
                    if(board[x, y] != newBoard[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameOfLife game = new GameOfLife(10, 15);
            game.Initialize();

            while((!game.AllAreDead()) && (!game.IsStateStable()))
            {
                game.Update();
                game.DisplayBoard();
                Thread.Sleep(500);
            }

            if(game.AllAreDead())
            {
                Console.WriteLine("All cells are extinct.");
            }
            else if(game.IsStateStable())
            {
                Console.WriteLine("The state of all cells is stable.");
            }
        }
    }
}