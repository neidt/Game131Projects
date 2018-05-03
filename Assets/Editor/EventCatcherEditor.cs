using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventCatcher))]
public class EventCatcherEditor : Editor
{
    //MoveBetweenTwoPoints moveScript;
    Transform objectTransform;
    Transform targetTran;
    SerializedProperty position;
    public override void OnInspectorGUI()
    {
        Event currentEvent = Event.current;
        //moveScript = ((MonoBehaviour)target).gameObject.GetComponent<MoveBetweenTwoPoints>();
        objectTransform = ((MonoBehaviour)target).gameObject.GetComponent<Transform>();
        //show the start and end positions
        //GUILayout.Label("Start Position: " + moveScript.startPosition);
        //GUILayout.Label("startPosition" + startPosition);
        //GUILayout.Label("End Position: " + moveScript.endPosition);
        base.OnInspectorGUI();

        //i dont even know what this is doing???
        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                //scale up
                if (currentEvent.keyCode == KeyCode.W)
                {
                    UnityEngine.MonoBehaviour.print("scaleing up");
                    objectTransform.localScale.Scale(Vector3.one);
                }
                //scale down
                if (currentEvent.keyCode == KeyCode.S)
                {
                    UnityEngine.MonoBehaviour.print("scaleing down");
                    objectTransform.localScale.Scale(-Vector3.one);
                    //same as above???
                }

                currentEvent.Use();
                break;
            case EventType.KeyUp:
                UnityEngine.MonoBehaviour.print("Key Up: " + currentEvent.keyCode);
                currentEvent.Use();
                break;
        }

    }

    private void print(object message)
    {
        UnityEngine.MonoBehaviour.print(message);
    }

    private void OnEnable()
    {
        ArrayList sceneViews = SceneView.sceneViews;
        if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();
    }

    private void OnSceneGUI()
    {
        /*Event currentEvent = Event.current;
        //moveScript = ((MonoBehaviour)target).gameObject.GetComponent<MoveBetweenTwoPoints>();
        objectTransform = ((MonoBehaviour)target).gameObject.GetComponent<Transform>();
        //show the start and end positions
        //GUILayout.Label("Start Position: " + moveScript.startPosition);
        //GUILayout.Label("startPosition" + startPosition);
        //GUILayout.Label("End Position: " + moveScript.endPosition);
        base.OnInspectorGUI();

        //i dont even know what this is doing???
        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                //scale up
                if (currentEvent.keyCode == KeyCode.W)
                {
                    UnityEngine.MonoBehaviour.print("scaleing up");
                    objectTransform.localScale.Scale(Vector3.one);
                }
                //scale down
                if (currentEvent.keyCode == KeyCode.S)
                {
                    UnityEngine.MonoBehaviour.print("scaleing down");
                    objectTransform.localScale.Scale(-Vector3.one);
                    //same as above???
                }
                currentEvent.Use();
                break;
            case EventType.KeyUp:
                UnityEngine.MonoBehaviour.print("Key Up: " + currentEvent.keyCode);
                currentEvent.Use();
                break;
        }*/
    }
}
    


