using UnityEngine;
using System;
using System.Collections;

namespace Platformer
{
	public class Engine : Page
	{
		static public Engine Instance { get; private set; }
		//static public Commands Commands { get; private set; }
		static public Pooler Pooler { get; private set; }
		static public int Width { get; private set; }
		static public int Height { get; private set; }
		static public float DeltaTime { get; private set; }
		static public float TimeRate = 1f;
		static public float FreezeTimer;
		static public Color ClearColor;
		static public bool ExitOnEscapeKeypress;

		private Scene scene;
		private Scene nextScene;
		private string windowTitle;
		#if DEBUG
		private TimeSpan counterElapsed = TimeSpan.Zero;
		private int counterFrames = 0;
		#endif

		public Map map;

		public Engine() {
			Instance = this;

			//IsMouseVisible = false;
			//IsFixedTimeStep = false;
			ExitOnEscapeKeypress = true;



			/*
			entityContainer = new EntityContainer();
			AddChild(entityContainer);
			Draw.Initialize(entityContainer);

			map = new Map(50, 20);

			Debug.Log (Core.playerManager.players.Count);
			Hero hero = new Hero(entityContainer);
			hero.SetPosition(1 * Config.GRID, 1 * Config.GRID); 
			hero.AddToContainer();

			FSprite s = new FSprite("Debug/Square");
			AddChild(s);
			s.scale = 0.25f;
			s.SetAnchor(0f, 0f);
			s.SetPosition(0, 0);
			*/
			ListenForUpdate(Update);

		}

		public void Initialize()
		{
			//base.Initialize();

			//UpdateView();
			//MInput.Initialize();
			Tracker.Initialize();
			Pooler = new Pooler();
			//Commands = new Commands();
			Platformer.Draw.Initialize(this);
		}

		protected void Update(/*GameTime gameTime*/)
		{
			//DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds * TimeRate;
			DeltaTime = Time.deltaTime;

			//Update input
			//MInput.Update();

			/*if (ExitOnEscapeKeypress && MInput.Keyboard.Pressed(Microsoft.Xna.Framework.Input.Keys.Escape))
			{
				Exit();
				return;
			}*/

			//Update current scene
			if (FreezeTimer > 0)
				FreezeTimer = Math.Max(FreezeTimer - DeltaTime, 0);
			else if (scene != null)
			{
				scene.BeforeUpdate();
				scene.Update();
				scene.AfterUpdate();
			}

			//Debug Console
			/*if (Commands.Open)
				Commands.UpdateOpen();
			else if (Commands.Enabled)
				Commands.UpdateClosed();*/

			//Changing scenes
			if (scene != nextScene)
			{
				if (scene != null)
					scene.End();
				scene = nextScene;
				OnSceneTransition();
				if (scene != null)
					scene.Begin();
			}

			//base.Update(gameTime);
			Platformer.Draw.SpriteBatch.MoveToFront();

		}

		protected void Draw(/*GameTime gameTime*/)
		{
			RenderCore();

			/*base.Draw(gameTime);
			if (Commands.Open)
				Commands.Render();*/
			#if DEBUG
			//Frame counter
			/*counterFrames++;
			counterElapsed += gameTime.ElapsedGameTime;
			if (counterElapsed > TimeSpan.FromSeconds(1))
			{
				Window.Title = windowTitle + " " + counterFrames.ToString() + " fps - " + (GC.GetTotalMemory(true) / 1048576f).ToString("F") + " MB";
				counterFrames = 0;
				counterElapsed -= TimeSpan.FromSeconds(1);
			}*/
			#endif
		}

		/// <summary>
		/// Override if you want to change the core rendering functionality of Monocle Engine.
		/// By default, this simply sets the render target to null, clears the screen, and renders the current Scene
		/// </summary>
		protected virtual void RenderCore()
		{
			if (scene != null)
				scene.BeforeRender();

			//GraphicsDevice.SetRenderTarget(null);
			//GraphicsDevice.Clear(ClearColor);

			if (scene != null)
			{
				scene.Render();
				scene.AfterRender();
			}
		}

		/// <summary>
		/// Called after a Scene ends, before the next Scene begins
		/// </summary>
		protected virtual void OnSceneTransition()
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		/// <summary>
		/// The currently active Scene. Note that if set, the Scene will not actually change until the end of the Update
		/// </summary>
		static public Scene Scene
		{
			get { return Instance.scene; }
			set { Instance.nextScene = value; }
		}


		/*public void HandleUpdate() {
			//Draw.SpriteBatch.MoveToFront();
			//entityContainer.SetPosition(entityContainer.GetPosition() + new Vector2(-1, 0));
		}*/

	}
}