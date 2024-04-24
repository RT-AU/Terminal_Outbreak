using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.InfoScreens
{
    internal class TitleScene : Scene
    {

        public TitleScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        {
            string mainTitle = $"{Environment.NewLine}▄▄▄█████▓█████ ██▀███  ███▄ ▄███▓██▓███▄    █ ▄▄▄      ██▓    {Environment.NewLine}▓  ██▒ ▓▓█   ▀▓██ ▒ ██▓██▒▀█▀ ██▓██▒██ ▀█   █▒████▄   ▓██▒    {Environment.NewLine}▒ ▓██░ ▒▒███  ▓██ ░▄█ ▓██    ▓██▒██▓██  ▀█ ██▒██  ▀█▄ ▒██░    {Environment.NewLine}░ ▓██▓ ░▒▓█  ▄▒██▀▀█▄ ▒██    ▒██░██▓██▒  ▐▌██░██▄▄▄▄██▒██░    {Environment.NewLine}  ▒██▒ ░░▒████░██▓ ▒██▒██▒   ░██░██▒██░   ▓██░▓█   ▓██░██████▒{Environment.NewLine}  ▒ ░░  ░░ ▒░ ░ ▒▓ ░▒▓░ ▒░   ░  ░▓ ░ ▒░   ▒ ▒ ▒▒   ▓▒█░ ▒░▓  ░{Environment.NewLine}    ░    ░ ░  ░ ░▒ ░ ▒░  ░      ░▒ ░ ░░   ░ ▒░ ▒   ▒▒ ░ ░ ▒  ░{Environment.NewLine}  ░        ░    ░░   ░░      ░   ▒ ░  ░   ░ ░  ░   ▒    ░ ░   {Environment.NewLine} ▒█████  █ ░  ██▄▄▄█████▓▄▄▄▄░  ██▀███ ▓█████▄▄▄   ░  ██ ▄█▀ ░{Environment.NewLine}▒██▒  ██▒██  ▓██▓  ██▒ ▓▓█████▄▓██ ▒ ██▓█   ▒████▄    ██▄█▒   {Environment.NewLine}▒██░  ██▓██  ▒██▒ ▓██░ ▒▒██▒ ▄█▓██ ░▄█ ▒███ ▒██  ▀█▄ ▓███▄░   {Environment.NewLine}▒██   ██▓▓█  ░██░ ▓██▓ ░▒██░█▀ ▒██▀▀█▄ ▒▓█  ░██▄▄▄▄██▓██ █▄   {Environment.NewLine}░ ████▓▒▒▒█████▓  ▒██▒ ░░▓█  ▀█░██▓ ▒██░▒████▓█   ▓██▒██▒ █▄  {Environment.NewLine}░ ▒░▒░▒░░▒▓▒ ▒ ▒  ▒ ░░  ░▒▓███▀░ ▒▓ ░▒▓░░ ▒░ ▒▒   ▓▒█▒ ▒▒ ▓▒  {Environment.NewLine}  ░ ▒ ▒░░░▒░ ░ ░    ░   ▒░▒   ░  ░▒ ░ ▒░░ ░  ░▒   ▒▒ ░ ░▒ ▒░  {Environment.NewLine}░ ░ ░ ▒  ░░░ ░ ░  ░      ░    ░  ░░   ░   ░   ░   ▒  ░ ░░ ░   {Environment.NewLine}    ░ ░    ░             ░        ░       ░  ░    ░  ░  ░     {Environment.NewLine}";
            string display = Utils.WrapText($"In a world ravaged by an unknown plague, society has crumbled, and once the sun sets the streets teem with the undead. As a survivor, you must navigate through the chaos, scavenge for resources, and fight to stay alive.");
            display += Utils.WrapText($"{Environment.NewLine}{Environment.NewLine}*CAUTION*: The method by which this game renders scenes will cause flickering in the terminal when keys are pressed. If you are sensitive to this, consider avoiding it.");
            display += Utils.WrapText($"{Environment.NewLine}{Environment.NewLine}Welcome to Terminal Outbreak. (Use the Arrow Keys to cycle through options and Enter to select). ");


            List<string> options = new List<string>();
            options.Add("Play");
            options.Add("About");
            options.Add("Exit");


            Menu mainMenu = new Menu(display, options, mainTitle);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();

                    Console.WriteLine(Utils.FrameText("Name Your Character"));
                    Console.WriteLine();
                    Console.CursorVisible = true;
                    string? playerName = Console.ReadLine();

                    while (string.IsNullOrEmpty(playerName))
                    {
                        Console.WriteLine($"Please enter chacter name and then press enter: {Environment.NewLine}");
                        playerName = Console.ReadLine();
                    }
                    terminalOutbreakGame.player.SetName(playerName);
                    Console.CursorVisible = false;

                    Console.Clear();

                    Console.WriteLine(Utils.FrameText(playerName, "'s Story"));

                    Console.WriteLine(Utils.WrapText($"{Environment.NewLine}The wind howls a desolate tune through the cracked windowpanes of your cabin. Nestled away on a cliff overlooking the city, it's your lone sanctuary in this ravaged world. The city is silent for now, but you know that when the moon rises so will its inhabitants. Three sides of your outpost are sheer rock face, a natural defence against the shambling hordes, but the south – a road leading back into the city – leaves you vulnerable."));
                    Console.WriteLine(Utils.WrapText($"{Environment.NewLine}Before communications went down a week ago, reports circulated of a rescue force working its way through the area, but with no further contact, you are not sure you could survive until their predicted arrival in 15 days. A sliver of hope gleams in the form of a helicopter landed in the clearing behind your cabin. Though clearly neglected for years, its lifeless engine and dead navigation systems mocking your predicament, its frame is remarkably intact. The chances may be slim, but if you can fix this bird of steel and soar out of this nightmare, you may just OUTLIVE the OUTBREAK."));

                    Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Press ENTER to continue...");
                    Utils.PressEnter();

                    PlayGame();
                    break;

                case 1:
                    DisplayAboutInformation();
                    break;

                case 2:
                    Utils.ExitGame();
                    break;
            }
        }

        private void PlayGame()
        {
            Console.Clear();
            terminalOutbreakGame.baseScene.Run();
        }



        private void DisplayAboutInformation()
        {
            Console.Clear();
            Console.WriteLine(Utils.FrameText("About"));
            Console.WriteLine("This game was created by Swift_Kogarashi (Komorebi) for the April 19-27th 2024 Text Jam.");
            Console.WriteLine(Utils.WrapText("This project draws inspiration from Chris Condon's 'The Last Stand' games for its thematic elements and from Michael Hadley's YouTube channel for menu and interaction designs."));
            Console.WriteLine(Utils.WrapText($"{Environment.NewLine}The goal of the game is to either repair the helicopter to escape, or to survive 15-20 nights against an ever-increasing zombie threat, while scavanging from the ruins of the city and building up your defenses and allies. You can trade for more weapons and resources using food rations, but beware, as running out could spell disaster."));
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"{Environment.NewLine}<< RETURN >>");
            Utils.PressEnter();
            Console.ResetColor();
            Run();

        }
    }
}
