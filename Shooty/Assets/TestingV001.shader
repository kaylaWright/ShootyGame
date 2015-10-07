// Shader created with Shader Forge v1.18 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.18;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:2865,x:33416,y:32435,varname:node_2865,prsc:2|diff-5232-RGB,spec-9363-OUT,gloss-2415-OUT,emission-8352-OUT,clip-7177-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:3318,x:31967,y:32643,ptovrint:False,ptlb:DissolveRamp,ptin:_DissolveRamp,varname:node_3318,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b1d7fee26e54cc3498f6267f072a45b9,ntxv:2,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:875,x:31721,y:32387,varname:node_875,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:5971,x:31917,y:32387,varname:node_5971,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-875-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:8163,x:32077,y:32405,varname:node_8163,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-5971-OUT;n:type:ShaderForge.SFN_ArcTan2,id:9009,x:32265,y:32405,varname:node_9009,prsc:2,attp:2|A-8163-G,B-8163-R;n:type:ShaderForge.SFN_Append,id:2368,x:32494,y:32405,varname:node_2368,prsc:2|A-5821-OUT,B-9009-OUT;n:type:ShaderForge.SFN_Vector1,id:8104,x:32301,y:32328,varname:node_8104,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:5441,x:32020,y:33048,ptovrint:False,ptlb:DIssolve Scatter Map,ptin:_DIssolveScatterMap,varname:node_5441,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:3558,x:31460,y:32843,ptovrint:False,ptlb:Dissolve Amount,ptin:_DissolveAmount,varname:node_3558,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:7177,x:32281,y:33011,varname:node_7177,prsc:2|A-290-OUT,B-5441-R;n:type:ShaderForge.SFN_RemapRange,id:290,x:32020,y:32845,varname:node_290,prsc:2,frmn:0,frmx:1,tomn:-0.76,tomx:0.7|IN-1701-OUT;n:type:ShaderForge.SFN_OneMinus,id:1701,x:31811,y:32845,varname:node_1701,prsc:2|IN-3558-OUT;n:type:ShaderForge.SFN_RemapRange,id:9388,x:32439,y:32838,varname:node_9388,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-7177-OUT;n:type:ShaderForge.SFN_Clamp01,id:9943,x:32636,y:32822,varname:node_9943,prsc:2|IN-9388-OUT;n:type:ShaderForge.SFN_OneMinus,id:5821,x:32636,y:32670,varname:node_5821,prsc:2|IN-9943-OUT;n:type:ShaderForge.SFN_Tex2d,id:5232,x:32964,y:32191,ptovrint:False,ptlb:DiffuseMap,ptin:_DiffuseMap,varname:node_5232,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aa75035ee2dffa446b6a4afc3b531f9d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:9363,x:32982,y:32381,varname:node_9363,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2415,x:33008,y:32453,varname:node_2415,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:563,x:32732,y:32409,varname:node_563,prsc:2,tex:b1d7fee26e54cc3498f6267f072a45b9,ntxv:0,isnm:False|UVIN-2368-OUT,TEX-3318-TEX;n:type:ShaderForge.SFN_Tex2d,id:5647,x:32210,y:32739,varname:node_5647,prsc:2,tex:b1d7fee26e54cc3498f6267f072a45b9,ntxv:0,isnm:False|TEX-3318-TEX;n:type:ShaderForge.SFN_Multiply,id:9371,x:32439,y:32659,varname:node_9371,prsc:2|A-6763-RGB,B-5647-RGB;n:type:ShaderForge.SFN_Color,id:6763,x:32199,y:32587,ptovrint:False,ptlb:DissolveColour,ptin:_DissolveColour,varname:node_6763,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:4005,x:32920,y:32542,varname:node_4005,prsc:2|A-563-RGB,B-9371-OUT;n:type:ShaderForge.SFN_Tex2d,id:2450,x:32979,y:32732,ptovrint:False,ptlb:EmissiveTex,ptin:_EmissiveTex,varname:node_2450,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:60e68bc59110eeb46a9a182a7e8d3a5e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:8352,x:33133,y:32558,varname:node_8352,prsc:2|A-4005-OUT,B-9-OUT;n:type:ShaderForge.SFN_Slider,id:6069,x:32839,y:32931,ptovrint:False,ptlb:EmiisivePower,ptin:_EmiisivePower,varname:node_6069,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Multiply,id:9,x:33176,y:32749,varname:node_9,prsc:2|A-2450-RGB,B-6069-OUT;proporder:5441-3558-3318-5232-6763-2450-6069;pass:END;sub:END;*/

Shader "Shader Forge/TestingV001" {
    Properties {
        _DIssolveScatterMap ("DIssolve Scatter Map", 2D) = "white" {}
        _DissolveAmount ("Dissolve Amount", Range(0, 1)) = 0
        _DissolveRamp ("DissolveRamp", 2D) = "black" {}
        _DiffuseMap ("DiffuseMap", 2D) = "white" {}
        _DissolveColour ("DissolveColour", Color) = (1,0,0,1)
        _EmissiveTex ("EmissiveTex", 2D) = "white" {}
        _EmiisivePower ("EmiisivePower", Range(0, 10)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _DissolveRamp; uniform float4 _DissolveRamp_ST;
            uniform sampler2D _DIssolveScatterMap; uniform float4 _DIssolveScatterMap_ST;
            uniform float _DissolveAmount;
            uniform sampler2D _DiffuseMap; uniform float4 _DiffuseMap_ST;
            uniform float4 _DissolveColour;
            uniform sampler2D _EmissiveTex; uniform float4 _EmissiveTex_ST;
            uniform float _EmiisivePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _DIssolveScatterMap_var = tex2D(_DIssolveScatterMap,TRANSFORM_TEX(i.uv0, _DIssolveScatterMap));
                float node_7177 = (((1.0 - _DissolveAmount)*1.46+-0.76)+_DIssolveScatterMap_var.r);
                clip(node_7177 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _DiffuseMap_var = tex2D(_DiffuseMap,TRANSFORM_TEX(i.uv0, _DiffuseMap));
                float3 diffuseColor = _DiffuseMap_var.rgb; // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, 0.0, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float2 node_8163 = (i.uv0*2.0+-1.0).rg;
                float2 node_2368 = float2((1.0 - saturate((node_7177*8.0+-4.0))),((atan2(node_8163.g,node_8163.r)/6.28318530718)+0.5));
                float4 node_563 = tex2D(_DissolveRamp,TRANSFORM_TEX(node_2368, _DissolveRamp));
                float4 node_5647 = tex2D(_DissolveRamp,TRANSFORM_TEX(i.uv0, _DissolveRamp));
                float3 node_4005 = (node_563.rgb*(_DissolveColour.rgb*node_5647.rgb));
                float4 _EmissiveTex_var = tex2D(_EmissiveTex,TRANSFORM_TEX(i.uv0, _EmissiveTex));
                float3 emissive = (node_4005+(_EmissiveTex_var.rgb*_EmiisivePower));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _DissolveRamp; uniform float4 _DissolveRamp_ST;
            uniform sampler2D _DIssolveScatterMap; uniform float4 _DIssolveScatterMap_ST;
            uniform float _DissolveAmount;
            uniform sampler2D _DiffuseMap; uniform float4 _DiffuseMap_ST;
            uniform float4 _DissolveColour;
            uniform sampler2D _EmissiveTex; uniform float4 _EmissiveTex_ST;
            uniform float _EmiisivePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _DIssolveScatterMap_var = tex2D(_DIssolveScatterMap,TRANSFORM_TEX(i.uv0, _DIssolveScatterMap));
                float node_7177 = (((1.0 - _DissolveAmount)*1.46+-0.76)+_DIssolveScatterMap_var.r);
                clip(node_7177 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _DiffuseMap_var = tex2D(_DiffuseMap,TRANSFORM_TEX(i.uv0, _DiffuseMap));
                float3 diffuseColor = _DiffuseMap_var.rgb; // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, 0.0, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _DIssolveScatterMap; uniform float4 _DIssolveScatterMap_ST;
            uniform float _DissolveAmount;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _DIssolveScatterMap_var = tex2D(_DIssolveScatterMap,TRANSFORM_TEX(i.uv0, _DIssolveScatterMap));
                float node_7177 = (((1.0 - _DissolveAmount)*1.46+-0.76)+_DIssolveScatterMap_var.r);
                clip(node_7177 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _DissolveRamp; uniform float4 _DissolveRamp_ST;
            uniform sampler2D _DIssolveScatterMap; uniform float4 _DIssolveScatterMap_ST;
            uniform float _DissolveAmount;
            uniform sampler2D _DiffuseMap; uniform float4 _DiffuseMap_ST;
            uniform float4 _DissolveColour;
            uniform sampler2D _EmissiveTex; uniform float4 _EmissiveTex_ST;
            uniform float _EmiisivePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 _DIssolveScatterMap_var = tex2D(_DIssolveScatterMap,TRANSFORM_TEX(i.uv0, _DIssolveScatterMap));
                float node_7177 = (((1.0 - _DissolveAmount)*1.46+-0.76)+_DIssolveScatterMap_var.r);
                float2 node_8163 = (i.uv0*2.0+-1.0).rg;
                float2 node_2368 = float2((1.0 - saturate((node_7177*8.0+-4.0))),((atan2(node_8163.g,node_8163.r)/6.28318530718)+0.5));
                float4 node_563 = tex2D(_DissolveRamp,TRANSFORM_TEX(node_2368, _DissolveRamp));
                float4 node_5647 = tex2D(_DissolveRamp,TRANSFORM_TEX(i.uv0, _DissolveRamp));
                float3 node_4005 = (node_563.rgb*(_DissolveColour.rgb*node_5647.rgb));
                float4 _EmissiveTex_var = tex2D(_EmissiveTex,TRANSFORM_TEX(i.uv0, _EmissiveTex));
                o.Emission = (node_4005+(_EmissiveTex_var.rgb*_EmiisivePower));
                
                float4 _DiffuseMap_var = tex2D(_DiffuseMap,TRANSFORM_TEX(i.uv0, _DiffuseMap));
                float3 diffColor = _DiffuseMap_var.rgb;
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0.0, specColor, specularMonochrome );
                float roughness = 1.0 - 0.5;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
