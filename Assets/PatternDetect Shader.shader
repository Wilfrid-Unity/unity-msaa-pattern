Shader "Unlit/PatternDetectShader"
{
    Properties
    {
        _PatternTexture ("Pattern Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #pragma multi_compile_local SAMPLE_COUNT_1 SAMPLE_COUNT_2 SAMPLE_COUNT_4 SAMPLE_COUNT_8
            #pragma multi_compile_local SAMPLE_INDEX_0 SAMPLE_INDEX_1 SAMPLE_INDEX_2 SAMPLE_INDEX_3 SAMPLE_INDEX_4 SAMPLE_INDEX_5 SAMPLE_INDEX_6 SAMPLE_INDEX_7

            #include "PatternDetectShaderInclude.cginc"

            ENDCG
        }
    }
}
