using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(MoveBetweenTwoPoints))] [CanEditMultipleObjects]
public class MoveBetweenTwoPointsEditor : Editor
{
    //get the script with the variables needed
    MoveBetweenTwoPoints moveScript;
    SerializedProperty position;

    //private SerializedProperty startPosition;
    //private SerializedProperty endPosition;

    public override void OnInspectorGUI()
    {
        moveScript = ((MonoBehaviour)target).gameObject.GetComponent<MoveBetweenTwoPoints>();
        Event currentEvent = Event.current;
        
        /*
        startPosition = this.serializedObject.FindProperty("startPosition");
        endPosition = this.serializedObject.FindProperty("endPosition");*/

        base.OnInspectorGUI();
        //show the start and end positions
        GUILayout.Label("Start Position: " + moveScript.startPosition);
        //GUILayout.Label("startPosition" + startPosition);
        GUILayout.Label("End Position: " + moveScript.endPosition);

        //get position of mouse and set the start point when holding left control
        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                if (currentEvent.keyCode == KeyCode.LeftAlt)
                {
                    UnityEngine.MonoBehaviour.print("Setting Start Position");

                    Vector3 screenPosition = Event.current.mousePosition;
                    screenPosition.y = Camera.current.pixelHeight - screenPosition.y;
                    Ray ray = Camera.current.ScreenPointToRay(screenPosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        // do stuff here using hit.point
                        moveScript.startPosition = hit.point;
                        // tell the event system you consumed the click
                        Event.current.Use();
                    }
                    
                }
                if (currentEvent.keyCode == KeyCode.LeftControl)
                {
                    UnityEngine.MonoBehaviour.print("Setting End Position");

                    Vector2 mousePos = currentEvent.mousePosition;
                    mousePos.y = Camera.current.pixelHeight - mousePos.y;
                    Vector3 worldPos = Camera.current.ScreenToWorldPoint(mousePos);
                    worldPos.z = 0;
                    position.vector3Value = worldPos;
                    moveScript.startPosition = worldPos;

                    currentEvent.Use();
                }
                //currentEvent.Use();
                break;
            case EventType.KeyUp:
                UnityEngine.MonoBehaviour.print("Key Up: " + currentEvent.keyCode);
                currentEvent.Use();
                break;

        }
        this.serializedObject.ApplyModifiedProperties();
    }
    void OnEnable()
    {
        position = this.serializedObject.FindProperty("position");  
    }

    private void OnSceneGUI()
    {
        //HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
        moveScript = ((MonoBehaviour)target).gameObject.GetComponent<MoveBetweenTwoPoints>();
        Event currentEvent = Event.current;

        //show the start and end positions
        GUILayout.Label("Start Position: (hold a to change) " + moveScript.startPosition);
        //GUILayout.Label("startPosition" + startPosition);
        GUILayout.Label("End Position: (hold d to change) " + moveScript.endPosition);

        //get position of mouse and set the start point when holding left control
        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                if (currentEvent.keyCode == KeyCode.A)
                {
                    UnityEngine.MonoBehaviour.print("Setting Start Position");

                    Vector3 screenPosition = Event.current.mousePosition;
                    screenPosition.y = Camera.current.pixelHeight - screenPosition.y;
                    Vector3 worldpos = Camera.current.ScreenToWorldPoint(screenPosition);
                    UnityEngine.MonoBehaviour.print("Mouse pos: " + worldpos);
                    moveScript.startPosition = worldpos;
                    

                }
                if (currentEvent.keyCode == KeyCode.D)
                {
                    UnityEngine.MonoBehaviour.print("Setting End Position");
                    Vector3 screenPosition = Event.current.mousePosition;
                    screenPosition.y = Camera.current.pixelHeight - screenPosition.y;
                    Vector3 worldpos = Camera.current.ScreenToWorldPoint(screenPosition);
                    worldpos.z = 0;
                    UnityEngine.MonoBehaviour.print("Mouse pos: " + screenPosition);
                    moveScript.endPosition = worldpos;
                    currentEvent.Use();
                }
                //currentEvent.Use();
                break;
            case EventType.KeyUp:
                UnityEngine.MonoBehaviour.print("Key Up: " + currentEvent.keyCode);
                currentEvent.Use();
                break;

        }
    }
}