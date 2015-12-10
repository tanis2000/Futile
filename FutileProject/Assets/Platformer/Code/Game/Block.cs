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
			Collider = new Hitbox(16, 16);
		}

		override public void Added(Scene scene)
		{
			Debug.Log("block added");
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