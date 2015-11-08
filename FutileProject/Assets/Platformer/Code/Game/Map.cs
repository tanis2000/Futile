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
				Block b = new Block(GamePage.instance.entityContainer);
				b.SetPosition(i * Config.GRID + Config.GRID/2, Config.GRID/2);
				blocks[i] = b;
				b.AddToContainer();
			}

			for (int i = 2 ; i < 10 ; i++) {
				Block b = new Block(GamePage.instance.entityContainer);
				b.SetPosition(i * Config.GRID + Config.GRID/2, 3*Config.GRID+Config.GRID/2);
				blocks[3*width+i] = b;
				b.AddToContainer();
			}

			Heart h = new Heart(GamePage.instance.entityContainer);
			h.SetPosition(4*Config.GRID, 2 * Config.GRID);
			h.AddToContainer();

		}
	}
}