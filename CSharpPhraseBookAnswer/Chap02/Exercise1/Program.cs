using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            // 2.1.3
            var songs = new Song[] {
                new Song("Let it be", "The Beatles", 243),
                new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
                new Song("Close To You", "Carpenters", 276),
                new Song("Honesty", "Billy Joel", 231),
                new Song("I Will Always Love You", "Whitney Houston", 273),
            };
            PrintSongs(songs);
            
        }

        // 2.1.4
        private static void PrintSongs(Song[] songs) {
            foreach (var song in songs) {
                Console.WriteLine(@"{0}, {1} {2:m\:ss}",
                    song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
            }
        }

        /*
           @"{0}, {1} {2:m\:ss}"에 관해서
           {} 안에서 :은 특별한 의미를 가진다. 따라서 :을 문자 ':'으로 표시하기 위해
           \:으로 썼다. 그리고 \:이 이스케이프 문자로 인식되지 않게 하기 위해 @을 앞에 붙여서
           축자 문자열 리터럴로 지정했다.
        */
    }

}
