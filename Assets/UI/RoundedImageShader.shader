Shader "Custom/RoundedImageShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Radius ("Radius", Range(0, 0.5)) = 0.1
    }
    SubShader {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        LOD 200
        Blend SrcAlpha OneMinusSrcAlpha

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Radius;
            fixed4 _Color;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                fixed4 texColor = tex2D(_MainTex, i.texcoord);
                float2 uv = i.texcoord * 2.0 - 1.0;
                float radius = _Radius;
                float dist = length(max(abs(uv) - float2(1.0 - radius, 1.0 - radius), 0.0));
                float alpha = smoothstep(radius, radius + 0.01, dist);
                texColor.a *= alpha;  // Apply the transparency based on distance
                return texColor;
            }
            ENDCG
        }
    }
}
