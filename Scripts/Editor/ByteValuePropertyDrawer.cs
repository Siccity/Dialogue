using System;
using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEditor;
using UnityEngine;

namespace DialogueEditor {
    [CustomPropertyDrawer(typeof(ByteValue))]
    public class DialogueSettingsPropertyDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            Rect pos = position;
            pos.width = position.width * 0.5f;
            property.Next(true);
            EditorGUI.PropertyField(pos, property, new GUIContent(""), false);
            ByteValue.ValueType valType = (ByteValue.ValueType) property.enumValueIndex;
            pos.x += pos.width;
            property.Next(false);

            //Get bytes
            byte[] bytes = new byte[property.arraySize];
            for (int i = 0; i < bytes.Length; i++) {
                bytes[i] = (byte) property.GetArrayElementAtIndex(i).intValue;
            }

            EditorGUI.BeginChangeCheck();
            //Modify bytes
            bytes = MultiValuePropertyField(pos, bytes, valType);

            if (EditorGUI.EndChangeCheck()) {
                //Set bytes
                property.ClearArray();
                for (int i = 0; i < bytes.Length; i++) {
                    property.InsertArrayElementAtIndex(i);
                    property.GetArrayElementAtIndex(i).intValue = bytes[i];
                }
                property.serializedObject.ApplyModifiedProperties();
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