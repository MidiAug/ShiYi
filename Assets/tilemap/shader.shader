Shader "Custom/RoundCornerTileShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // ��Ƭ����
        _Radius ("Radius", Range(0, 0.5)) = 0.5 // Բ�ǰ뾶
        _CornerType ("Corner Type", Float) = 0 // Բ������
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 200

        Blend SrcAlpha OneMinusSrcAlpha // ͸���Ȼ��
        ZWrite Off // �ر����д��
        Cull Off // �رձ����޳�
        Lighting Off // �رչ���

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Radius;
            int _CornerType;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.texcoord);

                float2 uv = i.texcoord; // ��ȡ��������
                bool discardPixel = false;

                // ���Ͻ�Բ��
                if (_CornerType & 1==1)
                {
                    if (uv.x < _Radius && uv.y > 1.0 - 4*_Radius)
                    {
                        float x=uv.x;
                        float y=uv.y;
                        float r=_Radius;
                        float a=16*(x-r)*(x-r);
                        float b=(y-1+4*r);
                        if(a+b*b>=1)discardPixel = true;
                    }
                }
                // ���Ͻ�Բ��
                if (_CornerType & 2==1)
                {
                    if (uv.x > 1.0 - _Radius && uv.y > 1.0 - _Radius)
                    {
                        float2 dist = uv - float2(1.0 - _Radius, 1.0 - _Radius);
                        if (length(dist) > _Radius) discardPixel = true;
                    }
                }
                // ���½�Բ��
                if (_CornerType & 4==1)
                {
                    if (uv.x < _Radius && uv.y < _Radius)
                    {
                        float2 dist = uv - float2(_Radius, _Radius);
                        if (length(dist) > _Radius) discardPixel = true;
                    }
                }
                // ���½�Բ��
                if (_CornerType & 8==1)
                {
                    if (uv.x > 1.0 - _Radius && uv.y < _Radius)
                    {
                        float2 dist = uv - float2(1.0 - _Radius, _Radius);
                        if (length(dist) > _Radius) discardPixel = true;
                    }
                }

                if (discardPixel) discard;

                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
