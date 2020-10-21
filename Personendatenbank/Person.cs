using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Personendatenbank
{
    public enum Gender { Männlich, Weiblich, Divers }

    public class Person
    {
        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public DateTime Geburtsdatum { get; set; }

        public bool Verheiratet { get; set; }

        public Color Lieblingsfarbe { get; set; }

        public Gender Geschlecht { get; set; } 
    }
}