//
// KinematicSprite.cs
//
// Author:
//       Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (c) 2013 S. Delcroix
//
using System;
using System.Drawing;

using MonoTouch.Cocos2D;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

namespace Kinematics
{
	public class KinematicSprite : CCSprite
	{
		public KinematicSprite (string filename) : base (filename)
		{

		}
		
		public KinematicSprite (CCTexture2D texture, RectangleF rect) : base (texture, rect)
		{
		}
		
		public Body Body { get; set; }
		
		public override PointF Position {
			get {
				return Body==null ? base.Position : Body.Position;
			}
			set {
				if (Body == null)
					base.Position = value;
				else
					Body.Position = value;
			}
		}
		
		public override float Rotation {
			get {
				return Body==null ? base.Rotation : Body.Rotation;
			}
			set {
				if (Body == null)
					base.Rotation = value;
				else
					Body.Rotation = value;
			}
		}
		
		[Export ("dirty:rotationX:rotationY:scaleX:scaleY:anchorPointInPoints:")]
		public bool Dirty (ref CGAffineTransform transform, float rotX, float rotY, float scaleX, float scaleY, PointF anchorPointInPoints)
		{
			if (Body == null) {
				transform = base.NodeToParentTransform ();
				return true;
			}
			
			PointF rot = Body.Rotation.UnitVector ();
			//var anchor = AnchorPointInPoints;
			
			float x = Body.Position.X + rot.X * -anchorPointInPoints.X * scaleX - rot.Y * -anchorPointInPoints.Y * scaleY;
			float y = Body.Position.Y + rot.Y * -anchorPointInPoints.X * scaleX + rot.X * -anchorPointInPoints.Y * scaleY;
			
			transform = new CGAffineTransform (rot.X * scaleX,
			                                   rot.Y * scaleX,
			                                   -rot.Y * scaleY,
			                                   rot.X * scaleY,
			                                   x,
			                                   y);
			
			return true;
		}
		
		//public override CGAffineTransform NodeToParentTransform ()
		//{
		//	if (Body == null)
		//		return base.NodeToParentTransform ();
		//
		//	// Although scale is not used by physics engines, it is calculated just in case
		//	// the sprite is animated (scaled up/down) using actions.
		//	// For more info see: http://www.cocos2d-iphone.org/forum/topic/68990
		//	PointF rot = Body.Rotation;
		//	var anchor = AnchorPointInPoints;
		//	var scaleX = ScaleX;
		//	var scaleY = ScaleY;
		//	float x = Body.Position.X + rot.X * -anchor.X * scaleX - rot.Y * -anchor.Y * scaleY;
		//	float y = Body.Position.Y + rot.Y * -anchor.X * scaleX + rot.X * -anchor.Y * scaleY;
		//
		//
		//	var transform = new CGAffineTransform (rot.X * scaleX,
		//	                                       rot.Y * scaleX,
		//	                                       -rot.Y * scaleY,
		//	                                       rot.X * scaleY,
		//	                                       x,
		//	                                       y);
		//	//Set the _transform native field ? doesn't look to be used
		//	return transform;
		//
		//}
		//
		//public override bool Dirty {
		//	get {
		//		return true;
		//	}
		//}
	}
}

