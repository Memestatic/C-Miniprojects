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
            for(int y = 0; y < boardHeight; y++)
            {
                for(int x = 0; x < boardWidth; x++)
                {
                    Console.Write(board[x, y] ? "O" : ".");
                }
                Console.WriteLine("\n");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameOfLife game = new GameOfLife(40, 10);
            game.Initialize();
            game.DisplayBoard();
        }
    }
}