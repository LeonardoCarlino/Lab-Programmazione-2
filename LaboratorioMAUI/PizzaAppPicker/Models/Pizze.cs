using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppPicker.Models
{
    internal class Pizze
    {
		private string _nome;

		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		private float _prezzo;

		public float Prezzo
		{
			get { return _prezzo; }
			set { _prezzo = value; }
		}

		private string _image;

		public string Image
		{
			get { return _image; }
			set { _image = value; }
		}

		private string _ingredienti;

		public string Ingredienti
		{
			get { return _ingredienti; }
			set { _ingredienti = value; }
		}

        public Pizze(string nome, float prezzo, string image, string ingredienti)
        {
            Nome = nome;
			Prezzo = prezzo;
			Image = image;
			Ingredienti = ingredienti;
        }

        public override bool Equals(object? obj)
        {
            return obj is Pizze pizze &&
                   _nome == pizze._nome &&
                   Nome == pizze.Nome &&
                   _prezzo == pizze._prezzo &&
                   Prezzo == pizze.Prezzo &&
                   _image == pizze._image &&
                   Image == pizze.Image &&
                   _ingredienti == pizze._ingredienti &&
                   Ingredienti == pizze.Ingredienti;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_nome, Nome, _prezzo, Prezzo, _image, Image, _ingredienti, Ingredienti);
        }
    }
}
