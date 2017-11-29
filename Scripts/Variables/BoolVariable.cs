using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Bool")]
public class BoolVariable : BaseVariable<bool> {
    public void Equals(bool value) {
        onCondition(this.value == value);
    }
}