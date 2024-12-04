class Game
{
  static char[,] Board = {
    {'1', '2', '3'},
    {'4', '5', '6'},
    {'7', '8', '9'}
  };

  static char currentUser = 'X';

  static void Main(string[] args)
  {
    Console.Clear();
    Console.WriteLine("*** Welcome To TicTacToe ***");

    byte turns = 0;
    bool gameIsOn = true;

    while (gameIsOn)
    {
      BoardOnConsole();
      Console.WriteLine($"User {currentUser}, enter index:");
      Arrow();
      string userInput = Console.ReadLine();

      // check for user input is valid or not
      if (int.TryParse(userInput, out int input) && input >= 1 && input <= 9)
      {
        // check the position is occupied or not to replace it
        if (Replacement(input))
        {
          turns++;
          //does we have winner?
          if (CheckForWin())
          {
            Replacement(input);
            BoardOnConsole();
            Console.WriteLine($"{currentUser} Won!");
            gameIsOn = false;
          }
          // is it draw?
          else if (turns == 9)
          {
            Console.WriteLine("DRAW!");
            gameIsOn = false;
          }
          // none of above, continue
          else
          {
            currentUser = currentUser == 'X' ? 'O' : 'X';
          }
        }
        // if it was occupied
        else
        {
          Console.WriteLine("This index is occupied!");
        }
      }
      // if input wasnt valid
      else Console.WriteLine("You entered wrong input!");
    }
  }

  static void Arrow() => Console.Write("=> ");

  static void BoardOnConsole()
  {
    Console.WriteLine($"\n {Board[0, 0]} | {Board[0, 1]} | {Board[0, 2]}");
    Console.WriteLine("---|---|---");
    Console.WriteLine($" {Board[1, 0]} | {Board[1, 1]} | {Board[1, 2]}");
    Console.WriteLine("---|---|---");
    Console.WriteLine($" {Board[2, 0]} | {Board[2, 1]} | {Board[2, 2]} \n");
  }

  static bool Replacement(int input)
  {
    int boardRow = (input - 1) / 3;
    int boardCol = (input - 1) % 3;

    if (Board[boardRow, boardCol] != 'X' && Board[boardRow, boardCol] != 'O')
    {
      Board[boardRow, boardCol] = currentUser;
      return true;
    }
    return false;
  }

  static bool CheckForWin()
  {
    for (int i = 0; i < 3; i++)
    {
      if (Board[0, i] == currentUser && Board[1, i] == currentUser && Board[2, i] == currentUser ||
          Board[i, 0] == currentUser && Board[i, 1] == currentUser && Board[i, 2] == currentUser)
      {
        return true;
      }
    }

    if (Board[0, 0] == currentUser && Board[1, 1] == currentUser && Board[2, 2] == currentUser ||
        Board[0, 2] == currentUser && Board[1, 1] == currentUser && Board[2, 0] == currentUser)
    {
      return true;
    }

    return false;
  }
}
