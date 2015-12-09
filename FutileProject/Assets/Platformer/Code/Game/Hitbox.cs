using UnityEngine;
using System;

namespace Platformer
{
	public class Hitbox : Collider
	{
		private float width;
		private float height;

		public Hitbox(float width, float height, float x = 0, float y = 0)
		{
			this.width = width;
			this.height = height;

			Position.x = x;
			Position.y = y;
		}

		public void CenterOrigin()
		{
			Position.x = -Width / 2;
			Position.y = -Height / 2;
		}

		public override float Width
		{
			get { return width; }
			set { width = value; }
		}

		public override float Height
		{
			get { return height; }
			set { height = value; }
		}

		public override float Left
		{
			get { return Position.x; }
			set { Position.x = value; }
		}

		public override float Top
		{
			get { return Position.y; }
			set { Position.y = value; }
		}

		public override float Right
		{
			get { return Position.x + Width; }
			set { Position.x = value - Width; }
		}

		public override float Bottom
		{
			get { return Position.y + Height; }
			set { Position.y = value - Height; }
		}

		public bool Intersects(Hitbox hitbox)
		{
			return AbsoluteLeft < hitbox.AbsoluteRight && AbsoluteRight > hitbox.AbsoluteLeft && AbsoluteBottom > hitbox.AbsoluteTop && AbsoluteTop < hitbox.AbsoluteBottom;
		}

		public bool Intersects(float x, float y, float width, float height)
		{
			return AbsoluteRight > x && AbsoluteBottom > y && AbsoluteLeft < x + width && AbsoluteTop < y + height;
		}

		public override Collider Clone()
		{
			return new Hitbox(width, height, Position.x, Position.y);
		}

		public override void Render(Color color)
		{
			Draw.HollowRect(AbsoluteX, AbsoluteY, Width, Height, color);
		}

		public void SetFromRectangle(Rect rect)
		{
			Position = new Vector2(rect.x, rect.y);
			Width = rect.width;
			Height = rect.height;
		}

		/*
         *  Get edges
         */

		public void GetTopEdge(out Vector2 from, out Vector2 to)
		{
			from.x = AbsoluteLeft;
			to.x = AbsoluteRight;
			from.y = to.y = AbsoluteTop;
		}

		public void GetBottomEdge(out Vector2 from, out Vector2 to)
		{
			from.x = AbsoluteLeft;
			to.x = AbsoluteRight;
			from.y = to.y = AbsoluteBottom;
		}

		public void GetLeftEdge(out Vector2 from, out Vector2 to)
		{
			from.y = AbsoluteTop;
			to.y = AbsoluteBottom;
			from.x = to.x = AbsoluteLeft;
		}

		public void GetRightEdge(out Vector2 from, out Vector2 to)
		{
			from.y = AbsoluteTop;
			to.y = AbsoluteBottom;
			from.x = to.x = AbsoluteRight;
		}

		/*
         *  Checking against other colliders
         */

		public override bool Collide(Vector2 point)
		{
			return Platformer.Collide.RectToPoint(AbsoluteLeft, AbsoluteTop, Width, Height, point);
		}

		public override bool Collide(Rect rect)
		{
			return AbsoluteRight > rect.left && AbsoluteBottom > rect.top && AbsoluteLeft < rect.right && AbsoluteTop < rect.bottom;
		}

		public override bool Collide(Vector2 from, Vector2 to)
		{
			return Platformer.Collide.RectToLine(AbsoluteLeft, AbsoluteTop, Width, Height, from, to);
		}

		public override bool Collide(Hitbox hitbox)
		{
			return Intersects(hitbox);
		}

		public override bool Collide(Grid grid)
		{
			return grid.Collide(Bounds);
		}

		public override bool Collide(Circle circle)
		{
			return Platformer.Collide.RectToCircle(AbsoluteLeft, AbsoluteTop, Width, Height, circle.AbsolutePosition, circle.Radius);
		}

		public override bool Collide(ColliderList list)
		{
			return list.Collide(this);
		}
	}
}
