using UnityEngine;
using System;

namespace Platformer
{
	public class MainScene : Scene
	{
		bool initialized = false;

		public MainScene () : base()
		{
			Debug.Log("MainScene");
		}

		public override void Update ()
		{
			base.Update ();
			if (Engine.Scene != null && !initialized) {
				Map map = new Map(50, 20);

				Debug.Log (Core.playerManager.players.Count);
				Hero hero = new Hero();
				hero.Position.x = 1 * Config.GRID;
				hero.Position.y = 1 * Config.GRID; 
				Engine.Scene.Add(hero);

				initialized = true;
			}
		}
	}
}

