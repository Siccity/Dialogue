using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Float")]
public class FloatVariable : BaseVariable<float> {
    public bool GreaterThan(float value) {
        return this.value > value;
    }

    public bool LessThan(float value) {
        return this.value < value;
    }

    public bool Equals(float value) {
        return this.value == value;
    }
}