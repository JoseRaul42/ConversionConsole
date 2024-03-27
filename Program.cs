using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;


namespace ConversionConsole
{

  




    class Program
    {






        static void Main(string[] args)
        {



            var parser = new CommandParser();
            int consoleWidth = Console.WindowWidth;

            // Centered Title
            string title = @$"                  .,,uod8B8bou,,.
              ..,uod8BBBBBBBBBBBBBBBBRPFT?l!i:.
         ,=m8BBBBBBBBBBBBBBBRPFT?!||||||||||||||
         !...:!TVBBBRPFT||||||||||!!^^""'   ||||
         !.......:!?|||||!!^^""'            ||||
         !.........||||                     ||||
         !.........||||  ##  JV             ||||
         !.........||||                     ||||
         !.........||||                     ||||
         !.........||||                     ||||
         !.........||||                     ||||
         `.........||||                    ,||||
          .;.......||||               _.-!!|||||
   .,uodWBBBBb.....||||       _.-!!|||||||||!:'
!YBBBBBBBBBBBBBBb..!|||:..-!!|||||||!iof68BBBBBb....
!..YBBBBBBBBBBBBBBb!!||||||||!iof68BBBBBBRPFT?!::   `.
!....YBBBBBBBBBBBBBBbaaitf68BBBBBBRPFT?!:::::::::     `.
!......YBBBBBBBBBBBBBBBBBBBRPFT?!::::::;:!^`;:::       `.
!........YBBBBBBBBBBRPFT?!::::::::::^''...::::::;         iBBbo.
`..........YBRPFT?!::::::::::::::::::::::::;iof68bo.      WBBBBbo.
  `..........:::::::::::::::::::::::;iof688888888888b.     `YBBBP^'
    `........::::::::::::::::;iof688888888888888888888b.     `
      `......:::::::::;iof688888888888888888888888888888b.
        `....:::;iof688888888888888888888888888888888899fT!
          `..::!8888888888888888888888888888888899fT|!^'
            `' !!988888888888888888888888899fT|!^'
                `!!8888888888888888899fT|!^'
                  `!988888888899fT|!^'
                    `!9899fT|!^'
                      `!^' ";
            string centeredTitle = title.PadLeft((consoleWidth + title.Length) / 2).PadRight(consoleWidth);

            // Centered Author
            string author = @$"_________                                        .__                 _________                            .__          
\_   ___ \  ____   _______  __ ___________  _____|__| ____   ____    \_   ___ \  ____   ____   __________ |  |   ____  
/    \  \/ /  _ \ /    \  \/ // __ \_  __ \/  ___/  |/  _ \ /    \   /    \  \/ /  _ \ /    \ /  ___/  _ \|  | _/ __ \ 
\     \___(  <_> )   |  \   /\  ___/|  | \/\___ \|  (  <_> )   |  \  \     \___(  <_> )   |  \\___ (  <_> )  |_\  ___/ 
 \______  /\____/|___|  /\_/  \___  >__|  /____  >__|\____/|___|  /   \______  /\____/|___|  /____  >____/|____/\___  >
        \/            \/          \/           \/               \/           \/            \/     \/                \/ ";
            string centeredAuthor = author.PadLeft((consoleWidth + author.Length) / 2).PadRight(consoleWidth);

            Console.WriteLine(centeredAuthor);
            Console.WriteLine(centeredTitle);
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    parser.ExecuteCommand(input.Trim());
                }
            }
        }
    }
}
