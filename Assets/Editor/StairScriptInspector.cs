using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(StairScript))]
public class RoomScriptInspector : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        StairScript stair = (StairScript)target;
        if (GUILayout.Button("Generate!"))
        {
            var children = new List<GameObject>();
            foreach (Transform child in stair.transform) children.Add(child.gameObject);
            children.ForEach(child => DestroyImmediate(child.gameObject));

            float StepWidth = stair.width / stair.steps;
            float StepHeight = stair.height / stair.steps;

            for (int i = 0; i < stair.steps; i++)
            {
                float height = (stair.steps - i) * StepHeight;

                GameObject step = GameObject.CreatePrimitive(PrimitiveType.Cube);
                step.transform.SetParent(stair.transform);
                step.transform.localPosition = new Vector3(i * StepWidth + 0.5f * StepWidth, height / 2f, stair.depth / 2f);
                step.transform.localScale = new Vector3(StepWidth, height, stair.depth);
                DestroyImmediate(step.GetComponent<Collider>());
            }
        }
    
    }
}
