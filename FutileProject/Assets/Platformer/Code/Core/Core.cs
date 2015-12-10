using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;

namespace Platformer
{
	public class Core : FContainer
	{
		public static Core instance;
		public static PlayerManager playerManager;
		public static AudioManager audioManager;
		public static EffectManager topEffectManager;
		public FContainer pageContainer;
		public Page currentPage;
	
		public Core ()
		{
			instance = this;
		
			AddChild (pageContainer = new FContainer ());
			AddChild (topEffectManager = new EffectManager (true));
		
			audioManager = new AudioManager ();
			FXPlayer.manager = audioManager.fxManager;
			MusicPlayer.manager = audioManager.musicManager;
			FXPlayer.Preload ();
		
			playerManager = new PlayerManager ();
		
			playerManager.Setup ();
		
			Engine engine = new Engine();
			engine.Initialize();
			ShowPage (engine);
			Engine.Scene = new MainScene(); 
		
			ListenForUpdate (Update);
		}
	
		public void StartGame ()
		{
			ShowPage (new Engine ());
		}
	
		public void ShowPage (Page page)
		{
			if (currentPage != null) {
				currentPage.Destroy ();
				currentPage.RemoveFromContainer ();
				currentPage = null;
			}
		
			currentPage = page;
			AddChild (currentPage);
			currentPage.Start ();
		}
	
		void Update ()
		{
			Draw.Clear();
			MusicPlayer.Update ();
			audioManager.Update ();
			playerManager.Update ();
		
		
			if (Input.GetKeyDown (KeyCode.R)) {
				Restart (); 
			}
		}
	
		public void Restart ()
		{
			ShowPage (new Engine ());
		}
	
		public void HandleApplicationPause ()
		{
			audioManager.HandleApplicationPause ();
		}
	
		public void HandleApplicationResume ()
		{
			audioManager.HandleApplicationResume ();
		}
	}







}













