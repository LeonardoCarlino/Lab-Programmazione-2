using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal abstract class QuestionBase
    {
		private string _text;

		// Proprietà
		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}

		private int _points;

		public int Points
		{
			get { return _points; }
			set 
			{	if(value < 0)
				{
					_points = 0;
				}
				else
				{
					_points = value;
				} 
			}
		}

		private string _imageName;

		public string ImageName
		{
			get { return _imageName; }
			set { _imageName = value; }
		}




		// Costruttore
		public QuestionBase(string text, int points, string imageName)
		{
			Text = text;
			Points = points;
			ImageName = imageName;
		}

		public abstract bool CheckAnswer(bool userAnswer);

	}
}
