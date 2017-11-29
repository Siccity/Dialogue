using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using XNode;

namespace Dialogue {
    [NodeTint("#CCCCFF")]
    public class Branch : DialogueBaseNode {

        [Input] public Chat.Connection input;
        public UnityEvent conditions;
        [Output] public Chat.Connection pass;
        [Output] public Chat.Connection fail;

        private bool success;

        public override void Trigger() {

            List<ICondition> iconditions = new List<ICondition>();
            // Get conditions
            for (int i = 0; i < conditions.GetPersistentEventCount(); i++) {
                ICondition condition = conditions.GetPersistentTarget(i) as ICondition;
                if (condition == null) Debug.LogWarning("Condition does not implement ICondition: " + conditions.GetPersistentMethodName(i));
                iconditions.Add(condition);
            }

            // Add listeners
            foreach (ICondition c in iconditions) c.AddListener(OnCondition);

            // Perform condition
            success = true;
            conditions.Invoke();

            // Remove listeners
            foreach (ICondition c in iconditions) c.RemoveListener(OnCondition);

            //Trigger next nodes
            NodePort port;
            if (success) port = GetOutputPort("pass");
            else port = GetOutputPort("fail");
            if (port == null) return;
            for (int i = 0; i < port.ConnectionCount; i++) {
                NodePort connection = port.GetConnection(i);
                (connection.node as DialogueBaseNode).Trigger();
            }
        }

        private void OnCondition(bool success) {
            if (!success) this.success = false;
        }
    }

    public interface ICondition {
        void AddListener(Action<bool> onCondition);
        void RemoveListener(Action<bool> onCondition);
    }
}