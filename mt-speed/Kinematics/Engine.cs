//
// Engine.cs
//
// Author:
//       Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (c) 2013 S. Delcroix
//
using System;
using System.Drawing;
using System.Collections.Generic;

namespace Kinematics
{
	public class Engine
	{
		List<Body> bodies = new List<Body> ();

		public PointF Gravity { get; set; }

		public void Add (Body body)
		{
			bodies.Add (body);
		}

		public float CurrentTimeStamp { get; private set; }

		public void Step (float dt)
		{
			if (dt == 0f)
				return;

			var prev_dt = CurrentTimeStamp;
			CurrentTimeStamp = dt;

			//Integrate positions and speeds
			foreach (var body in bodies) {
				//pos += vel * dt;
				body.Position = new PointF (body.Position.X + body.Velocity.X * dt, body.Position.Y + body.Velocity.Y * dt);
				//vel += acc * dt;
				body.Velocity = new PointF (body.Velocity.X + Gravity.X * dt, body.Velocity.Y + Gravity.Y * dt);
			}
		}

	}
}