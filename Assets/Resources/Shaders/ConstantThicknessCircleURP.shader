Shader "Custom/URP/ConstantThicknessCircle"
{
    Properties
    {
        [HDR] _Color ("Color", Color) = (1,1,1,1)
        _Thickness ("Thickness (world units)", Float) = 0.05
        _AA ("Edge softness (pixels)", Range(0.5, 3)) = 1
        
        _DashLength ("Dash length (world units)", Float) = 0.15
        _GapLength  ("Gap length (world units)", Float) = 0.10
        _Offset     ("Dash offset (periods)", Float) = 0
    }

    SubShader
    {
        Tags
        {
            "RenderPipeline"="UniversalPipeline"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "DisableBatching"="True"
        }

        Pass
        {
            Name "Unlit"
            Tags { "LightMode"="UniversalForward" }

            Blend SrcAlpha OneMinusSrcAlpha
            ZTest Always
            ZWrite Off
            Cull Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            // Совместимо с SRP Batcher
            CBUFFER_START(UnityPerMaterial)
                half4 _Color;
                float _Thickness;
                float _AA;
            
                float _DashLength;
                float _GapLength;
                float _Offset;
            CBUFFER_END

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv         : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 p          : TEXCOORD0; // позиция от центра в мировых единицах
                float2 halfSize   : TEXCOORD1; // полуразмеры квада в мировых единицах
            };

            Varyings vert (Attributes IN)
            {
                Varyings OUT;
                OUT.positionCS = TransformObjectToHClip(IN.positionOS.xyz);

                float4x4 m = GetObjectToWorldMatrix();
                float sx = length(float3(m._m00, m._m10, m._m20));
                float sy = length(float3(m._m01, m._m11, m._m21));

                OUT.halfSize = float2(sx, sy) * 0.5;
                OUT.p = (IN.uv * 2.0 - 1.0) * OUT.halfSize;
                return OUT;
            }

            half4 frag (Varyings IN) : SV_Target
            {
                // Нормированная координата: на границе эллипса length(q) = 1
                float2 q  = IN.p / IN.halfSize;
                float k0 = length(q);
                float k1 = length(IN.p / (IN.halfSize * IN.halfSize));

                // Расстояние до границы в мировых единицах (отрицательное — внутри).
                // При равных halfSize это точное значение: length(p) - R.
                float d = (k0 - 1.0) * k0 / max(k1, 1e-6);

                float halfT = _Thickness * 0.5;

                // Радиус средней линии кольца (для эллипса берём меньшую полуось)
                float R = max(min(IN.halfSize.x, IN.halfSize.y) - halfT, 1e-4);
                float circ = 6.2831853 * R;

                // Целое число штрихов, чтобы они замыкались без шва
                float period = max(_DashLength + _GapLength, 1e-4);
                float n = max(1.0, round(circ / period));
                float actualPeriod = circ / n;
                float dashLen = actualPeriod * (_DashLength / period);

                // Позиция вдоль дуги: 0 в центре штриха, в мировых единицах
                float t = atan2(IN.p.y, IN.p.x) / 6.2831853 + 0.5;
                float s = frac(t * n + _Offset);
                float u = (s - 0.5) * actualPeriod;

                // Расстояние до средней линии кольца (со знаком)
                float r = d + halfT;

                // Капсула со скруглёнными концами
                float ux = max(abs(u) - max(dashLen - _Thickness, 0.0) * 0.5, 0.0);
                float dist = length(float2(ux, r)) - halfT;

                // Сглаживание берём от d, а не от s (у frac и atan2 производные дают артефакты на стыках)
                float aa = max(fwidth(d) * _AA, 1e-6);
                float alpha = 1.0 - smoothstep(-aa, aa, dist);

                half4 col = _Color;
                col.a *= alpha;
                return col;
            }
            ENDHLSL
        }
    }
}
