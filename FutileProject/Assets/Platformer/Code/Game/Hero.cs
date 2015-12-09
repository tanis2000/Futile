using UnityEngine;
using System.Collections;

namespace Platformer
{
	public class Hero : Entity
	{
		public FContainer body;
		public FSprite bodySprite;

		public Hero () : base()
		{
			body = new FContainer ();
			bodySprite = new FSprite ("Game/player");
			body.AddChild (bodySprite);
			/*
			this.components.Add(new InputComponent(true, true));

			this.Collider = new Circle(bodySprite.width/2, xx, yy);
			this.quad = new Quad(this.Collider.Left, this.Collider.Bottom, this.Collider.Right, this.Collider.Top);
			entityContainer.quadTree.Insert(Collider, ref quad);*/
		}
		/*
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
				dy = 0.7f;

			SetPosition(xx, yy);
			body.SetPosition(xx, yy);
			Draw.Circle(Collider.Center, Collider.Width/2, Color.white, 10);
		}
		*/
	}
}