// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-8585-OUT,emission-8585-OUT;n:type:ShaderForge.SFN_Tex2d,id:2966,x:32127,y:32791,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_2966,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:09213581ec033d649beb747573a3322f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6030,x:32127,y:32986,ptovrint:False,ptlb:ScanLines,ptin:_ScanLines,varname:node_6030,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:82a48578e1e1ea44a87a813bfd2365a5,ntxv:0,isnm:False|UVIN-9946-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:1784,x:32127,y:33194,ptovrint:False,ptlb:Reticle,ptin:_Reticle,varname:node_1784,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e828a055addab6e4a9ca48dfe17f990d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:9066,x:32127,y:33386,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9066,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.7783019,c3:0.7783019,c4:1;n:type:ShaderForge.SFN_Add,id:8378,x:32351,y:32873,varname:node_8378,prsc:2|A-2966-RGB,B-1784-A;n:type:ShaderForge.SFN_Multiply,id:8585,x:32529,y:32991,varname:node_8585,prsc:2|A-8378-OUT,B-6199-OUT,C-9066-RGB;n:type:ShaderForge.SFN_Panner,id:9946,x:31865,y:33006,varname:node_9946,prsc:2,spu:0,spv:10|UVIN-933-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:933,x:31672,y:33049,varname:node_933,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:6199,x:32308,y:33027,varname:node_6199,prsc:2|A-6030-RGB,B-4721-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4721,x:32278,y:33175,ptovrint:False,ptlb:power,ptin:_power,varname:node_4721,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;proporder:2966-1784-6030-9066-4721;pass:END;sub:END;*/

Shader "Shader Forge/ScreenShader" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Reticle ("Reticle", 2D) = "white" {}
        _ScanLines ("ScanLines", 2D) = "white" {}
        _Color ("Color", Color) = (1,0.7783019,0.7783019,1)
        _power ("power", Float ) = 1.2
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _ScanLines; uniform float4 _ScanLines_ST;
            uniform sampler2D _Reticle; uniform float4 _Reticle_ST;
            uniform float4 _Color;
            uniform float _power;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _Reticle_var = tex2D(_Reticle,TRANSFORM_TEX(i.uv0, _Reticle));
                float4 node_8650 = _Time;
                float2 node_9946 = (i.uv0+node_8650.g*float2(0,10));
                float4 _ScanLines_var = tex2D(_ScanLines,TRANSFORM_TEX(node_9946, _ScanLines));
                float3 node_8585 = ((_MainTex_var.rgb+_Reticle_var.a)*(_ScanLines_var.rgb*_power)*_Color.rgb);
                float3 diffuseColor = node_8585;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = node_8585;
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _ScanLines; uniform float4 _ScanLines_ST;
            uniform sampler2D _Reticle; uniform float4 _Reticle_ST;
            uniform float4 _Color;
            uniform float _power;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _Reticle_var = tex2D(_Reticle,TRANSFORM_TEX(i.uv0, _Reticle));
                float4 node_3601 = _Time;
                float2 node_9946 = (i.uv0+node_3601.g*float2(0,10));
                float4 _ScanLines_var = tex2D(_ScanLines,TRANSFORM_TEX(node_9946, _ScanLines));
                float3 node_8585 = ((_MainTex_var.rgb+_Reticle_var.a)*(_ScanLines_var.rgb*_power)*_Color.rgb);
                float3 diffuseColor = node_8585;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
