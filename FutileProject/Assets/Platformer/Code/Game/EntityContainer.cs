using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Platformer
{
	public class EntityContainer : FContainer
	{
		public List<Entity> entities;

		public EntityContainer ()
		{
			entities = new List<Entity> ();

			ListenForUpdate(HandleUpdate);
		}

		void HandleUpdate()
		{
			int entityCount = entities.Count;
			
			for(int e = entityCount-1; e>=0; e--)//reverse order so removals ain't no thang
			{
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
