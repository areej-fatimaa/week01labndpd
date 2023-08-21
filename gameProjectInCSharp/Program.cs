using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZInput;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace gameProjectInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] maze = new char[25, 71];
            int pikachuhealthcounter = 20000;
            int score = 0;
            int totalbullet = 1000;
            int spikoBulletCount = 0;
            int pikachuBulletcount = 0;
            int spikohealthcounter = 6;
            int pikachux = 10;
            int pikachuy = 2;
            //movement spiko
            int spikox = 4;
            int spikoy = 8;
            string spikoDirection = "up";
            //characters for printing enemy and player
            char pika = (char)1;
            char pika2 = (char)17;
            char pika3 = (char)16;
            char pika4 = (char)124;
            char shark = (char)2;
            char misty1 = (char)19;
            char[,] spiko = new char[2, 3] { { ' ', shark, ' ' }, { pika2, misty1, pika3 } };
            char[,] pikachu = new char[2, 3] { { ' ', pika, ' ' }, { pika2, pika4, pika3 } };
            //spiko bullets
            int[] spikoBulletx = new int[10000];
            int[] spikoBullety = new int[10000];
            bool[] isBulletActivespiko = new bool[10000];
            //statrt of game
            StartGame(ref totalbullet, ref spikoBulletCount, ref pikachuBulletcount, ref score, ref spikohealthcounter, ref pikachuhealthcounter, ref pikachux, ref pikachuy, ref spikox, ref spikoy);
            Console.Clear();
            Console.Beep();
            Header();
            Console.WriteLine("1.start");
            Console.WriteLine("2.option");
            Console.WriteLine("3.exit");
            Console.WriteLine("Enter Your option: ");
            string option = Console.ReadLine();
            if (option == "1")
            {
                Console.WriteLine("1.New Game");
                Console.WriteLine("2.Resume");
                Console.WriteLine("Enter Your option: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    StartGame(ref totalbullet, ref spikoBulletCount, ref pikachuBulletcount, ref score, ref spikohealthcounter, ref pikachuhealthcounter, ref pikachux, ref pikachuy, ref spikox, ref spikoy);
                }
                if (choice == "2")
                {
                    ReadGameFromFile(ref totalbullet, ref spikoBulletCount, ref pikachuBulletcount, ref score, ref spikohealthcounter, ref pikachuhealthcounter, ref pikachux, ref pikachuy, ref spikox, ref spikoy);
                }
                Console.WriteLine("LOADING..........");
                Console.WriteLine("Press any key to continue! ");
                bool gameRun = true;
                Console.Clear();
                ReadMazeFromFile(maze);
                Maze(maze);
                if (spikohealthcounter > 0)
                {
                    PrintSpiko(spiko, spikohealthcounter, spikox, spikoy);
                }
                while (gameRun)
                {
                    Thread.Sleep(90);
                    PrintScore(ref score);
                    PrintSpikoHealth(spikohealthcounter);
                    Printpikachuhealth(pikachuhealthcounter, pikachux, pikachuy);
                    MoveSpiko(ref spiko, maze, ref spikoDirection, ref spikox, ref spikoy, ref spikohealthcounter);
                    if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow))
                    {
                        MovePikachuLeft(ref score, ref pikachu, ref pikachuhealthcounter, maze, ref pikachux, ref pikachuy);
                    }
                    if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow))
                    {
                        MovePikachuRight(ref score, ref pikachu, ref pikachuhealthcounter, maze, ref pikachux, ref pikachuy);
                    }
                    if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow))
                    {
                        MovePikachuUp(ref score, ref pikachu, ref pikachuhealthcounter, maze, ref pikachux, ref pikachuy);
                    }
                    if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow))
                    {
                        MovePikachuDown(ref score, ref pikachu, ref pikachuhealthcounter, maze, ref pikachux, ref pikachuy);
                    }
                    if (EZInput.Keyboard.IsKeyPressed(Key.Space))
                    {
                        //    generatebulletpikachu(totalbullet, pikachuBulletcount, pikachux, pikachuy);
                    }
                    if (EZInput.Keyboard.IsKeyPressed(Key.Tab))
                    {
                        //      generatebulletpikachupikachuleft(totalbullet, pikachuBulletcount, pikachux, pikachuy);
                    }

                    GenerateBulletSpiko(ref spikoBulletx, ref spikoBullety, ref isBulletActivespiko, ref spikoBulletCount, ref spikohealthcounter, ref spikox, ref spikoy);

                    //  MoveBulletSpiko(ref isBulletActivespiko,ref spikoBulletx,ref spikoBullety, ref spikoBulletCount);

                    //  movebulletpikachu();
                    // bulletcollisionwithpikachuofspiko(spikoBulletCount, pikachuhealthcounter, pikachux, pikachuy);
                    // bulletcollisionwitspiko(spikoBulletCount, spikohealthcounter, spikox, spikoy);

                    if (pikachuhealthcounter <= 0)
                    {
                        gameRun = false;
                        WriteGameToFile(ref totalbullet, ref spikoBulletCount, ref pikachuBulletcount, ref score, ref spikohealthcounter, ref pikachuhealthcounter, ref pikachux, ref pikachuy, ref spikox, ref spikoy);
                        Console.Clear();
                        //gameover(score);
                        Console.WriteLine("Enter any key to continue");
                        Console.ReadKey();
                    }
                }
            }
            else if (option == "2")
            {
                Console.Clear();
                GameInstruction();
            }
            else if (option == "3")
            {
                Console.WriteLine("Exit");
                Console.Clear();
            }
        }
        static void Header()
        {
            Console.WriteLine("LOADING....");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(" OooOOo.     o                   o           Oo             `o    O                       o               ");
            Console.WriteLine("O     `O o  O                  O            oO              o   O   o                   O                 ");
            Console.WriteLine("o      O    o                  o             O              O  O                        o                 ");
            Console.WriteLine("O     .o    o                  O            o'              oOo                         o                 ");
            Console.WriteLine("oOooOO'  O  O  o  .oOoO' .oOo  OoOo. O   o     .oOo         o  o    O  'OoOo. .oOoO .oOoO  .oOo. `oOOoOO. ");
            Console.WriteLine("o        o  OoO   O   o  O     o   o o   O     `Ooo.        O   O   o   o   O o   O o   O  O   o  O  o  o ");
            Console.WriteLine("O        O  o  O  o   O  o     o   O O   o         O        o    o  O   O   o O   o O   o  o   O  o  O  O ");
            Console.WriteLine("o'       o' O   o `OoO'o `OoO' O   o `OoO'o    `OoO'        O     O o'  o   O `OoOo `OoO'o `OoO'  O  o  o ");
            Console.WriteLine("                                                                                  O                       ");
            Console.WriteLine("                                                                               OoO'                       ");
        }
        static void Keys()
        {
            Console.WriteLine("LOADING........");
            Console.ReadKey();
            Console.WriteLine(":::    ::: :::::::::: :::   :::  ::::::::   ");
            Console.WriteLine(":+:   :+:  :+:        :+:   :+: :+:    :+:  ");
            Console.WriteLine("+:+  +:+   +:+         +:+ +:+  +:+         ");
            Console.WriteLine("+#++:++    +#++:++#     +#++:   +#++:++#++  ");
            Console.WriteLine("+#+  +#+   +#+           +#+           +#+  ");
            Console.WriteLine("#+#   #+#  #+#           #+#    #+#    #+#  ");
            Console.WriteLine("###    ### ##########    ###     ########   ");

            Console.WriteLine("Prees up key to move up");
            Console.WriteLine("Press down key to move ");
            Console.WriteLine("Press left key to move left");
            Console.WriteLine("Press right key to move right");
            Console.WriteLine("Press space key to shoot right");
            Console.WriteLine("Press tab key to shoot left");
        }
        static void Instructions()
        {

            Console.WriteLine("LOADING.....");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("::::::::::: ::::    :::  ::::::::  ::::::::::: :::::::::  :::    :::  ::::::::  ::::::::::: :::::::::::  ::::::::  ::::    :::  ::::::::  ");
            Console.WriteLine("    :+:     :+:+:   :+: :+:    :+:     :+:     :+:    :+: :+:    :+: :+:    :+:     :+:         :+:     :+:    :+: :+:+:   :+: :+:    :+: ");
            Console.WriteLine("    +:+     :+:+:+  +:+ +:+            +:+     +:+    +:+ +:+    +:+ +:+            +:+         +:+     +:+    +:+ :+:+:+  +:+ +:+        ");
            Console.WriteLine("    +#+     +#+ +:+ +#+ +#++:++#++     +#+     +#++:++#:  +#+    +:+ +#+            +#+         +#+     +#+    +:+ +#+ +:+ +#+ +#++:++#++ ");
            Console.WriteLine("    +#+     +#+  +#+#+#        +#+     +#+     +#+    +#+ +#+    +#+ +#+            +#+         +#+     +#+    +#+ +#+  +#+#+#        +#+ ");
            Console.WriteLine("    #+#     #+#   #+#+# #+#    #+#     #+#     #+#    #+# #+#    #+# #+#    #+#     #+#         #+#     #+#    #+# #+#   #+#+# #+#    #+# ");
            Console.WriteLine("########### ###    ####  ########      ###     ###    ###  ########   ########      ###     ###########  ########  ###    ####  ########  ");

            Console.WriteLine("shoot the sharks to get extra point");
            Console.WriteLine("collect fish to get points");
            Console.WriteLine("find a key to go to next leve");
            Console.WriteLine("save your player from bullets of sharks");
            Console.WriteLine("sharks health will decrease your bullets will hit them");
            Console.WriteLine("Player bullets should not touch small fish because they will die");
        }
        static void GameInstruction()
        {
            string choice = "";
            while (choice != "3")
            {
                Console.WriteLine("1.keys");
                Console.WriteLine("2.instructions");
                Console.WriteLine("3.exit");
                Console.WriteLine("Enter your option:");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    Keys();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

                else if (choice == "2")
                {
                    Console.Clear();
                    Instructions();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

                else if (choice == "3")
                {
                    Console.Clear();
                }
            }
        }
        static void Maze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }
        static void ReadMazeFromFile(char[,] maze)
        {
            string path = "D:\\oopweek01lab\\week01labndpd\\gameProjectInCSharp\\gameMaze.txt";
            StreamReader fp = new StreamReader(path);
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 70; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            fp.Close();
        }

        static void StartGame(ref int totalbullet, ref int spikoBulletCount, ref int pikachuBulletcount, ref int score, ref int spikohealthcounter, ref int pikachuhealthcounter, ref int pikachux, ref int pikachuy, ref int spikox, ref int spikoy)
        {

            pikachux = 10;
            pikachuy = 2;
            spikox = 4;
            spikoy = 8;
            score = 0;
            pikachuBulletcount = 0;
            spikoBulletCount = 0;
            totalbullet = 1000;
            spikohealthcounter = 6;
            pikachuhealthcounter = 2000;
        }
        static void WriteGameToFile(ref int totalbullet, ref int spikoBulletCount, ref int pikachuBulletcount, ref int score, ref int spikohealthcounter, ref int pikachuhealthcounter, ref int pikachux, ref int pikachuy, ref int spikox, ref int spikoy)
        {
            string path = "D:\\oopweek01lab\\week01labndpd\\gameProjectInCSharp\\game.txt";
            StreamWriter fileVariable = new StreamWriter(path);
            fileVariable.WriteLine(pikachux + "\n");
            fileVariable.WriteLine(pikachuy + "\n");
            fileVariable.WriteLine(spikox + "\n");
            fileVariable.WriteLine(spikoy + "\n");
            fileVariable.WriteLine(score + "\n");
            fileVariable.WriteLine(pikachuBulletcount + "\n");
            fileVariable.WriteLine(spikoBulletCount + "\n");
            fileVariable.WriteLine(totalbullet + "\n");
            fileVariable.WriteLine(spikohealthcounter + "\n");
            fileVariable.WriteLine(pikachuhealthcounter + "\n");
            Console.ReadKey();

        }
        static void ReadGameFromFile(ref int totalbullet, ref int spikoBulletCount, ref int pikachuBulletcount, ref int score, ref int spikohealthcounter, ref int pikachuhealthcounter, ref int pikachux, ref int pikachuy, ref int spikox, ref int spikoy)
        {
            StreamReader file = new StreamReader("game.txt");
            while (!file.EndOfStream)
            {
                pikachux = int.Parse(file.ReadLine());
                pikachuy = int.Parse(file.ReadLine());
                spikox = int.Parse(file.ReadLine());
                spikoy = int.Parse(file.ReadLine());
                score = int.Parse(file.ReadLine());
                pikachuBulletcount = int.Parse(file.ReadLine());
                spikoBulletCount = int.Parse(file.ReadLine());
                totalbullet = int.Parse(file.ReadLine());
                spikohealthcounter = int.Parse(file.ReadLine());
                pikachuhealthcounter = int.Parse(file.ReadLine());
            }
            file.Close();
        }
        static void PrintScore(ref int score)
        {
            Console.SetCursorPosition(105, 1);
            Console.WriteLine("Fishes: {0}", score);

        }
        static void PrintSpikoHealth(int spikohealthcounter)
        {
            if (spikohealthcounter >= 0)
            {
                Console.SetCursorPosition(105, 3);
                Console.WriteLine("Spiko Health {0}", spikohealthcounter);
            }
            else if (spikohealthcounter < 0)
            {
                Console.SetCursorPosition(105, 3);
                Console.WriteLine("Died         ");
            }
        }
        static void Printpikachuhealth(int pikachuhealthcounter, int pikachux, int pikachuy)
        {
            if (pikachuhealthcounter >= 0)
            {
                Console.SetCursorPosition(105, 6);
                Console.WriteLine("Pikachu Health: {0}", pikachuhealthcounter);
            }
            else if (pikachuhealthcounter == 0)
            {
                Console.SetCursorPosition(105, 6);
                Console.WriteLine("             Died");
            }
        }
        static void PrintSpiko(char[,] spiko, int spikoHealthCounter, int spikoX, int spikoY)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (spikoHealthCounter >= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(spikoX, spikoY + i);
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(spiko[i, j]);
                    }
                }
            }
            else if (spikoHealthCounter < 0)
            {
                EraseSpiko(spikoX, spikoY);
            }
        }
        static void PrintPikachu(char[,] pikachu, int pikachuhealthcounter, int pikachux, int pikachuy)
        {
            if (pikachuhealthcounter >= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(pikachux, pikachuy + i);
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(pikachu[i, j]);
                    }
                }
            }
            else if (pikachuhealthcounter < 0)
            {
                ErasePikachu(pikachux, pikachuy);
            }
        }
        static void ErasePikachu(int pikachux, int pikachuy)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(pikachux, pikachuy + i);
                Console.WriteLine("   ");
            }
        }
        static void EraseSpiko(int spikox, int spikoy)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(spikox, spikoy + i);
                Console.WriteLine("   ");
            }
        }
        static void MoveSpiko(ref char[,] spiko, char[,] maze, ref string spikoDirection, ref int spikox, ref int spikoy, ref int spikoHealthCounter)
        {
            bool flag = false;
            if (spikoDirection == "up")
            {
                for (int i = 0; i < 3; i++)
                {
                    if (maze[spikoy - 1, spikox + i] == '&')
                    {
                        flag = true;
                        spikoDirection = "down";
                    }
                }
                if (!flag)
                {
                    EraseSpiko(spikox, spikoy);
                    spikoy--;
                    PrintSpiko(spiko, spikoHealthCounter, spikox, spikoy);
                }
            }
            else if (spikoDirection == "down")
            {
                bool isflag = false;
                for (int i = 0; i < 3; i++)
                {
                    if (maze[spikoy + 2, spikox + i] == '&')
                    {
                        isflag = true;
                        spikoDirection = "up";
                    }
                }
                if (!isflag)
                {
                    EraseSpiko(spikox, spikoy);
                    spikoy++;
                    PrintSpiko(spiko, spikoHealthCounter, spikox, spikoy);

                }

            }

        }
        static void MovePikachuLeft(ref int score, ref char[,] pikachu, ref int pikachuhealthcounter, char[,] maze, ref int pikachux, ref int pikachuy)
        {
            bool flag = false;
            for (int i = 0; i < 2; i++)
            {
                if (maze[pikachuy + i, pikachux - 1] == '&')
                {
                    flag = true;
                }
                else if (maze[pikachuy + i, pikachux - 1] == '^')
                {
                    score++;
                }
            }
            if (!flag)
            {
                ErasePikachu(pikachux, pikachuy);
                pikachux--;
                PrintPikachu(pikachu, pikachuhealthcounter, pikachux, pikachuy);

            }
        }
        static void MovePikachuRight(ref int score, ref char[,] pikachu, ref int pikachuhealthcounter, char[,] maze, ref int pikachux, ref int pikachuy)
        {
            bool flag = false;
            for (int i = 0; i < 2; i++)
            {
                if (maze[pikachuy + i, pikachux + 3] == '&')
                {
                    flag = true;
                }
                else if (maze[pikachuy + i, pikachux + 3] == '^')
                {
                    score++;
                }
            }
            if (!flag)
            {
                ErasePikachu(pikachux, pikachuy);
                pikachux++;
                PrintPikachu(pikachu, pikachuhealthcounter, pikachux, pikachuy);

            }
        }
        static void MovePikachuUp(ref int score, ref char[,] pikachu, ref int pikachuhealthcounter, char[,] maze, ref int pikachux, ref int pikachuy)
        {
            bool flag = false;
            for (int i = 0; i < 3; i++)
            {
                if (maze[pikachuy - 1, pikachux + i] == '&')
                {
                    flag = true;
                }
                else if (maze[pikachuy - 1, pikachux + i] == '^')
                {
                    score++;
                }
            }
            if (!flag)
            {
                ErasePikachu(pikachux, pikachuy);
                pikachuy--;
                PrintPikachu(pikachu, pikachuhealthcounter, pikachux, pikachuy);

            }
        }
        static void MovePikachuDown(ref int score, ref char[,] pikachu, ref int pikachuhealthcounter, char[,] maze, ref int pikachux, ref int pikachuy)
        {
            bool flag = false;
            for (int i = 0; i < 3; i++)
            {
                if (maze[pikachuy + 2, pikachux + i] == '&')
                {
                    flag = true;
                }
                else if (maze[pikachuy + 2, pikachux + i] == '^')
                {
                    score++;
                }
            }
            if (!flag)
            {
                ErasePikachu(pikachux, pikachuy);
                pikachuy++;
                PrintPikachu(pikachu, pikachuhealthcounter, pikachux, pikachuy);

            }
        }
        static void GenerateBulletSpiko(ref int[] spikoBulletx, ref int[] spikoBullety, ref bool[] isBulletActivespiko, ref int spikoBulletCount, ref int spikohealthcounter, ref int spikox, ref int spikoy)
        {
            if (spikohealthcounter > 0)
            {
                spikoBulletx[spikoBulletCount] = spikox + 2;
                spikoBullety[spikoBulletCount] = spikoy;
                isBulletActivespiko[spikoBulletCount] = true;
                Console.SetCursorPosition(spikox + 2, spikoy);
                Console.WriteLine("-");
                spikoBulletCount++;
            }
        }
    }
    }
