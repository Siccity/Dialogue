using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Int")]
public class IntVariable : BaseVariable<int> {
    public bool GreaterThan(int value) {
        return this.value > value;
    }

    public bool LessThan(int value) {
        return this.value < value;
    }

    public bool Equals(int value) {
        return this.value == value;
    }
}