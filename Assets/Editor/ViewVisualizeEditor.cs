using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ViewVisualize))]
public class ViewVisualizeEditor : Editor
{
    [SerializeField] FloatVariable _viewRadius;
    private void OnSceneGUI()
    {
        ViewVisualize vv = target as ViewVisualize;
        Handles.color = Color.red;
        Handles.DrawWireArc(vv.transform.position, Vector3.forward, Vector3.right, 360, _viewRadius.Value);
    }
}
