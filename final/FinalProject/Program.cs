using System;

class Program
{
    static void Main(string[] args)
    {
        Player hero = new Player("Thorin", 100);

        GameEngine engine = new GameEngine(hero);

        engine.RunGame();
    }
}