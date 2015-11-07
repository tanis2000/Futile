using UnityEngine;
using System.Collections;

namespace Platformer
{
	public class InputComponent : Component
	{
		public bool firePressed;
		public bool leftPressed;
		public bool rightPressed;
		public bool jumpPressed;
		public bool jumpPressedPrev;

		public InputComponent (bool active, bool visible) : base(active, visible)
		{
		}

		override public void Update ()
		{
			base.Update();

			jumpPressedPrev = jumpPressed;
				
			if (Input.GetKeyDown (KeyCode.Space)) {
				firePressed = true;
			} else {
				firePressed = false;
			}
				
			if (Input.GetKey (KeyCode.LeftArrow)) {
				leftPressed = true;
			} else {
				leftPressed = false;
			}
				
			if (Input.GetKey (KeyCode.RightArrow)) {
				rightPressed = true;
			} else {
				rightPressed = false;
			}
				
			if (Input.GetKey (KeyCode.UpArrow)) {
				jumpPressed = true;
			} else {
				jumpPressed = false;
			}
		}
	}
}
