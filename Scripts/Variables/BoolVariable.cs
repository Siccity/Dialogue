using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Bool")]
public class BoolVariable : BaseVariable<bool> {
    public bool Equals(bool value) {
        return this.value == value;
    }
}