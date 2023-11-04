// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "SpaceGen/Stars_CG" {

	Properties {
	
		_Tint ("Tint", Color) = (1,1,1,1)
		_Stars1 ("Small stars", 2D) = "black" {}
		_Stars2 ("Big stars", 2D) = "black" {}

	}
	
	SubShader {
	
		Tags {"Queue"="Geometry-20" }
		 
		Pass {
		
			zwrite off
			cull front
			
			CGPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f {
			
				half4 pos : SV_POSITION;
				half2 uv_Stars1 : TEXCOORD0;
				half2 uv_Stars2 : TEXCOORD1;
														
			};
		
			half4 _Stars1_ST;
			half4 _Stars2_ST;
								
			v2f vert(appdata_base v) {
			
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv_Stars1 = TRANSFORM_TEX(v.texcoord, _Stars1);
				o.uv_Stars2 = TRANSFORM_TEX(v.texcoord, _Stars2);								
				return o;
				
			}
		
			sampler2D _Stars1;
			sampler2D _Stars2;
			half4 _Tint;		
			
			half4 frag(v2f IN) : COLOR {
			
				half4 t1 = tex2D (_Stars1, IN.uv_Stars1);
				half4 t2 = tex2D (_Stars2, IN.uv_Stars2);
				half4 c;
				c = ( t1 + t2 ) * _Tint * 2;
				return c;
				
			}
			
			ENDCG
			
		}

	}
	
}