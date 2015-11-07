using UnityEngine;
using System.Collections;

namespace Platformer
{
	public class Component
	{
		public Entity entity;
		public bool active;
		public bool visible;

		public Component(bool active, bool visible)
		{
			this.active = active;
			this.visible = visible;
		}

		public virtual void Added(Entity entity)
		{
			this.entity = entity;
		}
		
		public virtual void Removed(Entity entity)
		{
			this.entity = null;
		}
		
		public virtual void EntityAdded()
		{
		}
		
		public virtual void EntityRemoved()
		{
		}

		virtual public void Update ()
		{
		}
	}
}