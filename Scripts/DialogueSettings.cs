using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dialogue {
    [System.Serializable]
    public struct DialogueSettings {

        [SerializeField] public Item[] items;

        public int IndexOf(string key) {
            for (int i = 0; i < items.Length; i++) {
                if (items[i].key == key) return i;
            }
            return -1;
        }

        public bool Contains(string key) {
            return IndexOf(key) != -1;
        }

        [System.Serializable] public struct Item : ISerializationCallbackReceiver {
            public string key;
            public ByteValue value;

            void ISerializationCallbackReceiver.OnAfterDeserialize() { }

            void ISerializationCallbackReceiver.OnBeforeSerialize() {
                key = key.ToUpper().Replace(' ', '_').Trim('_');
            }
        }

    }
}