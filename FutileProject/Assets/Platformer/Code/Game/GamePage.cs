using UnityEngine;
using System.Collections;

namespace Platformer
{
	public class GamePage : Page
	{
		public static GamePage instance;

		public EntityContainer entityContainer;

		public Map map;

		public GamePage() {
			instance = this;
			entityContainer = new EntityContainer();
			AddChild(entityContainer);

			map = new Map(50, 20);

			Debug.Log (Core.playerManager.players.Count);
			Hero hero = new Hero(entityContainer);
			hero.SetPosition(1 * Config.GRID, 1 * Config.GRID); 
			hero.AddToContainer();
		}

	}
}