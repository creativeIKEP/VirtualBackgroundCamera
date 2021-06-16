Shader "Hidden/SelfieSegmentation/VirtualBackgroundVisuallizer"
{
    Properties
    {
        // Segmentation texture
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _inputImage;
            int _isBackGroundTexture;
            sampler2D _backImage;
            float4 _backGroundColor;
            float _threshold;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float4 col = tex2D(_inputImage, i.uv);
                float4 mask = tex2D(_MainTex, i.uv);
                float4 back = _isBackGroundTexture ? tex2D(_backImage, i.uv) : _backGroundColor;
                float4 p = (mask.r >= _threshold) ? col : back;
                return p;
            }
            ENDCG
        }
    }
}
