using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    public class DialogueNode : Node {
        [Input] public Connection input;
        [Output] public Connection output;
        [TextArea] public string text;
        public List<Answer> answers = new List<Answer>();

        [System.Serializable] public class Answer {
            [TextArea] public string text;
            public string portName;
        }
        [System.Serializable] public class Connection { }
    }
}