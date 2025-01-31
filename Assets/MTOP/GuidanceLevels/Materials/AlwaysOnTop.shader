Shader "Custom/AlwaysOnTopTransparent3D"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1) // Color with alpha support
        _Transparency ("Transparency", Range(0,1)) = 0.5 // Adjust transparency
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    
    SubShader
    {
        Tags { "Queue"="Overlay" "RenderType"="Transparent" }
        Pass
        {
            // Ensures it renders above everything
            ZTest Always
            ZWrite Off // Prevents depth conflicts
            Blend SrcAlpha OneMinusSrcAlpha // Enables transparency

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 normal : NORMAL;
            };

            float4 _Color;
            float _Transparency;
            float _Glossiness;
            float _Metallic;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                // Simulate basic lighting using normal direction
                float lightIntensity = saturate(dot(i.normal, float3(0,1,0)) * 0.5 + 0.5);
                float3 litColor = _Color.rgb * lightIntensity;
                
                return float4(litColor, _Transparency);
            }
            ENDCG
        }
    }
}
