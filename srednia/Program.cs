using System;

namespace srednia
{
    class Program
    {
        static void Main(string[] args)
        {
            string ver = "0.0.4";

            Console.Title = $"Średnia {ver}";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Program do obliczania średniej, Wersja {ver}, Autor: Adiks ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Witaj, mam nadzieję, że program ułatwi Ci obliczanie średniej :D");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Aby kontynuować naciśnij dowolny klawisz...");

            Console.ReadKey();
            Console.Clear();

            bool zapamietajWybor = false;
            char zapisanyWybor = '0';
            char wybor = '0';

            while (true)
            {
                Console.Clear();

            sprawdz:
                Console.Write("Podaj liczbę ocen: ");

                string x = Console.ReadLine();

                int liczbaOcen;

                Console.Clear();

                bool spr = int.TryParse(x, out liczbaOcen);

                while (!spr)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Liczba ocen musi być liczbą!");
                    Console.ResetColor();
                    Console.Write("Wprowadź liczbę ocen: ");
                    x = Console.ReadLine();
                    Console.Clear();
                    spr = int.TryParse(x, out liczbaOcen);
                }

                if (liczbaOcen < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Liczba ocen nie może być mniejsza lub równa 1");
                    Console.ResetColor();
                    goto sprawdz;
                }



                if (zapamietajWybor == false)
                {
                wybor:

                    Console.WriteLine("Czy twoje oceny posiadają wagę ?(T/N): ");
                    Console.Write("Wpisz T lub N: ");
                    wybor = Console.ReadKey().KeyChar;

                    Console.Clear();

                    if (wybor == 'T')
                    {
                        wybor = 't';
                    }
                    else if (wybor == 'N')
                    {
                        wybor = 'n';
                    }

                    if (wybor == 't' || wybor == 'n')
                    {

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Błędny wybór!");
                        Console.ReadKey();
                        Console.Clear();
                        Console.ResetColor();
                        goto wybor;
                    }

                drugiwybor:

                    Console.WriteLine("Czy wybór ma być zapamiętany do ponownego włączenia programu?(T/N): ");

                    char wyborZap = Console.ReadKey().KeyChar;

                    Console.Clear();

                    if (wyborZap == 'T' || wyborZap == 't')
                    {
                        zapamietajWybor = true;
                    }
                    else if (wyborZap == 'N' || wyborZap == 'n')
                    {
                        zapamietajWybor = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Błędny wybór!");
                        Console.ReadKey();
                        Console.Clear();
                        Console.ResetColor();
                        goto drugiwybor;
                    }
                }

                if (zapamietajWybor == true)
                {
                    zapisanyWybor = wybor;
                    wybor = zapisanyWybor;
                }

                Console.Clear();

                int licznik = 0;
                float suma = 0, srednia = 0, ocena = 0, waga = 0, sumaWagi = 0, iloczynWagi = 0;

                switch (wybor)
                {
                    case 'n':
                        for (int i = 0; i < liczbaOcen; i++)
                        {
                            licznik++;
                            ocena = 0;

                            Console.Write("Podaj {0} ocenę: ", licznik);

                            string y = Console.ReadLine();
                            spr = float.TryParse(y, out ocena);

                            Console.Clear();

                        tutaj:

                            while (!spr)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ocena musi być liczbą!");
                                Console.ResetColor();
                                Console.Write("Podaj {0} ocenę: ", licznik);
                                y = Console.ReadLine();
                                Console.Clear();
                                spr = float.TryParse(y, out ocena);
                            }

                            bool malaCzyDuza = false;

                            while (!malaCzyDuza)
                            {
                                if (ocena > 6 || ocena < 0)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nie ma takiej oceny!");
                                    Console.ResetColor();
                                    Console.Write("Podaj {0} ocenę:", licznik);
                                    y = Console.ReadLine();
                                    Console.Clear();
                                    spr = float.TryParse(y, out ocena);

                                    if (spr == false)
                                    {
                                        goto tutaj;
                                    }
                                }
                                else
                                {
                                    malaCzyDuza = true;
                                }
                            }

                            suma += ocena;
                        }

                        srednia = suma / liczbaOcen;

                        Console.Clear();
                        Console.WriteLine("Średnia wynosi {0}", Math.Round(srednia, 2)); Console.WriteLine();
                        
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        
                        Console.WriteLine("Jeżeli chcesz zakończyć działanie programu wciśnij 0");
                        Console.WriteLine("Jeżeli chcesz korzystać dalej z programu, naciśnij dowolny klawisz");
                        Console.ResetColor();
                        char koniec = Console.ReadKey().KeyChar;

                        if (koniec == '0')
                        {
                            Environment.Exit(0);
                        }

                        Console.Clear();
                        break;
                    case 't':
                        for (int i = 0; i < liczbaOcen; i++)
                        {
                            licznik++;
                            ocena = 0;
                            waga = 0;
                            Console.Write("Podaj {0} ocenę: ", licznik);

                            string y = Console.ReadLine();
                            spr = float.TryParse(y, out ocena);

                            Console.Write("Podaj {0} wagę oceny: ", licznik);

                            string z = Console.ReadLine();
                            bool spr2 = float.TryParse(z, out waga);

                            Console.Clear();

                        tutaj:

                            while (!spr || !spr2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ocena oraz waga musi być liczbą!");
                                Console.ResetColor();
                                Console.Write("Podaj {0} ocenę: ", licznik);
                                y = Console.ReadLine();

                                Console.Write("Podaj {0} wagę oceny: ", licznik);
                                z = Console.ReadLine();

                                Console.Clear();

                                spr = float.TryParse(y, out ocena);
                                spr2 = float.TryParse(z, out waga);
                            }

                            bool malaCzyDuza = false;

                            while (!malaCzyDuza)
                            {
                                if (ocena > 6 || ocena < 0)
                                {
                                    Console.Clear();

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nie ma takiej oceny!");
                                    Console.ResetColor();
                                    Console.Write("Podaj {0} ocenę:", licznik);

                                    y = Console.ReadLine();

                                    Console.Write("Podaj {0} wagę oceny: ", licznik);

                                    z = Console.ReadLine();

                                    Console.Clear();

                                    spr = float.TryParse(y, out ocena);
                                    spr2 = float.TryParse(z, out waga);

                                    if (spr == false || spr2 == false)
                                    {
                                        goto tutaj;
                                    }
                                }
                                else
                                {
                                    malaCzyDuza = true;
                                }
                            }

                            iloczynWagi += (ocena * waga);
                            sumaWagi += waga;

                        }

                        srednia = iloczynWagi / sumaWagi;

                        Console.Clear();

                        Console.WriteLine("Średnia wynosi {0}", Math.Round(srednia, 2)); Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("Jeżeli chcesz zakończyć działanie programu wciśnij 0");
                        Console.WriteLine("Jeżeli chcesz korzystać dalej z programu, naciśnij dowolny klawisz");
                        Console.ResetColor();

                        koniec = Console.ReadKey().KeyChar;

                        if (koniec == '0')
                        {
                            Environment.Exit(0);
                        }

                        Console.Clear();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Błędny wybór!");
                        Console.ReadKey();
                        Console.Clear();
                        Console.ResetColor();
                        break;
                };
            }
        }
    }
}
