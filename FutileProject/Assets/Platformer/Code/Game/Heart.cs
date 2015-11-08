using UnityEngine;
using System.Collections;

namespace Platformer
{
	public class Heart : Entity
	{
		public FContainer body;
		public FSprite bodySprite;
		
		public Heart (EntityContainer entityContainer) : base(entityContainer)
		{
			body = new FContainer ();
			bodySprite = new FSprite ("Game/heart");
			body.AddChild (bodySprite);
			
			this.Collider = new Circle (bodySprite.width / 2, xx, yy);
			this.quad = new Quad(this.Collider.Left, this.Collider.Bottom, this.Collider.Right, this.Collider.Top);
			entityContainer.quadTree.Insert(Collider, ref quad);
		}
		
		override public void HandleAdded ()
		{
			base.HandleAdded ();
			entityContainer.AddChild (body);
		}
		
		override public void HandleRemoved ()
		{
			base.HandleRemoved ();
			body.RemoveFromContainer ();
		}
		
		override public void Update ()
		{
			base.Update ();

			body.SetPosition (xx, yy);
		}

	}
}