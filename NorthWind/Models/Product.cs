using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace NorthWind.Models
{
    public class Product: Entity
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged(); }
		}

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }


    }
}
