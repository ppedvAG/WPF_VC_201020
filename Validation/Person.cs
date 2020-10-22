using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Validation
{
    //Für ValidatesOnDataErrors muss z.B. das Interface IDataErrorInfo implementiert werden. Dieses erfordert die Einbindung von zwei zusätzlichen
    public class Person : IDataErrorInfo
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.All(x => Char.IsLetter(x)))
                    name = value;
                else
                    //Bei einer Validierung per Exceptions wird die Exception-Message als Fehlemeldung verwendet. Die Exception wird automatisch von
                    //der GUI abgefangen (wenn in der Bindung ValidatesOnExceptions true ist)
                    throw new Exception("Bitte gib nur Buchstaben ein.");
            }
        }

        public int Alter { get; set; }

        public string Error
        {
            get { return ""; }
        }

        //Diese Indexer-Property wird von dem Interface gefordert und von der GUI als Validierung verwendet. Wenn ein nicht-leerer String zurückgegeben wird, 
        //dann wird dies als Fehler interpretiert und dieser String als Fehlermeldung
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case (nameof(Alter)):
                        if (Alter < 0) return "Dein Alter kann nicht negativ sein.";
                        if (Alter > 150) return "So alt bist du wahrscheinlich nicht.";
                        break;

                    default:
                        break;
                }

                return "";
            }
        }
    }
}
