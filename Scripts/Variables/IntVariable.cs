using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Int")]
public class IntVariable : BaseVariable<int> {
    public void GreaterThan(int value) {
        onCondition(this.value > value);
    }

    public void LessThan(int value) {
        onCondition(this.value < value);
    }

    public void Equals(int value) {
        onCondition(this.value == value);
    }
}