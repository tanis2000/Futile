using UnityEngine;
using System;

namespace Platformer
{
	public class Circle : Collider
	{
		public float Radius;
		
		public Circle(float radius, float x = 0, float y = 0)
		{
			Radius = radius;
			Position.x = x;
			Position.y = y;
		}
		
		public override float Width
		{
			get { return Radius * 2; }
			set { Radius = value / 2; }
		}
		
		public override float Height
		{
			get { return Radius * 2; }
			set { Radius = value / 2; }
		}
		
		public override float Left
		{
			get { return Position.x - Radius; }
			set { Position.x = value + Radius; }
		}
		
		public override float Top
		{
			get { return Position.y + Radius; }
			set { Position.y = value - Radius; }
		}
		
		public override float Right
		{
			get { return Position.x + Radius; }
			set { Position.x = value - Radius; }
		}
		
		public override float Bottom
		{
			get { return Position.y - Radius; }
			set { Position.y = value + Radius; }
		}
		
		public override Collider Clone()
		{
			return new Circle(Radius, Position.x, Position.y);
		}
		
		public override void Render(Color color)
		{
			Platformer.Draw.Circle(AbsolutePosition, Radius, color, 4);
		}
		
		/*
         *  Checking against other colliders
         */
		
		public override bool Collide(Vector2 point)
		{
			return Platformer.Collide.CircleToPoint(AbsolutePosition, Radius, point);
		}
		
		public override bool Collide(Rect rect)
		{
			return Platformer.Collide.RectToCircle(rect, AbsolutePosition, Radius);
		}
		
		public override bool Collide(Vector2 from, Vector2 to)
		{
			return Platformer.Collide.CircleToLine(AbsolutePosition, Radius, from, to);
		}
		
		public override bool Collide(Circle circle)
		{
			return Vector2.Distance(AbsolutePosition, circle.AbsolutePosition) < (Radius + circle.Radius);
		}
		
		public override bool Collide(Hitbox hitbox)
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
		}
		
	}
}
