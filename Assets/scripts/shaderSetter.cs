using UnityEngine;

public class shaderSetter : MonoBehaviour
{
    public Shader targetShader;

    void Start()
    {
        if (targetShader == null)
        {
            Debug.LogError("No shader assigned!");
            return;
        }

        Renderer[] renderers = FindObjectsOfType<Renderer>(true);

        foreach (Renderer rend in renderers)
        {
            Material[] mats = rend.materials;

            for (int i = 0; i < mats.Length; i++)
            {
                Material oldMat = mats[i];

                if (oldMat == null)
                    continue;

                Texture tex = null;
                Color color = Color.white;

                if (oldMat.HasProperty("_MainTex"))
                    tex = oldMat.GetTexture("_MainTex");

                if (oldMat.HasProperty("_Color"))
                    color = oldMat.GetColor("_Color");

                Material newMat = new Material(targetShader);

                if (newMat.HasProperty("_BaseMap"))
                    newMat.SetTexture("_BaseMap", tex);

                if (newMat.HasProperty("_BaseColor"))
                    newMat.SetColor("_BaseColor", color);

                mats[i] = newMat;
            }

            rend.materials = mats;
        }

        Debug.Log($"Converted {renderers.Length} renderers to URP Lit.");
    }
}