//
// Body.cs
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
	public class Body
	{
		public Body (float mass)
		{
			Mass = mass;
		}

		public float Mass { get; private set; }

		public PointF Position { get; set; }
		public float Rotation { get; set; }
		public PointF Velocity { get; set; }
	}
}

