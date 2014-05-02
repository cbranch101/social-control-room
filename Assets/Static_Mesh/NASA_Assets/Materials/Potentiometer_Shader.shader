// Shader created with Shader Forge Beta 0.31 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.31;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,hqsc:True,hqlp:False,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:1,fgcg:1,fgcb:1,fgca:1,fgde:0.03,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32323,y:32705|diff-25-OUT,spec-74-OUT,gloss-75-A,emission-90-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:32434,y:32273,tex:20e6f85748a67a547b32dcc414f9778c,ntxv:0,isnm:False|TEX-8-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8,x:33555,y:32432,ptlb:Potentiometer Gradient,ptin:_PotentiometerGradient,glob:False,tex:20e6f85748a67a547b32dcc414f9778c;n:type:ShaderForge.SFN_Tex2d,id:14,x:33020,y:33014,tex:20e6f85748a67a547b32dcc414f9778c,ntxv:0,isnm:False|TEX-8-TEX;n:type:ShaderForge.SFN_Multiply,id:25,x:32665,y:32421|A-2-RGB,B-27-RGB;n:type:ShaderForge.SFN_Color,id:27,x:32853,y:32421,ptlb:Bulb Darkness,ptin:_BulbDarkness,glob:False,c1:0.0627451,c2:0.0627451,c3:0.0627451,c4:1;n:type:ShaderForge.SFN_Multiply,id:33,x:32722,y:33016|A-14-RGB,B-39-OUT;n:type:ShaderForge.SFN_Tex2d,id:34,x:33444,y:33184,ptlb:Gradient,ptin:_Gradient,tex:e9a9781cad112c75d0008dfa8d76c639,ntxv:0,isnm:False|UVIN-36-UVOUT;n:type:ShaderForge.SFN_Rotator,id:36,x:33666,y:33184|UVIN-38-UVOUT,ANG-37-OUT;n:type:ShaderForge.SFN_Vector1,id:37,x:33905,y:33218,v1:1.57;n:type:ShaderForge.SFN_TexCoord,id:38,x:33717,y:33001,uv:0;n:type:ShaderForge.SFN_Step,id:39,x:33041,y:33184|A-34-RGB,B-53-OUT;n:type:ShaderForge.SFN_Slider,id:41,x:33444,y:33434,ptlb:Lights,ptin:_Lights,min:0,cur:0.5213675,max:1;n:type:ShaderForge.SFN_Posterize,id:53,x:33224,y:33433|IN-41-OUT,STPS-55-OUT;n:type:ShaderForge.SFN_Vector1,id:55,x:33450,y:33579,v1:9;n:type:ShaderForge.SFN_Multiply,id:74,x:32628,y:32736|A-2-RGB,B-75-RGB;n:type:ShaderForge.SFN_Color,id:75,x:32900,y:32784,ptlb:Bulb Specular,ptin:_BulbSpecular,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:90,x:32628,y:33146|A-33-OUT,B-92-OUT;n:type:ShaderForge.SFN_Slider,id:92,x:32665,y:33345,ptlb:Bulb Brightness,ptin:_BulbBrightness,min:0,cur:1,max:10;proporder:8-27-75-34-92-41;pass:END;sub:END;*/

Shader "Custom/Potentiometer_Shader" {
    Properties {
        _PotentiometerGradient ("Potentiometer Gradient", 2D) = "white" {}
        _BulbDarkness ("Bulb Darkness", Color) = (0.0627451,0.0627451,0.0627451,1)
        _BulbSpecular ("Bulb Specular", Color) = (0.5,0.5,0.5,1)
        _Gradient ("Gradient", 2D) = "white" {}
        _BulbBrightness ("Bulb Brightness", Range(0, 10)) = 1
        _Lights ("Lights", Range(0, 1)) = 0.5213675
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
            uniform sampler2D _PotentiometerGradient; uniform float4 _PotentiometerGradient_ST;
            uniform float4 _BulbDarkness;
            uniform sampler2D _Gradient; uniform float4 _Gradient_ST;
            uniform float _Lights;
            uniform float4 _BulbSpecular;
            uniform float _BulbBrightness;
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
                float2 node_106 = i.uv0;
                float node_36_ang = 1.57;
                float node_36_spd = 1.0;
                float node_36_cos = cos(node_36_spd*node_36_ang);
                float node_36_sin = sin(node_36_spd*node_36_ang);
                float2 node_36_piv = float2(0.5,0.5);
                float2 node_36 = (mul(i.uv0.rg-node_36_piv,float2x2( node_36_cos, -node_36_sin, node_36_sin, node_36_cos))+node_36_piv);
                float node_55 = 9.0;
                float3 emissive = ((tex2D(_PotentiometerGradient,TRANSFORM_TEX(node_106.rg, _PotentiometerGradient)).rgb*step(tex2D(_Gradient,TRANSFORM_TEX(node_36, _Gradient)).rgb,floor(_Lights * node_55) / (node_55 - 1)))*_BulbBrightness);
///////// Gloss:
                float gloss = _BulbSpecular.a;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float4 node_2 = tex2D(_PotentiometerGradient,TRANSFORM_TEX(node_106.rg, _PotentiometerGradient));
                float3 specularColor = (node_2.rgb*_BulbSpecular.rgb);
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * (node_2.rgb*_BulbDarkness.rgb);
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
            uniform sampler2D _PotentiometerGradient; uniform float4 _PotentiometerGradient_ST;
            uniform float4 _BulbDarkness;
            uniform sampler2D _Gradient; uniform float4 _Gradient_ST;
            uniform float _Lights;
            uniform float4 _BulbSpecular;
            uniform float _BulbBrightness;
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
                float gloss = _BulbSpecular.a;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float2 node_107 = i.uv0;
                float4 node_2 = tex2D(_PotentiometerGradient,TRANSFORM_TEX(node_107.rg, _PotentiometerGradient));
                float3 specularColor = (node_2.rgb*_BulbSpecular.rgb);
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * (node_2.rgb*_BulbDarkness.rgb);
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
