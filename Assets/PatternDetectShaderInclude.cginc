#ifndef PATTERN_DETECT_SHADER_INCLUDED
#define PATTERN_DETECT_SHADER_INCLUDED

#if SAMPLE_COUNT_1 
    #define NUM_SAMPLES 1
#elif SAMPLE_COUNT_2 
    #define NUM_SAMPLES 2
#elif SAMPLE_COUNT_4 
    #define NUM_SAMPLES 4
#elif SAMPLE_COUNT_8
    #define NUM_SAMPLES 8
#endif

#if SAMPLE_INDEX_0 
    #define SAMPLE_INDEX 0
#elif SAMPLE_INDEX_1
    #define SAMPLE_INDEX 1
#elif SAMPLE_INDEX_2
    #define SAMPLE_INDEX 2
#elif SAMPLE_INDEX_3
    #define SAMPLE_INDEX 3
#elif SAMPLE_INDEX_4
    #define SAMPLE_INDEX 4
#elif SAMPLE_INDEX_5
    #define SAMPLE_INDEX 5
#elif SAMPLE_INDEX_6
    #define SAMPLE_INDEX 6
#elif SAMPLE_INDEX_7
    #define SAMPLE_INDEX 7
#endif

    struct appdata
    {
        float4 vertex : POSITION;
    };

    struct v2f
    {
        float4 vertex : SV_POSITION;
    };

#if (NUM_SAMPLES > 1)
    Texture2DMS<float4, NUM_SAMPLES> _PatternTexture;
#else
    Texture2D<float4> _PatternTexture;
#endif

    float _SampleIndex;

    v2f vert(appdata v)
    {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        return o;
    }

    float4 frag(v2f i) : SV_Target
    {
#if (NUM_SAMPLES > 1)
        float4 col = _PatternTexture.Load(int2(0,0), SAMPLE_INDEX);
#else
        float4 col = _PatternTexture.Load(int3(0, 0, 0));
#endif
        return col;
    }

#endif // PATTERN_DETECT_SHADER_INCLUDED
