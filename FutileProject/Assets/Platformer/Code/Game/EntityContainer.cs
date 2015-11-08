using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Platformer
{
	public class EntityContainer : FContainer
	{
		public List<Entity> entities;

		public QuadTree<Collider> quadTree;

		public EntityContainer ()
		{
			entities = new List<Entity> ();
			quadTree = new QuadTree<Collider>(50, -100, -100, 50 * Config.GRID, 20 * Config.GRID);

			ListenForUpdate(HandleUpdate);
		}

		void HandleUpdate()
		{
			int entityCount = entities.Count;

			quadTree.Clear();
			for(int e = entityCount-1; e>=0; e--)//reverse order so removals ain't no thang
			{
				if (entities[e].Collider != null) {
					quadTree.Insert(entities[e].Collider, entities[e].quad);
				}
			}

			for(int e = entityCount-1; e>=0; e--)//reverse order so removals ain't no thang
			{
				if (entities[e].Collider != null) {
					List<Collider> collisions = new List<Collider>();
					quadTree.FindCollisions(entities[e].Collider, ref collisions);
					for (int c = collisions.Count-1 ; c>=0; c--) {
						entities[e].HandleCollision(collisions[c]);
					}
				}
				entities[e].Update();
			}

			/*if(Time.frameCount % 10 == 0)//don't bother updating them every single frame
			{
				if(debugSprites.Count > 0)
				{
					for(int d = 0; d<debugSprites.Count; d++)
					{
						debugSprites[d].RemoveFromContainer();
					}
					debugSprites.Clear();
				}
				
				if(Config.SHOULD_DEBUG_BLOCKING_RECTS)
				{
					for(int r = 0; r<blockingRects.Count; r++)
					{
						debugSprites.Add(CreateDebugSprite(blockingRects[r],Color.red));
					}
				}
			}*/
		}

	}
}
