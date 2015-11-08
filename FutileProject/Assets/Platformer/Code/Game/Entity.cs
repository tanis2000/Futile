using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Platformer
{
	public class Entity
	{
		public EntityContainer entityContainer;

		public ComponentList components;

		private Collider collider;
		public Quad quad;

		// Position in grid space
		public int cx;
		public int cy;

		// Position relative to current cell 0..1
		public float xr;
		public float yr;

		// Speed
		public float dx;
		public float dy;

		// Real x and y position in world space
		public float xx;
		public float yy;
		public bool isAdded = false;

		public Entity (EntityContainer entityContainer)
		{
			this.entityContainer = entityContainer;
			this.components = new ComponentList(this);
			cx = 0;
			cy = 0;
			xr = 0.5f;
			yr = 0.5f;
			dx = 0;
			dy = 0;
		}

		public void AddToContainer ()
		{
			HandleAdded ();
		}
		
		public void RemoveFromContainer ()
		{
			HandleRemoved ();
		}
		
		virtual public void HandleAdded ()
		{
			entityContainer.entities.Add (this);
			isAdded = true;
			if (components != null)
				foreach (var c in components)
					c.EntityAdded();
		}
		
		virtual public void HandleRemoved ()
		{
			entityContainer.entities.Remove (this);
			isAdded = false;
			if (components != null)
				foreach (var c in components)
					c.EntityRemoved();
		}
		
		virtual public void Update ()
		{
			components.Update();

			float frictX = 0.92f;
			float frictY = 0.94f;
			float gravity = -0.04f;
			
			// X component
			xr+=dx;
			dx*=frictX;
			if( HasCollision(cx-1,cy) && xr<=0.5f ) {
				dx = 0;
				xr = 0.5f;
			}
			if( HasCollision(cx+1,cy) && xr>=0.5f ) {
				dx = 0;
				xr = 0.5f;
			}
			while( xr<0 ) {
				cx--;
				xr++;
			}
			while( xr>1 ) {
				cx++;
				xr--;
			}
			
			// Y component
			if (this is Block) {
			} else {
				dy+=gravity;
			}
			yr+=dy;
			dy*=frictY;
			if( HasCollision(cx,cy+1) && yr>=0.4f ) {
				dy = 0;
				yr = 0.4f;
			}
			if( HasCollision(cx,cy-1) && yr<=0.5f ) {
				dy  = 0;
				yr = 0.5f;
			}
			
			while( yr<0 ) {
				cy--;
				yr++;
			}
			while( yr>1 ) {
				cy++;
				yr--;
			}

			xx = Mathf.FloorToInt((cx+xr)*Config.GRID);
			yy = Mathf.FloorToInt((cy+yr)*Config.GRID);

			if (collider != null) {
				collider.position.x = xx;
				collider.position.y = yy;
				quad.MinX = this.collider.Left;
				quad.MinY = this.collider.Bottom;
				quad.MaxX = this.collider.Right;
				quad.MaxY = this.collider.Top;
				Debug.Log ("XX: " + xx + ", YY: " + yy + ", CX: " + cx + ", CY: "+cy + ", XR: "+xr+", YR: "+yr+ ", L: " +this.collider.Left + ", B: " + this.collider.Bottom + ", R: " + this.collider.Right + ", T: "+ this.collider.Top);
				Debug.Log ("MinX: "+quad.MinX+", MinY: "+quad.MinY+", MaxX: "+quad.MaxX+", MaxY: "+quad.MaxY);
			}
		}
		
		public void SetPosition (float x, float y)
		{
			xx = x;
			yy = y;
			cx = Mathf.FloorToInt (xx / Config.GRID);
			cy = Mathf.FloorToInt (yy / Config.GRID);
			xr = (xx - cx * Config.GRID) / Config.GRID;
			yr = (yy - cy * Config.GRID) / Config.GRID;
		}
		
		public void SetPosition (Vector2 pos)
		{
			SetPosition(pos.x, pos.y);
		}
		
		public Vector2 GetPosition ()
		{
			return new Vector2 (xx, yy);	
		}

		public bool HasCollision (int cx, int cy)
		{
			if (cx < 0 || cy < 0 || cx >= GamePage.instance.map.width || cy >= GamePage.instance.map.height) {
				return true;
			} else {
				if (GamePage.instance.map.blocks [cy * GamePage.instance.map.width + cx] != null) {
					return true;
				} else {
					return false;
				}
			}
		}
		
		public bool OnGround ()
		{
			return HasCollision (cx, cy - 1) && yr <= 0.5;
		}

		virtual public void HandleCollision(Collider other) {
			Debug.Log("Other: " + other + ", E: " + other.entity);
		}

		public Collider Collider
		{
			get { return collider; }
			set
			{
				if (value == collider)
					return;
				#if DEBUG
				if (value.entity != null)
					Debug.LogError("Setting an Entity's Collider to a Collider already in use by another Entity");
				#endif
				if (collider != null)
					collider.Removed();
				collider = value;
				if (collider != null)
					collider.Added(this);
			}
		}

	}
}