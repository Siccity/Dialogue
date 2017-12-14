using System;
using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEngine;

public class BaseVariable<T> : ScriptableObject {
	public T value;

	public T GetValue() {
		return value;
	}

	public void SetValue(T value) {
		this.value = value;
	}
}