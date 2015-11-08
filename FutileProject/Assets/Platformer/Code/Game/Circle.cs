using UnityEngine;
using System;

namespace Platformer
{
	public class Circle : Collider
	{
		public float radius;
		
		public Circle(float radius, float x = 0, float y = 0)
		{
			this.radius = radius;
			position.x = x;
			position.y = y;
		}
		
		public override float Width
		{
			get { return radius * 2; }
			set { radius = value / 2; }
		}
		
		public override float Height
		{
			get { return radius * 2; }
			set { radius = value / 2; }
		}
		
		public override float Left
		{
			get { return position.x - radius; }
			set { position.x = value + radius; }
		}
		
		public override float Top
		{
			get { return position.y + radius; }
			set { position.y = value - radius; }
		}
		
		public override float Right
		{
			get { return position.x + radius; }
			set { position.x = value - radius; }
		}
		
		public override float Bottom
		{
			get { return position.y - radius; }
			set { position.y = value + radius; }
		}
		
		public override Collider Clone()
		{
			return new Circle(radius, position.x, position.y);
		}
		
		/*public override void Render(Color color)
		{
			Draw.Circle(AbsolutePosition, Radius, color, 4);
		}*/
		
		/*
         *  Checking against other colliders
         */
		
		/*public override bool Collide(Vector2 point)
		{
			return Monocle.Collide.CircleToPoint(AbsolutePosition, Radius, point);
		}
		
		public override bool Collide(Rectangle rect)
		{
			return Monocle.Collide.RectToCircle(rect, AbsolutePosition, Radius);
		}
		
		public override bool Collide(Vector2 from, Vector2 to)
		{
			return Monocle.Collide.CircleToLine(AbsolutePosition, Radius, from, to);
		}*/
		
		public override bool Collide(Circle circle)
		{
			return Vector2.Distance(AbsolutePosition, circle.AbsolutePosition) < (radius + circle.radius);
		}
		
		/*public override bool Collide(Hitbox hitbox)
		{
			return hitbox.Collide(this);
		}
		
		public override bool Collide(Grid grid)
		{
			return grid.Collide(this);
		}
		
		public override bool Collide(ColliderList list)
		{
			return list.Collide(this);
		}*/
		
	}
}
