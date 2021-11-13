using UnityEngine;
using XNode;


namespace DialogSystem.Base
{
	public class BaseNode : Node {

		public virtual string GetString() {
			return null;
		}

		public virtual Sprite GetSprite() {
			return null;
		}
	}
}