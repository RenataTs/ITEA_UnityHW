Shader "Custom/BlendingTexture"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SecondaryTex("2sdTexture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
        _Color2("Flash Color", Color) = (1, 1, 1, 1)
         _Blend("Texture transition", Range(0, 1)) = 0.5
         _LerpValue("Color transition", Range(0, 1)) = 0.5
        [Toggle] _isMixedTex("is MixedTexture", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _SecondaryTex;
        float _LerpValue;
        float _Blend;
        float _isMixedTex;

        fixed4 _Color;
        fixed4 _Color2;

        struct Input
        {
            float2 uv_MainTex;
            float4 _MainTex_ST;
            float4 _SecondaryTex_ST;
            float2 uv_SecondaryTex;
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = lerp(_Color, _Color2, _LerpValue);

            if (_isMixedTex)
            {
                o.Albedo = lerp(c, tex2D(_MainTex, IN.uv_MainTex) + tex2D(_SecondaryTex, IN.uv_SecondaryTex), _Blend) * c;
            }
            else
            {
                o.Albedo = lerp(tex2D(_MainTex, IN.uv_MainTex), tex2D(_SecondaryTex, IN.uv_SecondaryTex), _Blend) * c;
            }

        }
        ENDCG
    }
    FallBack "Diffuse"
}
