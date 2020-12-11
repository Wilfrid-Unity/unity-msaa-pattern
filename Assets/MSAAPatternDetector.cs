using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class MSAAPatternDetector : MonoBehaviour
{
    public RenderTexture[] patternRenderTextures;

    List<string> sampleLocations = new List<string>();

    int framesWaitedBeforeReadingTextures = 0;
    bool finishedReadingPatternPixels = false;   

    static readonly string[] sampleLocationStrings =
    {
        "-0.5    (-8 / 16)",
        "-0.4375 (-7 / 16)",
        "-0.375  (-6 / 16)",
        "-0.3125 (-5 / 16)",
        "-0.25   (-4 / 16)",
        "-0.1875 (-3 / 16)",
        "-0.125  (-2 / 16)",
        "-0.0625 (-1 / 16)",
        "+0.0    (+0 / 16)",
        "+0.0625 (+1 / 16)",
        "+0.125  (+2 / 16)",
        "+0.1875 (+3 / 16)",
        "+0.25   (+4 / 16)",
        "+0.3125 (+5 / 16)",
        "+0.375  (+6 / 16)",
        "+0.4375 (+7 / 16)",
    };

    void Update()
    {
        if (!finishedReadingPatternPixels)
        {
            ++framesWaitedBeforeReadingTextures;

            if(framesWaitedBeforeReadingTextures > 5)
            {
                for (int i = 0; i < 4; ++i)
                {
                    var patterRenderTexture = patternRenderTextures[i];
                    Texture2D patternRenderTextureCopy = new Texture2D( patterRenderTexture.width, patterRenderTexture.height, patterRenderTexture.graphicsFormat, TextureCreationFlags.None );
                    Rect readRegion = new Rect(0, 0, patterRenderTexture.width, patterRenderTexture.height);
                    RenderTexture.active = patterRenderTexture;
                    patternRenderTextureCopy.ReadPixels(readRegion, 0, 0);
                    Color[] patternPixels = patternRenderTextureCopy.GetPixels();
                    //int sampleCount = (int)Mathf.Pow(2, i);
                    string locations = "";
                    foreach (Color color in patternPixels)
                    {
                        // retrieve the indices that we encoded during SampleQuadsGenerator.Awake()
                        int x = (int)(16f*color.r + 0.5f);
                        int y = (int)(16f*color.g + 0.5f);
                        locations += $"{sampleLocationStrings[x]}, {sampleLocationStrings[y]}\n";
                    }
                    sampleLocations.Add(locations);
                }

                finishedReadingPatternPixels = true;
            }
        }
    }

    void OnGUI()
    {
        if(finishedReadingPatternPixels)
        {
            GUI.Label(new Rect(930, 040, 600, 20), sampleLocations[0]);
            GUI.Label(new Rect(930, 170, 600, 40), sampleLocations[1]);
            GUI.Label(new Rect(930, 340, 600, 80), sampleLocations[2]);
            GUI.Label(new Rect(930, 520, 600, 160), sampleLocations[3]);
        }
    }
}
