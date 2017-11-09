using Dialogue;
using UnityEditor;
using UnityEngine;

namespace DialogueEditor {
    [CustomPropertyDrawer(typeof(DialogueSettings))]
    public class DialogueSettingsPropertyDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            SerializedProperty itemsProperty = property.FindPropertyRelative("items");

            Rect removeRect = new Rect(position.x, position.y, 20, position.height);
            Rect keyRect = new Rect(position.x + 25, position.y, position.width * 0.5f - 20, position.height);
            Rect valueRect = new Rect(position.x + (position.width * 0.5f), position.y, position.width * 0.5f, position.height);

            SerializedProperty arrayProperty = itemsProperty.FindPropertyRelative("Array");

            for (int i = 0; i < itemsProperty.arraySize; i++) {
                if (GUI.Button(removeRect, "-")) {
                    itemsProperty.DeleteArrayElementAtIndex(i);
                    i--;
                    continue;
                }

                SerializedProperty keyProperty = arrayProperty.FindPropertyRelative("data[" + i + "].key");
                SerializedProperty valProperty = arrayProperty.FindPropertyRelative("data[" + i + "].value");

                EditorGUI.PropertyField(keyRect, keyProperty, new GUIContent(""), false);
                EditorGUI.PropertyField(valueRect, valProperty, new GUIContent(""), false);
                removeRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                keyRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                valueRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }
            removeRect.width = 50;
            if (GUI.Button(removeRect, "bool+")) {
                itemsProperty.InsertArrayElementAtIndex(itemsProperty.arraySize);
                itemsProperty.FindPropertyRelative("Array.data[" + (itemsProperty.arraySize - 1) + "].value.valueType").enumValueIndex = (int) ByteValue.ValueType.Bool;
            }
            removeRect.x += 55;
            if (GUI.Button(removeRect, "int+")) {
                itemsProperty.InsertArrayElementAtIndex(itemsProperty.arraySize);
                itemsProperty.FindPropertyRelative("Array.data[" + (itemsProperty.arraySize - 1) + "].value.valueType").enumValueIndex = (int) ByteValue.ValueType.Int;
            }
            removeRect.x += 55;
            if (GUI.Button(removeRect, "float+")) {
                itemsProperty.InsertArrayElementAtIndex(itemsProperty.arraySize);
                itemsProperty.FindPropertyRelative("Array.data[" + (itemsProperty.arraySize - 1) + "].value.valueType").enumValueIndex = (int) ByteValue.ValueType.Float;
            }
        }
    }
}