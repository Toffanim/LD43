// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Light_Shader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_WorldPosition("Position", Vector) = (0, 0, 0, 0)
		_Size("Size", Float) = 0
		_Color("Color", Color) = (0,0,0,0)
	}
	SubShader
	{
		Tags {"Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 worldPos : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _WorldPosition;
			float _Size;
			float3 _Color; 
			
			v2f vert (appdata v)
			{
				v2f o;
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.vertex = UnityObjectToClipPos(v.vertex);

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
			    float dist = distance(i.worldPos, _WorldPosition);
				float alpha = saturate( 1 - (dist - _Size)) / 3.f;
				fixed4 col = fixed4(_Color, alpha);
				return col;
			}
			ENDCG
		}
	}
}
