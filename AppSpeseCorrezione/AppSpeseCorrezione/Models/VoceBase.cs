using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpeseCorrezione.Models
{
    // Super Classe (base) astratta
    public abstract class VoceBase
    {   
        // variabile --> campo
        private string _descrizione;

        // Propfull (in java getter e setter)
        public string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }

        public abstract string ToRiga();

    }
}
