Conway's Game of Life
C# implementation


Program is executable via bin/Debug/net8.0/Game_of_Life.exe file. Therefore it will launch with default board size (10x15).
If you want to adjust it's size you simply have to run "Game of Life.exe" in terminal being in "net8.0" folder.
You can pass up to 2 argument which has to be intergers:
- first entered number is board's width
- second one is board's height

***
Example:
'"Game of Life.exe" 5 13' creates board 5x13
***

End conditions are:
1) All cells extinction.
2) Stable state where nothing changes between iterations.
3) Program entered infinite loop of 2 states changing continuously.

O - reprezents living cell
. - reprezents dead cell
