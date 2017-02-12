// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/Curvature" {
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Offset("Offset", Vector) = (0,0,0,0)
		_Distance("Distance", Float) = 0.0
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"
	}

	Pass
	{
		
		CGPROGRAM
		#pragma vertex vertex
		#pragma fragment fragment
		#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
		uniform float4 _Offset;
		uniform float _Distance;

		struct VertexComposition {
			float4 pos : SV_POSITION;
			float4 uv : TEXCOORD0;
		};

		VertexComposition vertex(appdata_base v)
		{
			VertexComposition vc;
			float4 vertexPosition = mul(UNITY_MATRIX_MV, v.vertex);
			float z = vertexPosition.z / _Distance;
			vertexPosition += _Offset*z*z;
			vc.pos = mul(UNITY_MATRIX_P, vertexPosition);
			vc.uv = v.texcoord;
			return vc;
		}

		half4 fragment(VertexComposition v) : COLOR
		{
			half4 result = tex2D(_MainTex, v.uv.xy);
			return result;
		}

		ENDCG
	}
}
		FallBack "Diffuse"
}