using System;

namespace Dialogue {
    [Serializable] public struct ByteValue {
        public enum ValueType { Bool, Float, Int }
        public ValueType valueType;
        public byte[] bytes;

        public ByteValue(byte[] bytes, ValueType valueType) {
            this.bytes = bytes;
            this.valueType = valueType;
        }
        
		public bool boolValue {
            get { return (bytes != null && bytes.Length == 1) ? BitConverter.ToBoolean(bytes, 0) : false; }
            set { bytes = BitConverter.GetBytes(value); }
        }

		public float floatValue {
            get { return (bytes != null && bytes.Length == 4) ? BitConverter.ToSingle(bytes, 0) : 0f; }
            set { bytes = BitConverter.GetBytes(value); }
        }

        public int intValue {
            get { return (bytes != null && bytes.Length == 4) ? BitConverter.ToInt32(bytes, 0) : 0; }
            set { bytes = BitConverter.GetBytes(value); }
        }
    }
}