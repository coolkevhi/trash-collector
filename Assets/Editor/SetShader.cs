#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class SetShader
{
    [MenuItem("Tools/Convert Materials To URP Lit")]
    static void Convert()
    {
        Shader urpLit = Shader.Find("Universal Render Pipeline/Lit");

        string[] guids = AssetDatabase.FindAssets("t:Material");

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            Texture tex = null;

            if (mat.HasProperty("_MainTex"))
                tex = mat.GetTexture("_MainTex");

            mat.shader = urpLit;

            if (tex && mat.HasProperty("_BaseMap"))
                mat.SetTexture("_BaseMap", tex);

            EditorUtility.SetDirty(mat);
        }

        AssetDatabase.SaveAssets();
        Debug.Log("Finished converting materials.");
    }
}
#endif