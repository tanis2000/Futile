using UnityEngine;
using System.Collections;

namespace Platformer
{
	public class Block : Entity
	{
		public FSprite sprite;

		public Block () : base()
		{
			sprite = new FSprite("Game/green-16");
		}

		override public void Added(Scene scene)
		{
			base.Added(scene);
			scene.AddChild (sprite);
		}
		
		override public void Removed (Scene scene)
		{
			base.Removed(scene);
			sprite.RemoveFromContainer();
		}

		override public void Update() {
			base.Update();

			sprite.SetPosition(Position);
		}


	}
}