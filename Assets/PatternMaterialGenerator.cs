using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternMaterialGenerator : MonoBehaviour
{
    public uint sampleCount;
    public RenderTexture sampleRenderTexture;
    public GameObject[] quads;

    // Start is called before the first frame update
    void Start()
    {
        if (sampleCount > 1)
            sampleRenderTexture.bindTextureMS = true;

        for(int sampleIndex = 0; sampleIndex < sampleCount; ++sampleIndex)
        {
            quads[sampleIndex].GetComponent<MeshRenderer>().material.SetTexture("_PatternTexture", sampleRenderTexture);
            quads[sampleIndex].GetComponent<MeshRenderer>().material.EnableKeyword($"SAMPLE_COUNT_{sampleCount}");
            if (sampleCount > 1)
                quads[sampleIndex].GetComponent<MeshRenderer>().material.EnableKeyword($"SAMPLE_INDEX_{sampleIndex}");
        }
    }
}
