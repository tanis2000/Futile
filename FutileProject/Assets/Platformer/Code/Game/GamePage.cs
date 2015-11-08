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

			FSprite s = new FSprite("Debug/Square");
			AddChild(s);
			s.scale = 0.25f;
			s.SetAnchor(0f, 0f);
			s.SetPosition(0, 0);

			ListenForUpdate(HandleUpdate);
		}

		public void HandleUpdate() {
			SetPosition(GetPosition() + new Vector2(-1, 0));
		}

	}
}