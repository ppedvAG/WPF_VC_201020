﻿using MVVM_Personendatenbank.Hilfsklassen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace MVVM_Personendatenbank.Model
{
    //Im Model-Teil eines MVVM-Programms werden die Buisness-Klassen abgelegt. Diese Klassen dürfen keine Referenzen auf die anderen MVVM-Teile haben.
    //Dieses Beispiel besteht nur aus einer Model-Klasse sowie einem Enumerator.

    //Model-Klasse 'Person' mit dem IDataErrorInfo-Interface zur Validierung der Benutzereingaben bezüglich der Klassenproperties
    public class Person : IDataErrorInfo
    {
        #region Statische Member

        //Statische Listenproperty zum Ablegen der geladenen Personen (ObservableCollection, damit die GUI über Veränderungen innerhalb der Liste
        //informiert wird)
        public static ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>();

        //Methode, welche Bsp-Daten generiert und damit den Zugriff auf eine Datenbank simuliert
        public static void LadePersonenAusDb()
        {
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Nass", Geburtsdatum = new DateTime(1988, 4, 13), Verheiratet = false, Lieblingsfarbe = Colors.Red, Geschlecht = Gender.Weiblich });
            Personenliste.Add(new Person() { Vorname = "Rainer", Nachname = "Zufall", Geburtsdatum = new DateTime(1987, 5, 22), Verheiratet = true, Lieblingsfarbe = Colors.Green, Geschlecht = Gender.Männlich });
        }

        #endregion

        //Properties der 'Person'-Klasse
        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public DateTime Geburtsdatum { get; set; }

        public bool Verheiratet { get; set; }

        public Color Lieblingsfarbe { get; set; }

        public Gender Geschlecht { get; set; }

        //Parameterloser Standartkonstruktor, welcher die leeren 'Person'-Objekte auf einen Startzustand setzt
        public Person()
        {
            //Die String-Eigenschaften werden auf "" initialisiert, um GUI-Fehler zu vermeiden
            this.Vorname = "";
            this.Nachname = "";
            //Die 'Gerburtsdatum'-Property wird auf das aktuelle Datum gesetzt, damit der Benutzer innerhalb der Auswahlmaske nicht so viel suchen muss
            this.Geburtsdatum = DateTime.Now.AddDays(1);
        }

        //Kopierkonstruktor, welcher eine 1-zu-1-Kopie eines übergebenen 'Person'-Objekts erzeugt
        public Person(Person altePerson)
        {
            this.Vorname = altePerson.Vorname;
            this.Nachname = altePerson.Nachname;
            this.Geschlecht = altePerson.Geschlecht;
            this.Lieblingsfarbe = altePerson.Lieblingsfarbe;
            this.Verheiratet = altePerson.Verheiratet;

            this.Geburtsdatum = new DateTime(altePerson.Geburtsdatum.Year, altePerson.Geburtsdatum.Month, altePerson.Geburtsdatum.Day);
        }

        //Durch das Interface geforderte Properties
        public string Error
        {
            get { return ""; }
        }

        //Property, welche die Validierungsfehler und deren Fehlermeldungen beinhaltet
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Vorname):
                        if (Vorname.Length <= 0 || Vorname.Length > 50) return "Bitte geben Sie Ihren Vornamen ein.";
                        if (!Vorname.All(x => Char.IsLetter(x))) return "Der Vorname darf nur Buchstaben einthalten.";
                        break;

                    case nameof(Nachname):
                        if (Nachname.Length <= 0 || Nachname.Length > 50) return "Bitte geben Sie Ihren Nachnamen ein.";
                        if (!Nachname.All(x => Char.IsLetter(x))) return "Der Nachname darf nur Buchstaben einthalten.";
                        break;

                    case nameof(Geburtsdatum):
                        if (Geburtsdatum > DateTime.Now) return "Das Geburtsdatum darf nicht in der Zukunft liegen.";
                        if (DateTime.Now.Year - Geburtsdatum.Year > 150) return "Das Geburtsdatum darf nicht mehr als 150 Jahre in der Vergangenheit liegen.";
                        break;

                    case nameof(Lieblingsfarbe):
                        if (Lieblingsfarbe.ToString().Equals("#00000000")) return "Wählen Sie Ihre Lieblingsfarbe aus.";
                        break;
                }
                return "";
            }
        }
    }
}