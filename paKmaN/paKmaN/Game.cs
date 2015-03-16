/***
*    ██████╗  █████╗ ██╗  ██╗███╗   ███╗ █████╗ ███╗   ██╗    ██████╗ ██╗   ██╗    ███╗   ██╗███████╗██████╗  █████╗ 
*    ██╔══██╗██╔══██╗██║ ██╔╝████╗ ████║██╔══██╗████╗  ██║    ██╔══██╗╚██╗ ██╔╝    ████╗  ██║██╔════╝██╔══██╗██╔══██╗
*    ██████╔╝███████║█████╔╝ ██╔████╔██║███████║██╔██╗ ██║    ██████╔╝ ╚████╔╝     ██╔██╗ ██║█████╗  ██████╔╝███████║
*    ██╔═══╝ ██╔══██║██╔═██╗ ██║╚██╔╝██║██╔══██║██║╚██╗██║    ██╔══██╗  ╚██╔╝      ██║╚██╗██║██╔══╝  ██╔══██╗██╔══██║
*    ██║     ██║  ██║██║  ██╗██║ ╚═╝ ██║██║  ██║██║ ╚████║    ██████╔╝   ██║       ██║ ╚████║███████╗██████╔╝██║  ██║
*    ╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝    ╚═════╝    ╚═╝       ╚═╝  ╚═══╝╚══════╝╚═════╝ ╚═╝  ╚═╝
*    4.2.2015.  19:48PM    Done by Nebojša Kalanj                                                                                                                
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Resources;
using System.Media;
using System.Diagnostics;

namespace paKmaN
{
    public class Program
    {
        static bool sessionFinished = false;
        static int startX = 20;
        static int startY = 11;
        static int lives;
        static int x, y;
        static int pacSpeed;

        

             

        static string[] map = {
               
                "|----------------------------------------|",
                "|                                        |",
                "|   |---|   --   |------|   --   |---|   |",
                "|   |---|   ||   |--||--|   ||   |---|   |",
                "|           ||      ||      ||           |",
                "|-------|   -----   --   -----   |-------|",
                "########|   |                |   |########",
                "########|   |   |---  ---|   |   |########",
                "|--------   -   |        |   -   --------|",
                "|               |        |               |",
                "|--------   -   |________|   -   --------|",
                "########|   |                |   |########",
                "########|   |   |--------|   |   |########",
                "|-------|   |   |---||---|   |   |-------|",
                "|                   ||                   |",
                "|   -----   |---|   ||   |---|   -----   |",
                "|   |-- |   |---|   --   |---|   | --|   |",
                "|      ||                        ||      |",
                "|--|   ||   |----------------|   ||   |--|",
                "|--|   --   |----------------|   --   |--|",
                "|                                        |",
                "|----------------------------------------|"

            };

        static int score;
        public static void Intro()
        {

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\n\n\n\n\t     ██████╗  █████╗ ██╗  ██╗███╗   ███╗ █████╗ ███╗   ██╗");
            Console.WriteLine("\t     ██╔══██╗██╔══██╗██║ ██╔╝████╗ ████║██╔══██╗████╗  ██║");
            Console.WriteLine("\t     ██████╔╝███████║█████╔╝ ██╔████╔██║███████║██╔██╗ ██║");
            Console.WriteLine("\t     ██╔═══╝ ██╔══██║██╔═██╗ ██║╚██╔╝██║██╔══██║██║╚██╗██║");
            Console.WriteLine("\t     ██║     ██║  ██║██║  ██╗██║ ╚═╝ ██║██║  ██║██║ ╚████║");
            Console.WriteLine("\t     ╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝\n");
            Console.WriteLine("\t    ██████╗ ██╗   ██╗    ███╗   ██╗███████╗██████╗  █████╗ ");
            Console.WriteLine("\t    ██╔══██╗╚██╗ ██╔╝    ████╗  ██║██╔════╝██╔══██╗██╔══██╗");
            Console.WriteLine("\t    ██████╔╝ ╚████╔╝     ██╔██╗ ██║█████╗  ██████╔╝███████║");
            Console.WriteLine("\t    ██╔══██╗  ╚██╔╝      ██║╚██╗██║██╔══╝  ██╔══██╗██╔══██║");
            Console.WriteLine("\t    ██████╔╝   ██║       ██║ ╚████║███████╗██████╔╝██║  ██║");
            Console.WriteLine("\t    ╚═════╝    ╚═╝       ╚═╝  ╚═══╝╚══════╝╚═════╝ ╚═╝  ╚═╝");

            Console.WriteLine("\n\n\n\t\t\t    Press Enter to Start :)");

            Console.ReadLine();
            Console.Clear();
        }

        public static void LoseScreen()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("        ▓██   ██▓ ▒█████   █    ██     ██▓     ▒█████    ██████ ▓█████ ");
            Console.WriteLine("         ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▓██▒    ▒██▒  ██▒▒██    ▒ ▓█   ▀ ");
            Console.WriteLine("          ▒██ ██░▒██░  ██▒▓██  ▒██░   ▒██░    ▒██░  ██▒░ ▓██▄   ▒███   ");
            Console.WriteLine("          ░ ▐██▓░▒██   ██░▓▓█  ░██░   ▒██░    ▒██   ██░  ▒   ██▒▒▓█  ▄ ");
            Console.WriteLine("          ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░██████▒░ ████▓▒░▒██████▒▒░▒████▒");
            Console.WriteLine("           ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒    ░ ▒░▓  ░░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░░░ ▒░ ░");
            Console.WriteLine("         ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░    ░ ░ ▒  ░  ░ ▒ ▒░ ░ ░▒  ░ ░ ░ ░  ░");
            Console.WriteLine("         ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░      ░ ░   ░ ░ ░ ▒  ░  ░  ░     ░   ");
            Console.WriteLine("         ░ ░         ░ ░     ░            ░  ░    ░ ░        ░     ░  ░");
            Console.WriteLine("         ░ ░                                                           ");

            Console.ReadLine();
            Environment.Exit(1);

        }
        public static void PrepareGameStart()
        {
            x = startX;
            y = startY;
            pacSpeed = 1;
            score = 0;
            lives = 3;

        }
        public static bool CanMoveTo(int x, int y, string[] map)
        {
            bool canMove = true;
            for (int row = 0; row < 22; row++)
            {
                for (int column = 0; column < 42; column++)
                {
                    if (map[row][column] == '|')
                        if ((x > column - 1) &&
                            (x < column + 1) &&
                            (y > row - 1) &&
                            (y < row + 1)
                            )
                        {
                            canMove = false;
                        }
                    if (map[row][column] == '-')
                        if ((x > column - 1) &&
                            (x < column + 1) &&
                            (y > row - 1) &&
                            (y < row + 1)
                            )
                        {
                            canMove = false;
                        }
                    if (map[row][column] == '_')
                        if ((x > column - 1) &&
                            (x < column + 1) &&
                            (y > row - 1) &&
                            (y < row + 1)
                            )
                        {
                            canMove = false;
                        }
                }
            }
            return canMove;
        }
        public static void Main(string[] args)
        {
            
            Console.Title = "paKmaN";

            int x = 20, y = 11;

            int lives = 3;

            ConsoleKeyInfo userKey;


            //Enemies
            float xEnemy = 15, yEnemy = 20;
            float xEnemy1 = 5, yEnemy1 = 1;
            float xEnemy2 = 10, yEnemy2 = 4;
            float xEnemy3 = 31, yEnemy3 = 10;
            float incrXEnemy = 0.4f;
            float incrXEnemy1 = 0.7f;
            float incrYEnemy = 0.3f;
            float incrYEnemy1 = 0.5f;

            // Dots
            bool visibleDot1 = true;
            bool visibleDot2 = true;
            bool visibleDot3 = true;
            bool visibleDot4 = true;
            bool visibleDot5 = true;
            bool visibleDot6 = true;
            bool visibleDot7 = true;
            bool visibleDot8 = true;
            bool visibleDot9 = true;
            bool visibleDot10 = true;
            bool visibleDot11 = true;
            bool visibleDot12 = true;
            bool visibleDot13 = true;
            bool visibleDot14 = true;
            bool visibleDot15 = true;
            bool visibleDot16 = true;
            bool visibleDot17 = true;
            bool visibleDot18 = true;
            bool visibleDot19 = true;
            bool visibleDot20 = true;
            bool visibleDot21 = true;
            bool visibleDot22 = true;
            bool visibleDot23 = true;
            bool visibleDot24 = true;
            bool visibleDot25 = true;
            bool visibleDot26 = true;
            bool visibleDot27 = true;
            bool visibleDot28 = true;
            bool visibleDot29 = true;
            bool visibleDot30 = true;
            bool visibleDot31 = true;
            bool visibleDot32 = true;
            bool visibleDot33 = true;
            bool visibleDot34 = true;
            bool visibleDot35 = true;
            bool visibleDot36 = true;
            bool visibleDot37 = true;
            bool visibleDot38 = true;
            bool visibleDot39 = true;
            bool visibleDot40 = true;
            bool visibleDot41 = true;
            bool visibleDot42 = true;
            bool visibleDot43 = true;
            bool visibleDot44 = true;
            bool visibleDot45 = true;
            bool visibleDot46 = true;
            bool visibleDot47 = true;
            bool visibleDot48 = true;
            bool visibleDot49 = true;
            bool visibleDot50 = true;
            bool visibleDot51 = true;
            bool visibleDot52 = true;
            bool visibleDot53 = true;
            bool visibleDot54 = true;
            bool visibleDot55 = true;
            bool visibleDot56 = true;
            bool visibleDot57 = true;
            bool visibleDot58 = true;
            bool visibleDot59 = true;
            bool visibleDot60 = true;
            bool visibleDot61 = true;
            bool visibleDot62 = true;
            bool visibleDot63 = true;
            bool visibleDot64 = true;
            bool visibleDot65 = true;
            bool visibleDot66 = true;
            bool visibleDot67 = true;
            bool visibleDot68 = true;
            bool visibleDot69 = true;
            bool visibleDot70 = true;
            bool visibleDot71 = true;
            bool visibleDot72 = true;
            bool visibleDot73 = true;
            bool visibleDot74 = true;
            bool visibleDot75 = true;
            bool visibleDot76 = true;
            bool visibleDot77 = true;
            bool visibleDot78 = true;
            bool visibleDot79 = true;
            bool visibleDot80 = true;
            bool visibleDot81 = true;
            bool visibleDot82 = true;
            bool visibleDot83 = true;
            bool visibleDot84 = true;
            bool visibleDot85 = true;
            bool visibleDot86 = true;
            bool visibleDot87 = true;
            bool visibleDot88 = true;
            bool visibleDot89 = true;
            bool visibleDot90 = true;
            bool visibleDot91 = true;
            bool visibleDot92 = true;
            bool visibleDot93 = true;
            bool visibleDot94 = true;
            bool visibleDot95 = true;
            bool visibleDot96 = true;
            bool visibleDot97 = true;
            bool visibleDot98 = true;
            bool visibleDot99 = true;
            bool visibleDot100 = true;
            bool visibleDot101 = true;
            bool visibleDot102 = true;
            bool visibleDot103 = true;
            bool visibleDot104 = true;
            bool visibleDot105 = true;
            bool visibleDot106 = true;
            bool visibleDot107 = true;
            bool visibleDot108 = true;
            bool visibleDot109 = true;
            bool visibleDot110 = true;
            bool visibleDot111 = true;
            bool visibleDot112 = true;
            bool visibleDot113 = true;
            bool visibleDot114 = true;
            bool visibleDot115 = true;
            bool visibleDot116 = true;
            bool visibleDot117 = true;
            bool visibleDot118 = true;
            bool visibleDot119 = true;
            bool visibleDot120 = true;
            bool visibleDot121 = true;
            bool visibleDot122 = true;
            bool visibleDot123 = true;
            bool visibleDot124 = true;
            bool visibleDot125 = true;
            bool visibleDot126 = true;
            bool visibleDot127 = true;
            bool visibleDot128 = true;
            bool visibleDot129 = true;
            bool visibleDot130 = true;
            bool visibleDot131 = true;
            bool visibleDot132 = true;
            bool visibleDot133 = true;
            bool visibleDot134 = true;
            bool visibleDot135 = true;
            bool visibleDot136 = true;
            bool visibleDot137 = true;
            bool visibleDot138 = true;
            bool visibleDot139 = true;
            bool visibleDot140 = true;
            bool visibleDot141 = true;
            bool visibleDot142 = true;
            bool visibleDot143 = true;
            bool visibleDot144 = true;
            bool visibleDot145 = true;
            bool visibleDot146 = true;
            bool visibleDot147 = true;
            bool visibleDot148 = true;
            bool visibleDot149 = true;
            bool visibleDot150 = true;
            bool visibleDot151 = true;
            bool visibleDot152 = true;
            bool visibleDot153 = true;
            bool visibleDot154 = true;
            bool visibleDot155 = true;
            bool visibleDot156 = true;
            bool visibleDot157 = true;
            bool visibleDot158 = true;
            bool visibleDot159 = true;
            bool visibleDot160 = true;
            bool visibleDot161 = true;
            bool visibleDot162 = true;
            bool visibleDot163 = true;
            bool visibleDot164 = true;
            bool visibleDot165 = true;
            bool visibleDot166 = true;
            bool visibleDot167 = true;
            bool visibleDot168 = true;
            bool visibleDot169 = true;
            bool visibleDot170 = true;
            bool visibleDot171 = true;
            bool visibleDot172 = true;
            bool visibleDot173 = true;
            bool visibleDot174 = true;
            bool visibleDot175 = true;
            bool visibleDot176 = true;
            bool visibleDot177 = true;
            bool visibleDot178 = true;
            bool visibleDot179 = true;
            bool visibleDot180 = true;
            bool visibleDot181 = true;
            bool visibleDot182 = true;
            bool visibleDot183 = true;
            bool visibleDot184 = true;
            bool visibleDot185 = true;
            bool visibleDot186 = true;
            bool visibleDot187 = true;
            bool visibleDot188 = true;
            bool visibleDot189 = true;
            bool visibleDot190 = true;
            bool visibleDot191 = true;
            bool visibleDot192 = true;
            bool visibleDot193 = true;
            bool visibleDot194 = true;
            bool visibleDot195 = true;
            bool visibleDot196 = true;
            bool visibleDot197 = true;
            bool visibleDot198 = true;
            bool visibleDot199 = true;
            bool visibleDot200 = true;
            bool visibleDot201 = true;
            bool visibleDot202 = true;
            bool visibleDot203 = true;
            bool visibleDot204 = true;
            bool visibleDot205 = true;
            bool visibleDot206 = true;
            bool visibleDot207 = true;
            bool visibleDot208 = true;
            bool visibleDot209 = true;
            bool visibleDot210 = true;
            bool visibleDot211 = true;
            bool visibleDot212 = true;
            bool visibleDot213 = true;
            bool visibleDot214 = true;
            bool visibleDot215 = true;
            bool visibleDot216 = true;
            bool visibleDot217 = true;
            bool visibleDot218 = true;
            bool visibleDot219 = true;
            bool visibleDot220 = true;
            bool visibleDot221 = true;
            bool visibleDot222 = true;
            bool visibleDot223 = true;
            bool visibleDot224 = true;
            bool visibleDot225 = true;
            bool visibleDot226 = true;
            bool visibleDot227 = true;
            bool visibleDot228 = true;
            bool visibleDot229 = true;
            bool visibleDot230 = true;
            bool visibleDot231 = true;
            bool visibleDot232 = true;
            bool visibleDot233 = true;
            bool visibleDot234 = true;
            bool visibleDot235 = true;
            bool visibleDot236 = true;
            bool visibleDot237 = true;
            bool visibleDot238 = true;
            bool visibleDot239 = true;
            bool visibleDot240 = true;
            bool visibleDot241 = true;
            bool visibleDot242 = true;
            bool visibleDot243 = true;
            bool visibleDot244 = true;
            bool visibleDot245 = true;
            bool visibleDot246 = true;
            bool visibleDot247 = true;
            bool visibleDot248 = true;
            bool visibleDot249 = true;
            bool visibleDot250 = true;
            bool visibleDot251 = true;
            bool visibleDot252 = true;
            bool visibleDot253 = true;
            bool visibleDot254 = true;
            bool visibleDot255 = true;
            bool visibleDot256 = true;
            bool visibleDot257 = true;
            bool visibleDot258 = true;
            bool visibleDot259 = true;
            bool visibleDot260 = true;
            bool visibleDot261 = true;
            bool visibleDot262 = true;
            bool visibleDot263 = true;
            bool visibleDot264 = true;
            int xDot1 = 2, yDot1 = 1;
            int xDot2 = 3, yDot2 = 1;
            int xDot3 = 4, yDot3 = 1;
            int xDot4 = 5, yDot4 = 1;
            int xDot5 = 6, yDot5 = 1;
            int xDot6 = 7, yDot6 = 1;
            int xDot7 = 8, yDot7 = 1;
            int xDot8 = 9, yDot8 = 1;
            int xDot9 = 10, yDot9 = 1;
            int xDot10 = 11, yDot10 = 1;
            int xDot11 = 12, yDot11 = 1;
            int xDot12 = 13, yDot12 = 1;
            int xDot13 = 14, yDot13 = 1;
            int xDot14 = 15, yDot14 = 1;
            int xDot15 = 16, yDot15 = 1;
            int xDot16 = 17, yDot16 = 1;
            int xDot17 = 18, yDot17 = 1;
            int xDot18 = 19, yDot18 = 1;
            int xDot19 = 20, yDot19 = 1;
            int xDot20 = 21, yDot20 = 1;
            int xDot21 = 22, yDot21 = 1;
            int xDot22 = 23, yDot22 = 1;
            int xDot23 = 24, yDot23 = 1;
            int xDot24 = 25, yDot24 = 1;
            int xDot25 = 26, yDot25 = 1;
            int xDot26 = 27, yDot26 = 1;
            int xDot27 = 28, yDot27 = 1;
            int xDot28 = 29, yDot28 = 1;
            int xDot29 = 30, yDot29 = 1;
            int xDot30 = 31, yDot30 = 1;
            int xDot31 = 32, yDot31 = 1;
            int xDot32 = 33, yDot32 = 1;
            int xDot33 = 34, yDot33 = 1;
            int xDot34 = 35, yDot34 = 1;
            int xDot35 = 36, yDot35 = 1;
            int xDot36 = 37, yDot36 = 1;
            int xDot37 = 38, yDot37 = 1;
            int xDot38 = 39, yDot38 = 1;
            int xDot39 = 39, yDot39 = 2;
            int xDot40 = 2, yDot40 = 2;
            int xDot41 = 2, yDot41 = 3;
            int xDot42 = 2, yDot42 = 4;
            int xDot43 = 3, yDot43 = 4;
            int xDot44 = 4, yDot44 = 4;
            int xDot45 = 5, yDot45 = 4;
            int xDot46 = 6, yDot46 = 4;
            int xDot47 = 7, yDot47 = 4;
            int xDot48 = 8, yDot48 = 4;
            int xDot49 = 9, yDot49 = 4;
            int xDot50 = 10, yDot50 = 4;
            int xDot51 = 10, yDot51 = 2;
            int xDot52 = 10, yDot52 = 3;
            int xDot53 = 10, yDot53 = 4;
            int xDot54 = 10, yDot54 = 5;
            int xDot55 = 10, yDot55 = 6;
            int xDot56 = 10, yDot56 = 7;
            int xDot57 = 10, yDot57 = 8;
            int xDot58 = 10, yDot58 = 9;
            int xDot59 = 10, yDot59 = 10;
            int xDot60 = 10, yDot60 = 11;
            int xDot61 = 10, yDot61 = 12;
            int xDot62 = 10, yDot62 = 13;
            int xDot63 = 10, yDot63 = 14;
            int xDot64 = 10, yDot64 = 15;
            int xDot65 = 10, yDot65 = 16;
            int xDot66 = 10, yDot66 = 17;
            int xDot67 = 10, yDot67 = 18;
            int xDot68 = 10, yDot68 = 19;
            int xDot69 = 10, yDot69 = 20;
            int xDot70 = 2, yDot70 = 20;
            int xDot71 = 3, yDot71 = 20;
            int xDot72 = 4, yDot72 = 20;
            int xDot73 = 5, yDot73 = 20;
            int xDot74 = 6, yDot74 = 20;
            int xDot75 = 7, yDot75 = 20;
            int xDot76 = 8, yDot76 = 20;
            int xDot77 = 9, yDot77 = 20;
            int xDot78 = 11, yDot78 = 20;
            int xDot79 = 12, yDot79 = 20;
            int xDot80 = 13, yDot80 = 20;
            int xDot81 = 14, yDot81 = 20;
            int xDot82 = 15, yDot82 = 20;
            int xDot83 = 16, yDot83 = 20;
            int xDot84 = 17, yDot84 = 20;
            int xDot85 = 18, yDot85 = 20;
            int xDot86 = 19, yDot86 = 20;
            int xDot87 = 20, yDot87 = 20;
            int xDot88 = 21, yDot88 = 20;
            int xDot89 = 22, yDot89 = 20;
            int xDot90 = 23, yDot90 = 20;
            int xDot91 = 24, yDot91 = 20;
            int xDot92 = 25, yDot92 = 20;
            int xDot93 = 26, yDot93 = 20;
            int xDot94 = 27, yDot94 = 20;
            int xDot95 = 28, yDot95 = 20;
            int xDot96 = 29, yDot96 = 20;
            int xDot97 = 30, yDot97 = 20;
            int xDot98 = 31, yDot98 = 20;
            int xDot99 = 32, yDot99 = 20;
            int xDot100 = 33, yDot100 = 20;
            int xDot101 = 34, yDot101 = 20;
            int xDot102 = 35, yDot102 = 20;
            int xDot103 = 36, yDot103 = 20;
            int xDot104 = 37, yDot104 = 20;
            int xDot105 = 38, yDot105 = 20;
            int xDot106 = 39, yDot106 = 20;
            int xDot107 = 36, yDot107 = 19;
            int xDot108 = 36, yDot108 = 18;
            int xDot109 = 36, yDot109 = 17;
            int xDot110 = 37, yDot110 = 17;
            int xDot111 = 38, yDot111 = 17;
            int xDot112 = 39, yDot112 = 17;
            int xDot113 = 39, yDot113 = 16;
            int xDot114 = 39, yDot114 = 15;
            int xDot115 = 39, yDot115 = 14;
            int xDot116 = 38, yDot116 = 14;
            int xDot117 = 37, yDot117 = 14;
            int xDot118 = 36, yDot118 = 14;
            int xDot119 = 35, yDot119 = 14;
            int xDot120 = 34, yDot120 = 14;
            int xDot121 = 33, yDot121 = 14;
            int xDot122 = 32, yDot122 = 14;
            int xDot123 = 31, yDot123 = 14;
            int xDot124 = 31, yDot124 = 15;
            int xDot125 = 31, yDot125 = 16;
            int xDot126 = 31, yDot126 = 17;
            int xDot127 = 31, yDot127 = 18;
            int xDot128 = 31, yDot128 = 19;
            int xDot129 = 31, yDot129 = 13;
            int xDot130 = 31, yDot130 = 12;
            int xDot131 = 31, yDot131 = 11;
            int xDot132 = 31, yDot132 = 10;
            int xDot133 = 31, yDot133 = 9;
            int xDot134 = 31, yDot134 = 8;
            int xDot135 = 31, yDot135 = 7;
            int xDot136 = 31, yDot136 = 6;
            int xDot137 = 31, yDot137 = 5;
            int xDot138 = 31, yDot138 = 4;
            int xDot139 = 31, yDot139 = 3;
            int xDot140 = 31, yDot140 = 2;
            int xDot141 = 32, yDot141 = 4;
            int xDot142 = 33, yDot142 = 4;
            int xDot143 = 34, yDot143 = 4;
            int xDot144 = 35, yDot144 = 4;
            int xDot145 = 36, yDot145 = 4;
            int xDot146 = 37, yDot146 = 4;
            int xDot147 = 38, yDot147 = 4;
            int xDot148 = 39, yDot148 = 4;
            int xDot149 = 39, yDot149 = 3;
            int xDot150 = 9, yDot150 = 14;
            int xDot151 = 8, yDot151 = 14;
            int xDot152 = 7, yDot152 = 14;
            int xDot153 = 6, yDot153 = 14;
            int xDot154 = 5, yDot154 = 14;
            int xDot155 = 4, yDot155 = 14;
            int xDot156 = 3, yDot156 = 14;
            int xDot157 = 2, yDot157 = 14;
            int xDot158 = 2, yDot158 = 15;
            int xDot159 = 2, yDot159 = 16;
            int xDot160 = 2, yDot160 = 17;
            int xDot161 = 3, yDot161 = 17;
            int xDot162 = 4, yDot162 = 17;
            int xDot163 = 5, yDot163 = 17;
            int xDot164 = 5, yDot164 = 18;
            int xDot165 = 5, yDot165 = 19;
            int xDot166 = 11, yDot166 = 17;
            int xDot167 = 12, yDot167 = 17;
            int xDot168 = 13, yDot168 = 17;
            int xDot169 = 14, yDot169 = 17;
            int xDot170 = 15, yDot170 = 17;
            int xDot171 = 16, yDot171 = 17;
            int xDot172 = 17, yDot172 = 17;
            int xDot173 = 18, yDot173 = 17;
            int xDot174 = 19, yDot174 = 17;
            int xDot175 = 20, yDot175 = 17;
            int xDot176 = 21, yDot176 = 17;
            int xDot177 = 22, yDot177 = 17;
            int xDot178 = 23, yDot178 = 17;
            int xDot179 = 24, yDot179 = 17;
            int xDot180 = 25, yDot180 = 17;
            int xDot181 = 26, yDot181 = 17;
            int xDot182 = 27, yDot182 = 17;
            int xDot183 = 28, yDot183 = 17;
            int xDot184 = 29, yDot184 = 17;
            int xDot185 = 30, yDot185 = 17;
            int xDot186 = 11, yDot186 = 14;
            int xDot187 = 12, yDot187 = 14;
            int xDot188 = 13, yDot188 = 14;
            int xDot189 = 14, yDot189 = 14;
            int xDot190 = 15, yDot190 = 14;
            int xDot191 = 16, yDot191 = 14;
            int xDot192 = 17, yDot192 = 14;
            int xDot193 = 18, yDot193 = 14;
            int xDot194 = 18, yDot194 = 15;
            int xDot195 = 18, yDot195 = 16;
            int xDot196 = 11, yDot196 = 9;
            int xDot197 = 12, yDot197 = 9;
            int xDot198 = 13, yDot198 = 9;
            int xDot199 = 14, yDot199 = 9;
            int xDot200 = 14, yDot200 = 10;
            int xDot201 = 14, yDot201 = 11;
            int xDot202 = 14, yDot202 = 12;
            int xDot203 = 14, yDot203 = 13;
            int xDot204 = 14, yDot204 = 8;
            int xDot205 = 14, yDot205 = 7;
            int xDot206 = 14, yDot206 = 6;
            int xDot207 = 15, yDot207 = 6;
            int xDot208 = 16, yDot208 = 6;
            int xDot209 = 17, yDot209 = 6;
            int xDot210 = 18, yDot210 = 6;
            int xDot211 = 19, yDot211 = 6;
            int xDot212 = 20, yDot212 = 6;
            int xDot213 = 21, yDot213 = 6;
            int xDot214 = 22, yDot214 = 6;
            int xDot215 = 23, yDot215 = 6;
            int xDot216 = 24, yDot216 = 6;
            int xDot217 = 25, yDot217 = 6;
            int xDot218 = 26, yDot218 = 6;
            int xDot219 = 27, yDot219 = 6;
            int xDot220 = 27, yDot220 = 7;
            int xDot221 = 27, yDot221 = 8;
            int xDot222 = 27, yDot222 = 9;
            int xDot223 = 27, yDot223 = 10;
            int xDot224 = 27, yDot224 = 11;
            int xDot225 = 27, yDot225 = 12;
            int xDot226 = 27, yDot226 = 13;
            int xDot227 = 27, yDot227 = 14;
            int xDot228 = 23, yDot228 = 14;
            int xDot229 = 23, yDot229 = 15;
            int xDot230 = 23, yDot230 = 16;
            int xDot231 = 24, yDot231 = 14;
            int xDot232 = 25, yDot232 = 14;
            int xDot233 = 26, yDot233 = 14;
            int xDot234 = 28, yDot234 = 14;
            int xDot235 = 29, yDot235 = 14;
            int xDot236 = 30, yDot236 = 14;
            int xDot237 = 15, yDot237 = 11;
            int xDot238 = 16, yDot238 = 11;
            int xDot239 = 17, yDot239 = 11;
            int xDot240 = 18, yDot240 = 11;
            int xDot241 = 19, yDot241 = 11;
            int xDot242 = 21, yDot242 = 11;
            int xDot243 = 22, yDot243 = 11;
            int xDot244 = 23, yDot244 = 11;
            int xDot245 = 24, yDot245 = 11;
            int xDot246 = 25, yDot246 = 11;
            int xDot247 = 26, yDot247 = 11;
            int xDot248 = 28, yDot248 = 9;
            int xDot249 = 29, yDot249 = 9;
            int xDot250 = 30, yDot250 = 9;
            int xDot251 = 23, yDot251 = 5;
            int xDot252 = 23, yDot252 = 4;
            int xDot253 = 24, yDot253 = 4;
            int xDot254 = 25, yDot254 = 4;
            int xDot255 = 26, yDot255 = 4;
            int xDot256 = 26, yDot256 = 3;
            int xDot257 = 26, yDot257 = 2;
            int xDot258 = 18, yDot258 = 5;
            int xDot259 = 18, yDot259 = 4;
            int xDot260 = 17, yDot260 = 4;
            int xDot261 = 16, yDot261 = 4;
            int xDot262 = 15, yDot262 = 4;
            int xDot263 = 15, yDot263 = 3;
            int xDot264 = 15, yDot264 = 2;

            //Score
            int score = 0;
            int pacSpeed = 1;

            Console.CursorVisible = false;

            Intro();

            while (!sessionFinished)
            {
                PrepareGameStart();

                // Game Loop
                bool gameEnd = false;
                while (!gameEnd)
                {
                    // Drawing Score
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(65, 1);
                    Console.Write("Score: {0}", score);
                    Console.SetCursorPosition(50, 1);
                    Console.Write("Lives: {0}", lives);

                    // Drawing DOTS
                    Console.ForegroundColor = ConsoleColor.White;
                    if (visibleDot1)
                    {
                        Console.SetCursorPosition(xDot1, yDot1);
                        Console.Write(".");
                    }
                    if (visibleDot2)
                    {
                        Console.SetCursorPosition(xDot2, yDot2);
                        Console.Write(".");
                    }
                    if (visibleDot3)
                    {
                        Console.SetCursorPosition(xDot3, yDot3);
                        Console.Write(".");
                    }
                    if (visibleDot4)
                    {
                        Console.SetCursorPosition(xDot4, yDot4);
                        Console.Write(".");
                    }
                    if (visibleDot5)
                    {
                        Console.SetCursorPosition(xDot5, yDot5);
                        Console.Write(".");
                    }
                    if (visibleDot6)
                    {
                        Console.SetCursorPosition(xDot6, yDot6);
                        Console.Write(".");
                    }
                    if (visibleDot7)
                    {
                        Console.SetCursorPosition(xDot7, yDot7);
                        Console.Write(".");
                    }
                    if (visibleDot8)
                    {
                        Console.SetCursorPosition(xDot8, yDot8);
                        Console.Write(".");
                    }
                    if (visibleDot9)
                    {
                        Console.SetCursorPosition(xDot9, yDot9);
                        Console.Write(".");
                    }
                    if (visibleDot10)
                    {
                        Console.SetCursorPosition(xDot10, yDot10);
                        Console.Write(".");
                    }
                    if (visibleDot11)
                    {
                        Console.SetCursorPosition(xDot11, yDot11);
                        Console.Write(".");
                    }
                    if (visibleDot12)
                    {
                        Console.SetCursorPosition(xDot12, yDot12);
                        Console.Write(".");
                    }
                    if (visibleDot13)
                    {
                        Console.SetCursorPosition(xDot13, yDot13);
                        Console.Write(".");
                    }
                    if (visibleDot14)
                    {
                        Console.SetCursorPosition(xDot14, yDot14);
                        Console.Write(".");
                    }
                    if (visibleDot15)
                    {
                        Console.SetCursorPosition(xDot15, yDot15);
                        Console.Write(".");
                    }
                    if (visibleDot16)
                    {
                        Console.SetCursorPosition(xDot16, yDot16);
                        Console.Write(".");
                    }
                    if (visibleDot17)
                    {
                        Console.SetCursorPosition(xDot17, yDot17);
                        Console.Write(".");
                    }
                    if (visibleDot18)
                    {
                        Console.SetCursorPosition(xDot18, yDot18);
                        Console.Write(".");
                    }
                    if (visibleDot19)
                    {
                        Console.SetCursorPosition(xDot19, yDot19);
                        Console.Write(".");
                    }
                    if (visibleDot20)
                    {
                        Console.SetCursorPosition(xDot20, yDot20);
                        Console.Write(".");
                    }
                    if (visibleDot21)
                    {
                        Console.SetCursorPosition(xDot21, yDot21);
                        Console.Write(".");
                    }
                    if (visibleDot22)
                    {
                        Console.SetCursorPosition(xDot22, yDot22);
                        Console.Write(".");
                    }
                    if (visibleDot23)
                    {
                        Console.SetCursorPosition(xDot23, yDot23);
                        Console.Write(".");
                    }
                    if (visibleDot24)
                    {
                        Console.SetCursorPosition(xDot24, yDot24);
                        Console.Write(".");
                    }
                    if (visibleDot25)
                    {
                        Console.SetCursorPosition(xDot25, yDot25);
                        Console.Write(".");
                    }
                    if (visibleDot26)
                    {
                        Console.SetCursorPosition(xDot26, yDot26);
                        Console.Write(".");
                    }
                    if (visibleDot27)
                    {
                        Console.SetCursorPosition(xDot27, yDot27);
                        Console.Write(".");
                    }
                    if (visibleDot28)
                    {
                        Console.SetCursorPosition(xDot28, yDot28);
                        Console.Write(".");
                    }
                    if (visibleDot29)
                    {
                        Console.SetCursorPosition(xDot29, yDot29);
                        Console.Write(".");
                    }
                    if (visibleDot30)
                    {
                        Console.SetCursorPosition(xDot30, yDot30);
                        Console.Write(".");
                    }
                    if (visibleDot31)
                    {
                        Console.SetCursorPosition(xDot31, yDot31);
                        Console.Write(".");
                    }
                    if (visibleDot32)
                    {
                        Console.SetCursorPosition(xDot32, yDot32);
                        Console.Write(".");
                    }
                    if (visibleDot33)
                    {
                        Console.SetCursorPosition(xDot33, yDot33);
                        Console.Write(".");
                    }
                    if (visibleDot34)
                    {
                        Console.SetCursorPosition(xDot34, yDot34);
                        Console.Write(".");
                    }
                    if (visibleDot35)
                    {
                        Console.SetCursorPosition(xDot35, yDot35);
                        Console.Write(".");
                    }
                    if (visibleDot36)
                    {
                        Console.SetCursorPosition(xDot36, yDot36);
                        Console.Write(".");
                    }
                    if (visibleDot37)
                    {
                        Console.SetCursorPosition(xDot37, yDot37);
                        Console.Write(".");
                    }
                    if (visibleDot38)
                    {
                        Console.SetCursorPosition(xDot38, yDot38);
                        Console.Write(".");
                    }
                    if (visibleDot39)
                    {
                        Console.SetCursorPosition(xDot39, yDot39);
                        Console.Write(".");
                    }
                    if (visibleDot40)
                    {
                        Console.SetCursorPosition(xDot40, yDot40);
                        Console.Write(".");
                    }
                    if (visibleDot41)
                    {
                        Console.SetCursorPosition(xDot41, yDot41);
                        Console.Write(".");
                    }
                    if (visibleDot42)
                    {
                        Console.SetCursorPosition(xDot42, yDot42);
                        Console.Write(".");
                    }
                    if (visibleDot43)
                    {
                        Console.SetCursorPosition(xDot43, yDot43);
                        Console.Write(".");
                    }
                    if (visibleDot44)
                    {
                        Console.SetCursorPosition(xDot44, yDot44);
                        Console.Write(".");
                    }
                    if (visibleDot45)
                    {
                        Console.SetCursorPosition(xDot45, yDot45);
                        Console.Write(".");
                    }
                    if (visibleDot46)
                    {
                        Console.SetCursorPosition(xDot46, yDot46);
                        Console.Write(".");
                    }
                    if (visibleDot47)
                    {
                        Console.SetCursorPosition(xDot47, yDot47);
                        Console.Write(".");
                    }
                    if (visibleDot48)
                    {
                        Console.SetCursorPosition(xDot48, yDot48);
                        Console.Write(".");
                    }
                    if (visibleDot49)
                    {
                        Console.SetCursorPosition(xDot49, yDot49);
                        Console.Write(".");
                    }
                    if (visibleDot50)
                    {
                        Console.SetCursorPosition(xDot50, yDot50);
                        Console.Write(".");
                    }
                    if (visibleDot51)
                    {
                        Console.SetCursorPosition(xDot51, yDot51);
                        Console.Write(".");
                    }
                    if (visibleDot52)
                    {
                        Console.SetCursorPosition(xDot52, yDot52);
                        Console.Write(".");
                    }
                    if (visibleDot53)
                    {
                        Console.SetCursorPosition(xDot53, yDot53);
                        Console.Write(".");
                    }
                    if (visibleDot54)
                    {
                        Console.SetCursorPosition(xDot54, yDot54);
                        Console.Write(".");
                    }
                    if (visibleDot55)
                    {
                        Console.SetCursorPosition(xDot55, yDot55);
                        Console.Write(".");
                    }
                    if (visibleDot56)
                    {
                        Console.SetCursorPosition(xDot56, yDot56);
                        Console.Write(".");
                    }
                    if (visibleDot57)
                    {
                        Console.SetCursorPosition(xDot57, yDot57);
                        Console.Write(".");
                    }
                    if (visibleDot58)
                    {
                        Console.SetCursorPosition(xDot58, yDot58);
                        Console.Write(".");
                    }
                    if (visibleDot59)
                    {
                        Console.SetCursorPosition(xDot59, yDot59);
                        Console.Write(".");
                    }
                    if (visibleDot60)
                    {
                        Console.SetCursorPosition(xDot60, yDot60);
                        Console.Write(".");
                    }
                    if (visibleDot61)
                    {
                        Console.SetCursorPosition(xDot61, yDot61);
                        Console.Write(".");
                    }
                    if (visibleDot62)
                    {
                        Console.SetCursorPosition(xDot62, yDot62);
                        Console.Write(".");
                    }
                    if (visibleDot63)
                    {
                        Console.SetCursorPosition(xDot63, yDot63);
                        Console.Write(".");
                    }
                    if (visibleDot64)
                    {
                        Console.SetCursorPosition(xDot64, yDot64);
                        Console.Write(".");
                    }
                    if (visibleDot65)
                    {
                        Console.SetCursorPosition(xDot65, yDot65);
                        Console.Write(".");
                    }
                    if (visibleDot66)
                    {
                        Console.SetCursorPosition(xDot66, yDot66);
                        Console.Write(".");
                    }
                    if (visibleDot67)
                    {
                        Console.SetCursorPosition(xDot67, yDot67);
                        Console.Write(".");
                    }
                    if (visibleDot68)
                    {
                        Console.SetCursorPosition(xDot68, yDot68);
                        Console.Write(".");
                    }
                    if (visibleDot69)
                    {
                        Console.SetCursorPosition(xDot69, yDot69);
                        Console.Write(".");
                    }
                    if (visibleDot70)
                    {
                        Console.SetCursorPosition(xDot70, yDot70);
                        Console.Write(".");
                    }
                    if (visibleDot71)
                    {
                        Console.SetCursorPosition(xDot71, yDot71);
                        Console.Write(".");
                    }
                    if (visibleDot72)
                    {
                        Console.SetCursorPosition(xDot72, yDot72);
                        Console.Write(".");
                    }
                    if (visibleDot73)
                    {
                        Console.SetCursorPosition(xDot73, yDot73);
                        Console.Write(".");
                    }
                    if (visibleDot74)
                    {
                        Console.SetCursorPosition(xDot74, yDot74);
                        Console.Write(".");
                    }
                    if (visibleDot75)
                    {
                        Console.SetCursorPosition(xDot75, yDot75);
                        Console.Write(".");
                    }
                    if (visibleDot76)
                    {
                        Console.SetCursorPosition(xDot76, yDot76);
                        Console.Write(".");
                    }
                    if (visibleDot77)
                    {
                        Console.SetCursorPosition(xDot77, yDot77);
                        Console.Write(".");
                    }
                    if (visibleDot78)
                    {
                        Console.SetCursorPosition(xDot78, yDot78);
                        Console.Write(".");
                    }
                    if (visibleDot79)
                    {
                        Console.SetCursorPosition(xDot79, yDot79);
                        Console.Write(".");
                    }
                    if (visibleDot80)
                    {
                        Console.SetCursorPosition(xDot80, yDot80);
                        Console.Write(".");
                    }
                    if (visibleDot81)
                    {
                        Console.SetCursorPosition(xDot81, yDot81);
                        Console.Write(".");
                    }
                    if (visibleDot82)
                    {
                        Console.SetCursorPosition(xDot82, yDot82);
                        Console.Write(".");
                    }
                    if (visibleDot83)
                    {
                        Console.SetCursorPosition(xDot83, yDot83);
                        Console.Write(".");
                    }
                    if (visibleDot84)
                    {
                        Console.SetCursorPosition(xDot84, yDot84);
                        Console.Write(".");
                    }
                    if (visibleDot85)
                    {
                        Console.SetCursorPosition(xDot85, yDot85);
                        Console.Write(".");
                    }
                    if (visibleDot86)
                    {
                        Console.SetCursorPosition(xDot86, yDot86);
                        Console.Write(".");
                    }
                    if (visibleDot87)
                    {
                        Console.SetCursorPosition(xDot87, yDot87);
                        Console.Write(".");
                    }
                    if (visibleDot88)
                    {
                        Console.SetCursorPosition(xDot88, yDot88);
                        Console.Write(".");
                    }
                    if (visibleDot89)
                    {
                        Console.SetCursorPosition(xDot89, yDot89);
                        Console.Write(".");
                    }
                    if (visibleDot90)
                    {
                        Console.SetCursorPosition(xDot90, yDot90);
                        Console.Write(".");
                    }
                    if (visibleDot91)
                    {
                        Console.SetCursorPosition(xDot91, yDot91);
                        Console.Write(".");
                    }
                    if (visibleDot92)
                    {
                        Console.SetCursorPosition(xDot92, yDot92);
                        Console.Write(".");
                    }
                    if (visibleDot93)
                    {
                        Console.SetCursorPosition(xDot93, yDot93);
                        Console.Write(".");
                    }
                    if (visibleDot94)
                    {
                        Console.SetCursorPosition(xDot94, yDot94);
                        Console.Write(".");
                    }
                    if (visibleDot95)
                    {
                        Console.SetCursorPosition(xDot95, yDot95);
                        Console.Write(".");
                    }
                    if (visibleDot96)
                    {
                        Console.SetCursorPosition(xDot96, yDot96);
                        Console.Write(".");
                    }
                    if (visibleDot97)
                    {
                        Console.SetCursorPosition(xDot97, yDot97);
                        Console.Write(".");
                    }
                    if (visibleDot98)
                    {
                        Console.SetCursorPosition(xDot98, yDot98);
                        Console.Write(".");
                    }
                    if (visibleDot99)
                    {
                        Console.SetCursorPosition(xDot99, yDot99);
                        Console.Write(".");
                    }
                    if (visibleDot100)
                    {
                        Console.SetCursorPosition(xDot100, yDot100);
                        Console.Write(".");
                    }
                    if (visibleDot101)
                    {
                        Console.SetCursorPosition(xDot101, yDot101);
                        Console.Write(".");
                    }
                    if (visibleDot102)
                    {
                        Console.SetCursorPosition(xDot102, yDot102);
                        Console.Write(".");
                    }
                    if (visibleDot103)
                    {
                        Console.SetCursorPosition(xDot103, yDot103);
                        Console.Write(".");
                    }
                    if (visibleDot104)
                    {
                        Console.SetCursorPosition(xDot104, yDot104);
                        Console.Write(".");
                    }
                    if (visibleDot105)
                    {
                        Console.SetCursorPosition(xDot105, yDot105);
                        Console.Write(".");
                    }
                    if (visibleDot106)
                    {
                        Console.SetCursorPosition(xDot106, yDot106);
                        Console.Write(".");
                    }
                    if (visibleDot107)
                    {
                        Console.SetCursorPosition(xDot107, yDot107);
                        Console.Write(".");
                    }
                    if (visibleDot108)
                    {
                        Console.SetCursorPosition(xDot108, yDot108);
                        Console.Write(".");
                    }
                    if (visibleDot109)
                    {
                        Console.SetCursorPosition(xDot109, yDot109);
                        Console.Write(".");
                    }
                    if (visibleDot110)
                    {
                        Console.SetCursorPosition(xDot110, yDot110);
                        Console.Write(".");
                    }
                    if (visibleDot111)
                    {
                        Console.SetCursorPosition(xDot111, yDot111);
                        Console.Write(".");
                    }
                    if (visibleDot112)
                    {
                        Console.SetCursorPosition(xDot112, yDot112);
                        Console.Write(".");
                    }
                    if (visibleDot113)
                    {
                        Console.SetCursorPosition(xDot113, yDot113);
                        Console.Write(".");
                    }
                    if (visibleDot114)
                    {
                        Console.SetCursorPosition(xDot114, yDot114);
                        Console.Write(".");
                    }
                    if (visibleDot115)
                    {
                        Console.SetCursorPosition(xDot115, yDot115);
                        Console.Write(".");
                    }
                    if (visibleDot116)
                    {
                        Console.SetCursorPosition(xDot116, yDot116);
                        Console.Write(".");
                    }
                    if (visibleDot117)
                    {
                        Console.SetCursorPosition(xDot117, yDot117);
                        Console.Write(".");
                    }
                    if (visibleDot118)
                    {
                        Console.SetCursorPosition(xDot118, yDot118);
                        Console.Write(".");
                    }
                    if (visibleDot119)
                    {
                        Console.SetCursorPosition(xDot119, yDot119);
                        Console.Write(".");
                    }
                    if (visibleDot120)
                    {
                        Console.SetCursorPosition(xDot120, yDot120);
                        Console.Write(".");
                    }
                    if (visibleDot121)
                    {
                        Console.SetCursorPosition(xDot121, yDot121);
                        Console.Write(".");
                    }
                    if (visibleDot122)
                    {
                        Console.SetCursorPosition(xDot122, yDot122);
                        Console.Write(".");
                    }
                    if (visibleDot123)
                    {
                        Console.SetCursorPosition(xDot123, yDot123);
                        Console.Write(".");
                    }
                    if (visibleDot124)
                    {
                        Console.SetCursorPosition(xDot124, yDot124);
                        Console.Write(".");
                    }
                    if (visibleDot125)
                    {
                        Console.SetCursorPosition(xDot125, yDot125);
                        Console.Write(".");
                    }
                    if (visibleDot126)
                    {
                        Console.SetCursorPosition(xDot126, yDot126);
                        Console.Write(".");
                    }
                    if (visibleDot127)
                    {
                        Console.SetCursorPosition(xDot127, yDot127);
                        Console.Write(".");
                    }
                    if (visibleDot128)
                    {
                        Console.SetCursorPosition(xDot128, yDot128);
                        Console.Write(".");
                    }
                    if (visibleDot129)
                    {
                        Console.SetCursorPosition(xDot129, yDot129);
                        Console.Write(".");
                    }
                    if (visibleDot130)
                    {
                        Console.SetCursorPosition(xDot130, yDot130);
                        Console.Write(".");
                    }
                    if (visibleDot131)
                    {
                        Console.SetCursorPosition(xDot131, yDot131);
                        Console.Write(".");
                    }
                    if (visibleDot132)
                    {
                        Console.SetCursorPosition(xDot132, yDot132);
                        Console.Write(".");
                    }
                    if (visibleDot133)
                    {
                        Console.SetCursorPosition(xDot133, yDot133);
                        Console.Write(".");
                    }
                    if (visibleDot134)
                    {
                        Console.SetCursorPosition(xDot134, yDot134);
                        Console.Write(".");
                    }
                    if (visibleDot135)
                    {
                        Console.SetCursorPosition(xDot135, yDot135);
                        Console.Write(".");
                    }
                    if (visibleDot136)
                    {
                        Console.SetCursorPosition(xDot136, yDot136);
                        Console.Write(".");
                    }
                    if (visibleDot137)
                    {
                        Console.SetCursorPosition(xDot137, yDot137);
                        Console.Write(".");
                    }
                    if (visibleDot138)
                    {
                        Console.SetCursorPosition(xDot138, yDot138);
                        Console.Write(".");
                    }
                    if (visibleDot139)
                    {
                        Console.SetCursorPosition(xDot139, yDot139);
                        Console.Write(".");
                    }
                    if (visibleDot140)
                    {
                        Console.SetCursorPosition(xDot140, yDot140);
                        Console.Write(".");
                    }
                    if (visibleDot141)
                    {
                        Console.SetCursorPosition(xDot141, yDot141);
                        Console.Write(".");
                    }
                    if (visibleDot142)
                    {
                        Console.SetCursorPosition(xDot142, yDot142);
                        Console.Write(".");
                    }
                    if (visibleDot143)
                    {
                        Console.SetCursorPosition(xDot143, yDot143);
                        Console.Write(".");
                    }
                    if (visibleDot144)
                    {
                        Console.SetCursorPosition(xDot144, yDot144);
                        Console.Write(".");
                    }
                    if (visibleDot145)
                    {
                        Console.SetCursorPosition(xDot145, yDot145);
                        Console.Write(".");
                    }
                    if (visibleDot146)
                    {
                        Console.SetCursorPosition(xDot146, yDot146);
                        Console.Write(".");
                    }
                    if (visibleDot147)
                    {
                        Console.SetCursorPosition(xDot147, yDot147);
                        Console.Write(".");
                    }
                    if (visibleDot148)
                    {
                        Console.SetCursorPosition(xDot148, yDot148);
                        Console.Write(".");
                    }
                    if (visibleDot149)
                    {
                        Console.SetCursorPosition(xDot149, yDot149);
                        Console.Write(".");
                    }
                    if (visibleDot150)
                    {
                        Console.SetCursorPosition(xDot150, yDot150);
                        Console.Write(".");
                    }
                    if (visibleDot151)
                    {
                        Console.SetCursorPosition(xDot151, yDot151);
                        Console.Write(".");
                    }
                    if (visibleDot152)
                    {
                        Console.SetCursorPosition(xDot152, yDot152);
                        Console.Write(".");
                    }
                    if (visibleDot153)
                    {
                        Console.SetCursorPosition(xDot153, yDot153);
                        Console.Write(".");
                    }
                    if (visibleDot154)
                    {
                        Console.SetCursorPosition(xDot154, yDot154);
                        Console.Write(".");
                    }
                    if (visibleDot155)
                    {
                        Console.SetCursorPosition(xDot155, yDot155);
                        Console.Write(".");
                    }
                    if (visibleDot156)
                    {
                        Console.SetCursorPosition(xDot156, yDot156);
                        Console.Write(".");
                    }
                    if (visibleDot157)
                    {
                        Console.SetCursorPosition(xDot157, yDot157);
                        Console.Write(".");
                    }
                    if (visibleDot158)
                    {
                        Console.SetCursorPosition(xDot158, yDot158);
                        Console.Write(".");
                    }
                    if (visibleDot159)
                    {
                        Console.SetCursorPosition(xDot159, yDot159);
                        Console.Write(".");
                    }
                    if (visibleDot160)
                    {
                        Console.SetCursorPosition(xDot160, yDot160);
                        Console.Write(".");
                    }
                    if (visibleDot161)
                    {
                        Console.SetCursorPosition(xDot161, yDot161);
                        Console.Write(".");
                    }
                    if (visibleDot162)
                    {
                        Console.SetCursorPosition(xDot162, yDot162);
                        Console.Write(".");
                    }
                    if (visibleDot163)
                    {
                        Console.SetCursorPosition(xDot163, yDot163);
                        Console.Write(".");
                    }
                    if (visibleDot164)
                    {
                        Console.SetCursorPosition(xDot164, yDot164);
                        Console.Write(".");
                    }
                    if (visibleDot165)
                    {
                        Console.SetCursorPosition(xDot165, yDot165);
                        Console.Write(".");
                    }
                    if (visibleDot166)
                    {
                        Console.SetCursorPosition(xDot166, yDot166);
                        Console.Write(".");
                    }
                    if (visibleDot167)
                    {
                        Console.SetCursorPosition(xDot167, yDot167);
                        Console.Write(".");
                    }
                    if (visibleDot168)
                    {
                        Console.SetCursorPosition(xDot168, yDot168);
                        Console.Write(".");
                    }
                    if (visibleDot169)
                    {
                        Console.SetCursorPosition(xDot169, yDot169);
                        Console.Write(".");
                    }

                    if (visibleDot170)
                    {
                        Console.SetCursorPosition(xDot170, yDot170);
                        Console.Write(".");
                    }
                    if (visibleDot171)
                    {
                        Console.SetCursorPosition(xDot171, yDot171);
                        Console.Write(".");
                    }
                    if (visibleDot172)
                    {
                        Console.SetCursorPosition(xDot172, yDot172);
                        Console.Write(".");
                    }
                    if (visibleDot173)
                    {
                        Console.SetCursorPosition(xDot173, yDot173);
                        Console.Write(".");
                    }
                    if (visibleDot174)
                    {
                        Console.SetCursorPosition(xDot174, yDot174);
                        Console.Write(".");
                    }
                    if (visibleDot175)
                    {
                        Console.SetCursorPosition(xDot175, yDot175);
                        Console.Write(".");
                    }
                    if (visibleDot176)
                    {
                        Console.SetCursorPosition(xDot176, yDot176);
                        Console.Write(".");
                    }
                    if (visibleDot177)
                    {
                        Console.SetCursorPosition(xDot177, yDot177);
                        Console.Write(".");
                    }
                    if (visibleDot178)
                    {
                        Console.SetCursorPosition(xDot178, yDot178);
                        Console.Write(".");
                    }
                    if (visibleDot179)
                    {
                        Console.SetCursorPosition(xDot179, yDot179);
                        Console.Write(".");
                    }
                    if (visibleDot180)
                    {
                        Console.SetCursorPosition(xDot180, yDot180);
                        Console.Write(".");
                    }
                    if (visibleDot181)
                    {
                        Console.SetCursorPosition(xDot181, yDot181);
                        Console.Write(".");
                    }
                    if (visibleDot182)
                    {
                        Console.SetCursorPosition(xDot182, yDot182);
                        Console.Write(".");
                    }
                    if (visibleDot183)
                    {
                        Console.SetCursorPosition(xDot183, yDot183);
                        Console.Write(".");
                    }
                    if (visibleDot184)
                    {
                        Console.SetCursorPosition(xDot184, yDot184);
                        Console.Write(".");
                    }
                    if (visibleDot185)
                    {
                        Console.SetCursorPosition(xDot185, yDot185);
                        Console.Write(".");
                    }
                    if (visibleDot186)
                    {
                        Console.SetCursorPosition(xDot186, yDot186);
                        Console.Write(".");
                    }
                    if (visibleDot187)
                    {
                        Console.SetCursorPosition(xDot187, yDot187);
                        Console.Write(".");
                    }
                    if (visibleDot188)
                    {
                        Console.SetCursorPosition(xDot188, yDot188);
                        Console.Write(".");
                    }
                    if (visibleDot189)
                    {
                        Console.SetCursorPosition(xDot189, yDot189);
                        Console.Write(".");
                    }
                    if (visibleDot190)
                    {
                        Console.SetCursorPosition(xDot190, yDot190);
                        Console.Write(".");
                    }
                    if (visibleDot191)
                    {
                        Console.SetCursorPosition(xDot191, yDot191);
                        Console.Write(".");
                    }
                    if (visibleDot192)
                    {
                        Console.SetCursorPosition(xDot192, yDot192);
                        Console.Write(".");
                    }
                    if (visibleDot193)
                    {
                        Console.SetCursorPosition(xDot193, yDot193);
                        Console.Write(".");
                    }
                    if (visibleDot194)
                    {
                        Console.SetCursorPosition(xDot194, yDot194);
                        Console.Write(".");
                    }
                    if (visibleDot195)
                    {
                        Console.SetCursorPosition(xDot195, yDot195);
                        Console.Write(".");
                    }
                    if (visibleDot196)
                    {
                        Console.SetCursorPosition(xDot196, yDot196);
                        Console.Write(".");
                    }
                    if (visibleDot197)
                    {
                        Console.SetCursorPosition(xDot197, yDot197);
                        Console.Write(".");
                    }
                    if (visibleDot198)
                    {
                        Console.SetCursorPosition(xDot198, yDot198);
                        Console.Write(".");
                    }
                    if (visibleDot199)
                    {
                        Console.SetCursorPosition(xDot199, yDot199);
                        Console.Write(".");
                    }
                    if (visibleDot200)
                    {
                        Console.SetCursorPosition(xDot200, yDot200);
                        Console.Write(".");
                    }
                    if (visibleDot201)
                    {
                        Console.SetCursorPosition(xDot201, yDot201);
                        Console.Write(".");
                    }
                    if (visibleDot202)
                    {
                        Console.SetCursorPosition(xDot202, yDot202);
                        Console.Write(".");
                    }
                    if (visibleDot203)
                    {
                        Console.SetCursorPosition(xDot203, yDot203);
                        Console.Write(".");
                    }
                    if (visibleDot204)
                    {
                        Console.SetCursorPosition(xDot204, yDot204);
                        Console.Write(".");
                    }
                    if (visibleDot205)
                    {
                        Console.SetCursorPosition(xDot205, yDot205);
                        Console.Write(".");
                    }
                    if (visibleDot206)
                    {
                        Console.SetCursorPosition(xDot206, yDot206);
                        Console.Write(".");
                    }
                    if (visibleDot207)
                    {
                        Console.SetCursorPosition(xDot207, yDot207);
                        Console.Write(".");
                    }
                    if (visibleDot208)
                    {
                        Console.SetCursorPosition(xDot208, yDot208);
                        Console.Write(".");
                    }
                    if (visibleDot209)
                    {
                        Console.SetCursorPosition(xDot209, yDot209);
                        Console.Write(".");
                    }
                    if (visibleDot210)
                    {
                        Console.SetCursorPosition(xDot210, yDot210);
                        Console.Write(".");
                    }
                    if (visibleDot211)
                    {
                        Console.SetCursorPosition(xDot211, yDot211);
                        Console.Write(".");
                    }
                    if (visibleDot212)
                    {
                        Console.SetCursorPosition(xDot212, yDot212);
                        Console.Write(".");
                    }
                    if (visibleDot213)
                    {
                        Console.SetCursorPosition(xDot213, yDot213);
                        Console.Write(".");
                    }
                    if (visibleDot214)
                    {
                        Console.SetCursorPosition(xDot214, yDot214);
                        Console.Write(".");
                    }
                    if (visibleDot215)
                    {
                        Console.SetCursorPosition(xDot215, yDot215);
                        Console.Write(".");
                    }
                    if (visibleDot216)
                    {
                        Console.SetCursorPosition(xDot216, yDot216);
                        Console.Write(".");
                    }
                    if (visibleDot217)
                    {
                        Console.SetCursorPosition(xDot217, yDot217);
                        Console.Write(".");
                    }
                    if (visibleDot218)
                    {
                        Console.SetCursorPosition(xDot218, yDot218);
                        Console.Write(".");
                    }
                    if (visibleDot219)
                    {
                        Console.SetCursorPosition(xDot219, yDot219);
                        Console.Write(".");
                    }
                    if (visibleDot220)
                    {
                        Console.SetCursorPosition(xDot220, yDot220);
                        Console.Write(".");
                    }
                    if (visibleDot221)
                    {
                        Console.SetCursorPosition(xDot221, yDot221);
                        Console.Write(".");
                    }
                    if (visibleDot222)
                    {
                        Console.SetCursorPosition(xDot222, yDot222);
                        Console.Write(".");
                    }
                    if (visibleDot223)
                    {
                        Console.SetCursorPosition(xDot223, yDot223);
                        Console.Write(".");
                    }
                    if (visibleDot224)
                    {
                        Console.SetCursorPosition(xDot224, yDot224);
                        Console.Write(".");
                    }
                    if (visibleDot225)
                    {
                        Console.SetCursorPosition(xDot225, yDot225);
                        Console.Write(".");
                    }
                    if (visibleDot226)
                    {
                        Console.SetCursorPosition(xDot226, yDot226);
                        Console.Write(".");
                    }
                    if (visibleDot227)
                    {
                        Console.SetCursorPosition(xDot227, yDot227);
                        Console.Write(".");
                    }
                    if (visibleDot228)
                    {
                        Console.SetCursorPosition(xDot228, yDot228);
                        Console.Write(".");
                    }
                    if (visibleDot229)
                    {
                        Console.SetCursorPosition(xDot229, yDot229);
                        Console.Write(".");
                    }
                    if (visibleDot230)
                    {
                        Console.SetCursorPosition(xDot230, yDot230);
                        Console.Write(".");
                    }
                    if (visibleDot231)
                    {
                        Console.SetCursorPosition(xDot231, yDot231);
                        Console.Write(".");
                    }
                    if (visibleDot232)
                    {
                        Console.SetCursorPosition(xDot232, yDot232);
                        Console.Write(".");
                    }
                    if (visibleDot233)
                    {
                        Console.SetCursorPosition(xDot233, yDot233);
                        Console.Write(".");
                    }
                    if (visibleDot234)
                    {
                        Console.SetCursorPosition(xDot234, yDot234);
                        Console.Write(".");
                    }
                    if (visibleDot235)
                    {
                        Console.SetCursorPosition(xDot235, yDot235);
                        Console.Write(".");
                    }
                    if (visibleDot236)
                    {
                        Console.SetCursorPosition(xDot236, yDot236);
                        Console.Write(".");
                    }
                    if (visibleDot237)
                    {
                        Console.SetCursorPosition(xDot237, yDot237);
                        Console.Write(".");
                    }
                    if (visibleDot238)
                    {
                        Console.SetCursorPosition(xDot238, yDot238);
                        Console.Write(".");
                    }
                    if (visibleDot239)
                    {
                        Console.SetCursorPosition(xDot239, yDot239);
                        Console.Write(".");
                    }
                    if (visibleDot240)
                    {
                        Console.SetCursorPosition(xDot240, yDot240);
                        Console.Write(".");
                    }
                    if (visibleDot241)
                    {
                        Console.SetCursorPosition(xDot241, yDot241);
                        Console.Write(".");
                    }
                    if (visibleDot242)
                    {
                        Console.SetCursorPosition(xDot242, yDot242);
                        Console.Write(".");
                    }
                    if (visibleDot243)
                    {
                        Console.SetCursorPosition(xDot243, yDot243);
                        Console.Write(".");
                    }
                    if (visibleDot244)
                    {
                        Console.SetCursorPosition(xDot244, yDot244);
                        Console.Write(".");
                    }
                    if (visibleDot245)
                    {
                        Console.SetCursorPosition(xDot245, yDot245);
                        Console.Write(".");
                    }
                    if (visibleDot246)
                    {
                        Console.SetCursorPosition(xDot246, yDot246);
                        Console.Write(".");
                    }
                    if (visibleDot247)
                    {
                        Console.SetCursorPosition(xDot247, yDot247);
                        Console.Write(".");
                    }
                    if (visibleDot248)
                    {
                        Console.SetCursorPosition(xDot248, yDot248);
                        Console.Write(".");
                    }
                    if (visibleDot249)
                    {
                        Console.SetCursorPosition(xDot249, yDot249);
                        Console.Write(".");
                    }
                    if (visibleDot250)
                    {
                        Console.SetCursorPosition(xDot250, yDot250);
                        Console.Write(".");
                    }
                    if (visibleDot251)
                    {
                        Console.SetCursorPosition(xDot251, yDot251);
                        Console.Write(".");
                    }
                    if (visibleDot252)
                    {
                        Console.SetCursorPosition(xDot252, yDot252);
                        Console.Write(".");
                    }
                    if (visibleDot253)
                    {
                        Console.SetCursorPosition(xDot253, yDot253);
                        Console.Write(".");
                    }
                    if (visibleDot254)
                    {
                        Console.SetCursorPosition(xDot254, yDot254);
                        Console.Write(".");
                    }
                    if (visibleDot255)
                    {
                        Console.SetCursorPosition(xDot255, yDot255);
                        Console.Write(".");
                    }
                    if (visibleDot256)
                    {
                        Console.SetCursorPosition(xDot256, yDot256);
                        Console.Write(".");
                    }
                    if (visibleDot257)
                    {
                        Console.SetCursorPosition(xDot257, yDot257);
                        Console.Write(".");
                    }
                    if (visibleDot258)
                    {
                        Console.SetCursorPosition(xDot258, yDot258);
                        Console.Write(".");
                    }
                    if (visibleDot259)
                    {
                        Console.SetCursorPosition(xDot259, yDot259);
                        Console.Write(".");
                    }
                    if (visibleDot260)
                    {
                        Console.SetCursorPosition(xDot260, yDot260);
                        Console.Write(".");
                    }
                    if (visibleDot261)
                    {
                        Console.SetCursorPosition(xDot261, yDot261);
                        Console.Write(".");
                    }
                    if (visibleDot262)
                    {
                        Console.SetCursorPosition(xDot262, yDot262);
                        Console.Write(".");
                    }
                    if (visibleDot263)
                    {
                        Console.SetCursorPosition(xDot263, yDot263);
                        Console.Write(".");
                    }
                    if (visibleDot264)
                    {
                        Console.SetCursorPosition(xDot264, yDot264);
                        Console.Write(".");
                    }

                    //Drawing of the map
                    for (int row = 0; row < 22; row++)
                    {
                        for (int column = 0; column < 42; column++)
                        {
                            Console.SetCursorPosition(column, row);
                            if (map[row][column] == '|')
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("|", row, column);
                            }
                            if (map[row][column] == '-')
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("-");
                            }
                            if (map[row][column] == '_')
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("-");
                            }
                            if (map[row][column] == '#')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("#");
                            }
                            if (map[row][column] == ' ')
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(" ");
                            }
                        }
                    }


                    //PAKMAN
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(x, y);
                    Console.Write("C");

                    Enemies(xEnemy, yEnemy, xEnemy1, yEnemy1, xEnemy2, yEnemy2, xEnemy3, yEnemy3);

                    // Read keys and calculate new position
                    if (Console.KeyAvailable)
                    {
                        userKey = Console.ReadKey(false);

                        if (userKey.Key == ConsoleKey.RightArrow && CanMoveTo(x + pacSpeed, y, map))
                        {
                            x += pacSpeed;
                        }
                        if (userKey.Key == ConsoleKey.LeftArrow && CanMoveTo(x - pacSpeed, y, map))
                        {
                            x -= pacSpeed;
                        }
                        if (userKey.Key == ConsoleKey.DownArrow && CanMoveTo(x, y + pacSpeed, map))
                        {
                            y += pacSpeed;
                        }
                        if (userKey.Key == ConsoleKey.UpArrow && CanMoveTo(x, y - pacSpeed, map))
                        {
                            y -= pacSpeed;
                        }

                        if (userKey.Key == ConsoleKey.Escape)
                            Environment.Exit(1);
                    }


                    // Move enemies and environment
                    xEnemy += incrXEnemy;
                    xEnemy1 += incrXEnemy1;
                    yEnemy2 += incrYEnemy;
                    yEnemy3 += incrYEnemy1;
                    if ((xEnemy < 1) || (xEnemy > 39))
                        incrXEnemy = -incrXEnemy;
                    if ((xEnemy1 < 1) || (xEnemy1 > 39))
                        incrXEnemy1 = -incrXEnemy1;
                    if ((yEnemy2 < 1) || (yEnemy2 > 20))
                        incrYEnemy = -incrYEnemy;
                    if ((yEnemy3 < 1) || (yEnemy3 > 20))
                        incrYEnemy1 = -incrYEnemy1;

                    // Collisions, lose energy or lives, etc
                    if (
                        (x > xEnemy - 1) &&
                        (x < xEnemy + 1) &&
                        (y > yEnemy - 1) &&
                        (y < yEnemy + 1)
                        )
                    {
                        x = startX;
                        y = startY;
                        lives--;
                        if (lives == 0)
                            LoseScreen();

                    }
                    if (
                            (x > xEnemy1 - 1) &&
                            (x < xEnemy1 + 1) &&
                            (y > yEnemy1 - 1) &&
                            (y < yEnemy1 + 1)
                            )
                    {
                        x = startX;
                        y = startY;
                        lives--;
                        if (lives == 0)
                            LoseScreen();

                    }
                    if (
                            (x > xEnemy2 - 1) &&
                            (x < xEnemy2 + 1) &&
                            (y > yEnemy2 - 1) &&
                            (y < yEnemy2 + 1)
                            )
                    {
                        x = startX;
                        y = startY;
                        lives--;
                        if (lives == 0)
                            LoseScreen();
                    }
                    if (
                            (x > xEnemy3 - 1) &&
                            (x < xEnemy3 + 1) &&
                            (y > yEnemy3 - 1) &&
                            (y < yEnemy3 + 1)
                            )
                    {
                        x = startX;
                        y = startY;
                        lives--;
                        if (lives == 0)
                            LoseScreen();

                    }

                    if ((x == xDot1) && (y == yDot1) && visibleDot1)
                    {
                        score += 10;
                        visibleDot1 = false;
                    }
                    if ((x == xDot2) && (y == yDot2) && visibleDot2)
                    {
                        score += 10;
                        visibleDot2 = false;
                    }
                    if ((x == xDot3) && (y == yDot3) && visibleDot3)
                    {
                        score += 10;
                        visibleDot3 = false;
                    }
                    if ((x == xDot4) && (y == yDot4) && visibleDot4)
                    {
                        score += 10;
                        visibleDot4 = false;
                    }
                    if ((x == xDot5) && (y == yDot5) && visibleDot5)
                    {
                        score += 10;
                        visibleDot5 = false;
                    }
                    if ((x == xDot6) && (y == yDot6) && visibleDot6)
                    {
                        score += 10;
                        visibleDot6 = false;
                    }
                    if ((x == xDot7) && (y == yDot7) && visibleDot7)
                    {
                        score += 10;
                        visibleDot7 = false;
                    }
                    if ((x == xDot8) && (y == yDot8) && visibleDot8)
                    {
                        score += 10;
                        visibleDot8 = false;
                    }
                    if ((x == xDot9) && (y == yDot9) && visibleDot9)
                    {
                        score += 10;
                        visibleDot9 = false;
                    }
                    if ((x == xDot10) && (y == yDot10) && visibleDot10)
                    {
                        score += 10;
                        visibleDot10 = false;
                    }
                    if ((x == xDot11) && (y == yDot11) && visibleDot11)
                    {
                        score += 10;
                        visibleDot11 = false;
                    }
                    if ((x == xDot12) && (y == yDot12) && visibleDot12)
                    {
                        score += 10;
                        visibleDot12 = false;
                    }
                    if ((x == xDot13) && (y == yDot13) && visibleDot13)
                    {
                        score += 10;
                        visibleDot13 = false;
                    }
                    if ((x == xDot14) && (y == yDot14) && visibleDot14)
                    {
                        score += 10;
                        visibleDot14 = false;
                    }
                    if ((x == xDot15) && (y == yDot15) && visibleDot15)
                    {
                        score += 10;
                        visibleDot15 = false;
                    }
                    if ((x == xDot16) && (y == yDot16) && visibleDot16)
                    {
                        score += 10;
                        visibleDot16 = false;
                    }
                    if ((x == xDot17) && (y == yDot17) && visibleDot17)
                    {
                        score += 10;
                        visibleDot17 = false;
                    }
                    if ((x == xDot18) && (y == yDot18) && visibleDot18)
                    {
                        score += 10;
                        visibleDot18 = false;
                    }
                    if ((x == xDot19) && (y == yDot19) && visibleDot19)
                    {
                        score += 10;
                        visibleDot19 = false;
                    }
                    if ((x == xDot20) && (y == yDot20) && visibleDot20)
                    {
                        score += 10;
                        visibleDot20 = false;
                    }
                    if ((x == xDot21) && (y == yDot21) && visibleDot21)
                    {
                        score += 10;;
                        visibleDot21 = false;
                    }
                    if ((x == xDot22) && (y == yDot22) && visibleDot22)
                    {
                        score += 10;
                        visibleDot22 = false;
                    }
                    if ((x == xDot23) && (y == yDot23) && visibleDot23)
                    {
                        score += 10;
                        visibleDot23 = false;
                    }
                    if ((x == xDot24) && (y == yDot24) && visibleDot24)
                    {
                        score += 10;
                        visibleDot24 = false;
                    }
                    if ((x == xDot25) && (y == yDot25) && visibleDot25)
                    {
                        score += 10;
                        visibleDot25 = false;
                    }
                    if ((x == xDot26) && (y == yDot26) && visibleDot26)
                    {
                        score += 10;
                        visibleDot26 = false;
                    }
                    if ((x == xDot27) && (y == yDot27) && visibleDot27)
                    {
                        score += 10;
                        visibleDot27 = false;
                    }
                    if ((x == xDot28) && (y == yDot28) && visibleDot28)
                    {
                        score += 10;
                        visibleDot28 = false;
                    }
                    if ((x == xDot29) && (y == yDot29) && visibleDot29)
                    {
                        score += 10;
                        visibleDot29 = false;
                    }
                    if ((x == xDot30) && (y == yDot30) && visibleDot30)
                    {
                        score += 10;
                        visibleDot30 = false;
                    }
                    if ((x == xDot31) && (y == yDot31) && visibleDot31)
                    {
                        score += 10;
                        visibleDot31 = false;
                    }
                    if ((x == xDot32) && (y == yDot32) && visibleDot32)
                    {
                        score += 10;
                        visibleDot32 = false;
                    }
                    if ((x == xDot33) && (y == yDot33) && visibleDot33)
                    {
                        score += 10;
                        visibleDot33 = false;
                    }
                    if ((x == xDot34) && (y == yDot34) && visibleDot34)
                    {
                        score += 10;
                        visibleDot34 = false;
                    }
                    if ((x == xDot35) && (y == yDot35) && visibleDot35)
                    {
                        score += 10;
                        visibleDot35 = false;
                    }
                    if ((x == xDot36) && (y == yDot36) && visibleDot36)
                    {
                        score += 10;
                        visibleDot36 = false;
                    }
                    if ((x == xDot37) && (y == yDot37) && visibleDot37)
                    {
                        score += 10;
                        visibleDot37 = false;
                    }
                    if ((x == xDot38) && (y == yDot38) && visibleDot38)
                    {
                        score += 10;
                        visibleDot38 = false;
                    }
                    if ((x == xDot39) && (y == yDot39) && visibleDot39)
                    {
                        score += 10;
                        visibleDot39 = false;
                    }
                    if ((x == xDot40) && (y == yDot40) && visibleDot40)
                    {
                        score += 10;
                        visibleDot40 = false;
                    }
                    if ((x == xDot41) && (y == yDot41) && visibleDot41)
                    {
                        score += 10;
                        visibleDot41 = false;
                    }
                    if ((x == xDot42) && (y == yDot42) && visibleDot42)
                    {
                        score += 10;
                        visibleDot42 = false;
                    }
                    if ((x == xDot43) && (y == yDot43) && visibleDot43)
                    {
                        score += 10;
                        visibleDot43 = false;
                    }
                    if ((x == xDot44) && (y == yDot44) && visibleDot44)
                    {
                        score += 10;
                        visibleDot44 = false;
                    }
                    if ((x == xDot45) && (y == yDot45) && visibleDot45)
                    {
                        score += 10;
                        visibleDot45 = false;
                    }
                    if ((x == xDot46) && (y == yDot46) && visibleDot46)
                    {
                        score += 10;
                        visibleDot46 = false;
                    }
                    if ((x == xDot47) && (y == yDot47) && visibleDot47)
                    {
                        score += 10;
                        visibleDot47 = false;
                    }
                    if ((x == xDot48) && (y == yDot48) && visibleDot48)
                    {
                        score += 10;
                        visibleDot48 = false;
                    }
                    if ((x == xDot49) && (y == yDot49) && visibleDot49)
                    {
                        score += 10;
                        visibleDot49 = false;
                    }
                    if ((x == xDot50) && (y == yDot50) && visibleDot50)
                    {
                        score += 10;
                        visibleDot50 = false;
                    }
                    if ((x == xDot51) && (y == yDot51) && visibleDot51)
                    {
                        score += 10;
                        visibleDot51 = false;
                    }
                    if ((x == xDot52) && (y == yDot52) && visibleDot52)
                    {
                        score += 10;
                        visibleDot52 = false;
                    }
                    if ((x == xDot53) && (y == yDot53) && visibleDot53)
                    {
                        score += 10;
                        visibleDot53 = false;
                    }
                    if ((x == xDot54) && (y == yDot54) && visibleDot54)
                    {
                        score += 10;
                        visibleDot54 = false;
                    }
                    if ((x == xDot55) && (y == yDot55) && visibleDot55)
                    {
                        score += 10;
                        visibleDot55 = false;
                    }
                    if ((x == xDot56) && (y == yDot56) && visibleDot56)
                    {
                        score += 10;
                        visibleDot56 = false;
                    }
                    if ((x == xDot57) && (y == yDot57) && visibleDot57)
                    {
                        score += 10;
                        visibleDot57 = false;
                    }
                    if ((x == xDot58) && (y == yDot58) && visibleDot58)
                    {
                        score += 10;
                        visibleDot58 = false;
                    }
                    if ((x == xDot59) && (y == yDot59) && visibleDot59)
                    {
                        score += 10;
                        visibleDot59 = false;
                    }
                    if ((x == xDot60) && (y == yDot60) && visibleDot60)
                    {
                        score += 10;
                        visibleDot60 = false;
                    }
                    if ((x == xDot61) && (y == yDot61) && visibleDot61)
                    {
                        score += 10;
                        visibleDot61 = false;
                    }
                    if ((x == xDot62) && (y == yDot62) && visibleDot62)
                    {
                        score += 10;
                        visibleDot62 = false;
                    }
                    if ((x == xDot63) && (y == yDot63) && visibleDot63)
                    {
                        score += 10;
                        visibleDot63 = false;
                    }
                    if ((x == xDot64) && (y == yDot64) && visibleDot64)
                    {
                        score += 10;
                        visibleDot64 = false;
                    }
                    if ((x == xDot65) && (y == yDot65) && visibleDot65)
                    {
                        score += 10;
                        visibleDot65 = false;
                    }
                    if ((x == xDot66) && (y == yDot66) && visibleDot66)
                    {
                        score += 10;
                        visibleDot66 = false;
                    }
                    if ((x == xDot67) && (y == yDot67) && visibleDot67)
                    {
                        score += 10;
                        visibleDot67 = false;
                    }
                    if ((x == xDot68) && (y == yDot68) && visibleDot68)
                    {
                        score += 10;
                        visibleDot68 = false;
                    }
                    if ((x == xDot69) && (y == yDot69) && visibleDot69)
                    {
                        score += 10;
                        visibleDot69 = false;
                    }
                    if ((x == xDot70) && (y == yDot70) && visibleDot70)
                    {
                        score += 10;
                        visibleDot70 = false;
                    }
                    if ((x == xDot71) && (y == yDot71) && visibleDot71)
                    {
                        score += 10;
                        visibleDot71 = false;
                    }
                    if ((x == xDot72) && (y == yDot72) && visibleDot72)
                    {
                        score += 10;
                        visibleDot72 = false;
                    }
                    if ((x == xDot73) && (y == yDot73) && visibleDot73)
                    {
                        score += 10;
                        visibleDot73 = false;
                    }
                    if ((x == xDot74) && (y == yDot74) && visibleDot74)
                    {
                        score += 10;
                        visibleDot74 = false;
                    }
                    if ((x == xDot75) && (y == yDot75) && visibleDot75)
                    {
                        score += 10;
                        visibleDot75 = false;
                    }
                    if ((x == xDot76) && (y == yDot76) && visibleDot76)
                    {
                        score += 10;
                        visibleDot76 = false;
                    }
                    if ((x == xDot77) && (y == yDot77) && visibleDot77)
                    {
                        score += 10;
                        visibleDot77 = false;
                    }
                    if ((x == xDot78) && (y == yDot78) && visibleDot78)
                    {
                        score += 10;
                        visibleDot78 = false;
                    }
                    if ((x == xDot79) && (y == yDot79) && visibleDot79)
                    {
                        score += 10;
                        visibleDot79 = false;
                    }
                    if ((x == xDot80) && (y == yDot80) && visibleDot80)
                    {
                        score += 10;
                        visibleDot80 = false;
                    }
                    if ((x == xDot81) && (y == yDot81) && visibleDot81)
                    {
                        score += 10;
                        visibleDot81 = false;
                    }
                    if ((x == xDot82) && (y == yDot82) && visibleDot82)
                    {
                        score += 10;
                        visibleDot82 = false;
                    }
                    if ((x == xDot83) && (y == yDot83) && visibleDot83)
                    {
                        score += 10;
                        visibleDot83 = false;
                    }
                    if ((x == xDot84) && (y == yDot84) && visibleDot84)
                    {
                        score += 10;
                        visibleDot84 = false;
                    }
                    if ((x == xDot85) && (y == yDot85) && visibleDot85)
                    {
                        score += 10;
                        visibleDot85 = false;
                    }
                    if ((x == xDot86) && (y == yDot86) && visibleDot86)
                    {
                        score += 10;
                        visibleDot86 = false;
                    }
                    if ((x == xDot87) && (y == yDot87) && visibleDot87)
                    {
                        score += 10;
                        visibleDot87 = false;
                    }
                    if ((x == xDot88) && (y == yDot88) && visibleDot88)
                    {
                        score += 10;
                        visibleDot88 = false;
                    }
                    if ((x == xDot89) && (y == yDot89) && visibleDot89)
                    {
                        score += 10;
                        visibleDot89 = false;
                    }
                    if ((x == xDot90) && (y == yDot90) && visibleDot90)
                    {
                        score += 10;
                        visibleDot90 = false;
                    }
                    if ((x == xDot91) && (y == yDot91) && visibleDot91)
                    {
                        score += 10;
                        visibleDot91 = false;
                    }
                    if ((x == xDot92) && (y == yDot92) && visibleDot92)
                    {
                        score += 10;
                        visibleDot92 = false;
                    }
                    if ((x == xDot93) && (y == yDot93) && visibleDot93)
                    {
                        score += 10;
                        visibleDot93 = false;
                    }
                    if ((x == xDot94) && (y == yDot94) && visibleDot94)
                    {
                        score += 10;
                        visibleDot94 = false;
                    }
                    if ((x == xDot95) && (y == yDot95) && visibleDot95)
                    {
                        score += 10;
                        visibleDot95 = false;
                    }
                    if ((x == xDot96) && (y == yDot96) && visibleDot96)
                    {
                        score += 10;
                        visibleDot96 = false;
                    }
                    if ((x == xDot97) && (y == yDot97) && visibleDot97)
                    {
                        score += 10;
                        visibleDot97 = false;
                    }
                    if ((x == xDot98) && (y == yDot98) && visibleDot98)
                    {
                        score += 10;
                        visibleDot98 = false;
                    }
                    if ((x == xDot99) && (y == yDot99) && visibleDot99)
                    {
                        score += 10;
                        visibleDot99 = false;
                    }
                    if ((x == xDot100) && (y == yDot100) && visibleDot100)
                    {
                        score += 10;
                        visibleDot100 = false;
                    }
                    if ((x == xDot101) && (y == yDot101) && visibleDot101)
                    {
                        score += 10;
                        visibleDot101 = false;
                    }
                    if ((x == xDot102) && (y == yDot102) && visibleDot102)
                    {
                        score += 10;
                        visibleDot102 = false;
                    }
                    if ((x == xDot103) && (y == yDot103) && visibleDot103)
                    {
                        score += 10;
                        visibleDot103 = false;
                    }
                    if ((x == xDot104) && (y == yDot104) && visibleDot104)
                    {
                        score += 10;
                        visibleDot104 = false;
                    }
                    if ((x == xDot105) && (y == yDot105) && visibleDot105)
                    {
                        score += 10;
                        visibleDot105 = false;
                    }
                    if ((x == xDot106) && (y == yDot106) && visibleDot106)
                    {
                        score += 10;
                        visibleDot106 = false;
                    }
                    if ((x == xDot107) && (y == yDot107) && visibleDot107)
                    {
                        score += 10;
                        visibleDot107 = false;
                    }
                    if ((x == xDot108) && (y == yDot108) && visibleDot108)
                    {
                        score += 10;
                        visibleDot108 = false;
                    }
                    if ((x == xDot109) && (y == yDot109) && visibleDot109)
                    {
                        score += 10;
                        visibleDot109 = false;
                    }
                    if ((x == xDot110) && (y == yDot110) && visibleDot110)
                    {
                        score += 10;
                        visibleDot110 = false;
                    }
                    if ((x == xDot111) && (y == yDot111) && visibleDot111)
                    {
                        score += 10;
                        visibleDot111 = false;
                    }
                    if ((x == xDot112) && (y == yDot112) && visibleDot112)
                    {
                        score += 10;
                        visibleDot112 = false;
                    }
                    if ((x == xDot113) && (y == yDot113) && visibleDot113)
                    {
                        score += 10;
                        visibleDot113 = false;
                    }
                    if ((x == xDot114) && (y == yDot114) && visibleDot114)
                    {
                        score += 10;
                        visibleDot114 = false;
                    }
                    if ((x == xDot115) && (y == yDot115) && visibleDot115)
                    {
                        score += 10;
                        visibleDot115 = false;
                    }
                    if ((x == xDot116) && (y == yDot116) && visibleDot116)
                    {
                        score += 10;
                        visibleDot116 = false;
                    }
                    if ((x == xDot117) && (y == yDot117) && visibleDot117)
                    {
                        score += 10;
                        visibleDot117 = false;
                    }
                    if ((x == xDot118) && (y == yDot118) && visibleDot118)
                    {
                        score += 10;
                        visibleDot118 = false;
                    }
                    if ((x == xDot119) && (y == yDot119) && visibleDot119)
                    {
                        score += 10;
                        visibleDot119 = false;
                    }
                    if ((x == xDot120) && (y == yDot120) && visibleDot120)
                    {
                        score += 10;
                        visibleDot120 = false;
                    }
                    if ((x == xDot121) && (y == yDot121) && visibleDot121)
                    {
                        score += 10;
                        visibleDot121 = false;
                    }
                    if ((x == xDot122) && (y == yDot122) && visibleDot122)
                    {
                        score += 10;
                        visibleDot122 = false;
                    }
                    if ((x == xDot123) && (y == yDot123) && visibleDot123)
                    {
                        score += 10;
                        visibleDot123 = false;
                    }
                    if ((x == xDot124) && (y == yDot124) && visibleDot124)
                    {
                        score += 10;
                        visibleDot124 = false;
                    }
                    if ((x == xDot125) && (y == yDot125) && visibleDot125)
                    {
                        score += 10;
                        visibleDot125 = false;
                    }
                    if ((x == xDot126) && (y == yDot126) && visibleDot126)
                    {
                        score += 10;
                        visibleDot126 = false;
                    }
                    if ((x == xDot127) && (y == yDot127) && visibleDot127)
                    {
                        score += 10;
                        visibleDot127 = false;
                    }
                    if ((x == xDot128) && (y == yDot128) && visibleDot128)
                    {
                        score += 10;
                        visibleDot128 = false;
                    }
                    if ((x == xDot129) && (y == yDot129) && visibleDot129)
                    {
                        score += 10;
                        visibleDot129 = false;
                    }
                    if ((x == xDot130) && (y == yDot130) && visibleDot130)
                    {
                        score += 10;
                        visibleDot130 = false;
                    }
                    if ((x == xDot131) && (y == yDot131) && visibleDot131)
                    {
                        score += 10;
                        visibleDot131 = false;
                    }
                    if ((x == xDot132) && (y == yDot132) && visibleDot132)
                    {
                        score += 10;
                        visibleDot132 = false;
                    }
                    if ((x == xDot133) && (y == yDot133) && visibleDot133)
                    {
                        score += 10;
                        visibleDot133 = false;
                    }
                    if ((x == xDot134) && (y == yDot134) && visibleDot134)
                    {
                        score += 10;
                        visibleDot134 = false;
                    }
                    if ((x == xDot135) && (y == yDot135) && visibleDot135)
                    {
                        score += 10;
                        visibleDot135 = false;
                    }
                    if ((x == xDot136) && (y == yDot136) && visibleDot136)
                    {
                        score += 10;
                        visibleDot136 = false;
                    }
                    if ((x == xDot137) && (y == yDot137) && visibleDot137)
                    {
                        score += 10;
                        visibleDot137 = false;
                    }
                    if ((x == xDot138) && (y == yDot138) && visibleDot138)
                    {
                        score += 10;
                        visibleDot138 = false;
                    }
                    if ((x == xDot139) && (y == yDot139) && visibleDot139)
                    {
                        score += 10;
                        visibleDot139 = false;
                    }
                    if ((x == xDot140) && (y == yDot140) && visibleDot140)
                    {
                        score += 10;
                        visibleDot140 = false;
                    }
                    if ((x == xDot141) && (y == yDot141) && visibleDot141)
                    {
                        score += 10;
                        visibleDot141 = false;
                    }
                    if ((x == xDot142) && (y == yDot142) && visibleDot142)
                    {
                        score += 10;
                        visibleDot142 = false;
                    }
                    if ((x == xDot143) && (y == yDot143) && visibleDot143)
                    {
                        score += 10;
                        visibleDot143 = false;
                    }
                    if ((x == xDot144) && (y == yDot144) && visibleDot144)
                    {
                        score += 10;
                        visibleDot144 = false;
                    }
                    if ((x == xDot145) && (y == yDot145) && visibleDot145)
                    {
                        score += 10;
                        visibleDot145 = false;
                    }
                    if ((x == xDot146) && (y == yDot146) && visibleDot146)
                    {
                        score += 10;
                        visibleDot146 = false;
                    }
                    if ((x == xDot147) && (y == yDot147) && visibleDot147)
                    {
                        score += 10;
                        visibleDot147 = false;
                    }
                    if ((x == xDot148) && (y == yDot148) && visibleDot148)
                    {
                        score += 10;
                        visibleDot148 = false;
                    }
                    if ((x == xDot149) && (y == yDot149) && visibleDot149)
                    {
                        score += 10;
                        visibleDot149 = false;
                    }
                    if ((x == xDot150) && (y == yDot150) && visibleDot150)
                    {
                        score += 10;
                        visibleDot150 = false;
                    }
                    if ((x == xDot151) && (y == yDot151) && visibleDot151)
                    {
                        score += 10;
                        visibleDot151 = false;
                    }
                    if ((x == xDot152) && (y == yDot152) && visibleDot152)
                    {
                        score += 10;
                        visibleDot152 = false;
                    }
                    if ((x == xDot153) && (y == yDot153) && visibleDot153)
                    {
                        score += 10;
                        visibleDot153 = false;
                    }
                    if ((x == xDot154) && (y == yDot154) && visibleDot154)
                    {
                        score += 10;
                        visibleDot154 = false;
                    }
                    if ((x == xDot155) && (y == yDot155) && visibleDot155)
                    {
                        score += 10;
                        visibleDot155 = false;
                    }
                    if ((x == xDot156) && (y == yDot156) && visibleDot156)
                    {
                        score += 10;
                        visibleDot156 = false;
                    }
                    if ((x == xDot157) && (y == yDot157) && visibleDot157)
                    {
                        score += 10;
                        visibleDot157 = false;
                    }
                    if ((x == xDot158) && (y == yDot158) && visibleDot158)
                    {
                        score += 10;
                        visibleDot158 = false;
                    }
                    if ((x == xDot159) && (y == yDot159) && visibleDot159)
                    {
                        score += 10;
                        visibleDot159 = false;
                    }
                    if ((x == xDot160) && (y == yDot160) && visibleDot160)
                    {
                        score += 10;
                        visibleDot160 = false;
                    }
                    if ((x == xDot161) && (y == yDot161) && visibleDot161)
                    {
                        score += 10;
                        visibleDot161 = false;
                    }
                    if ((x == xDot162) && (y == yDot162) && visibleDot162)
                    {
                        score += 10;
                        visibleDot162 = false;
                    }
                    if ((x == xDot163) && (y == yDot163) && visibleDot163)
                    {
                        score += 10;
                        visibleDot163 = false;
                    }
                    if ((x == xDot164) && (y == yDot164) && visibleDot164)
                    {
                        score += 10;
                        visibleDot164 = false;
                    }
                    if ((x == xDot165) && (y == yDot165) && visibleDot165)
                    {
                        score += 10;
                        visibleDot165 = false;
                    }
                    if ((x == xDot166) && (y == yDot166) && visibleDot166)
                    {
                        score += 10;
                        visibleDot166 = false;
                    }
                    if ((x == xDot167) && (y == yDot167) && visibleDot167)
                    {
                        score += 10;
                        visibleDot167 = false;
                    }
                    if ((x == xDot168) && (y == yDot168) && visibleDot168)
                    {
                        score += 10;
                        visibleDot168 = false;
                    }
                    if ((x == xDot169) && (y == yDot169) && visibleDot169)
                    {
                        score += 10;
                        visibleDot169 = false;
                    }
                    if ((x == xDot170) && (y == yDot170) && visibleDot170)
                    {
                        score += 10;
                        visibleDot170 = false;
                    }
                    if ((x == xDot171) && (y == yDot171) && visibleDot171)
                    {
                        score += 10;
                        visibleDot171 = false;
                    }
                    if ((x == xDot172) && (y == yDot172) && visibleDot172)
                    {
                        score += 10;
                        visibleDot172 = false;
                    }
                    if ((x == xDot173) && (y == yDot173) && visibleDot173)
                    {
                        score += 10;
                        visibleDot173 = false;
                    }
                    if ((x == xDot174) && (y == yDot174) && visibleDot174)
                    {
                        score += 10;
                        visibleDot174 = false;
                    }
                    if ((x == xDot175) && (y == yDot175) && visibleDot175)
                    {
                        score += 10;
                        visibleDot175 = false;
                    }
                    if ((x == xDot176) && (y == yDot176) && visibleDot176)
                    {
                        score += 10;
                        visibleDot176 = false;
                    }
                    if ((x == xDot177) && (y == yDot177) && visibleDot177)
                    {
                        score += 10;
                        visibleDot177 = false;
                    }
                    if ((x == xDot178) && (y == yDot178) && visibleDot178)
                    {
                        score += 10;
                        visibleDot178 = false;
                    }
                    if ((x == xDot179) && (y == yDot179) && visibleDot179)
                    {
                        score += 10;
                        visibleDot179 = false;
                    }
                    if ((x == xDot180) && (y == yDot180) && visibleDot180)
                    {
                        score += 10;
                        visibleDot180 = false;
                    }
                    if ((x == xDot181) && (y == yDot181) && visibleDot181)
                    {
                        score += 10;
                        visibleDot181 = false;
                    }
                    if ((x == xDot182) && (y == yDot182) && visibleDot182)
                    {
                        score += 10;
                        visibleDot182 = false;
                    }
                    if ((x == xDot183) && (y == yDot183) && visibleDot183)
                    {
                        score += 10;
                        visibleDot183 = false;
                    }
                    if ((x == xDot184) && (y == yDot184) && visibleDot184)
                    {
                        score += 10;
                        visibleDot184 = false;
                    }
                    if ((x == xDot185) && (y == yDot185) && visibleDot185)
                    {
                        score += 10;
                        visibleDot185 = false;
                    }
                    if ((x == xDot186) && (y == yDot186) && visibleDot186)
                    {
                        score += 10;
                        visibleDot186 = false;
                    }
                    if ((x == xDot187) && (y == yDot187) && visibleDot187)
                    {
                        score += 10;
                        visibleDot187 = false;
                    }
                    if ((x == xDot188) && (y == yDot188) && visibleDot188)
                    {
                        score += 10;
                        visibleDot188 = false;
                    }
                    if ((x == xDot189) && (y == yDot189) && visibleDot189)
                    {
                        score += 10;
                        visibleDot189 = false;
                    }
                    if ((x == xDot190) && (y == yDot190) && visibleDot190)
                    {
                        score += 10;
                        visibleDot190 = false;
                    }
                    if ((x == xDot191) && (y == yDot191) && visibleDot191)
                    {
                        score += 10;
                        visibleDot191 = false;
                    }
                    if ((x == xDot192) && (y == yDot192) && visibleDot192)
                    {
                        score += 10;
                        visibleDot192 = false;
                    }
                    if ((x == xDot193) && (y == yDot193) && visibleDot193)
                    {
                        score += 10;
                        visibleDot193 = false;
                    }
                    if ((x == xDot194) && (y == yDot194) && visibleDot194)
                    {
                        score += 10;
                        visibleDot194 = false;
                    }
                    if ((x == xDot195) && (y == yDot195) && visibleDot195)
                    {
                        score += 10;
                        visibleDot195 = false;
                    }
                    if ((x == xDot196) && (y == yDot196) && visibleDot196)
                    {
                        score += 10;
                        visibleDot196 = false;
                    }
                    if ((x == xDot197) && (y == yDot197) && visibleDot197)
                    {
                        score += 10;
                        visibleDot197 = false;
                    }
                    if ((x == xDot198) && (y == yDot198) && visibleDot198)
                    {
                        score += 10;
                        visibleDot198 = false;
                    }
                    if ((x == xDot199) && (y == yDot199) && visibleDot199)
                    {
                        score += 10;
                        visibleDot199 = false;
                    }
                    if ((x == xDot200) && (y == yDot200) && visibleDot200)
                    {
                        score += 10;
                        visibleDot200 = false;
                    }
                    if ((x == xDot201) && (y == yDot201) && visibleDot201)
                    {
                        score += 10;
                        visibleDot201 = false;
                    }
                    if ((x == xDot202) && (y == yDot202) && visibleDot202)
                    {
                        score += 10;
                        visibleDot202 = false;
                    }
                    if ((x == xDot203) && (y == yDot203) && visibleDot203)
                    {
                        score += 10;
                        visibleDot203 = false;
                    }
                    if ((x == xDot204) && (y == yDot204) && visibleDot204)
                    {
                        score += 10;
                        visibleDot204 = false;
                    }
                    if ((x == xDot205) && (y == yDot205) && visibleDot205)
                    {
                        score += 10;
                        visibleDot205 = false;
                    }
                    if ((x == xDot206) && (y == yDot206) && visibleDot206)
                    {
                        score += 10;
                        visibleDot206 = false;
                    }
                    if ((x == xDot207) && (y == yDot207) && visibleDot207)
                    {
                        score += 10;
                        visibleDot207 = false;
                    }
                    if ((x == xDot208) && (y == yDot208) && visibleDot208)
                    {
                        score += 10;
                        visibleDot208 = false;
                    }
                    if ((x == xDot209) && (y == yDot209) && visibleDot209)
                    {
                        score += 10;
                        visibleDot209 = false;
                    }
                    if ((x == xDot210) && (y == yDot210) && visibleDot210)
                    {
                        score += 10;
                        visibleDot210 = false;
                    }
                    if ((x == xDot211) && (y == yDot211) && visibleDot211)
                    {
                        score += 10;
                        visibleDot211 = false;
                    }
                    if ((x == xDot212) && (y == yDot212) && visibleDot212)
                    {
                        score += 10;
                        visibleDot212 = false;
                    }
                    if ((x == xDot213) && (y == yDot213) && visibleDot213)
                    {
                        score += 10;
                        visibleDot213 = false;
                    }
                    if ((x == xDot214) && (y == yDot214) && visibleDot214)
                    {
                        score += 10;
                        visibleDot214 = false;
                    }
                    if ((x == xDot215) && (y == yDot215) && visibleDot215)
                    {
                        score += 10;
                        visibleDot215 = false;
                    }
                    if ((x == xDot216) && (y == yDot216) && visibleDot216)
                    {
                        score += 10;
                        visibleDot216 = false;
                    }
                    if ((x == xDot217) && (y == yDot217) && visibleDot217)
                    {
                        score += 10;
                        visibleDot217 = false;
                    }
                    if ((x == xDot218) && (y == yDot218) && visibleDot218)
                    {
                        score += 10;
                        visibleDot218 = false;
                    }
                    if ((x == xDot219) && (y == yDot219) && visibleDot219)
                    {
                        score += 10;
                        visibleDot219 = false;
                    }
                    if ((x == xDot220) && (y == yDot220) && visibleDot220)
                    {
                        score += 10;
                        visibleDot220 = false;
                    }
                    if ((x == xDot221) && (y == yDot221) && visibleDot221)
                    {
                        score += 10;
                        visibleDot221 = false;
                    }
                    if ((x == xDot222) && (y == yDot222) && visibleDot222)
                    {
                        score += 10;
                        visibleDot222 = false;
                    }
                    if ((x == xDot223) && (y == yDot223) && visibleDot223)
                    {
                        score += 10;
                        visibleDot223 = false;
                    }
                    if ((x == xDot224) && (y == yDot224) && visibleDot224)
                    {
                        score += 10;
                        visibleDot224 = false;
                    }
                    if ((x == xDot225) && (y == yDot225) && visibleDot225)
                    {
                        score += 10;
                        visibleDot225 = false;
                    }
                    if ((x == xDot226) && (y == yDot226) && visibleDot226)
                    {
                        score += 10;
                        visibleDot226 = false;
                    }
                    if ((x == xDot227) && (y == yDot227) && visibleDot227)
                    {
                        score += 10;
                        visibleDot227 = false;
                    }
                    if ((x == xDot228) && (y == yDot228) && visibleDot228)
                    {
                        score += 10;
                        visibleDot228 = false;
                    }
                    if ((x == xDot229) && (y == yDot229) && visibleDot229)
                    {
                        score += 10;
                        visibleDot229 = false;
                    }
                    if ((x == xDot230) && (y == yDot230) && visibleDot230)
                    {
                        score += 10;
                        visibleDot230 = false;
                    }
                    if ((x == xDot231) && (y == yDot231) && visibleDot231)
                    {
                        score += 10;
                        visibleDot231 = false;
                    }
                    if ((x == xDot232) && (y == yDot232) && visibleDot232)
                    {
                        score += 10;
                        visibleDot232 = false;
                    }
                    if ((x == xDot233) && (y == yDot233) && visibleDot233)
                    {
                        score += 10;
                        visibleDot233 = false;
                    }
                    if ((x == xDot234) && (y == yDot234) && visibleDot234)
                    {
                        score += 10;
                        visibleDot234 = false;
                    }
                    if ((x == xDot235) && (y == yDot235) && visibleDot235)
                    {
                        score += 10;
                        visibleDot235 = false;
                    }
                    if ((x == xDot236) && (y == yDot236) && visibleDot236)
                    {
                        score += 10;
                        visibleDot236 = false;
                    }
                    if ((x == xDot237) && (y == yDot237) && visibleDot237)
                    {
                        score += 10;
                        visibleDot237 = false;
                    }
                    if ((x == xDot238) && (y == yDot238) && visibleDot238)
                    {
                        score += 10;
                        visibleDot238 = false;
                    }
                    if ((x == xDot239) && (y == yDot239) && visibleDot239)
                    {
                        score += 10;
                        visibleDot239 = false;
                    }
                    if ((x == xDot240) && (y == yDot240) && visibleDot240)
                    {
                        score += 10;
                        visibleDot240 = false;
                    }
                    if ((x == xDot241) && (y == yDot241) && visibleDot241)
                    {
                        score += 10;
                        visibleDot241 = false;
                    }
                    if ((x == xDot242) && (y == yDot242) && visibleDot242)
                    {
                        score += 10;
                        visibleDot242 = false;
                    }
                    if ((x == xDot243) && (y == yDot243) && visibleDot243)
                    {
                        score += 10;
                        visibleDot243 = false;
                    }
                    if ((x == xDot244) && (y == yDot244) && visibleDot244)
                    {
                        score += 10;
                        visibleDot244 = false;
                    }
                    if ((x == xDot245) && (y == yDot245) && visibleDot245)
                    {
                        score += 10;
                        visibleDot245 = false;
                    }
                    if ((x == xDot246) && (y == yDot246) && visibleDot246)
                    {
                        score += 10;
                        visibleDot246 = false;
                    }
                    if ((x == xDot247) && (y == yDot247) && visibleDot247)
                    {
                        score += 10;
                        visibleDot247 = false;
                    }
                    if ((x == xDot248) && (y == yDot248) && visibleDot248)
                    {
                        score += 10;
                        visibleDot248 = false;
                    }
                    if ((x == xDot249) && (y == yDot249) && visibleDot249)
                    {
                        score += 10;
                        visibleDot249 = false;
                    }
                    if ((x == xDot250) && (y == yDot250) && visibleDot250)
                    {
                        score += 10;
                        visibleDot250 = false;
                    }
                    if ((x == xDot251) && (y == yDot251) && visibleDot251)
                    {
                        score += 10;
                        visibleDot251 = false;
                    }
                    if ((x == xDot252) && (y == yDot252) && visibleDot252)
                    {
                        score += 10;
                        visibleDot252 = false;
                    }
                    if ((x == xDot253) && (y == yDot253) && visibleDot253)
                    {
                        score += 10;
                        visibleDot253 = false;
                    }
                    if ((x == xDot254) && (y == yDot254) && visibleDot254)
                    {
                        score += 10;
                        visibleDot254 = false;
                    }
                    if ((x == xDot255) && (y == yDot255) && visibleDot255)
                    {
                        score += 10;
                        visibleDot255 = false;
                    }
                    if ((x == xDot256) && (y == yDot256) && visibleDot256)
                    {
                        score += 10;
                        visibleDot256 = false;
                    }
                    if ((x == xDot257) && (y == yDot257) && visibleDot257)
                    {
                        score += 10;
                        visibleDot257 = false;
                    }
                    if ((x == xDot258) && (y == yDot258) && visibleDot258)
                    {
                        score += 10;
                        visibleDot258 = false;
                    }
                    if ((x == xDot259) && (y == yDot259) && visibleDot259)
                    {
                        score += 10;
                        visibleDot259 = false;
                    }
                    if ((x == xDot260) && (y == yDot260) && visibleDot260)
                    {
                        score += 10;
                        visibleDot260 = false;
                    }
                    if ((x == xDot261) && (y == yDot261) && visibleDot261)
                    {
                        score += 10;
                        visibleDot261 = false;
                    }
                    if ((x == xDot262) && (y == yDot262) && visibleDot262)
                    {
                        score += 10;
                        visibleDot262 = false;
                    }
                    if ((x == xDot263) && (y == yDot263) && visibleDot263)
                    {
                        score += 10;
                        visibleDot263 = false;
                    }
                    if ((x == xDot264) && (y == yDot264) && visibleDot264)
                    {
                        score += 10;
                        visibleDot264 = false;
                    }
                    


                    //Win screen 
                    if ((visibleDot1 == false) && (visibleDot2 == false)
                        && (visibleDot3 == false) && (visibleDot4 == false)
                        && (visibleDot5 == false) && (visibleDot6 == false)
                        && (visibleDot7 == false) && (visibleDot8 == false)
                        && (visibleDot9 == false) && (visibleDot10 == false)
                        && (visibleDot11 == false) && (visibleDot12 == false)
                        && (visibleDot13 == false) && (visibleDot14 == false)
                        && (visibleDot15 == false) && (visibleDot16 == false)
                        && (visibleDot17 == false) && (visibleDot18 == false)
                        && (visibleDot19 == false) && (visibleDot20 == false)
                        && (visibleDot21 == false) && (visibleDot22 == false)
                        && (visibleDot23 == false) && (visibleDot24 == false)
                        && (visibleDot25 == false) && (visibleDot26 == false)
                        && (visibleDot27 == false) && (visibleDot28 == false)
                        && (visibleDot29 == false) && (visibleDot30 == false)
                        && (visibleDot31 == false) && (visibleDot32 == false)
                        && (visibleDot33 == false) && (visibleDot34 == false)
                        && (visibleDot35 == false) && (visibleDot36 == false)
                        && (visibleDot37 == false) && (visibleDot38 == false)
                        && (visibleDot39 == false) && (visibleDot40 == false)
                        && (visibleDot41 == false) && (visibleDot42 == false)
                        && (visibleDot43 == false) && (visibleDot44 == false)
                        && (visibleDot45 == false) && (visibleDot46 == false)
                        && (visibleDot47 == false) && (visibleDot48 == false)
                        && (visibleDot49 == false) && (visibleDot50 == false)
                        && (visibleDot51 == false) && (visibleDot52 == false)
                        && (visibleDot53 == false) && (visibleDot54 == false)
                        && (visibleDot55 == false) && (visibleDot56 == false)
                        && (visibleDot57 == false) && (visibleDot58 == false)
                        && (visibleDot59 == false) && (visibleDot60 == false)
                        && (visibleDot61 == false) && (visibleDot62 == false)
                        && (visibleDot63 == false) && (visibleDot64 == false)
                        && (visibleDot65 == false) && (visibleDot66 == false)
                        && (visibleDot67 == false) && (visibleDot68 == false)
                        && (visibleDot69 == false) && (visibleDot70 == false)
                        && (visibleDot71 == false) && (visibleDot72 == false)
                        && (visibleDot73 == false) && (visibleDot74 == false)
                        && (visibleDot75 == false) && (visibleDot76 == false)
                        && (visibleDot77 == false) && (visibleDot78 == false)
                        && (visibleDot79 == false) && (visibleDot80 == false)
                        && (visibleDot81 == false) && (visibleDot82 == false)
                        && (visibleDot83 == false) && (visibleDot84 == false)
                        && (visibleDot85 == false) && (visibleDot86 == false)
                        && (visibleDot87 == false) && (visibleDot88 == false)
                        && (visibleDot89 == false) && (visibleDot90 == false)
                        && (visibleDot91 == false) && (visibleDot92 == false)
                        && (visibleDot93 == false) && (visibleDot94 == false)
                        && (visibleDot95 == false) && (visibleDot96 == false)
                        && (visibleDot97 == false) && (visibleDot98 == false)
                        && (visibleDot99 == false) && (visibleDot100 == false)
                        && (visibleDot101 == false) && (visibleDot102 == false)
                        && (visibleDot103 == false) && (visibleDot104 == false)
                        && (visibleDot105 == false) && (visibleDot106 == false)
                        && (visibleDot107 == false) && (visibleDot108 == false)
                        && (visibleDot109 == false) && (visibleDot110 == false)
                        && (visibleDot111 == false) && (visibleDot112 == false)
                        && (visibleDot113 == false) && (visibleDot114 == false)
                        && (visibleDot115 == false) && (visibleDot116 == false)
                        && (visibleDot117 == false) && (visibleDot118 == false)
                        && (visibleDot119 == false) && (visibleDot120 == false)
                        && (visibleDot121 == false) && (visibleDot122 == false)
                        && (visibleDot123 == false) && (visibleDot124 == false)
                        && (visibleDot125 == false) && (visibleDot126 == false)
                        && (visibleDot127 == false) && (visibleDot128 == false)
                        && (visibleDot129 == false) && (visibleDot130 == false)
                        && (visibleDot131 == false) && (visibleDot132 == false)
                        && (visibleDot133 == false) && (visibleDot134 == false)
                        && (visibleDot135 == false) && (visibleDot136 == false)
                        && (visibleDot137 == false) && (visibleDot138 == false)
                        && (visibleDot139 == false) && (visibleDot140 == false)
                        && (visibleDot141 == false) && (visibleDot142 == false)
                        && (visibleDot143 == false) && (visibleDot144 == false)
                        && (visibleDot145 == false) && (visibleDot146 == false)
                        && (visibleDot147 == false) && (visibleDot148 == false)
                        && (visibleDot149 == false) && (visibleDot150 == false)
                        && (visibleDot151 == false) && (visibleDot152 == false)
                        && (visibleDot153 == false) && (visibleDot154 == false)
                        && (visibleDot155 == false) && (visibleDot156 == false)
                        && (visibleDot157 == false) && (visibleDot158 == false)
                        && (visibleDot159 == false) && (visibleDot160 == false)
                        && (visibleDot161 == false) && (visibleDot162 == false)
                        && (visibleDot163 == false) && (visibleDot164 == false)
                        && (visibleDot165 == false) && (visibleDot166 == false)
                        && (visibleDot167 == false) && (visibleDot168 == false)
                        && (visibleDot169 == false) && (visibleDot170 == false)
                        && (visibleDot171 == false) && (visibleDot172 == false)
                        && (visibleDot173 == false) && (visibleDot174 == false)
                        && (visibleDot175 == false) && (visibleDot176 == false)
                        && (visibleDot177 == false) && (visibleDot178 == false)
                        && (visibleDot179 == false) && (visibleDot180 == false)
                        && (visibleDot181 == false) && (visibleDot182 == false)
                        && (visibleDot183 == false) && (visibleDot184 == false)
                        && (visibleDot185 == false) && (visibleDot186 == false)
                        && (visibleDot187 == false) && (visibleDot188 == false)
                        && (visibleDot189 == false) && (visibleDot190 == false)
                        && (visibleDot191 == false) && (visibleDot192 == false)
                        && (visibleDot193 == false) && (visibleDot194 == false)
                        && (visibleDot195 == false) && (visibleDot196 == false)
                        && (visibleDot197 == false) && (visibleDot198 == false)
                        && (visibleDot199 == false) && (visibleDot200 == false)
                        && (visibleDot201 == false) && (visibleDot202 == false)
                        && (visibleDot203 == false) && (visibleDot204 == false)
                        && (visibleDot205 == false) && (visibleDot206 == false)
                        && (visibleDot207 == false) && (visibleDot208 == false)
                        && (visibleDot209 == false) && (visibleDot210 == false)
                        && (visibleDot211 == false) && (visibleDot212 == false)
                        && (visibleDot213 == false) && (visibleDot214 == false)
                        && (visibleDot215 == false) && (visibleDot216 == false)
                        && (visibleDot217 == false) && (visibleDot218 == false)
                        && (visibleDot219 == false) && (visibleDot220 == false)
                        && (visibleDot221 == false) && (visibleDot222 == false)
                        && (visibleDot223 == false) && (visibleDot224 == false)
                        && (visibleDot225 == false) && (visibleDot226 == false)
                        && (visibleDot227 == false) && (visibleDot228 == false)
                        && (visibleDot229 == false) && (visibleDot230 == false)
                        && (visibleDot231 == false) && (visibleDot232 == false)
                        && (visibleDot233 == false) && (visibleDot234 == false)
                        && (visibleDot235 == false) && (visibleDot236 == false)
                        && (visibleDot237 == false) && (visibleDot238 == false)
                        && (visibleDot239 == false) && (visibleDot240 == false)
                        && (visibleDot241 == false) && (visibleDot242 == false)
                        && (visibleDot243 == false) && (visibleDot244 == false)
                        && (visibleDot245 == false) && (visibleDot246 == false)
                        && (visibleDot247 == false) && (visibleDot248 == false)
                        && (visibleDot249 == false) && (visibleDot250 == false)
                        && (visibleDot251 == false) && (visibleDot252 == false)
                        && (visibleDot253 == false) && (visibleDot254 == false)
                        && (visibleDot255 == false) && (visibleDot256 == false)
                        && (visibleDot257 == false) && (visibleDot258 == false)
                        && (visibleDot259 == false) && (visibleDot260 == false)
                        && (visibleDot261 == false) && (visibleDot262 == false)
                        && (visibleDot263 == false))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(28, 12);
                        Console.Write("You Win! Your score is: {0}!", score);
                        Console.ReadLine();
                        Environment.Exit(1);
                    }
                }

                Thread.Sleep(60);
            }// end of game loop

            Intro();


        }// end of session
        private static void Enemies(float xEnemy, float yEnemy, float xEnemy1, float yEnemy1, float xEnemy2, float yEnemy2, float xEnemy3, float yEnemy3)
        {
            //Enemies
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((int)xEnemy, (int)yEnemy);
            Console.Write("X");
            Console.SetCursorPosition((int)xEnemy1, (int)yEnemy1);
            Console.Write("X");
            Console.SetCursorPosition((int)xEnemy2, (int)yEnemy2);
            Console.Write("X");
            Console.SetCursorPosition((int)xEnemy3, (int)yEnemy3);
            Console.Write("X");
        }
    }// end of  Main

}// end of class
