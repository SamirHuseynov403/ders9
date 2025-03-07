using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders8
{
    static class clKomands
    {
        static clUser[] users = new clUser[3];
        static clGenre[] janrlar = new clGenre[5];
        static clMovie[] kinolar = new clMovie[5];
        static clUserListMovie[] UserSelectedMovies = new clUserListMovie[2];
        static int userid;
        static string usertype;
        static int countlistusermovie = 0;
        static int countkino = 5;
        static int countjanr = 5;
        public static void AllUsers()
        {
            users[0] = new clUser { UserId = 0, Username = "Samir", Password = "123", UserType = UserType.Admin };
            users[1] = new clUser { UserId = 1, Username = "Murad", Password = "456", UserType = UserType.User };
            users[2] = new clUser { UserId = 2, Username = "Nicat", Password = "789", UserType = UserType.User };
        }
        public static void UserSorgu()
        {
            while (true)
            {
                Console.Clear();
                FonDefault();
                Console.WriteLine("Istifadeci girisi");
                Console.WriteLine(new string('_', 30));
                Console.WriteLine("");
                Console.WriteLine("İstifadeci ad:");
                string username = Console.ReadLine();
                Console.WriteLine("Sifre:");
                string password = Console.ReadLine();

                bool userFound = false;

                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i].Username == username && users[i].Password == password)
                    {
                        userFound = true;
                        Console.Clear();
                        Console.WriteLine($"{users[i].UserType} {users[i].Username} Xos Gelmisiniz");

                        userid = users[i].UserId;
                        usertype = users[i].UserType.ToString();

                        if (users[i].UserType == UserType.Admin)
                        {
                            FonAdmin();
                            ListsAdmin();
                            
                        }
                        else if (users[i].UserType == UserType.User)
                        {
                            FonUser();
                            ListsUser();
                            
                        }
                        return;
                    }
                }

                if (!userFound)
                {
                    Console.WriteLine("Istifadeci adi ve ya Parol duz deyil");
                    Console.WriteLine("Davam etmek ucun Enter basin...");
                    Console.ReadLine();
                }
            }
        }
        public static void ListsAdmin()
        {
            Console.WriteLine("Aşağıdakı siyahıdan seçim edin");
            Console.WriteLine(" 1. Kino Elave et");
            Console.WriteLine(" 2. Kino sil");
            Console.WriteLine(" 3. Janr elave et");
            Console.WriteLine(" 4. Janr sil");
            Console.WriteLine(" 5. Kino baxis saylari");
            Console.WriteLine(" 6. Istifadeciler");
            Console.WriteLine("User çıxış (U) enter");
            Console.WriteLine("Programdan çıxış (P) enter");

            string secim = Console.ReadLine().ToUpper();

            switch (secim)
            {
                case "1":
                    AddKino();
                    break;
                case "2":
                    DeleteKino();
                    ExitProgramOrUser();
                    break;
                case "3":
                    AddJanr();
                    break;
                case "4":
                    DeleteJanr();
                    ExitProgramOrUser();
                    break;
                case "5":
                    Console.Clear();
                    KinolariShow();
                    ExitProgramOrUser();
                    break;
                case "6":
                    UsersShow();
                    ExitProgramOrUser();
                    break;
                case "U":
                    UserSorgu();
                    break;
                case "P":
                    Environment.Exit(0);
                    return;

            }
        }
        public static void ListsUser()
        {
            Console.WriteLine("Aşağıdakı siyahıdan seçim edin");
            Console.WriteLine(" 1. Kino Izle");
            Console.WriteLine(" 2. Kino adi ile tap");
            Console.WriteLine(" 3. Baxmaq ucun siyahıya film elave ed");
            Console.WriteLine(" 4. Janr uzre kino axtar");
            Console.WriteLine(" 5. Secdiyiniz kinolar");
            Console.WriteLine("User çıxış (U) enter");
            Console.WriteLine("Programdan çıxış (P) enter");

            string secim = Console.ReadLine().ToUpper();

            switch (secim)
            {
                case "1":
                    KinolariShow();
                    WatchMovie();
                    break;

                case "2":
                    SearchKinoName();
                    ExitProgramOrUser();
                    break;
                case "3":
                    UserWatchList();
                    return;
                case "4":
                    FilterKinoJanr();
                    ExitProgramOrUser();
                    return;
                case "5":
                    UserMovieListShow();
                    ExitProgramOrUser();
                    return;
                case "E":
                    ListsUser();
                    return;
                case "U":
                    UserSorgu();
                    return;
                case "P":
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Yanlis secim!");
                    break;
            }
        }
        static void ExitProgramOrUser()
        {
            Console.WriteLine();
            Console.WriteLine("Novbeti emeliyyat ucun secim edin");
            Console.WriteLine("Esas menu (E) enter");
            Console.WriteLine("User çıxış (U) enter");
            Console.WriteLine("Programdan çıxış (P) enter");

            while (true)
            {
                string UserRequest = Console.ReadLine();

                if (UserRequest == "E" || UserRequest == "e")
                {
                    Console.Clear();
                    if (usertype == UserType.User.ToString())
                    {
                        ListsUser();
                        return;
                    }
                    if (usertype == UserType.Admin.ToString())
                    {
                        ListsAdmin();
                        return;
                    }
                }
                else if (UserRequest == "U" || UserRequest == "u")
                {
                    Console.Clear();
                    UserSorgu();
                    return;
                }
                else if (UserRequest == "P" || UserRequest == "p")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Duzhun secim edin");
                }
            }
        }
        public static void Hazirjanrlar()
        {
            janrlar[0] = new clGenre { GenreID = 0, NameGenre = "Komediya" };
            janrlar[1] = new clGenre { GenreID = 1, NameGenre = "Dram" };
            janrlar[2] = new clGenre { GenreID = 2, NameGenre = "Qorxu" };
            janrlar[3] = new clGenre { GenreID = 3, NameGenre = "Tarixi" };
            janrlar[4] = new clGenre { GenreID = 4, NameGenre = "Macera" };
        }
        public static void HazirKinolar()
        {
            kinolar[0] = new clMovie { MovieId = 0, MovieName = "Yol Ehvalati", NameGenre = janrlar[0].NameGenre, ViewCount = 0 };
            kinolar[1] = new clMovie { MovieId = 1, MovieName = "Nabat", NameGenre = janrlar[1].NameGenre, ViewCount = 0 };
            kinolar[2] = new clMovie { MovieId = 2, MovieName = "Ovsuncu", NameGenre = janrlar[2].NameGenre, ViewCount = 0 };
            kinolar[3] = new clMovie { MovieId = 3, MovieName = "Axırıncı aşırım", NameGenre = janrlar[3].NameGenre, ViewCount = 0 };
            kinolar[4] = new clMovie { MovieId = 4, MovieName = "Bakı fethi", NameGenre = janrlar[4].NameGenre, ViewCount = 0 };
        }
        public static void KinolariShow()
        {
            Console.WriteLine("Kinolar siyahısı:");
            for (int i = 0; i < kinolar.Length; i++)
            {
                if (kinolar[i] != null && kinolar[i].NameGenre != null)
                {
                    Console.WriteLine($"ID: {kinolar[i].MovieId} - Kino adı: {kinolar[i].MovieName} - Janr: {kinolar[i].NameGenre} - Baxış sayı: {kinolar[i].ViewCount}");
                }
            }
            Console.WriteLine();
        }
        public static void WatchMovie()
        {
            while (true)
            {
                bool find = false;
                Console.WriteLine("Baxmaq ucun kono ID uzre secim edin.");
                int KinoId = int.Parse(Console.ReadLine());
                for (int i = 0; i < kinolar.Length; i++)
                {
                    if (KinoId == kinolar[i].MovieId)
                    {
                        kinolar[i].ViewCount++;
                        Console.WriteLine($"Siz {kinolar[i].MovieName} kinosuna baxdiniz");
                        find = true;
                        ExitProgramOrUser();
                        return;
                    }
                }
                if (find == false)
                {
                    Console.WriteLine("Secdiyiniz ID uzre kino tapilmadi");
                    Console.Clear();
                }
            }
        }
        public static void UserWatchList()
        {
            KinolariShow();

            while (true)
            {
                Console.WriteLine("Kino ID-si ni daxil edin (Cixis ucun 'C' yazin):");
                string input = Console.ReadLine();

                if (input == "C" || input == "c")
                {
                    Console.Clear();
                    ExitProgramOrUser();
                    break;
                }

                int idno;
                if (!int.TryParse(input, out idno))
                {
                    Console.WriteLine("Yanlis daxil edildi kino ID-si və ya 'C' yazın.");
                    continue;
                }

                bool isExist = false;
                for (int j = 0; j < countlistusermovie; j++)
                {
                    if (UserSelectedMovies[j].UserId == userid && UserSelectedMovies[j].MovieId == idno)
                    {
                        Console.WriteLine("Bu kino listde var");
                        isExist = true;
                        break;
                    }
                }

                if (isExist)
                {
                    continue;
                }

                if (countlistusermovie >= UserSelectedMovies.Length)
                {
                    int newLength = UserSelectedMovies.Length * 2;
                    if (newLength == 0) newLength = 1;

                    clUserListMovie[] newArray = new clUserListMovie[newLength];
                    for (int k = 0; k < UserSelectedMovies.Length; k++)
                    {
                        newArray[k] = UserSelectedMovies[k];
                    }
                    UserSelectedMovies = newArray;
                }

                bool kinoTapildi = false;
                for (int i = 0; i < kinolar.Length; i++)
                {
                    if (idno == kinolar[i].MovieId)
                    {
                        UserSelectedMovies[countlistusermovie] = new clUserListMovie(); // Mütləq yarat
                        UserSelectedMovies[countlistusermovie].UserId = userid;
                        UserSelectedMovies[countlistusermovie].MovieId = kinolar[i].MovieId;
                        UserSelectedMovies[countlistusermovie].MovieName = kinolar[i].MovieName;
                        UserSelectedMovies[countlistusermovie].GenreName = kinolar[i].NameGenre;
                        countlistusermovie++;
                        Console.WriteLine("Kino liste elave edildi.");
                        kinoTapildi = true;
                        break;
                    }
                }

                if (!kinoTapildi)
                {
                    Console.WriteLine("Bele bir kino tapilmadi.");
                }

                Console.WriteLine();
            }
        }
        public static void UserMovieListShow()
        {
            if (countlistusermovie == 0)
            {
                Console.WriteLine("Kino listiniz bosdur");
                ExitProgramOrUser();
            }
            else
            {
                Console.WriteLine("Sizin kino listiniz");
                for (int i = 0; i < UserSelectedMovies.Length; i++)
                {
                    Console.WriteLine($"ID: {UserSelectedMovies[i].MovieId} - Kino adı: {UserSelectedMovies[i].MovieName} - Janr: {UserSelectedMovies[i].GenreName}");
                }
                Console.WriteLine();
                ExitProgramOrUser();
            }
        }
        public static void AddKino()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Kino adi daxil edin (Cixis ucun 'C' yazin):");
                string kinoAdi = Console.ReadLine();

                if (kinoAdi == "C" || kinoAdi == "c")
                {
                    Console.Clear();
                    ExitProgramOrUser();
                    break;
                }

                Console.WriteLine("Janr secin:");
                for (int i = 0; i < countjanr; i++)
                {
                    Console.WriteLine($"{i}. {janrlar[i].NameGenre}");
                }

                int janrId;
                while (true)
                {
                    Console.WriteLine("Janr ID daxil edin (Cixis ucun 'C' yazin):");
                    string janrInput = Console.ReadLine();

                    if (janrInput.ToUpper() == "C")
                    {
                        Console.WriteLine("Kino elave etmeyi dayandirdiniz.");
                        Console.Clear();
                        ExitProgramOrUser();
                        return;
                    }

                    if (int.TryParse(janrInput, out janrId) && janrId >= 0 && janrId < countjanr)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Yanlis Janr ID, yeniden daxil edin!");
                    }
                }



                if (countkino >= kinolar.Length)
                {
                    int newLength = kinolar.Length * 2;
                    if (newLength == 0) newLength = 1;

                    clMovie[] newKinolar = new clMovie[newLength];
                    for (int i = 0; i < kinolar.Length; i++)
                    {
                        newKinolar[i] = kinolar[i];
                    }
                    kinolar = newKinolar;
                }

                kinolar[countkino] = new clMovie
                {
                    MovieId = countkino,
                    MovieName = kinoAdi,
                    NameGenre = janrlar[janrId].NameGenre,
                    ViewCount = 0
                };

                Console.WriteLine($"'{kinoAdi}' adi ile kino elave olundu.");
                countkino++;

                Console.WriteLine();
            }
        }
        public static void DeleteKino()
        {
            Console.Clear();
            KinolariShow();

            Console.WriteLine("Silmek istediyiniz kino ID-sini daxil edin (Cixis ucun 'C' yazin):");
            string input = Console.ReadLine();

            if (input == "C" || input == "c")
            {
                ExitProgramOrUser();
                return;
            }

            int id;
            if (!int.TryParse(input, out id))
            {
                Console.WriteLine("Yanlis ID daxil edildi!");
                return;
            }

            bool tapildi = false;
            for (int i = 0; i < countkino; i++)
            {
                if (kinolar[i] != null && kinolar[i].MovieId == id)
                {
                    tapildi = true;
                    for (int j = i; j < countkino - 1; j++)
                    {
                        kinolar[j] = kinolar[j + 1];
                    }
                    kinolar[countkino - 1] = null;
                    countkino--;
                    Console.WriteLine("Kino ugurla silindi!");
                    break;
                }
            }

            if (!tapildi)
            {
                Console.WriteLine("Bu ID ilə kino tapilmadi!");
            }
        }
        public static void AddJanr()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Janr adi daxil edin (Cixis ucun 'C' yazin):");
                string janrAdi = Console.ReadLine();

                if (janrAdi.ToUpper() == "C")
                {
                    Console.Clear();
                    ExitProgramOrUser();
                    break;
                }

                if (countjanr >= janrlar.Length)
                {
                    int newLength = janrlar.Length * 2;
                    if (newLength == 0) newLength = 1;

                    clGenre[] newJanrlar = new clGenre[newLength];
                    for (int i = 0; i < janrlar.Length; i++)
                    {
                        newJanrlar[i] = janrlar[i];
                    }
                    janrlar = newJanrlar;
                }

                janrlar[countjanr] = new clGenre
                {
                    GenreID = countjanr,
                    NameGenre = janrAdi
                };

                Console.WriteLine($"'{janrAdi}' adi ile janr elave olundu.");
                countjanr++;

                Console.WriteLine();
            }
        }
        public static void DeleteJanr()
        {
            Console.Clear();
            Hazirjanrlar();

            Console.WriteLine("Silmek istediyiniz janr ID-sini daxil edin (Cixis ucun 'C' yazin):");
            string input = Console.ReadLine();

            if (input.ToUpper() == "C")
            {
                ExitProgramOrUser();
                return;
            }

            int id;
            if (!int.TryParse(input, out id))
            {
                Console.WriteLine("Yanlis ID daxil edildi!");
                return;
            }

            bool tapildi = false;
            for (int i = 0; i < countjanr; i++)
            {
                if (janrlar[i] != null && janrlar[i].GenreID == id)
                {
                    tapildi = true;
                    for (int j = i; j < countjanr - 1; j++)
                    {
                        janrlar[j] = janrlar[j + 1];
                        janrlar[j].GenreID = j;
                    }
                    janrlar[countjanr - 1] = null;
                    countjanr--;
                    Console.WriteLine("Janr ugurla silindi!");
                    break;
                }
            }

            if (!tapildi)
            {
                Console.WriteLine("Bu ID ilə janr tapilmadi!");
            }
        }
        public static void UsersShow()
        {
            Console.WriteLine("User siyahısı:");
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] != null && users[i].Username != null)
                {
                    Console.WriteLine($"İstifadeci: {users[i].Username} - İstifadeci novu: {users[i].UserType}");
                }
            }
            Console.WriteLine();
        }
        public static void FilterKinoJanr()
        {
            Console.Clear();

            Console.WriteLine("Janrlar siyahisi:");
            for (int i = 0; i < countjanr; i++)
            {
                if (janrlar[i] != null)
                {
                    Console.WriteLine($"{i}. {janrlar[i].NameGenre}");
                }
            }

            Console.WriteLine("Janr ID-si uzre kinolari goster (Cixis ucun 'C' yazin):");
            string input = Console.ReadLine();

            if (input == "C" || input == "c")
            {
                ExitProgramOrUser();
                return;
            }

            int janrId;
            if (!int.TryParse(input, out janrId) || janrId < 0 || janrId >= countjanr || janrlar[janrId] == null)
            {
                Console.WriteLine("Yanlis Janr ID daxil edildi!");
                return;
            }

            string secilenJanr = janrlar[janrId].NameGenre;
            Console.WriteLine($"\n'{secilenJanr}' janrında olan kinolar:");

            bool tapildi = false;
            for (int i = 0; i < countkino; i++)
            {
                if (kinolar[i] != null && kinolar[i].NameGenre == secilenJanr)
                {
                    Console.WriteLine($"ID: {kinolar[i].MovieId} - {kinolar[i].MovieName} - Baxis sayi: {kinolar[i].ViewCount}");
                    tapildi = true;
                }
            }

            if (!tapildi)
            {
                Console.WriteLine("Bu janrda kino tapilmadi.");
            }
        }
        public static void SearchKinoName()
        {
            Console.Clear();

            Console.WriteLine("Kino adını daxil edin (Cixis ucun 'C' yazın):");
            string input = Console.ReadLine();

            if (input == "C" || input == "c")
            {
                ExitProgramOrUser();
                return;
            }

            bool tapildi = false;
            Console.WriteLine("\nAxtarıs neticeleri:");
            for (int i = 0; i < countkino; i++)
            {
                if (kinolar[i] != null && kinolar[i].MovieName == input)
                {
                    Console.WriteLine($"ID: {kinolar[i].MovieId} - {kinolar[i].MovieName} - Janr: {kinolar[i].NameGenre} - Baxis sayi: {kinolar[i].ViewCount}");
                    tapildi = true;
                }
            }

            if (!tapildi)
            {
                Console.WriteLine("Kino tapılmadı.");
            }
        }
        public static void FonAdmin()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        public static void FonUser()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        public static void FonDefault()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
        }

    }
}
