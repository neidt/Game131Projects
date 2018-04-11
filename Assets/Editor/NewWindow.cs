using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System.Text;

public class NewWindow : EditorWindow
{
    [MenuItem("Tools/Level Editor")]
    //using the unity manual for the init part
    // Add menu named "My Window" to the Window menu
    private static NewWindow instance;

    private static void ShowLevelEditor()
    {
       NewWindow.ShowWindow();
    }
    public static void ShowWindow()
    {
        instance = EditorWindow.GetWindow<NewWindow>();
        instance.titleContent = new GUIContent("Level Editor");
    }


    private float currentX = 0.0f;
    private void OnGUI()
    {

        //GUILayout.Label("");

        if (GUILayout.Button("Create Obstacle"))
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
    }
}
