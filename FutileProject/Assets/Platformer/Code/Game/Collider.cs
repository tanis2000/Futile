﻿using UnityEngine;
using System;

namespace Platformer
{
	public abstract class Collider
	{
		public Entity entity { get; private set; }

		public Vector2 position;
		
		internal virtual void Added (Entity entity)
		{
			this.entity = entity;
		}
		
		internal virtual void Removed ()
		{
			this.entity = null;
		}
		
		public bool Collide (Entity entity)
		{
			return Collide (entity.Collider);
		}
		
		public bool Collide (Collider collider)
		{
			/*if (collider is Hitbox)
			{
				return Collide(collider as Hitbox);
			}
			else if (collider is Grid)
			{
				return Collide(collider as Grid);
			}
			else if (collider is ColliderList)
			{
				return Collide(collider as ColliderList);
			}
			else*/
			if (collider is Circle) {
				return Collide (collider as Circle);
			} else
				throw new Exception ("Collisions against the collider type are not implemented!");
		}
		
		//public abstract bool Collide(Vector2 point);
		//public abstract bool Collide(Rectangle rect);
		//public abstract bool Collide(Vector2 from, Vector2 to);
		//public abstract bool Collide(Hitbox hitbox);
		//public abstract bool Collide(Grid grid);
		public abstract bool Collide (Circle circle);
		//public abstract bool Collide(ColliderList list);
		public abstract Collider Clone ();
		//public abstract void Render(Color color);
		public abstract float Width { get; set; }

		public abstract float Height { get; set; }

		public abstract float Top { get; set; }

		public abstract float Bottom { get; set; }

		public abstract float Left { get; set; }

		public abstract float Right { get; set; }
		
		public float CenterX {
			get {
				return Left + Width / 2f;
			}
			
			set {
				Left = value - Width / 2f;
			}
		}
		
		public float CenterY {
			get {
				return Top + Height / 2f;
			}
			
			set {
				Top = value - Height / 2f;
			}
		}
		
		public Vector2 TopLeft {
			get {
				return new Vector2 (Left, Top);
			}
			
			set {
				Left = value.x;
				Top = value.y;
			}
		}
		
		public Vector2 TopCenter {
			get {
				return new Vector2 (CenterX, Top);
			}
			
			set {
				CenterX = value.x;
				Top = value.y;
			}
		}
		
		public Vector2 TopRight {
			get {
				return new Vector2 (Right, Top);
			}
			
			set {
				Right = value.x;
				Top = value.y;
			}
		}
		
		public Vector2 CenterLeft {
			get {
				return new Vector2 (Left, CenterY);
			}
			
			set {
				Left = value.x;
				CenterY = value.y;
			}
		}
		
		public Vector2 Center {
			get {
				return new Vector2 (CenterX, CenterY);
			}
			
			set {
				CenterX = value.x;
				CenterY = value.y;
			}
		}
		
		public Vector2 CenterRight {
			get {
				return new Vector2 (Right, CenterY);
			}
			
			set {
				Right = value.x;
				CenterY = value.y;
			}
		}
		
		public Vector2 BottomLeft {
			get {
				return new Vector2 (Left, Bottom);
			}
			
			set {
				Left = value.x;
				Bottom = value.y;
			}
		}
		
		public Vector2 BottomCenter {
			get {
				return new Vector2 (CenterX, Bottom);
			}
			
			set {
				CenterX = value.x;
				Bottom = value.y;
			}
		}
		
		public Vector2 BottomRight {
			get {
				return new Vector2 (Right, Bottom);
			}
			
			set {
				Right = value.x;
				Bottom = value.y;
			}
		}
		
		/*public void Render()
		{
			Render(Color.Red);
		}*/
		
		public Vector2 AbsolutePosition {
			get {
				if (entity != null)
					return entity.GetPosition () + position;
				else
					return position;
			}
		}
		
		public float AbsoluteX {
			get {
				if (entity != null)
					return entity.GetPosition ().x + position.x;
				else
					return position.x;
			}
		}
		
		public float AbsoluteY {
			get {
				if (entity != null)
					return entity.GetPosition ().y + position.y;
				else
					return position.y;
			}
		}
		
		public float AbsoluteTop {
			get {
				if (entity != null)
					return Top + entity.GetPosition ().y;
				else
					return Top;
			}
		}
		
		public float AbsoluteBottom {
			get {
				if (entity != null)
					return Bottom + entity.GetPosition ().y;
				else
					return Bottom;
			}
		}
		
		public float AbsoluteLeft {
			get {
				if (entity != null)
					return Left + entity.GetPosition ().x;
				else
					return Left;
			}
		}
		
		public float AbsoluteRight {
			get {
				if (entity != null)
					return Right + entity.GetPosition ().x;
				else
					return Right;
			}
		}
		
		public Rect Bounds {
			get {
				return new Rect ((int)AbsoluteLeft, (int)AbsoluteTop, (int)Width, (int)Height);
			}
		}
	}
}