using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(MoveBetweenTwoPoints))] [CanEditMultipleObjects]
public class MoveBetweenTwoPointsEditor : Editor
{
    //get the script with the variables needed
    MoveBetweenTwoPoints moveScript;
    Transform obstacle;
    SerializedProperty position;

    //private SerializedProperty startPosition;
    //private SerializedProperty endPosition;

    public override void OnInspectorGUI()
    {
        moveScript = ((MonoBehaviour)target).gameObject.GetComponent<MoveBetweenTwoPoints>();
        obstacle = ((MonoBehaviour)target).gameObject.GetComponent<Transform>();

        /*
        startPosition = this.serializedObject.FindProperty("startPosition");
        endPosition = this.serializedObject.FindProperty("endPosition");*/

        base.OnInspectorGUI();

        //show the start and end positions
        GUILayout.Label("Start Position (hold 'a' to change): " + moveScript.startPosition);
        GUILayout.Label("End Position (hold 'd' to change): " + moveScript.endPosition);
        GUILayout.Label("Obstacle Position (hold 's' to change): " + obstacle.transform.position);
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
        obstacle = ((MonoBehaviour)target).gameObject.GetComponent<Transform>();
        Event currentEvent = Event.current;
        
        //get position of mouse and set the start point when holding left control
        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                if (currentEvent.keyCode == KeyCode.A)
                {
                    //set start position
                    UnityEngine.MonoBehaviour.print("Setting Track's Start Position");
                    Vector3 screenPosition = Event.current.mousePosition;
                    screenPosition.y = Camera.current.pixelHeight - screenPosition.y;
                    Vector3 worldpos = Camera.current.ScreenToWorldPoint(screenPosition);
                    worldpos.z = 0;
                    //UnityEngine.MonoBehaviour.print("Mouse pos: " + worldpos);
                    moveScript.startPosition = worldpos;
                    currentEvent.Use();
                }
                if (currentEvent.keyCode == KeyCode.D)
                {
                    //set the end position
                    UnityEngine.MonoBehaviour.print("Setting Track's End Position");
                    Vector3 screenPosition = Event.current.mousePosition;
                    screenPosition.y = Camera.current.pixelHeight - screenPosition.y;
                    Vector3 worldpos = Camera.current.ScreenToWorldPoint(screenPosition);
                    worldpos.z = 0;
                    //UnityEngine.MonoBehaviour.print("Mouse pos: " + screenPosition);
                    moveScript.endPosition = worldpos;
                    currentEvent.Use();
                }
                if(currentEvent.keyCode == KeyCode.S)
                {
                    //move the track and the object
                    UnityEngine.MonoBehaviour.print("Setting Obstacle's Position");
                    Vector3 screenPosition = Event.current.mousePosition;
                    screenPosition.y = Camera.current.pixelHeight - screenPosition.y;
                    Vector3 worldpos = Camera.current.ScreenToWorldPoint(screenPosition);
                    worldpos.z = 0;

                    obstacle.transform.position = worldpos;
                    //get the length and position of the track, then move that proportionally to the object's movement
                    float trackLength = Vector3.Distance(moveScript.startPosition, moveScript.endPosition);
                    
                    moveScript.startPosition.x = obstacle.transform.position.x - (trackLength / 2);
                    moveScript.startPosition.y = obstacle.transform.position.y;
                    moveScript.endPosition.x = obstacle.transform.position.x + (trackLength / 2);
                    moveScript.endPosition.y = obstacle.transform.position.y;  

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