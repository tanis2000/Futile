using UnityEngine;
using System.Collections;

namespace Platformer
{
	public class Hero : Entity
	{
		public FContainer body;
		public FSprite bodySprite;

		public Hero (EntityContainer entityContainer) : base(entityContainer)
		{
			body = new FContainer ();
			bodySprite = new FSprite ("Game/player");
			body.AddChild (bodySprite);

			this.components.Add(new InputComponent(true, true));
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

		override public void Update() {
			base.Update();

			InputComponent ic = components.Get<InputComponent>();
			float speed = 0.04f;
			
			if(ic.leftPressed)
				dx -= speed;
			
			if( ic.rightPressed )
				dx += speed;
			
			if( ic.jumpPressed && OnGround() )
				dy = 0.5f;

			body.SetPosition(xx, yy);
		}
	}
}