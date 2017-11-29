using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using UnityEngine.Events;
namespace Dialogue {
	[NodeTint("#FFFFAA")]
	public class Event : DialogueBaseNode {
		[Input] public Connection input;
		public UnityEvent trigger;

		public override void Trigger() {
			trigger.Invoke();
		}
	}
}