using UnityEngine;
using System;


namespace Platformer
{
	public class GravityComponent : Component
	{
		public float gravity = -9.8f;
		public GravityComponent () : base(true, false)
		{
		}

		public override void Update ()
		{
			base.Update ();
			Entity.Position.y += gravity * Time.deltaTime;
		}
	}
}

