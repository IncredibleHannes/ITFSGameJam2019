Shader "Assets/MergeShader"
{
    Properties
    {
        [PerRendererData]_MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
            "IgnoreProjector" = "True"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "True"
        }
    
        Cull Off
        Lighting Off
        ZWrite Off
        ColorMask RGBA
    
        Pass
        {
            // if the value in the buffer is 0, run this pass and increment the buffer
            Stencil
            {
                Ref 0
                Comp Equal
                Pass IncrSat
            }
        
            // default blending for first pass
            Blend SrcAlpha OneMinusSrcAlpha
        
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
        
            #include "UnityCG.cginc"
    
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };
    
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };
    
            sampler2D _MainTex;
            float4 _MainTex_ST;
    
            v2f vert (appdata input)
            {
                v2f output;
                output.vertex = UnityObjectToClipPos(input.vertex);
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                output.color = input.color;
                return output;
            }
        
            fixed4 frag (v2f input) : SV_Target
            {
                fixed4 textureColor = tex2D(_MainTex, input.uv) * input.color;
                return textureColor;
            }
            ENDCG
        }
    
        Pass
        {
            // if the value in the buffer is 1, run this pass
            Stencil
            {
                Ref 1
                Comp Equal
            }
    
            // additively blend any overlaps
            Blend One One
    
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
    
            #include "UnityCG.cginc"
    
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };
    
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };
    
            sampler2D _MainTex;
            float4 _MainTex_ST;
    
            v2f vert(appdata input)
            {
                v2f output;
                output.vertex = UnityObjectToClipPos(input.vertex);
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                output.color = input.color;
                return output;
            }
    
            fixed4 frag(v2f input) : SV_Target
            {
                fixed4 textureColor = tex2D(_MainTex, input.uv) * input.color;
                return textureColor;
            }
            ENDCG
        }
    }
}
