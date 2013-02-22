//
// CCLayerExtensions.cs
//
// Author:
//       Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (c) 2013 S. Delcroix
//
using System;
using MonoTouch.Cocos2D;

namespace mtspeed
{
	public static class CCLayerExtensions
	{
		public static CCScene Scene (this CCLayer layer)
		{
			var scene = new CCScene ();
			scene.Add (layer);
			return scene;
		}
	}
}

