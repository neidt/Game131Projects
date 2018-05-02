using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventCatcher))]
public class EventCatcherEditor : Editor
{
    MoveBetweenTwoPoints moveScript;
    SerializedProperty position;
    public override void OnInspectorGUI()
    {
        Event currentEvent = Event.current;
        moveScript = ((MonoBehaviour)target).gameObject.GetComponent<MoveBetweenTwoPoints>();
        //show the start and end positions
        GUILayout.Label("Start Position: " + moveScript.startPosition);
        //GUILayout.Label("startPosition" + startPosition);
        GUILayout.Label("End Position: " + moveScript.endPosition);
        base.OnInspectorGUI();

        //i dont even know what this is doing???
        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                //scale up
                if(currentEvent.keyCode == KeyCode.W)
                {
                    UnityEngine.MonoBehaviour.print("scaleing up");
                    //somehow figure out what gameobject this script is attached to ????
                    //then scale it????
                }
                //scale down
                if(currentEvent.keyCode == KeyCode.S)
                {
                    UnityEngine.MonoBehaviour.print("scaleing down");
                    
                    //same as above???
                }
                //rotate left
                if(currentEvent.keyCode == KeyCode.A)
                {
                    //?????
                }
                //rotate right
                if(currentEvent.keyCode == KeyCode.D)
                {
                    //????
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

    /*private void OnSceneGUI()
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
    }*/
    
}

/**using UnityEditor;
using UnityEngine;
using System.Text;

public class BouncinessEditor : EditorWindow
{
    public float hSliderVal = 0.5f;
    [MenuItem("Tools/Bounciness Editor")]
    public static void ShowWindow()
    {
        GetWindow<BouncinessEditor>("Bounciness");
    }
    private void OnGUI()
    {
        hSliderVal = GUILayout.HorizontalSlider(hSliderVal, 0.0f, 1.0f);
        GUILayout.Label("Bounciness");
        GUILayout.Label(hSliderVal.ToString());

        if (GUILayout.Button("Change Bounciness"))
        {
            //string[] bouncyMat = AssetDatabase.FindAssets("pMatBouncy");
            string[] matGuids = AssetDatabase.FindAssets("pMatBouncy");
            StringBuilder guidBuilder = new StringBuilder();
            foreach (string matGuid in matGuids)
            {
                guidBuilder.AppendLine(matGuid);
            }
            UnityEngine.MonoBehaviour.print(guidBuilder.ToString());

            if (matGuids.Length > 0)
            {
                string trueMatGuid = matGuids[0];
                string assetPath = AssetDatabase.GUIDToAssetPath(trueMatGuid);
                UnityEngine.MonoBehaviour.print(assetPath);

                //GameObject matTemplate = AssetDatabase.LoadAssetAtPath(assetPath, typeof(PhysicsMaterial2D)) as GameObject;
                //matTemplate.GetComponent<PhysicsMaterial2D>().bounciness = hSliderVal;
                PhysicsMaterial2D material = AssetDatabase.LoadAssetAtPath(assetPath, typeof(PhysicsMaterial2D)) as PhysicsMaterial2D;
                material.bounciness = hSliderVal;
                //GameObject newWall = GameObject.Instantiate(matTemplate);
                //newWall.name = matTemplate.name;
            }
        }
    }
}*/
