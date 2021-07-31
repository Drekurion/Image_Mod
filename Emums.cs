using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APO_Projekt
{
	public enum SliderDialogType
	{
		Blur,
		GaussBlur,
		Threshold,
		AdaptiveThreshold,
		Posterize,
		MedianBlur
	}
	public enum DataTableDialogType
	{
		Moments,
		Diameter,
		ShapeAspects
	}

	public enum LogicOperationType
	{
		NOT,
		AND,
		OR,
		XOR,
		NXOR
	}
	public enum LogicWindowType
	{
		Horizontal,
		Vertical,
		Star
	}
}
