// Shader created with Shader Forge Beta 0.31 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.31;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,hqsc:True,hqlp:False,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32328,y:32683|diff-2-RGB,spec-4-RGB,gloss-4-A,emission-131-OUT;n:type:ShaderForge.SFN_Color,id:2,x:32718,y:32480,ptlb:Screen Color Off,ptin:_ScreenColorOff,glob:False,c1:0.051,c2:0.01,c3:0.01,c4:1;n:type:ShaderForge.SFN_Color,id:4,x:32844,y:32647,ptlb:Specularity,ptin:_Specularity,glob:False,c1:0.6911765,c2:0.6454368,c3:0.6454368,c4:0.4941176;n:type:ShaderForge.SFN_Tex2d,id:5,x:33259,y:32702,ptlb:Screen Image,ptin:_ScreenImage,tex:efd7e021c4f31ee4894f0df711cc9a94,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:11,x:33158,y:33036,ptlb:Scan lines,ptin:_Scanlines,tex:f5f09cf8c1c80984dbf03fde029b55ae,ntxv:0,isnm:False|UVIN-41-UVOUT;n:type:ShaderForge.SFN_Add,id:12,x:32754,y:32872|A-227-OUT,B-28-OUT;n:type:ShaderForge.SFN_TexCoord,id:18,x:33808,y:33042,uv:0;n:type:ShaderForge.SFN_Multiply,id:28,x:32968,y:33036|A-11-RGB,B-30-OUT;n:type:ShaderForge.SFN_Slider,id:30,x:33136,y:33257,ptlb:Scan Lines Intensity,ptin:_ScanLinesIntensity,min:0,cur:0.1,max:1;n:type:ShaderForge.SFN_Panner,id:41,x:33357,y:33044,spu:1,spv:1|UVIN-18-UVOUT,DIST-81-OUT;n:type:ShaderForge.SFN_Time,id:70,x:33808,y:33498;n:type:ShaderForge.SFN_Multiply,id:81,x:33558,y:33362|A-198-OUT,B-70-T;n:type:ShaderForge.SFN_Subtract,id:131,x:32601,y:33071|A-12-OUT,B-139-OUT;n:type:ShaderForge.SFN_Tex2d,id:132,x:33392,y:33807,ptlb:Vignetting,ptin:_Vignetting,tex:4416db42cf2b3cd48a38e51a55ca0bd9,ntxv:0,isnm:False|UVIN-171-OUT;n:type:ShaderForge.SFN_OneMinus,id:133,x:33108,y:33808|IN-132-RGB;n:type:ShaderForge.SFN_Multiply,id:139,x:32848,y:33732|A-133-OUT,B-142-OUT;n:type:ShaderForge.SFN_Slider,id:142,x:33055,y:34020,ptlb:Vignetting Intensity,ptin:_VignettingIntensity,min:0,cur:0.9033077,max:1.25;n:type:ShaderForge.SFN_TexCoord,id:155,x:34021,y:33789,uv:0;n:type:ShaderForge.SFN_Multiply,id:156,x:33752,y:33806|A-155-UVOUT,B-157-OUT;n:type:ShaderForge.SFN_Vector1,id:157,x:34021,y:33998,v1:0.6;n:type:ShaderForge.SFN_Vector1,id:164,x:33769,y:34020,v1:0.2;n:type:ShaderForge.SFN_Add,id:171,x:33575,y:33806|A-156-OUT,B-164-OUT;n:type:ShaderForge.SFN_Exp,id:184,x:33947,y:33244,et:1|IN-213-OUT;n:type:ShaderForge.SFN_Subtract,id:198,x:33771,y:33277|A-184-OUT,B-199-OUT;n:type:ShaderForge.SFN_Vector1,id:199,x:33966,y:33421,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:213,x:34176,y:33186,ptlb:Scan Lines Speed,ptin:_ScanLinesSpeed,glob:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:227,x:33029,y:32775|A-5-RGB,B-228-OUT;n:type:ShaderForge.SFN_ValueProperty,id:228,x:33259,y:32884,ptlb:Screen Image Brightness,ptin:_ScreenImageBrightness,glob:False,v1:1.25;proporder:5-228-2-4-11-30-213-132-142;pass:END;sub:END;*/

Shader "Custom/Screen_Shader" {
    Properties {
        _ScreenImage ("Screen Image", 2D) = "white" {}
        _ScreenImageBrightness ("Screen Image Brightness", Float ) = 1.25
        _ScreenColorOff ("Screen Color Off", Color) = (0.051,0.01,0.01,1)
        _Specularity ("Specularity", Color) = (0.6911765,0.6454368,0.6454368,0.4941176)
        _Scanlines ("Scan lines", 2D) = "white" {}
        _ScanLinesIntensity ("Scan Lines Intensity", Range(0, 1)) = 0.1
        _ScanLinesSpeed ("Scan Lines Speed", Float ) = 1
        _Vignetting ("Vignetting", 2D) = "white" {}
        _VignettingIntensity ("Vignetting Intensity", Range(0, 1.25)) = 0.9033077
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
            uniform float4 _TimeEditor;
            uniform float4 _ScreenColorOff;
            uniform float4 _Specularity;
            uniform sampler2D _ScreenImage; uniform float4 _ScreenImage_ST;
            uniform sampler2D _Scanlines; uniform float4 _Scanlines_ST;
            uniform float _ScanLinesIntensity;
            uniform sampler2D _Vignetting; uniform float4 _Vignetting_ST;
            uniform float _VignettingIntensity;
            uniform float _ScanLinesSpeed;
            uniform float _ScreenImageBrightness;
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
////// Emissive:
                float2 node_236 = i.uv0;
                float4 node_70 = _Time + _TimeEditor;
                float2 node_41 = (i.uv0.rg+((exp2(_ScanLinesSpeed)-1.0)*node_70.g)*float2(1,1));
                float2 node_171 = ((i.uv0.rg*0.6)+0.2);
                float3 emissive = (((tex2D(_ScreenImage,TRANSFORM_TEX(node_236.rg, _ScreenImage)).rgb*_ScreenImageBrightness)+(tex2D(_Scanlines,TRANSFORM_TEX(node_41, _Scanlines)).rgb*_ScanLinesIntensity))-((1.0 - tex2D(_Vignetting,TRANSFORM_TEX(node_171, _Vignetting)).rgb)*_VignettingIntensity));
///////// Gloss:
                float gloss = _Specularity.a;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = _Specularity.rgb;
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * _ScreenColorOff.rgb;
                finalColor += specular;
                finalColor += emissive;
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
            uniform float4 _TimeEditor;
            uniform float4 _ScreenColorOff;
            uniform float4 _Specularity;
            uniform sampler2D _ScreenImage; uniform float4 _ScreenImage_ST;
            uniform sampler2D _Scanlines; uniform float4 _Scanlines_ST;
            uniform float _ScanLinesIntensity;
            uniform sampler2D _Vignetting; uniform float4 _Vignetting_ST;
            uniform float _VignettingIntensity;
            uniform float _ScanLinesSpeed;
            uniform float _ScreenImageBrightness;
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
                float gloss = _Specularity.a;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = _Specularity.rgb;
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * _ScreenColorOff.rgb;
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
