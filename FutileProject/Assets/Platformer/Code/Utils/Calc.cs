using UnityEngine;
using System.Collections;

namespace Platformer {
public static class Calc {

		public static Vector2 AngleToVector(float angleRadians, float length) {
			return new Vector2((float)Mathf.Cos(angleRadians) * length,
				(float)Mathf.Sin(angleRadians) * length);
		}
}

}