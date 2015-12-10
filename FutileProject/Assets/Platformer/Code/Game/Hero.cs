using UnityEngine;
using System.Collections;

namespace Platformer
{
	public class Hero : Entity
	{
		public FContainer body;
		public FSprite bodySprite;

		float vx = 0;
		float vy = 0;

		public Hero () : base()
		{
			body = new FContainer ();
			Engine.Scene.AddChild(body);
			bodySprite = new FSprite ("Game/player");
			body.AddChild (bodySprite);

			Add(new InputComponent(true, true));
			Add(new GravityComponent());
			this.Collider = new Circle(bodySprite.width/2, CenterX, CenterY);
			this.quad = new Quad(this.Collider.Left, this.Collider.Bottom, this.Collider.Right, this.Collider.Top);
			Engine.Scene.quadTree.Insert(Collider, ref quad);
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
		}*/

		override public void Update() {
			base.Update();

			InputComponent ic = Components.Get<InputComponent>();
			float speed = 0.04f;
			
			if(ic.leftPressed)
				vx -= speed;
			
			if( ic.rightPressed )
				vx += speed;
			
			if( ic.jumpPressed /*&& OnGround()*/ )
				vy = 0.7f;

			Position.x += vx;
			Position.y += vy;
			body.SetPosition(Position);
			Draw.Circle(Collider.AbsolutePosition, Collider.Width/2, Color.white, 10);
		}

	}
}