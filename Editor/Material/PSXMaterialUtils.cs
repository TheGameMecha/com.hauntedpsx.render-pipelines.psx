using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;
using UnityEngine.Experimental.Rendering;
using HauntedPSX.RenderPipelines.PSX.Runtime;

namespace HauntedPSX.RenderPipelines.PSX.Editor
{
    public static class PSXMaterialUtils
    {
        public enum RenderQueueCategory
        {
            Main = 0,
            Background,
            UIOverlay
        }

        public enum LightingMode
        {
            Lit = 0,
            Unlit
        }

        public enum ShadingEvaluationMode
        {
            PerVertex = 0,
            PerPixel
        }

        public enum SurfaceType
        {
            Opaque,
            Transparent
        }

        public enum BlendMode
        {
            AlphaPostmultiply, // Old school alpha-blending mode.
            AlphaPremultiply, // Physically plausible transparency mode, implemented as alpha pre-multiply
            Additive,
            Multiply,
            Subtractive
        }

        public enum VertexColorMode
        {
            Disabled = 0,
            Color,
            Lighting
        }

        public enum RenderFace
        {
            Front = 2,
            Back = 1,
            Both = 0
        }

        public enum ReflectionBlendMode
        {
            Additive = 0,
            Subtractive,
            Multiply
        }

        public static class Tags
        {
            public static readonly string RenderType = "RenderType";
            public static readonly string Opaque = "Opaque";
            public static readonly string TransparentCutout = "TransparentCutout";
            public static readonly string Transparent = "Transparent";
        }

        public static class PropertyNames
        {
            public static readonly string _VertexColorMode = "_VertexColorMode";
            public static readonly string _RenderQueueCategory = "_RenderQueueCategory";
            public static readonly string _LightingMode = "_LightingMode";
            public static readonly string _LightingBaked = "_LightingBaked";
            public static readonly string _LightingDynamic = "_LightingDynamic";
            public static readonly string _ShadingEvaluationMode = "_ShadingEvaluationMode";
            public static readonly string _Surface = "_Surface";
            public static readonly string _Blend = "_Blend";
            public static readonly string _Cull = "_Cull";
            public static readonly string _BlendOp = "_BlendOp";
            public static readonly string _SrcBlend = "_SrcBlend";
            public static readonly string _DstBlend = "_DstBlend";
            public static readonly string _ZWrite = "_ZWrite";
            public static readonly string _AlphaClip = "_AlphaClip";
            public static readonly string _AlphaClippingDitherIsEnabled = "_AlphaClippingDitherIsEnabled";
            public static readonly string _AffineTextureWarpingWeight = "_AffineTextureWarpingWeight";
            public static readonly string _PrecisionGeometryWeight = "_PrecisionGeometryWeight";
            public static readonly string _FogWeight = "_FogWeight";
            public static readonly string _Cutoff = "_Cutoff";
            public static readonly string _ReceiveShadows = "_ReceiveShadows";
            public static readonly string _MainTex = "_MainTex";
            public static readonly string _MainColor = "_MainColor";
            public static readonly string _EmissionTexture = "_EmissionTexture";
            public static readonly string _EmissionColor = "_EmissionColor";
            public static readonly string _EmissionBakedMultiplier = "_EmissionBakedMultiplier";
            public static readonly string _Reflection = "_Reflection";
            public static readonly string _ReflectionCubemap = "_ReflectionCubemap";
            public static readonly string _ReflectionTexture = "_ReflectionTexture";
            public static readonly string _ReflectionColor = "_ReflectionColor";
            public static readonly string _ReflectionBlendMode = "_ReflectionBlendMode";
        }

        public static class PropertyIDs
        {
            public static readonly int _VertexColorMode = Shader.PropertyToID(PropertyNames._VertexColorMode);
            public static readonly int _RenderQueueCategory = Shader.PropertyToID(PropertyNames._RenderQueueCategory);
            public static readonly int _LightingMode = Shader.PropertyToID(PropertyNames._LightingMode);
            public static readonly int _LightingBaked = Shader.PropertyToID(PropertyNames._LightingBaked);
            public static readonly int _LightingDynamic = Shader.PropertyToID(PropertyNames._LightingDynamic);
            public static readonly int _ShadingEvaluationMode = Shader.PropertyToID(PropertyNames._ShadingEvaluationMode);
            public static readonly int _Surface = Shader.PropertyToID(PropertyNames._Surface);
            public static readonly int _Blend = Shader.PropertyToID(PropertyNames._Blend);
            public static readonly int _Cull = Shader.PropertyToID(PropertyNames._Cull);
            public static readonly int _BlendOp = Shader.PropertyToID(PropertyNames._BlendOp);
            public static readonly int _SrcBlend = Shader.PropertyToID(PropertyNames._SrcBlend);
            public static readonly int _DstBlend = Shader.PropertyToID(PropertyNames._DstBlend);
            public static readonly int _ZWrite = Shader.PropertyToID(PropertyNames._ZWrite);
            public static readonly int _AlphaClip = Shader.PropertyToID(PropertyNames._AlphaClip);
            public static readonly int _AlphaClippingDitherIsEnabled = Shader.PropertyToID(PropertyNames._AlphaClippingDitherIsEnabled);
            public static readonly int _AffineTextureWarpingWeight = Shader.PropertyToID(PropertyNames._AffineTextureWarpingWeight);
            public static readonly int _PrecisionGeometryWeight = Shader.PropertyToID(PropertyNames._PrecisionGeometryWeight);
            public static readonly int _FogWeight = Shader.PropertyToID(PropertyNames._FogWeight);
            public static readonly int _Cutoff = Shader.PropertyToID(PropertyNames._Cutoff);
            public static readonly int _ReceiveShadows = Shader.PropertyToID(PropertyNames._ReceiveShadows);
            public static readonly int _MainTex = Shader.PropertyToID(PropertyNames._MainTex);
            public static readonly int _MainColor = Shader.PropertyToID(PropertyNames._MainColor);
            public static readonly int _EmissionTexture = Shader.PropertyToID(PropertyNames._EmissionTexture);
            public static readonly int _EmissionColor = Shader.PropertyToID(PropertyNames._EmissionColor);
            public static readonly int _EmissionBakedMultiplier = Shader.PropertyToID(PropertyNames._EmissionBakedMultiplier);
            public static readonly int _Reflection = Shader.PropertyToID(PropertyNames._Reflection);
            public static readonly int _ReflectionCubemap = Shader.PropertyToID(PropertyNames._ReflectionCubemap);
            public static readonly int _ReflectionTexture = Shader.PropertyToID(PropertyNames._ReflectionTexture);
            public static readonly int _ReflectionColor = Shader.PropertyToID(PropertyNames._ReflectionColor);
            public static readonly int _ReflectionBlendMode = Shader.PropertyToID(PropertyNames._ReflectionBlendMode);
        }

        public static class LegacyPropertyNames
        {
            public static readonly string _EmissiveColor = "_EmissiveColor";
            public static readonly string _EmissionEnabled = "_EmissionEnabled";
        }

        public static class LegacyPropertyIDs
        {
            public static readonly int _EmissiveColor = Shader.PropertyToID(LegacyPropertyNames._EmissiveColor);
            public static readonly int _EmissionEnabled = Shader.PropertyToID(LegacyPropertyNames._EmissionEnabled);
        }

        public static class Keywords
        {
            public static readonly string _VERTEX_COLOR_MODE_COLOR = "_VERTEX_COLOR_MODE_COLOR";
            public static readonly string _VERTEX_COLOR_MODE_LIGHTING = "_VERTEX_COLOR_MODE_LIGHTING";
            public static readonly string _LIGHTING_BAKED_ON = "_LIGHTING_BAKED_ON";
            public static readonly string _LIGHTING_DYNAMIC_ON = "_LIGHTING_DYNAMIC_ON";
            public static readonly string _SHADING_EVALUATION_MODE_PER_VERTEX = "_SHADING_EVALUATION_MODE_PER_VERTEX";
            public static readonly string _SHADING_EVALUATION_MODE_PER_PIXEL = "_SHADING_EVALUATION_MODE_PER_PIXEL";
            public static readonly string _EMISSION = "_EMISSION";
            public static readonly string _ALPHATEST_ON = "_ALPHATEST_ON";
            public static readonly string _ALPHAPREMULTIPLY_ON = "_ALPHAPREMULTIPLY_ON";
            public static readonly string _ALPHAMODULATE_ON = "_ALPHAMODULATE_ON";
            public static readonly string _REFLECTION_ON = "_REFLECTION_ON";
            public static readonly string _FOG_ON = "_FOG_ON";
        }

        public static class Styles
        {
            // Categories
            public static readonly GUIContent SurfaceOptions =
                new GUIContent("Surface Options", "Controls how HPSXRP renders the Material on a screen.");

            public static readonly GUIContent SurfaceInputs = new GUIContent("Surface Inputs",
                "These settings describe the look and feel of the surface itself.");

            public static readonly GUIContent AdvancedLabel = new GUIContent("Advanced",
                "These settings affect behind-the-scenes rendering and underlying calculations.");

            public static readonly GUIContent VertexColorMode = new GUIContent("Vertex Color Mode",
                "Controls how vertex colors are interpreted by the shader. VertexColorMode.Color multiplies the vertex color data with the MainTex value. This is useful for adding variation to the MainTex color per vertex, such as in a particle sim. VertexColorMode.Lighting interprets the vertexColor data as per-vertex lighting. The result will be added to other lighting that may be present.");

            public static readonly GUIContent RenderQueueCategory =
                new GUIContent("Render Queue Category", "Controls when this object is rendered.\nMaterials set to Background are rendered first.\nMaterials set to Main are rendered second.\nMaterials set to UIOverlay are rendered last.\nThe CameraVolume override controls whether or not the depth buffer will be cleared between these stages.");

            public static readonly GUIContent LightingMode =
                new GUIContent("Lighting Mode", "Controls whether or not lighting is evaluated.");

            public static readonly GUIContent LightingBaked =
                new GUIContent("Baked Lighting Enabled", "Controls whether or not baked lighting is sampled from lightmaps and probes.");

            public static readonly GUIContent LightingVertexColor =
                new GUIContent("Vertex Color Lighting Enabled", "Controls whether or not lighting is sampled from vertex color data.");

            public static readonly GUIContent LightingDynamic =
                new GUIContent("Dynamic Lighting Enabled", "Controls whether or not lighting is evaluated from realtime light sources.");

            public static readonly GUIContent ShadingEvaluationMode =
                new GUIContent("Shading Evaluation Mode", "Controls whether shading is evaluated per vertex or per pixel. This includes lighting, and fog.");

            public static readonly GUIContent surfaceType = new GUIContent("Surface Type",
                "Select a surface type for your texture. Choose between Opaque or Transparent.");

            public static readonly GUIContent blendingMode = new GUIContent("Blending Mode",
                "Controls how the color of the Transparent surface blends with the Material color in the background.");

            public static readonly GUIContent cullingText = new GUIContent("Render Face",
                "Specifies which faces to cull from your geometry. Front culls front faces. Back culls backfaces. None means that both sides are rendered.");

            public static readonly GUIContent alphaClipText = new GUIContent("Alpha Clipping",
                "Makes your Material act like a Cutout shader. Use this to create a transparent effect with hard edges between opaque and transparent areas.");

            public static readonly GUIContent alphaClippingDitherText = new GUIContent("Alpha Clipping Dither",
                "Makes your Material Cutout use the dither pattern specified in PSXRenderPipelineResources. Use this to create a transparent effect with approximate smooth transparency. The results are noiser than true transparency, but does not suffer from sorting problems.");

            public static readonly GUIContent affineTextureWarpingWeight = new GUIContent("Affine Texture Warping Weight",
                "Allows you to decrease the amount of affine texture warping on your material. A value of 1.0 results in no change, and simply uses the Affine Texture Warping parameter from the Volume System. A value of 0.0 results in no affine texture warping. A value of 0.5 results in 50% of the affine texture warping from the Volume System.");

            public static readonly GUIContent precisionGeometryWeight = new GUIContent("Precision Geometry Weight",
                "Allows you to decrease the amount of vertex snapping on your material. A value of 1.0 results in no change, and simply uses the PrecisionVolume.Geometry parameter from the Volume System. A value of 0.0 results in no vertex snapping. A value of 0.5 results in 50% blend between vertex snapping from the Volume System, and no vertex snapping.");

            public static readonly GUIContent fogWeight = new GUIContent("Fog Weight",
                "Specifies how much of the global Fog Volume is applied to this surface. In general this should be left at 1.0. Set to 0.0 to fully disable fog (and which avoids cost of evaluating fog). This parameter is particularly useful for tuning the look of skybox geometry.");

            public static readonly GUIContent mainTex = new GUIContent("Main Tex",
                "Specifies the base Material and/or Color of the surface. If you’ve selected Transparent or Alpha Clipping under Surface Options, your Material uses the Texture’s alpha channel or color.");

            public static readonly GUIContent emissionTex = new GUIContent("Emission Map",
                "Sets a Texture map to use for emission. You can also select a color with the color picker. Colors are multiplied over the Texture.");

            public static readonly GUIContent emissionBakedMultiplier = new GUIContent("Emission Baked Multiplier",
                "Multiplier for artificially increasing or decreasing emission intensity when captured in baked lighting. In general, this should kept at 1.0. Increasing or decreasing this value is not physically plausible. Values other than 1.0 can be useful when fine tuning the amount of light an emissive surface emits in the bake, without affecting the way the emissive surface appears.");
        
            public static readonly GUIContent reflection = new GUIContent("Reflection",
                "Specifies whether or not to apply cubemap reflections. Turn off when not in use to avoid performance cost.");

            public static readonly GUIContent reflectionCubemap = new GUIContent("Reflection Cubemap",
                "Specifies the cubemap used to simulate incoming reflections from the environment.");

            public static readonly GUIContent reflectionTexture = new GUIContent("Reflection Map",
                "Sets a Texture map to use for controlling how reflective the surface is. You can also select a color with the color picker. Colors are multiplied over the Texture.");

            public static readonly GUIContent reflectionBlendMode = new GUIContent("Reflection Blend Mode",
                "Controls how reflections are blending with other incoming light at the surface. Additive is the standard, physically-based approach. Subtractive and Multiply blend modes are for special effects.");
        }

        // Copied from shaderGUI as it is a protected function in an abstract class, unavailable to others
        public static MaterialProperty FindProperty(string propertyName, MaterialProperty[] properties)
        {
            return FindProperty(propertyName, properties, true);
        }

        // Copied from shaderGUI as it is a protected function in an abstract class, unavailable to others
        public static MaterialProperty FindProperty(string propertyName, MaterialProperty[] properties, bool propertyIsMandatory)
        {
            for (int index = 0; index < properties.Length; ++index)
            {
                if (properties[index] != null && properties[index].name == propertyName)
                    return properties[index];
            }
            if (propertyIsMandatory)
                throw new ArgumentException("Could not find MaterialProperty: '" + propertyName + "', Num properties: " + (object) properties.Length);
            return null;
        }

        public static void SetMaterialKeywords(Material material)
        {
            // Clear all keywords for fresh start
            ClearMaterialKeywords(material);

            SetupMaterialLightingMode(material);
            SetupMaterialShadingEvaluationMode(material);
            SetupMaterialBlendMode(material);
            SetupMaterialFogKeyword(material);
            SetupMaterialReflectionKeyword(material);
            SetupMaterialEmissionKeyword(material);
        }

        public static void ClearMaterialKeywords(Material material)
        {
            material.shaderKeywords = null;
        }

        public static void SetupMaterialEmissionKeyword(Material material)
        {
            if (material.HasProperty(LegacyPropertyIDs._EmissiveColor)) { MaterialEditor.FixupEmissiveFlag(material); }

            bool shouldEmissionBeEnabled = (material.globalIlluminationFlags & MaterialGlobalIlluminationFlags.EmissiveIsBlack) == 0;
            if (material.HasProperty(LegacyPropertyIDs._EmissionEnabled) && !shouldEmissionBeEnabled)
                shouldEmissionBeEnabled = material.GetFloat(LegacyPropertyIDs._EmissionEnabled) >= 0.5f;

            CoreUtils.SetKeyword(material, Keywords._EMISSION, shouldEmissionBeEnabled);
        }

        public static void SetupMaterialShadingEvaluationMode(Material material)
        {
            if (material == null) { throw new ArgumentNullException("material"); }
                
            ShadingEvaluationMode shadingEvaluationMode = (ShadingEvaluationMode)material.GetFloat(PropertyIDs._ShadingEvaluationMode);

            switch (shadingEvaluationMode)
            {
                case ShadingEvaluationMode.PerVertex:
                    material.EnableKeyword(Keywords._SHADING_EVALUATION_MODE_PER_VERTEX);
                    material.DisableKeyword(Keywords._SHADING_EVALUATION_MODE_PER_PIXEL);
                    break;
                case ShadingEvaluationMode.PerPixel:
                    material.DisableKeyword(Keywords._SHADING_EVALUATION_MODE_PER_VERTEX);
                    material.EnableKeyword(Keywords._SHADING_EVALUATION_MODE_PER_PIXEL);
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }   
        }

        public static void SetupMaterialLightingMode(Material material, bool vertexColorSupported = true)
        {
            if (material == null)
                throw new ArgumentNullException("material");
                
            LightingMode lightingMode = (LightingMode)material.GetFloat(PropertyIDs._LightingMode);
            VertexColorMode vertexColorMode = vertexColorSupported
                ? (VertexColorMode)material.GetFloat(PropertyIDs._VertexColorMode)
                : VertexColorMode.Disabled;

            bool lightingBakedEnabled = material.GetFloat(PropertyIDs._LightingBaked) == 1;
            bool lightingVertexColorEnabled = vertexColorSupported && (vertexColorMode == VertexColorMode.Lighting);
            bool lightingDynamicEnabled = material.GetFloat(PropertyIDs._LightingDynamic) == 1;

            if (vertexColorMode == VertexColorMode.Color)
            {
                material.EnableKeyword(Keywords._VERTEX_COLOR_MODE_COLOR);
            }
            else
            {
                material.DisableKeyword(Keywords._VERTEX_COLOR_MODE_COLOR);
            }

            switch (lightingMode)
            {
                case LightingMode.Unlit:
                {
                    material.DisableKeyword(Keywords._LIGHTING_BAKED_ON);
                    material.DisableKeyword(Keywords._VERTEX_COLOR_MODE_LIGHTING);
                    material.DisableKeyword(Keywords._LIGHTING_DYNAMIC_ON);
                    break;
                }
                case LightingMode.Lit:
                default: // Old versions of the material can have enum values serialized outside the range that we are currently supporting. Default these materials back to lit.
                {
                    if (lightingBakedEnabled)
                    {
                        material.EnableKeyword(Keywords._LIGHTING_BAKED_ON);
                    }
                    else
                    {
                        material.DisableKeyword(Keywords._LIGHTING_BAKED_ON);
                    }

                    if (lightingVertexColorEnabled)
                    {
                        material.EnableKeyword(Keywords._VERTEX_COLOR_MODE_LIGHTING);
                    }
                    else
                    {
                        material.DisableKeyword(Keywords._VERTEX_COLOR_MODE_LIGHTING);
                    }

                    if (lightingDynamicEnabled)
                    {
                        material.EnableKeyword(Keywords._LIGHTING_DYNAMIC_ON);
                    }
                    else
                    {
                        material.DisableKeyword(Keywords._LIGHTING_DYNAMIC_ON);
                    }
                    break;
                }
            }
        }

        public static void SetupMaterialLightingModeNoVertexColorSupported(Material material)
        {
            if (material == null)
                throw new ArgumentNullException("material");
                
            LightingMode lightingMode = (LightingMode)material.GetFloat(PropertyIDs._LightingMode);

            bool lightingBakedEnabled = material.GetFloat(PropertyIDs._LightingBaked) == 1;
            bool lightingDynamicEnabled = material.GetFloat(PropertyIDs._LightingDynamic) == 1;

            switch (lightingMode)
            {
                case LightingMode.Unlit:
                {
                    material.DisableKeyword(Keywords._LIGHTING_BAKED_ON);
                    material.DisableKeyword(Keywords._LIGHTING_DYNAMIC_ON);
                    break;
                }
                case LightingMode.Lit:
                default: // Old versions of the material can have enum values serialized outside the range that we are currently supporting. Default these materials back to lit.
                {
                    if (lightingBakedEnabled)
                    {
                        material.EnableKeyword(Keywords._LIGHTING_BAKED_ON);
                    }
                    else
                    {
                        material.DisableKeyword(Keywords._LIGHTING_BAKED_ON);
                    }

                    if (lightingDynamicEnabled)
                    {
                        material.EnableKeyword(Keywords._LIGHTING_DYNAMIC_ON);
                    }
                    else
                    {
                        material.DisableKeyword(Keywords._LIGHTING_DYNAMIC_ON);
                    }
                    break;
                }
            }
        }

        public static void SetupMaterialBlendMode(Material material)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            SurfaceType surfaceType = (SurfaceType)material.GetFloat(PropertyIDs._Surface);
            RenderQueueCategory category = (RenderQueueCategory)(int)material.GetFloat(PropertyIDs._RenderQueueCategory);
            bool transparent = surfaceType == SurfaceType.Transparent;
            int renderQueueOffset = 0; // TODO: Expose options for user to offset within the queue.
            bool alphaClip = material.GetFloat(PropertyIDs._AlphaClip) == 1;

            material.renderQueue = GetRenderQueueFromCategory(category, transparent, renderQueueOffset, alphaClip);

            if (alphaClip)
            {
                material.EnableKeyword(Keywords._ALPHATEST_ON);
            }
            else
            {
                material.DisableKeyword(Keywords._ALPHATEST_ON);
            }

            
            if (surfaceType == SurfaceType.Opaque)
            {
                if (alphaClip)
                {
                    // TODO: Do I actually need to support these override tags? I'm not using them.
                    material.SetOverrideTag(Tags.RenderType, Tags.TransparentCutout);
                }
                else
                {
                    // TODO: Do I actually need to support these override tags? I'm not using them.
                    material.SetOverrideTag(Tags.RenderType, Tags.Opaque);
                }
                material.SetInt(PropertyIDs._BlendOp, (int)UnityEngine.Rendering.BlendOp.Add);
                material.SetInt(PropertyIDs._SrcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt(PropertyIDs._DstBlend, (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt(PropertyIDs._ZWrite, 1);
                material.DisableKeyword(Keywords._ALPHAPREMULTIPLY_ON);
                // material.SetShaderPassEnabled("ShadowCaster", true);
            }
            else // SurfaceType == SurfaceType.Transparent
            {
                PSXMaterialUtils.BlendMode blendMode = (PSXMaterialUtils.BlendMode)material.GetFloat(PropertyIDs._Blend);
                
                // Specific Transparent Mode Settings
                switch (blendMode)
                {
                    case PSXMaterialUtils.BlendMode.AlphaPostmultiply:
                        material.SetInt(PropertyIDs._BlendOp, (int)UnityEngine.Rendering.BlendOp.Add);
                        material.SetInt(PropertyIDs._SrcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                        material.SetInt(PropertyIDs._DstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                        material.DisableKeyword(Keywords._ALPHAPREMULTIPLY_ON);
                        break;
                    case PSXMaterialUtils.BlendMode.AlphaPremultiply:
                        material.SetInt(PropertyIDs._BlendOp, (int)UnityEngine.Rendering.BlendOp.Add);
                        material.SetInt(PropertyIDs._SrcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                        material.SetInt(PropertyIDs._DstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                        material.EnableKeyword(Keywords._ALPHAPREMULTIPLY_ON);
                        break;
                    case PSXMaterialUtils.BlendMode.Additive:
                        material.SetInt(PropertyIDs._BlendOp, (int)UnityEngine.Rendering.BlendOp.Add);
                        material.SetInt(PropertyIDs._SrcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                        material.SetInt(PropertyIDs._DstBlend, (int)UnityEngine.Rendering.BlendMode.One);
                        material.DisableKeyword(Keywords._ALPHAPREMULTIPLY_ON);
                        break;
                    case PSXMaterialUtils.BlendMode.Multiply:
                        material.SetInt(PropertyIDs._BlendOp, (int)UnityEngine.Rendering.BlendOp.Add);
                        material.SetInt(PropertyIDs._SrcBlend, (int)UnityEngine.Rendering.BlendMode.DstColor);
                        material.SetInt(PropertyIDs._DstBlend, (int)UnityEngine.Rendering.BlendMode.Zero);
                        material.DisableKeyword(Keywords._ALPHAPREMULTIPLY_ON);
                        material.EnableKeyword(Keywords._ALPHAMODULATE_ON);
                        break;
                    case PSXMaterialUtils.BlendMode.Subtractive:
                        material.SetInt(PropertyIDs._BlendOp, (int)UnityEngine.Rendering.BlendOp.ReverseSubtract);
                        material.SetInt(PropertyIDs._SrcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                        material.SetInt(PropertyIDs._DstBlend, (int)UnityEngine.Rendering.BlendMode.One);
                        material.DisableKeyword(Keywords._ALPHAPREMULTIPLY_ON);
                        material.DisableKeyword(Keywords._ALPHAMODULATE_ON);
                        break;
                    default:
                        Debug.Assert(false, "Error: Encountered unsupported blendmode: " + blendMode);
                        break;
                }

                // General Transparent Material Settings
                // TODO: Do I actually need to support these override tags? I'm not using them.
                material.SetOverrideTag(Tags.RenderType, Tags.Transparent);
                material.SetInt(PropertyIDs._ZWrite, 0);
            }
        }

        public static void SetupMaterialFogKeyword(Material material)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            bool fog = material.GetFloat(PropertyIDs._FogWeight) > 0.0f;
            if (fog)
            {
                material.EnableKeyword(Keywords._FOG_ON);
            }
            else
            {
                material.DisableKeyword(Keywords._FOG_ON);
            }
        }

        public static void SetupMaterialReflectionKeyword(Material material)
        {
            if (material == null)
                throw new ArgumentNullException("material");

            bool reflection = material.GetFloat(PropertyIDs._Reflection) == 1;
            if (reflection)
            {
                material.EnableKeyword(Keywords._REFLECTION_ON);
            }
            else
            {
                material.DisableKeyword(Keywords._REFLECTION_ON);
            }

            ReflectionBlendMode reflectionBlendMode = (ReflectionBlendMode)material.GetInt(PropertyIDs._ReflectionBlendMode);
        }

        public static void DoPopup(GUIContent label, MaterialProperty property, string[] options, MaterialEditor materialEditor)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            EditorGUI.showMixedValue = property.hasMixedValue;

            var mode = property.floatValue;
            EditorGUI.BeginChangeCheck();
            mode = EditorGUILayout.Popup(label, (int)mode, options);
            if (EditorGUI.EndChangeCheck())
            {
                materialEditor.RegisterPropertyChangeUndo(label.text);
                property.floatValue = mode;
            }

            EditorGUI.showMixedValue = false;
        }

        // Helper to show texture and color properties
        public static Rect TextureColorProps(MaterialEditor materialEditor, GUIContent label, MaterialProperty textureProp, MaterialProperty colorProp, bool hdr = false)
        {
            Rect rect = EditorGUILayout.GetControlRect();
            EditorGUI.showMixedValue = textureProp.hasMixedValue;
            materialEditor.TexturePropertyMiniThumbnail(rect, textureProp, label.text, label.tooltip);
            EditorGUI.showMixedValue = false;

            if (colorProp != null)
            {
                EditorGUI.BeginChangeCheck();
                EditorGUI.showMixedValue = colorProp.hasMixedValue;
                int indentLevel = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;
                Rect rectAfterLabel = new Rect(rect.x + EditorGUIUtility.labelWidth, rect.y,
                    EditorGUIUtility.fieldWidth, EditorGUIUtility.singleLineHeight);
                var col = EditorGUI.ColorField(rectAfterLabel, GUIContent.none, colorProp.colorValue, true,
                    false, hdr);
                EditorGUI.indentLevel = indentLevel;
                if (EditorGUI.EndChangeCheck())
                {
                    materialEditor.RegisterPropertyChangeUndo(colorProp.displayName);
                    colorProp.colorValue = col;
                }
                EditorGUI.showMixedValue = false;
            }

            return rect;
        }

        public static int GetRenderQueueFromCategory(RenderQueueCategory category, bool transparent, int offset, bool alphaClip)
        {
            switch (category)
            {
                case RenderQueueCategory.Background: return PSXRenderQueue.ChangeType(transparent ? PSXRenderQueue.RenderQueueType.BackgroundTransparent : PSXRenderQueue.RenderQueueType.BackgroundOpaque, offset, alphaClip);
                case RenderQueueCategory.Main: return PSXRenderQueue.ChangeType(transparent ? PSXRenderQueue.RenderQueueType.MainTransparent : PSXRenderQueue.RenderQueueType.MainOpaque, offset, alphaClip);
                case RenderQueueCategory.UIOverlay: return PSXRenderQueue.ChangeType(transparent ? PSXRenderQueue.RenderQueueType.UIOverlayTransparent : PSXRenderQueue.RenderQueueType.UIOverlayOpaque, offset, alphaClip);
                default: throw new ArgumentException("category");
            }
        }

        public static void DrawAdvancedOptions(Material material, MaterialEditor materialEditor)
        {
            materialEditor.EnableInstancingField();
        }

        public static void DrawMainProperties(Material material, MaterialEditor materialEditor, MaterialProperty mainTexProp, MaterialProperty mainColorProp)
        {
            if (mainTexProp != null && mainColorProp != null) // Draw the mainTex, most shader will have at least a mainTex
            {
                materialEditor.TexturePropertySingleLine(Styles.mainTex, mainTexProp, mainColorProp);
                
                // TODO Temporary fix for lightmapping, to be replaced with attribute tag.
                if (material.HasProperty(PropertyIDs._MainTex))
                {
                    material.SetTexture(PropertyIDs._MainTex, mainTexProp.textureValue);
                    var mainTexTiling = mainTexProp.textureScaleAndOffset;
                    material.SetTextureScale(PropertyIDs._MainTex, new Vector2(mainTexTiling.x, mainTexTiling.y));
                    material.SetTextureOffset(PropertyIDs._MainTex, new Vector2(mainTexTiling.z, mainTexTiling.w));
                }
            }
        }

        public static void DrawEmissionProperties(
            Material material,
            MaterialEditor materialEditor,
            MaterialProperty emissionTextureProp,
            MaterialProperty emissionColorProp,
            MaterialProperty emissionBakedMultiplierProp)
        {
            // Emission for GI?
            bool emissive = materialEditor.EmissionEnabledProperty();
            bool hadEmissionTexture = emissionTextureProp.textureValue != null;

            EditorGUI.BeginDisabledGroup(!emissive);
            {
                // Texture and HDR color controls
                materialEditor.TexturePropertyWithHDRColor(Styles.emissionTex, emissionTextureProp,
                    emissionColorProp,
                    false);

                EditorGUI.BeginChangeCheck();
                float emissionBakedMultiplier = EditorGUILayout.FloatField(Styles.emissionBakedMultiplier, emissionBakedMultiplierProp.floatValue);
                if (EditorGUI.EndChangeCheck())
                    emissionBakedMultiplierProp.floatValue = emissionBakedMultiplier;

                
            }
            EditorGUI.EndDisabledGroup();

            // If texture was assigned and color was black set color to white
            var brightness = emissionColorProp.colorValue.maxColorComponent;
            if (emissionTextureProp.textureValue != null && !hadEmissionTexture && brightness <= 0f)
                emissionColorProp.colorValue = Color.white;

            // HPSXRP does not support RealtimeEmissive. We set it to bake emissive and handle the emissive is black right.
            if (emissive)
            {
                material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.BakedEmissive;
                if (brightness <= 0f)
                    material.globalIlluminationFlags |= MaterialGlobalIlluminationFlags.EmissiveIsBlack;
            }
        }

        public static void DrawReflectionProperties(
            Material material,
            MaterialEditor materialEditor,
            MaterialProperty reflectionProp,
            MaterialProperty reflectionBlendModeProp,
            MaterialProperty reflectionCubemapProp,
            MaterialProperty reflectionTextureProp,
            MaterialProperty reflectionColorProp)
        {
            var reflection = true;
            var hadReflectionTexture = reflectionTextureProp.textureValue != null;

            EditorGUI.BeginChangeCheck();
            reflection = EditorGUILayout.Toggle(Styles.reflection, reflectionProp.floatValue == 1);
            if (EditorGUI.EndChangeCheck())
                reflectionProp.floatValue = reflection ? 1 : 0;

            EditorGUI.BeginDisabledGroup(!reflection);
            {
                DoPopup(Styles.reflectionBlendMode, reflectionBlendModeProp, Enum.GetNames(typeof(ReflectionBlendMode)), materialEditor);

                materialEditor.TexturePropertySingleLine(Styles.reflectionCubemap, reflectionCubemapProp);

                // Texture and HDR color controls
                materialEditor.TexturePropertyWithHDRColor(Styles.reflectionTexture, reflectionTextureProp, reflectionColorProp, false);
            }
            EditorGUI.EndDisabledGroup();

            // If texture was assigned and color was black set color to white
            var brightness = reflectionColorProp.colorValue.maxColorComponent;
            if (reflectionTextureProp.textureValue != null && !hadReflectionTexture && brightness <= 0f)
                reflectionColorProp.colorValue = Color.white;
        }

        public static void DrawTileOffset(MaterialEditor materialEditor, MaterialProperty textureProp)
        {
            materialEditor.TextureScaleOffsetProperty(textureProp);
        }

        public static void DrawRenderQueueCategory(MaterialEditor materialEditor, MaterialProperty renderQueueCategoryProp)
        {
            DoPopup(Styles.RenderQueueCategory, renderQueueCategoryProp, Enum.GetNames(typeof(RenderQueueCategory)), materialEditor);
        }

        public static void DrawVertexColorMode(MaterialEditor materialEditor, MaterialProperty vertexColorModeProp)
        {
            DoPopup(Styles.VertexColorMode, vertexColorModeProp, Enum.GetNames(typeof(VertexColorMode)), materialEditor);
        }

        public static void DrawLightingMode(Material material, MaterialEditor materialEditor, MaterialProperty lightingModeProp, MaterialProperty lightingBakedProp, MaterialProperty lightingDynamicProp)
        {
            DoPopup(Styles.LightingMode, lightingModeProp, Enum.GetNames(typeof(LightingMode)), materialEditor);

            if ((lightingModeProp.floatValue != (float)LightingMode.Lit) && (lightingModeProp.floatValue != (float)LightingMode.Unlit))
            {
                // Old versions of the material can have enum values serialized outside the range that we are currently supporting. Default these materials back to lit.
                lightingModeProp.floatValue = (float)LightingMode.Lit;
            }

            if ((LightingMode)material.GetFloat(PropertyIDs._LightingMode) == LightingMode.Lit)
            {
                EditorGUI.BeginChangeCheck();
                bool lightingBakedEnabled = EditorGUILayout.Toggle(Styles.LightingBaked, lightingBakedProp.floatValue == 1);
                if (EditorGUI.EndChangeCheck())
                    lightingBakedProp.floatValue = lightingBakedEnabled ? 1 : 0;

                EditorGUI.BeginChangeCheck();
                bool lightingDynamicEnabled = EditorGUILayout.Toggle(Styles.LightingDynamic, lightingDynamicProp.floatValue == 1);
                if (EditorGUI.EndChangeCheck())
                    lightingDynamicProp.floatValue = lightingDynamicEnabled ? 1 : 0;
            }
        }

        public static void DrawShadingEvaluationMode(MaterialEditor materialEditor, MaterialProperty shadingEvaluationModeProp)
        {
            DoPopup(Styles.ShadingEvaluationMode, shadingEvaluationModeProp, Enum.GetNames(typeof(ShadingEvaluationMode)), materialEditor);
        }

        public static void DrawSurfaceTypeAndBlendMode(Material material, MaterialEditor materialEditor, MaterialProperty surfaceTypeProp, MaterialProperty blendModeProp)
        {
            DoPopup(Styles.surfaceType, surfaceTypeProp, Enum.GetNames(typeof(SurfaceType)), materialEditor);

            if ((SurfaceType)material.GetFloat(PropertyIDs._Surface) == SurfaceType.Transparent)
            {
                DoPopup(Styles.blendingMode, blendModeProp, Enum.GetNames(typeof(PSXMaterialUtils.BlendMode)), materialEditor);
            }
        }

        public static void DrawCullingSettings(Material material, MaterialEditor materialEditor, MaterialProperty cullingProp)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUI.showMixedValue = cullingProp.hasMixedValue;
            var culling = (RenderFace)cullingProp.floatValue;
            culling = (RenderFace)EditorGUILayout.EnumPopup(Styles.cullingText, culling);
            if (EditorGUI.EndChangeCheck())
            {
                materialEditor.RegisterPropertyChangeUndo(Styles.cullingText.text);
                cullingProp.floatValue = (float)culling;
                material.doubleSidedGI = (RenderFace)cullingProp.floatValue != RenderFace.Front;
            }

            EditorGUI.showMixedValue = false;
        }

        public static void DrawAlphaClippingSettings(Material material, MaterialProperty alphaClipProp, MaterialProperty alphaClippingDitherIsEnabledProp)
        {
            if ((SurfaceType)material.GetFloat(PropertyIDs._Surface) == SurfaceType.Transparent)
            {
                alphaClipProp.floatValue = 0;
                alphaClippingDitherIsEnabledProp.floatValue = 0;
            }
            else
            {
                EditorGUI.BeginChangeCheck();
                EditorGUI.showMixedValue = alphaClipProp.hasMixedValue;
                var alphaClipEnabled = EditorGUILayout.Toggle(Styles.alphaClipText, alphaClipProp.floatValue == 1);
                if (EditorGUI.EndChangeCheck())
                    alphaClipProp.floatValue = alphaClipEnabled ? 1 : 0;
                EditorGUI.showMixedValue = false;

                if (alphaClipProp.floatValue > 0.5f)
                {
                    EditorGUI.BeginChangeCheck();
                    bool alphaClippingDitherIsEnabled = EditorGUILayout.Toggle(Styles.alphaClippingDitherText, alphaClippingDitherIsEnabledProp.floatValue == 1);
                    if (EditorGUI.EndChangeCheck())
                        alphaClippingDitherIsEnabledProp.floatValue = alphaClippingDitherIsEnabled ? 1 : 0;
                }
            }
        }

        public static void DrawAffineTextureWarpingWeight(MaterialProperty affineTextureWarpingWeightProp)
        {
            EditorGUI.BeginChangeCheck();
            var affineTextureWarpingWeight = EditorGUILayout.Slider(Styles.affineTextureWarpingWeight, affineTextureWarpingWeightProp.floatValue, 0.0f, 1.0f);
            if (EditorGUI.EndChangeCheck())
            {
                affineTextureWarpingWeightProp.floatValue = affineTextureWarpingWeight;
            }
        }

        public static void DrawPrecisionGeometryWeight(MaterialProperty precisionGeometryWeightProp)
        {
            EditorGUI.BeginChangeCheck();
            var precisionGeometryWeight = EditorGUILayout.Slider(Styles.precisionGeometryWeight, precisionGeometryWeightProp.floatValue, 0.0f, 1.0f);
            if (EditorGUI.EndChangeCheck())
            {
                precisionGeometryWeightProp.floatValue = precisionGeometryWeight;
            }
        }

        public static void DrawFogWeight(MaterialProperty fogWeightProp)
        {
            EditorGUI.BeginChangeCheck();
            var fogWeight = EditorGUILayout.Slider(Styles.fogWeight, fogWeightProp.floatValue, 0.0f, 1.0f);
            if (EditorGUI.EndChangeCheck())
            {
                fogWeightProp.floatValue = fogWeight;
            }
        }

        static public bool TextureHasAlpha(Texture2D inTex)
        {
            if (inTex != null)
            {
                return GraphicsFormatUtility.HasAlphaChannel(GraphicsFormatUtility.GetGraphicsFormat(inTex.format, true));
            }
            return false;
        }
    }
}