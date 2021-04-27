using System;
using System.Linq;

/*
    
     */
namespace lab5
{
    internal class Program
    {
        public abstract class Composition
        {
            public string SongTitle { get; set; }

            public int SongDuration { get; set; }
            public string Info;

            public abstract void InfoFormat();

            public Composition(string Title, int Duration)
            {
                SongDuration = Duration;
                SongTitle = Title;
            }

            public override string ToString()
            {
                InfoFormat();
                return Info;
            }
        }
        
        public class Album
        {
            private Composition[] _compositions;
            public string Singer { get; set; }
            public string Genre { get; set; }
            public string Released { get; set; }
            public int Duration { get; set; }
            public string Info;

            public Album(string singer, string genre, string released, Composition[] compositions)
            {
                Singer = singer;
                Genre = genre;
                Released = released;
                _compositions = compositions;
                //Array.Copy(compositions, 0, _compositions, 0);
                foreach (Composition comp in compositions)
                {
                    Duration += comp.SongDuration;
                }
            }

            public void FormInfo()
            {
                Info = $"Исполнитель: {Singer}\n" +
                       $"Жанр: {Genre}\n" +
                       $"Год выпуска: {Released}\n" +
                       $"Общая длительность: {Duration}\n" +
                       $"Все композиции: \n";
                for (int i = 0; i < _compositions.Length; i++)
                {
                    Info += $"Композици №{i+1}:\n" + _compositions[i];
                }
            }

            public override string ToString()
            {
                FormInfo();
                return Info;
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;
                try
                {
                    Album temp = (Album)obj;
                    return Singer == temp.Singer && Genre == temp.Genre && Released == temp.Released
                           && Duration == temp.Duration && Enumerable.SequenceEqual(_compositions, temp._compositions);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка сравнения");
                    return false;
                }
            }
        }

        public class Collection
        {
            public Album[] _albums;
            public string collectionTitle { get; set; }
            public string Owner { get; set; }
            public string Info;

            public Collection(string Title, string owner, Album[] albums)
            {
                collectionTitle = Title;
                Owner = owner;
                _albums = albums;
            }

            public void FormInfo()
            {
                Info = $"Название коллекции: {collectionTitle}\n" +
                                  $"Владелец: {Owner}\n";
                for (int i = 0; i < _albums.Length; i++)
                {
                    Info += $"Альбом №{i+1}:\n" + _albums[i];
                }
            }

            public override string ToString()
            {
                FormInfo();
                return Info;
            }
        }

        public class Song : Composition
        {
            public string text { get; set; }
            public string author { get; set; }

            public override void InfoFormat()
            {
                Info = $"Название: {SongTitle}\n" +
                       $"Продолжительность: {SongDuration}\n" +
                       $"Текст: {text}\n" +
                       $"Автор текста: {author}\n";
            }
            public Song(string Title, int Duration, string Text, string Author) : base(Title, Duration)
            {
                text = Text;
                author = Author;
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType()) return false;
                try
                {
                    Song temp = (Song) obj;
                    return SongTitle == temp.SongTitle && SongDuration == temp.SongDuration && text == temp.text && author == temp.author;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка! Нельзя сравнивать объекты разных классов. Вы пытались сравнить объект класса Song с другим");
                    //Console.WriteLine(e);
                    //Environment.Exit(0);
                    //throw; //Без этого не работает exit
                    return false;
                }
                
            }
        }

        public class Instrumental : Composition
        {
            public string[] instruments;
            public override void InfoFormat()
            {
                Info = $"Название: {SongTitle}\n" +
                       $"Продолжительность: {SongDuration}\n" +
                       $"Инструменты: " + string.Join(", ", instruments);
            }

            public Instrumental(string Title, int Duration, string[] Instruments) : base(Title, Duration)
            {
                instruments = Instruments;
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                try
                {
                    Instrumental temp = (Instrumental) obj;
                    return SongTitle == temp.SongTitle && SongDuration == temp.SongDuration && Enumerable.SequenceEqual(instruments, temp.instruments);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка! Нельзя сравнивать объекты разных классов. Вы пытались сравнить объект класса Instrumental с другим");
                    Console.WriteLine(e);
                    //
                    //Environment.Exit(0);
                    //throw; //Без этого не работает exit
                    return false;
                }
                
            }
        }
        
        public static void Main(string[] args)
        {
            Composition[] songs = new Composition[3];
            songs[0] = new Song("Hollowness", 600, "a lot of letters", "Minami");
            songs[1] = new Song("Shuuen Requiem", 250, "a little bit of letters", "My First Story");
            songs[2] = new Instrumental("Everything will freeze", 600, new string[]{"Guitar", "Drums", "Bass"});
            Album[] my = new Album[1];
            my[0] = new Album("Undead Corporation", "Rock, Metalcore", "2013", songs);
            Collection col = new Collection("Моя коллекция", "Я", my);
            //Console.WriteLine(col);
            
            Album test = new Album("Undead Corporation", "Rock, Metalcore", "2013", songs);
            if(test.Equals(my[0])) Console.WriteLine("Same albums!");
                else Console.WriteLine("Diff albums");
            
            Composition[] songs1 = new Composition[3];
            songs1[0] = new Song("Shuuen Requiem", 250, "a little bit of letters", "My First Story");
            songs1[1] = new Song("Hollowness", 600, "a lot of letters", "Minami");
            songs1[2] = new Instrumental("Everything will freeze", 600, new string[]{"Guitar", "Drums", "Bass"});
            test = new Album("Undead Corporation", "Rock, Metalcore", "2013", songs1);
            if(test.Equals(my[0])) Console.WriteLine("Same albums!");
                else Console.WriteLine("Diff albums");
        }
    }
}