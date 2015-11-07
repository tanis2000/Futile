using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Platformer
{
	public class Map
	{
		public int width;
		public int height;
		public Object[] blocks;

		public Map(int width, int height) 
		{
			this.width = width;
			this.height = height;
			blocks = new Object[width*height]; 
			blocks[0] = new Object();
			blocks[1] = new Object();
			blocks[2] = new Object();
			blocks[3] = new Object();
		}
	}
}