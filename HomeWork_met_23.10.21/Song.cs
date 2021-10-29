using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_met_23._10._21
{
    class Song
    {
        public string name, author;
        Song prev;
        public void SetName(string s) { name = s; }
        public void SetAuthor(string s) { author = s; }
        public void SetPrev(List<Song> songs)
        {
            if (songs.Count > 0) {prev = songs.Last(); }
            else { prev = null; }
        }
        public string Title() { return $"{name} - {author}"; }
        public bool Equals(Song song)
        {
            if (song.author.Equals(prev.author) & song.name.Equals(prev.name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
