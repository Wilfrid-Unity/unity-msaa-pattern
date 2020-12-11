using UnityEngine;

public class SampleQuadsGenerator : MonoBehaviour
{
    public GameObject quadTemplate;

    void Awake()
    {
        // Instantiate all the quads that will be rendered onto the 1px render target
        for(int i_x = 0; i_x < 16; ++i_x)
        {
            for(int i_y = 0; i_y < 16; ++i_y)
            {
                // convert quad centers from [0, 15] to [-7.5, +7.5]
                float x = (float)i_x -7.5f;
                float y = (float)i_y -7.5f;
                GameObject obj = Instantiate(quadTemplate, new Vector3(x, y, 0), Quaternion.identity, this.transform);

                // encode indices as color channels
                float r = (float)i_x / 16f;
                float g = (float)i_y / 16f;
                obj.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(r, g, 0.0f, 1.0f));
            }
        }
    }
}
