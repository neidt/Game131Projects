using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(EventCatcher))]
public class EventCatcherEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
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
        Event currentEvent = Event.current;

        //types of event stuff
        UnityEngine.MonoBehaviour.print("event picked up: " + currentEvent.type);

        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                if (currentEvent.keyCode != KeyCode.None)
                {
                    UnityEngine.MonoBehaviour.print("Key down: " + currentEvent.keyCode);
                }
                currentEvent.Use();
                break;
            case EventType.KeyUp:
                UnityEngine.MonoBehaviour.print("Key Up: " + currentEvent.keyCode);
                currentEvent.Use();
                break;
        }
    }
}
