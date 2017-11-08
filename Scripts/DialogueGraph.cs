using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    [CreateAssetMenu(menuName = "Dialogue", fileName = "NewDialogue")]
    public class DialogueGraph : NodeGraph {
		[HideInInspector] public DialogueNode current;
		public DialogueSettings settings;
    }
}