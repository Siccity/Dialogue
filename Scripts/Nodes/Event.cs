using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using UnityEngine.Events;
namespace Dialogue {
	[NodeTint("#FFFFAA")]
	public class Event : DialogueBaseNode {
		[Input] public Connection input;
		public Function trigger;

		public override void Trigger() {
			trigger.Invoke();
		}
	}
}