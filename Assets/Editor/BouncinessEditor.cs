using UnityEditor;
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
}
