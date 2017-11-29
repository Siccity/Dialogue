using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Float")]
public class FloatVariable : BaseVariable<float> {
    public void GreaterThan(float value) {
        onCondition(this.value > value);
    }

    public void LessThan(float value) {
        onCondition(this.value < value);
    }

    public void Equals(float value) {
        onCondition(this.value == value);
    }
}