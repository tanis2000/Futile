using System;
using UnityEngine;

namespace Platformer
{
	public class GraphicsComponent : Component
	{
		public Vector2 Position;
		public Vector2 Origin;
		public Vector2 Scale = Vector2.one;
		public float Zoom = 1.0f;
		public float Rotation;
		public Color Color = Color.white;

		public GraphicsComponent (bool active) : base(active, true)
		{
		}

		public float X
		{
			get { return Position.x; }
			set { Position.x = value; }
		}

		public float Y
		{
			get { return Position.y; }
			set { Position.y = value; }
		}

		/*
		public bool FlipX
		{
			get
			{
				return (Effects & SpriteEffects.FlipHorizontally) == SpriteEffects.FlipHorizontally;
			}

			set
			{
				Effects = value ? (Effects | SpriteEffects.FlipHorizontally) : (Effects & ~SpriteEffects.FlipHorizontally);
			}
		}

		public bool FlipY
		{
			get
			{
				return (Effects & SpriteEffects.FlipVertically) == SpriteEffects.FlipVertically;
			}

			set
			{
				Effects = value ? (Effects | SpriteEffects.FlipVertically) : (Effects & ~SpriteEffects.FlipVertically);
			}
		}*/

		public Vector2 RenderPosition
		{
			get
			{
				return (Entity == null ? Vector2.zero : Entity.Position) + Position;
			}
		}

		public void DrawOutline(int offset = 1)
		{
			DrawOutline(Color.black, offset);
		}

		public void DrawOutline(Color color, int offset = 1)
		{
			Vector2 pos = Position;
			Color was = Color;
			Color = color;

			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					if (i != 0 || j != 0)
					{
						Position = pos + new Vector2(i * offset, j * offset);
						Render();
					}
				}
			}

			Position = pos;
			Color = was;
		}

	}
}

