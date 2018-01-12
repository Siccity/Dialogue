using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
namespace Dialogue {
	[NodeTint("#FFFFAA")]
	public class Event : DialogueBaseNode {
		[Input] public Connection input;
		
		public SerializableEvent[] trigger; // Could use UnityEvent here, but UnityEvent has a bug that prevents it from serializing correctly on custom EditorWindows. So i implemented my own.

		public override void Trigger() {
			for (int i = 0; i < trigger.Length; i++) {
				trigger[i].Invoke();
			}
		}
	}
}