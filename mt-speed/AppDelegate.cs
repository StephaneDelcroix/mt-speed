//
// AppDelegate.cs
//
// Author:
//       Stephane Delcroix <stephane@delcroix.org>
//
// Copyright (c) 2013 S. Delcroix
//
using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using MonoTouch.Cocos2D;

namespace mtspeed
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		public UINavigationController NavController { get ; private set; }
		CCDirectorIOS director;
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			var glView = CCGLView.View(window.Bounds);
			
			director = (CCDirectorIOS)CCDirector.SharedDirector;
			director.WantsFullScreenLayout = true;
			
			director.DisplayStats = true;
			
			director.AnimationInterval = 1.0/60;
			
			director.View = glView;
			
			director.Projection = CCDirectorProjection.TwoD;
			
			//if (!director.EnableRetinaDisplay(true))
			//	Console.WriteLine ("Retina Display not supported");
			
			CCTexture2D.DefaultAlphaPixelFormat = CCTexture2DPixelFormat.Rgba8888;
			
			var fileUtils = CCFileUtils.SharedFileUtils;
			fileUtils.EnableFallbackSuffixes=false;
			fileUtils.IPhoneRetinaDisplaySuffix="-hd";
			fileUtils.IPadSuffix="-ipad";
			fileUtils.IPhoneRetinaDisplaySuffix="-ipadhd";
			
			CCTexture2D.PVRImageHavePremultipliedAlpha = true;
			
			director.PushScene (new DemoLayer ().Scene ());
			
			// Create a Navigation Controller with the Director
			NavController = new UINavigationController(director) {NavigationBarHidden=true};
			
			// set the Navigation Controller as the root view controller
			if (UIDevice.CurrentDevice.CheckSystemVersion (5, 0))
				window.RootViewController = NavController; 
			else
				window.AddSubview (NavController.View);     
			
			window.MakeKeyAndVisible ();
			
			return true;
		}
		
		public override void DidEnterBackground (UIApplication application)
		{
			if (NavController.VisibleViewController == director)
				director.StopAnimation ();
		}
		
		public override void WillEnterForeground (UIApplication application)
		{
			if (NavController.VisibleViewController == director)
				director.StartAnimation ();
		}
		
		public override void WillTerminate (UIApplication application)
		{
			CCDirector.SharedDirector.End();
		}
		
		public override void ReceiveMemoryWarning (UIApplication application)
		{
			CCDirector.SharedDirector.PurgeCachedData ();
		}
		
		public override void ApplicationSignificantTimeChange (UIApplication application)
		{
			CCDirector.SharedDirector.NextDeltaTimeZero=true;
		}
	}

}

