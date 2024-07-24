using System.Collections.Concurrent;

namespace GameOfLife
{
    public class GameOfLife
    {
        private int boardWidth;
        private int boardHeight;

        int iterationCounter;

        private bool[,] board;
        private bool[,] previousBoard;
        private bool[,] prePreviousBoard;


        public GameOfLife(int width = 10, int height = 15)
        {
            boardWidth = width;
            boardHeight = height;
            board = new bool[boardWidth, boardHeight];
            previousBoard = new bool[boardWidth, boardHeight];
            prePreviousBoard = new bool[boardWidth, boardHeight];
        }

        public void Initialize()
        {
            iterationCounter = 0;

            Random rand = new();
            for(int x = 0; x < boardWidth; x++)
            {
                for(int y = 0; y < boardHeight; y++)
                {
                    board[x, y] = (rand.Next(0, 2) == 0);
                    previousBoard[x, y] = false;
                    prePreviousBoard[x, y] = false;
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

        private int CountLiveNeighbors(int x, int y)
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
            if(iterationCounter > 0)
            {
                prePreviousBoard = previousBoard;
            }

            previousBoard = board;

            iterationCounter++;

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
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    if (previousBoard[x, y] != board[x, y])
                    {
                        return false; // Found a difference
                    }
                }
            }

            return true; // No differences found, state is stable
        }

        public bool IsInLoop()
        {
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    if (prePreviousBoard[x, y] != board[x, y])
                    {
                        return false; // Found a difference
                    }
                }
            }

            return true; // No differences found, state is stable
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            bool widthConverted = false;
            bool heightConverted = false;

            try
            {
                if(args.Length > 2)
                {
                    throw new ArgumentException("Please provide the width and height of the board.");
                }

                int width = 10;
                int height = 15;
                if(args.Length > 0)
                {
                    widthConverted = int.TryParse(args[0], out width);
                    if(!widthConverted)
                        throw new ArgumentException("Please provide valid width and height values.");
                }
                    
                
                if(args.Length > 1)
                {
                    heightConverted = int.TryParse(args[1], out height);
                    if(!heightConverted)
                        throw new ArgumentException("Please provide valid width and height values.");
                }

                
                GameOfLife game = new GameOfLife(width, height);
                game.Initialize();

                while((!game.AllAreDead()) && (!game.IsStateStable()) && (!game.IsInLoop()))
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
                else if(game.IsInLoop())
                {
                    Console.WriteLine("The state of all cells is in a loop.");
                }
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}