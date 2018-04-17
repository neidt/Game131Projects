using UnityEditor;
using UnityEngine;

public class BouncinessEditor : EditorWindow
{
    public float hSliderVal = 0.0f;
    [MenuItem("Window/Bounciness Editor")]
    public static void ShowWindow()
    {
        GetWindow<BouncinessEditor>("Bounciness");
    }
    private void OnGUI()
    {
        hSliderVal = GUILayout.HorizontalSlider(hSliderVal, 0.0f, 100.0f);
        GUILayout.Label("Change Bounciness");
    }

}
