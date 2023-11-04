// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "SpaceGen/Nebula_CG" {

	Properties {
	
		_Color ("Main Color", Color) = (1,1,1,1)
		_Color2 ("Main Color", Color) = (1,1,1,1)				
		_MainTex ("Nebula #1 (RGB)", 2D) = "black" {}
		_MainTex2 ("Nebula #2 (RGB)", 2D) = "black" {}
		_MainTex3 ("Nebula #1 (RGB)", 2D) = "white" {}
		_MainTex4 ("Nebula #2 (RGB)", 2D) = "black" {}

	}
	
	SubShader {
	
		Tags {"Queue"="Geometry-10"}
			
		Pass {

			zwrite off
			cull front
			blend one one
			
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
	
			struct v2f {
			
				half4 pos : SV_POSITION;
				half2 uv_MainTex : TEXCOORD0;
				half2 uv_MainTex2 : TEXCOORD1;
								
			};
		
			half4 _MainTex_ST;
			half4 _MainTex2_ST;
				
			v2f vert(appdata_base v) {
			
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv_MainTex = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.uv_MainTex2 = TRANSFORM_TEX(v.texcoord, _MainTex2);								
				return o;
				
			}
		
			sampler2D _MainTex;
			sampler2D _MainTex2;
			half4 _Color;		

			half4 frag(v2f IN) : COLOR {
			
				half4 t1 = tex2D (_MainTex, IN.uv_MainTex);
				half4 t2 = tex2D (_MainTex2, IN.uv_MainTex2);
				half4 c;
				c = t1 * t2 * _Color * 2;
				return c;
				
			}
			
			ENDCG
			
		}
		
		Pass {
		
			zwrite off
			cull front
			blend one one
			
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f {
			
				half4 pos : SV_POSITION;
				half2 uv_MainTex3 : TEXCOORD0;
				half2 uv_MainTex4 : TEXCOORD1;
														
			};
		
			half4 _MainTex3_ST;
			half4 _MainTex4_ST;
								
			v2f vert(appdata_full v) {
			
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv_MainTex3 = TRANSFORM_TEX(v.texcoord, _MainTex3);
				o.uv_MainTex4 = TRANSFORM_TEX(v.texcoord1, _MainTex4);								
				return o;
				
			}
		
			sampler2D _MainTex3;
			sampler2D _MainTex4;
			half4 _Color;		
			half4 _Color2;
						
			half4 frag(v2f IN) : COLOR {
			
				half4 t1 = tex2D (_MainTex3, IN.uv_MainTex3);
				half4 t2 = tex2D (_MainTex4, IN.uv_MainTex4);
				half4 c;
				c = t1 * t2 * 2 * _Color2;
				return c;
				
			}
			
			ENDCG
			
		}		
		
	}
	
}