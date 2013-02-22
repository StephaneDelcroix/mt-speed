//
// PointFExtensions.cs
//
// Author:
//       Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (c) 2013 S. Delcroix
//
using System;
using System.Drawing;

namespace Kinematics
{
	public static class FloatExtensions
	{
		public static PointF UnitVector(this float angle)
		{
			return new PointF ((float)Math.Cos (angle), (float)Math.Sin (angle));
		}
	}
}

