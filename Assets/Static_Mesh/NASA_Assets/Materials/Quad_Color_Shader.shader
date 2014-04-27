// Shader created with Shader Forge Beta 0.31 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.31;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,hqsc:True,hqlp:False,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32240,y:32690|diff-117-OUT,spec-133-OUT,gloss-156-OUT;n:type:ShaderForge.SFN_ChannelBlend,id:117,x:32361,y:32275|M-135-OUT,R-118-RGB,G-120-RGB,B-122-RGB,A-124-RGB;n:type:ShaderForge.SFN_Color,id:118,x:32747,y:32207,ptlb:Color 1,ptin:_Color1,glob:False,c1:1,c2:0,c3:0,c4:0;n:type:ShaderForge.SFN_Color,id:120,x:32875,y:32356,ptlb:Color 2,ptin:_Color2,glob:False,c1:0,c2:1,c3:0,c4:0;n:type:ShaderForge.SFN_Color,id:122,x:32749,y:32491,ptlb:Color 3,ptin:_Color3,glob:False,c1:0,c2:0,c3:1,c4:0;n:type:ShaderForge.SFN_Color,id:124,x:32604,y:32569,ptlb:Color 4,ptin:_Color4,glob:False,c1:0.5,c2:0,c3:0.5,c4:1;n:type:ShaderForge.SFN_Tex2d,id:126,x:33080,y:31854,tex:a218b580352f84845ae45f90a10a98ca,ntxv:0,isnm:False|TEX-141-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:133,x:32786,y:32825|M-135-OUT,R-143-RGB,G-145-RGB,B-147-RGB,A-149-RGB;n:type:ShaderForge.SFN_Append,id:135,x:32869,y:31854|A-126-RGB,B-126-A;n:type:ShaderForge.SFN_Tex2dAsset,id:141,x:33080,y:31689,ptlb:Quad Shader IMG,ptin:_QuadShaderIMG,glob:False,tex:a218b580352f84845ae45f90a10a98ca;n:type:ShaderForge.SFN_Color,id:143,x:33105,y:32682,ptlb:Specular 1,ptin:_Specular1,glob:False,c1:1,c2:0.5,c3:0.5,c4:0;n:type:ShaderForge.SFN_Color,id:145,x:33210,y:32827,ptlb:Specular 2,ptin:_Specular2,glob:False,c1:0.5,c2:1,c3:0.5,c4:0;n:type:ShaderForge.SFN_Color,id:147,x:33210,y:33014,ptlb:Specular 3,ptin:_Specular3,glob:False,c1:0.5,c2:0.5,c3:1,c4:0;n:type:ShaderForge.SFN_Color,id:149,x:33056,y:33127,ptlb:Specular 4,ptin:_Specular4,glob:False,c1:0.75,c2:0.25,c3:0.75,c4:1;n:type:ShaderForge.SFN_ChannelBlend,id:156,x:32676,y:33064|M-135-OUT,R-143-A,G-145-A,B-147-A,A-149-A;proporder:141-118-143-120-145-122-147-124-149;pass:END;sub:END;*/

Shader "Custom/NewShader" {
    Properties {
        _QuadShaderIMG ("Quad Shader IMG", 2D) = "white" {}
        _Color1 ("Color 1", Color) = (1,0,0,0)
        _Specular1 ("Specular 1", Color) = (1,0.5,0.5,0)
        _Color2 ("Color 2", Color) = (0,1,0,0)
        _Specular2 ("Specular 2", Color) = (0.5,1,0.5,0)
        _Color3 ("Color 3", Color) = (0,0,1,0)
        _Specular3 ("Specular 3", Color) = (0.5,0.5,1,0)
        _Color4 ("Color 4", Color) = (0.5,0,0.5,1)
        _Specular4 ("Specular 4", Color) = (0.75,0.25,0.75,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "ForwardBase"
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
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float4 _Color3;
            uniform float4 _Color4;
            uniform sampler2D _QuadShaderIMG; uniform float4 _QuadShaderIMG_ST;
            uniform float4 _Specular1;
            uniform float4 _Specular2;
            uniform float4 _Specular3;
            uniform float4 _Specular4;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 uv0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.uv0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.xyz;
///////// Gloss:
                float2 node_161 = i.uv0;
                float4 node_126 = tex2D(_QuadShaderIMG,TRANSFORM_TEX(node_161.rg, _QuadShaderIMG));
                float4 node_135 = float4(node_126.rgb,node_126.a);
                float gloss = (node_135.r*_Specular1.a + node_135.g*_Specular2.a + node_135.b*_Specular3.a + node_135.a*_Specular4.a);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = (node_135.r*_Specular1.rgb + node_135.g*_Specular2.rgb + node_135.b*_Specular3.rgb + node_135.a*_Specular4.rgb);
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * (node_135.r*_Color1.rgb + node_135.g*_Color2.rgb + node_135.b*_Color3.rgb + node_135.a*_Color4.rgb);
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float4 _Color3;
            uniform float4 _Color4;
            uniform sampler2D _QuadShaderIMG; uniform float4 _QuadShaderIMG_ST;
            uniform float4 _Specular1;
            uniform float4 _Specular2;
            uniform float4 _Specular3;
            uniform float4 _Specular4;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 uv0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.uv0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float2 node_162 = i.uv0;
                float4 node_126 = tex2D(_QuadShaderIMG,TRANSFORM_TEX(node_162.rg, _QuadShaderIMG));
                float4 node_135 = float4(node_126.rgb,node_126.a);
                float gloss = (node_135.r*_Specular1.a + node_135.g*_Specular2.a + node_135.b*_Specular3.a + node_135.a*_Specular4.a);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = (node_135.r*_Specular1.rgb + node_135.g*_Specular2.rgb + node_135.b*_Specular3.rgb + node_135.a*_Specular4.rgb);
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * (node_135.r*_Color1.rgb + node_135.g*_Color2.rgb + node_135.b*_Color3.rgb + node_135.a*_Color4.rgb);
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
