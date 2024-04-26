using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.InfoScreens
{
    internal class EndingAndCreditsScene : Scene
    {
        public EndingAndCreditsScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public void HelicopterVictory()
        {
            string playerName = terminalOutbreakGame.player.GetName();
            Console.Clear();
            string header = Utils.FrameText("Victory - Helicopter Escape");
            string display = Utils.WrapText($"{Environment.NewLine}As the helicopter finally roars to life, {playerName} looks back over their outpost. It had saved their life, of that there was no doubt. Memories flood {playerName}'s mind — the trials, the victories, everything leading to this moment. A few seconds pass, before {playerName} slams the door shut, knowing that their journey, though fraught with danger, had led them to this moment of freedom. As the helicopter lifts off into the horizon, {playerName} bids farewell to the outpost, forever etched in their memory as the sanctuary that had seen them through their darkest hours.{Environment.NewLine}");

            List<string> options = new List<string>();
            options.Add("Credits");
            options.Add("EXIT GAME");

            Menu warningMenu = new Menu(display, options, header);
            int selectedIndex = warningMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    terminalOutbreakGame.endingAndCreditsScene.Credits();
                    break;
                case 1:
                    Utils.ExitGame();
                    break;
            }
        }

        public void RescueVictory()
        {
            string playerName = terminalOutbreakGame.player.GetName();
            Console.Clear();
            string header = Utils.FrameText("Victory - Survived 25 Days");
            string display = Utils.WrapText($"{Environment.NewLine}After nearly a month without communications, suddenly the radio crackles back online, a signal! Finally able to get the word out, {playerName} stands amidst the safety of their outpost, a survivor against all odds. The once-simple outpost, now a testament to resilience and determination, stands as a beacon of hope in the midst of a world ravaged by chaos. {playerName} watches with a mix of disbelief and gratitude as the rescue team's armoured Humvee tears up the road towards them. As they drive away, {playerName} looks back one last time, bidding farewell to the outpost that had become their home, their fortress, and their refuge in the face of adversity, and known that they will be forever changed by the trials they endured in the crucible of survival.{Environment.NewLine}");

            List<string> options = new List<string>();
            options.Add("Credits");
            options.Add("EXIT GAME");

            Menu warningMenu = new Menu(display, options, header);
            int selectedIndex = warningMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    terminalOutbreakGame.endingAndCreditsScene.Credits();
                    break;
                case 1:
                    Utils.ExitGame();
                    break;
            }
        }

        public void Credits()
        {
            Console.Clear();
            string header = Utils.FrameText("CREDITS");
            string display = Utils.WrapText($"{Environment.NewLine}GAME DEVELOPER: Komorebi{Environment.NewLine}");
            display += $"{Environment.NewLine}INSPIRATIONS:{Environment.NewLine} - Chris Condon and his game series \"The Last Stand\", which was a huge inspiration for this game.";
            display += $"{Environment.NewLine} - Michael Hadley on YouTube for menu and interaction designs{Environment.NewLine}";
            display += $"{Environment.NewLine}ART: {Environment.NewLine} - ASCII Art Archive for the Title Screen art \"Bloody\"{Environment.NewLine}";
            display += $"{Environment.NewLine}Made for the April 19-27th 2024 Text Jam{Environment.NewLine}";
            display += $"{Environment.NewLine}Thank you for playing my game!{Environment.NewLine}";
            List<string> options = new List<string>();
            options.Add("EXIT GAME");

            Menu warningMenu = new Menu(display, options, header);
            int selectedIndex = warningMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    Utils.ExitGame();
                    break;
            }
        }
    }
}
