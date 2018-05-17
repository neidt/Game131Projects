using UnityEditor;
using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class BouncinessEditor : EditorWindow
{
    public float hBounceSliderVal = 0.5f;
    private PhysicsMaterial2D bounceMat;
    SerializedProperty bounce;

    [MenuItem("Tools/Bounciness Editor")]
    public static void ShowWindow()
    {
        GetWindow<BouncinessEditor>("Bounciness");
    }
    private void OnGUI()
    {
        hBounceSliderVal = GUILayout.HorizontalSlider(hBounceSliderVal, 0.0f, 1.0f);
        GUILayout.Label("Bounciness");
        GUILayout.Label(hBounceSliderVal.ToString());

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

                bounceMat = new PhysicsMaterial2D();
                bounceMat.bounciness = hBounceSliderVal; 
            }
        }
    }
}
