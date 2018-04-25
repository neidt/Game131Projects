using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System.Text;

public class NewWindow : EditorWindow
{
    [MenuItem("Tools/Level Editor Window")]
    public static void ShowWindow()
    {
        GetWindow<NewWindow>("New Object Window");
    }

    private float currentX = 0.0f;
    private void OnGUI()
    {
        //new obstacle button
        if (GUILayout.Button("Create New Obstacle"))
        {
            string[] wallGuids = AssetDatabase.FindAssets("wallBasePrefab");
            StringBuilder guidBuilder = new StringBuilder();
            foreach(string wallGuid in wallGuids)
            {
                guidBuilder.AppendLine(wallGuid);
            }
            UnityEngine.MonoBehaviour.print(guidBuilder.ToString());

            if(wallGuids.Length > 0)
            {
                string trueWallGuid = wallGuids[0];
                string assetPath = AssetDatabase.GUIDToAssetPath(trueWallGuid);
                UnityEngine.MonoBehaviour.print(assetPath);

                GameObject wallTemplate = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;
                GameObject newWall =GameObject.Instantiate(wallTemplate);
                newWall.name = wallTemplate.name;

                Vector2 newWallPos = new Vector2(0,0);
                newWallPos.x = currentX;
                
                currentX += 1f;
            }
        }

        //new target button
        if (GUILayout.Button("Create New Target"))
        {
            string[] targetGuids = AssetDatabase.FindAssets("Target");
            StringBuilder guidBuilder = new StringBuilder();
            foreach (string targetGuid in targetGuids)
            {
                guidBuilder.AppendLine(targetGuid);
            }
            UnityEngine.MonoBehaviour.print(guidBuilder.ToString());

            if (targetGuids.Length > 0)
            {
                string trueTargetGuid = targetGuids[0];
                string assetPath = AssetDatabase.GUIDToAssetPath(trueTargetGuid);
                UnityEngine.MonoBehaviour.print(assetPath);

                GameObject targetTemplate = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;
                GameObject newTarget = GameObject.Instantiate(targetTemplate);
                newTarget.name = targetTemplate.name;

                Vector2 newTargetPos = new Vector2(0, 0);
                newTargetPos.x = currentX;

                currentX += 1f;
            }
        }
    }//end onGUI
}
