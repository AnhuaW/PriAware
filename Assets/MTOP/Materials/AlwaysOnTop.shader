Shader "Custom/AlwaysOnTopTransparent3D_VR_Quest"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1) // Base color with transparency
        _Transparency ("Transparency", Range(0,1)) = 0.5 // Adjust transparency
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }

    SubShader
    {
        Tags { "Queue"="Overlay" "RenderType"="Transparent" "IgnoreProjector"="True" }
        LOD 100

        Pass
        {
            ZTest Always    // Ensures the object always renders on top
            ZWrite Off      // Disables writing to the depth buffer
            Blend SrcAlpha OneMinusSrcAlpha // Enables transparency
            Cull Off        // Fixes single-eye rendering by rendering both sides

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma multi_compile_fog
            #pragma target 3.0  // Ensures compatibility with Quest (GLES3 & Vulkan)

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 normal : NORMAL;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            float4 _Color;
            float _Transparency;
            float _Glossiness;
            float _Metallic;

            v2f vert (appdata v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                // Ensure proper stereo transformation (Fixes left-eye issue)
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
