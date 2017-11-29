using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;
using XNodeEditor;

namespace DialogueEditor {
	[CustomNodeGraphEditor(typeof(DialogueGraph))]
	public class DialogueGraphEditor : NodeGraphEditor {
		
		public override string GetNodePath(System.Type type) {
			if (type.Namespace != "Dialogue") return null;
			else return base.GetNodePath(type).Replace("Dialogue/","");
		}
	}
}