Shader "Custom/ChromaKeyBlack"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Threshold ("Threshold", Range(0,1)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
LOD 100

Blend SrcAlpha OneMinusSrcAlpha

Cull Off

ZWrite Off

        Pass
        {
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

sampler2D _MainTex;
float _Threshold;

struct appdata
{
    float4 vertex : POSITION;
    float2 uv : TEXCOORD0;
};

struct v2f
{
    float2 uv : TEXCOORD0;
    float4 vertex : SV_POSITION;
};

v2f vert(appdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = v.uv;
    return o;
}

fixed4 frag(v2f i) : SV_Target
{
    fixed4 col = tex2D(_MainTex, i.uv);

    float alpha = 1.0;
    float3 keyColor = float3(0, 0, 0);
    float diff = distance(col.rgb, keyColor);

    if (diff < _Threshold)
    {
        alpha = 0.0;
    }

    col.a = alpha;
    return col;
}
            ENDCG
        }
    }
}
