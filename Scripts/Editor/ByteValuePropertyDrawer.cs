using System;
using Dialogue;
using UnityEditor;
using UnityEngine;

namespace DialogueEditor {
    [CustomPropertyDrawer(typeof(ByteValue))]
    public class ByteValuePropertyDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            SerializedProperty bytesProperty = property.FindPropertyRelative("bytes");
            SerializedProperty valueTypeProperty = property.FindPropertyRelative("valueType");
            ByteValue.ValueType valType = (ByteValue.ValueType) valueTypeProperty.enumValueIndex;
            //Get bytes
            byte[] bytes = new byte[bytesProperty.arraySize];
            for (int i = 0; i < bytes.Length; i++) {
                bytes[i] = (byte) bytesProperty.GetArrayElementAtIndex(i).intValue;
            }

            EditorGUI.BeginChangeCheck();
            //Modify bytes
            bytes = MultiValuePropertyField(position, bytes, valType);

            if (EditorGUI.EndChangeCheck()) {
                //Set bytes
                bytesProperty.ClearArray();
                for (int i = 0; i < bytes.Length; i++) {
                    bytesProperty.InsertArrayElementAtIndex(i);
                    bytesProperty.GetArrayElementAtIndex(i).intValue = bytes[i];
                }
                bytesProperty.serializedObject.ApplyModifiedProperties();
            }
        }

        public static byte[] MultiValuePropertyField(Rect position, byte[] bytes, ByteValue.ValueType valueType) {
            EditorGUIUtility.labelWidth = 16;

            switch (valueType) {
                case ByteValue.ValueType.Bool:
                    if (bytes == null || bytes.Length != 1) bytes = new byte[1];
                    return BitConverter.GetBytes(EditorGUI.Toggle(position, " ", BitConverter.ToBoolean(bytes, 0)));
                case ByteValue.ValueType.Float:
                    if (bytes == null || bytes.Length != 4) bytes = new byte[4];
                    return BitConverter.GetBytes(EditorGUI.FloatField(position, " ", BitConverter.ToSingle(bytes, 0)));
                case ByteValue.ValueType.Int:
                    if (bytes == null || bytes.Length != 4) bytes = new byte[4];
                    return BitConverter.GetBytes(EditorGUI.IntField(position, " ", BitConverter.ToInt32(bytes, 0)));
                default:
                    return new byte[0];
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return base.GetPropertyHeight(property, label);
        }
    }
}