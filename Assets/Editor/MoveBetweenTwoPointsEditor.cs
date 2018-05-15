using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
[CustomEditor(typeof(MoveBetweenTwoPoints))]
[CanEditMultipleObjects]
public class MoveBetweenTwoPointsEditor : Editor
{
    //get the script with the variables needed
    MoveBetweenTwoPoints moveScript;
    Transform obstacle;
    
    SerializedProperty position;
    Vector3 rotateVec = new Vector3(0, 0, 1);
    public float hSliderVal = 0.5f;
    //private SerializedProperty startPosition;
    //private SerializedProperty endPosition;

    public override void OnInspectorGUI()
    {
        moveScript = ((MonoBehaviour)target).gameObject.GetComponent<MoveBetweenTwoPoints>();
        obstacle = ((MonoBehaviour)target).gameObject.GetComponent<Transform>();
       
        GUIStyle style = new GUIStyle();
        style.richText = true;
        /*
        startPosition = this.serializedObject.FindProperty("startPosition");
        endPosition = this.serializedObject.FindProperty("endPosition");*/

        base.OnInspectorGUI();

        //bounciness editor
        hSliderVal = GUILayout.HorizontalSlider(hSliderVal, 0.0f, 1.0f);
        GUILayout.Label("Bounciness");
        GUILayout.Label(hSliderVal.ToString());

        if (GUILayout.Button("Change Bounciness"))
        {

            //bounciness = hSliderVal;

        }

        //show the start and end positions
        GUILayout.Label("<color=green>Start Position (hold 'a' to change):</color> " + moveScript.startPosition, style);
        GUILayout.Label("<color=red>End Position (hold 'd' to change):</color> " + moveScript.endPosition, style);
        GUILayout.Label("Obstacle Position (hold 's' to change): " + obstacle.transform.position, style);
        GUILayout.Label("Obstacle Scale ('u' and 'j' to change): " + obstacle.transform.localScale);
        GUILayout.Label("Obstacle Rotation ('y' and 'i' to change): " + obstacle.transform.rotation);
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
                if (currentEvent.keyCode == KeyCode.S)
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
                if (currentEvent.keyCode == KeyCode.U)
                {
                    UnityEngine.MonoBehaviour.print("Scaling up");
                    obstacle.transform.localScale += Vector3.one;
                }
                if (currentEvent.keyCode == KeyCode.J)
                {
                    UnityEngine.MonoBehaviour.print("Scaling Down");
                    obstacle.transform.localScale -= Vector3.one;
                }
                if (currentEvent.keyCode == KeyCode.Y)
                {
                    UnityEngine.MonoBehaviour.print("rotating left");
                    obstacle.transform.Rotate(rotateVec);
                }
                if (currentEvent.keyCode == KeyCode.I)
                {
                    UnityEngine.MonoBehaviour.print("rotating right");
                    obstacle.transform.Rotate(-rotateVec);
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