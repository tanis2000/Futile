using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Platformer
{
	public class Main : MonoBehaviour
	{	
		public static Main instance;
		public Core core;
	
		private void Start ()
		{
			instance = this; 
		
			Go.defaultEaseType = GoEaseType.Linear;
			Go.duplicatePropertyRule = GoDuplicatePropertyRuleType.RemoveRunningProperty;
		
			//Time.timeScale = 0.1f;
		
			bool isIPad = SystemInfo.deviceModel.Contains ("iPad");
		
			bool shouldSupportPortraitUpsideDown = isIPad; //only support portrait upside-down on iPad
		
			FutileParams fparams = new FutileParams (true, true, false, shouldSupportPortraitUpsideDown);
		
			fparams.backgroundColor = RXUtils.GetColorFromHex (0x111111);
			fparams.shouldLerpToNearestResolutionLevel = false;
			fparams.resolutionLevelPickMode = FResolutionLevelPickMode.Downwards;
		
			fparams.AddResolutionLevel (320.0f, 1.0f, 1.0f, "");
			fparams.AddResolutionLevel (640.0f, 2.0f, 1.0f, "");
			fparams.AddResolutionLevel (960.0f, 3.0f, 1.0f, "");
			fparams.AddResolutionLevel (1280.0f, 4.0f, 1.0f, "");
		
			fparams.origin = new Vector2 (0.5f, 0.5f);
		
			Futile.instance.Init (fparams);
		
			FFacetType.Quad.maxEmptyAmount = 100;
			FFacetType.Quad.expansionAmount = 100;
			FFacetType.Quad.initialAmount = 100;
		
			FAtlas mainAtlas = Futile.atlasManager.LoadAtlas ("Atlases/MainAtlas");
			mainAtlas.texture.filterMode = FilterMode.Point;
		
			Fonts.Load ();
		
			Config.Setup ();
		
			//Wolf.WolfAnimation.SetupAnimations ();
			//Human.HumanAnimation.SetupAnimations ();
		
			core = new Core ();
			Futile.stage.AddChild (core);
		
			Futile.screen.SignalResize += HandleSignalResize;
			HandleSignalResize (false);
		}
	
		void HandleSignalResize (bool wasResizedDueToOrientationChange)
		{
			Futile.stage.scale = Mathf.Ceil (Futile.screen.width / Config.WIDTH);
		}
	
		public void Update ()
		{
			if (Input.GetKeyDown (KeyCode.F)) {
				Screen.fullScreen = !Screen.fullScreen;
			}
		}
	
		void OnApplicationQuit ()
		{
		
		}
	
		void OnApplicationPause (bool isPaused)
		{
			if (isPaused && Core.instance != null) {
				Core.instance.HandleApplicationPause ();
			} else if (!isPaused && Core.instance != null) {
				Core.instance.HandleApplicationResume ();
			}
		}
	
	}
}









