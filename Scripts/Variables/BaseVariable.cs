using System;
using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;

public class BaseVariable<T> : ScriptableObject, Dialogue.ICondition {
	protected Action<bool> onCondition;
	public T value;

	public T GetValue() {
		return value;
	}

	public void SetValue(T value) {
		this.value = value;
	}

	void ICondition.AddListener(Action<bool> onCondition) {
		this.onCondition += onCondition;
	}

	void ICondition.RemoveListener(Action<bool> onCondition) {
		this.onCondition -= onCondition;
	}
}