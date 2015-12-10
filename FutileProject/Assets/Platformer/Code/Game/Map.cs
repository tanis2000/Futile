using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Platformer
{
	public class Map
	{
		public int width;
		public int height;
		public Block[] blocks;

		public Map(int width, int height) 
		{
			this.width = width;
			this.height = height;
			blocks = new Block[width*height];

			for (int i = 0 ; i < 10 ; i++) {
				Block b = new Block();
				b.Position = new Vector2(i * Config.GRID + Config.GRID/2, Config.GRID/2);
				blocks[i] = b;
				Engine.Scene.Add(b);
			}

			for (int i = 2 ; i < 10 ; i++) {
				Block b = new Block();
				b.Position = new Vector2(i * Config.GRID + Config.GRID/2, 3*Config.GRID+Config.GRID/2);
				blocks[3*width+i] = b;
				Engine.Scene.Add(b);
			}

			Heart h = new Heart();
			h.Position.x = 4*Config.GRID;
			h.Position.y = 2 * Config.GRID;
			Engine.Scene.Add(h);

		}
	}
}