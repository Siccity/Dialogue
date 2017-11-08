using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue {
    public class DialogueBranch : Node {

        [Input] public DialogueNode.Connection input;
        public Condition[] condition;
        [Output] public DialogueNode.Connection pass;
        [Output] public DialogueNode.Connection fail;

        [System.Serializable]
        public struct Condition {
            public enum CompareMethod { Less, Equal, Greater }
            public string key;
            public ByteValue value;
            public CompareMethod compareMethod;

            //Returns true if condition is met for settings
            public bool IsMet(DialogueSettings settings) {
                int i = settings.IndexOf(key);
                if (i != -1) {
                    DialogueSettings.Item item = settings.items[i];
                    switch (item.value.valueType) {
                        case ByteValue.ValueType.Bool:
                            bool b1 = item.value.boolValue;
                            bool b2 = value.boolValue;
                            return (b1 == b2);
                        case ByteValue.ValueType.Float:
                            float f1 = item.value.floatValue;
                            float f2 = value.floatValue;
                            switch (compareMethod) {
                                case CompareMethod.Less:
                                    return (f1 < f2);
                                case CompareMethod.Greater:
                                    return (f1 > f2);
                                default:
                                    return (f1 == f2);
                            }
                        case ByteValue.ValueType.Int:
                            int i1 = item.value.intValue;
                            int i2 = value.intValue;
                            switch (compareMethod) {
                                case CompareMethod.Less:
                                    return (i1 < i2);
                                case CompareMethod.Greater:
                                    return (i1 > i2);
                                default:
                                    return (i1 == i2);
                            }
                    }
                }
                return false;
            }
        }
    }
}