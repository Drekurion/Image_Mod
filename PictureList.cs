using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APO_Projekt
{
	public abstract class PictureList
	{
		public static Dictionary<string, Picture> All = new Dictionary<string, Picture>();
		public static Picture Focused;
	}
}
