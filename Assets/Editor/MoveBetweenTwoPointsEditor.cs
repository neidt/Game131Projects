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
    public override void OnInspectorGUI()
    {
        moveScript = ((MonoBehaviour)target).gameObject.GetComponent<MoveBetweenTwoPoints>();
        Event currentEvent = Event.current;

        base.OnInspectorGUI();
        //show the start and end positions
        GUILayout.Label("Start Position: " + moveScript.startPosition);
        GUILayout.Label("End Position: " + moveScript.endPosition);

        //get position of mouse and set the start point when holding left control
        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                if (currentEvent.keyCode == KeyCode.LeftShift)
                {
                    UnityEngine.MonoBehaviour.print("Setting Start Position");
                    Vector2 mousePos = Event.current.mousePosition;
                    mousePos.y = Camera.current.pixelHeight - mousePos.y;

                    Vector3 worldPos = Camera.current.ScreenToWorldPoint(mousePos);
                    worldPos.z = 0;

                    position.vector3Value = worldPos;
                    moveScript.startPosition = worldPos;
                }
                else if (currentEvent.keyCode == KeyCode.LeftControl)
                {
                    UnityEngine.MonoBehaviour.print("Setting End Position");
                    Vector2 mousePos = Event.current.mousePosition;
                    mousePos.y = Camera.current.pixelHeight - mousePos.y;

                    Vector3 worldPos = Camera.current.ScreenToWorldPoint(mousePos);
                    worldPos.z = 0;

                    position.vector3Value = worldPos;

                    //set start pos
                    moveScript.endPosition = worldPos;
                }
                currentEvent.Use();
                break;
            case EventType.KeyUp:
                UnityEngine.MonoBehaviour.print("Key Up: " + currentEvent.keyCode);
                currentEvent.Use();
                break;

        }
    }
    void OnEnable()
    {
        position = this.serializedObject.FindProperty("position");  
    }
}