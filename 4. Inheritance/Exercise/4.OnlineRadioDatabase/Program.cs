using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.OnlineRadioDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Split(";");
                string artistName = input[0];
                string songName = input[1];
                var duration = input[2].Split(":");

                try
                {
                    bool validMinutes = int.TryParse(duration[0], out int minutes);
                    bool validSeconds = int.TryParse(duration[1], out int seconds);

                    if (validMinutes==false||validSeconds==false)
                    {
                        throw new InvalidSongLengthException();
                    }

                    Song song = new Song(artistName, songName, minutes, seconds);

                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongLengthException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Songs added: {songs.Count}");
            int totalSongSeconds = songs.Sum(x => x.Seconds + x.Minutes * 60);
            TimeSpan totalTime = TimeSpan.FromSeconds(totalSongSeconds);
            string result = string.Format($"{totalTime.Hours}h {totalTime.Minutes}m {totalTime.Seconds}s");
            Console.WriteLine($"Playlist length: {result}");
        }
    }
}
