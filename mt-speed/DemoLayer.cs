//
// DemoLayer.cs
//
// Author:
//       Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (c) 2013 S. Delcroix
//
using System;

using System.Drawing;
using MonoTouch.Cocos2D;

using Kinematics;

namespace mtspeed
{
	public class DemoLayer : CCLayer
	{	
		int bodyCount;
		Random rand = new Random ();

		Engine engine;
		CCSpriteBatchNode batchnode;

		public DemoLayer () {
			engine = new Engine {
				Gravity = new PointF (0,-10),
			};
				
			batchnode = new CCSpriteBatchNode ("sprites.png");
				
			var winsize = CCDirectorIOS.SharedDirector.WinSize;

			for (var i=-35;i<35;i++)
			for (var j=-25;j<25;j++) {
				var ball = new KinematicSprite (batchnode.Texture, new RectangleF (0,0,4,4)) {
					Body = new Body (1),
					Position = new PointF (winsize.Width/2 + i*5, winsize.Height/2+j*5),
				};
				engine.Add (ball.Body);
				batchnode.Add (ball);
			}

			var bullet = new KinematicSprite (batchnode.Texture, new RectangleF (16, 0, 8, 8)) {
				Body = new Body (10) {
					Velocity = new PointF (80,80),
				},
				Position = new PointF (0,0),
			};
			engine.Add (bullet.Body);
			batchnode.Add (bullet);
			Add (batchnode);

		}

		public override void OnEnter ()
		{
			base.OnEnter ();
			Schedule (Update);
		}
		
		void Update (float dt)
		{
			engine.Step (dt);
		}
	}
}


