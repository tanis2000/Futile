using UnityEngine;
using System.Collections;

namespace Platformer
{
	public class Block : Entity
	{
		public FSprite sprite;

		public Block (EntityContainer entityContainer) : base(entityContainer)
		{
			sprite = new FSprite("Game/green-16");
		}

		override public void HandleAdded ()
		{
			base.HandleAdded ();
			entityContainer.AddChild (sprite);
		}
		
		override public void HandleRemoved ()
		{
			base.HandleRemoved ();
			sprite.RemoveFromContainer ();
		}

		override public void Update() {
			base.Update();

			sprite.SetPosition(xx, yy);
		}


	}
}