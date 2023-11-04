// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "SpaceGen/CloudsClusters_CG" {

	Properties {
	
		_Tint1 ("Cloud tint", Color) = (1,1,1,1)
		_Tint2 ("Cluster tint", Color) = (1,1,1,1)				
		_Cloud1 ("Cloud #1", 2D) = "black" {}
		_Cloud2 ("Cloud #2", 2D) = "black" {}
		_ClusterMask ("Cluster mask #1", 2D) = "white" {}
		_ClusterMask2 ("Cluster mask #2", 2D) = "white" {}				
		_Stars ("Cluster stars", 2D) = "black" {}

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
				half2 uv_Cloud1 : TEXCOORD0;
				half2 uv_Cloud2 : TEXCOORD1;
								
			};
		
			half4 _Cloud1_ST;
			half4 _Cloud2_ST;
				
			v2f vert(appdata_base v) {
			
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv_Cloud1 = TRANSFORM_TEX(v.texcoord, _Cloud1);
				o.uv_Cloud2 = TRANSFORM_TEX(v.texcoord, _Cloud2);								
				return o;
				
			}
		
			sampler2D _Cloud1;
			sampler2D _Cloud2;
			half4 _Tint1;		

			half4 frag(v2f IN) : COLOR {
			
				half4 t1 = tex2D (_Cloud1, IN.uv_Cloud1);
				half4 t2 = tex2D (_Cloud2, IN.uv_Cloud2);
				half4 c;
				c = t1 * t2 * _Tint1 * 2;
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
				half2 uv_ClusterMask : TEXCOORD0;
				half2 uv_Stars : TEXCOORD1;
														
			};
		
			half4 _ClusterMask_ST;
			half4 _Stars_ST;
								
			v2f vert(appdata_full v) {
			
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv_ClusterMask = TRANSFORM_TEX(v.texcoord, _ClusterMask);
				o.uv_Stars = TRANSFORM_TEX(v.texcoord1, _Stars);								
				return o;
				
			}
		
			sampler2D _ClusterMask;
			sampler2D _ClusterMask2;				
			sampler2D _Stars;
			half4 _Tint1;		
			half4 _Tint2;
						
			half4 frag(v2f IN) : COLOR {
			
				half4 t1 = tex2D (_ClusterMask, IN.uv_ClusterMask);
				half4 t2 = tex2D (_ClusterMask2, IN.uv_ClusterMask);
				half4 t3 = tex2D (_Stars, IN.uv_Stars);
				half4 c;
				c = (t1 + t2) * t3 * 2 * _Tint2;
				return c;
				
			}
			
			ENDCG
			
		}		
		
	}
	
}