﻿/*
* Copyright (c) 2012 Nicholas Woodfield
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

using System;
using System.Runtime.InteropServices;

namespace Assimp.Unmanaged {
    /// <summary>
    /// Represents an aiScene struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiScene {
        /// <summary>
        /// unsigned int, flags about the state of the scene
        /// </summary>
        public SceneFlags Flags;

        /// <summary>
        /// aiNode*, root node of the scenegraph.
        /// </summary>
        public IntPtr RootNode;

        /// <summary>
        /// Number of meshes contained.
        /// </summary>
        public uint NumMeshes;

        /// <summary>
        /// aiMesh**, meshes in the scene.
        /// </summary>
        public IntPtr Meshes;

        /// <summary>
        /// Number of materials contained.
        /// </summary>
        public uint NumMaterials;

        /// <summary>
        /// aiMaterial**, materials in the scene.
        /// </summary>
        public IntPtr Materials;

        /// <summary>
        /// Number of animations contained.
        /// </summary>
        public uint NumAnimations;

        /// <summary>
        /// aiAnimation**, animations in the scene.
        /// </summary>
        public IntPtr Animations;

        /// <summary>
        /// Number of embedded textures contained.
        /// </summary>
        public uint NumTextures;

        /// <summary>
        /// aiTexture**, textures in the scene.
        /// </summary>
        public IntPtr Textures;

        /// <summary>
        /// Number of lights contained.
        /// </summary>
        public uint NumLights;

        /// <summary>
        /// aiLight**, lights in the scene.
        /// </summary>
        public IntPtr Lights;

        /// <summary>
        /// Number of cameras contained.
        /// </summary>
        public uint NumCameras;

        /// <summary>
        /// aiCamera**, cameras in the scene.
        /// </summary>
        public IntPtr Cameras;
    }

    /// <summary>
    /// Represents an aiNode struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiNode {
        /// <summary>
        /// Name of the node.
        /// </summary>
        public AiString Name;

        /// <summary>
        /// Node's transform relative to its parent.
        /// </summary>
        public Matrix4x4 Transformation;

        /// <summary>
        /// aiNode*, node's parent.
        /// </summary>
        public IntPtr parent;

        /// <summary>
        /// Number of children the node owns.
        /// </summary>
        public uint NumChildren;

        /// <summary>
        /// aiNode**, array of nodes this node owns.
        /// </summary>
        public IntPtr Children;

        /// <summary>
        /// Number of meshes referenced by this node.
        /// </summary>
        public uint NumMeshes;

        /// <summary>
        /// unsigned int*, array of mesh indices.
        /// </summary>
        public IntPtr Meshes;
    }

    /// <summary>
    /// Represents an aiMesh struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiMesh {
        /// <summary>
        /// unsigned int, bitwise flag detailing types of primitives contained.
        /// </summary>
        public PrimitiveType PrimitiveTypes;

        /// <summary>
        /// Number of vertices in the mesh, denotes length of
        /// -all- per-vertex arrays.
        /// </summary>
        public uint NumVertices;

        /// <summary>
        /// Number of faces in the mesh.
        /// </summary>
        public uint NumFaces;

        /// <summary>
        /// aiVector3D*, array of positions.
        /// </summary>
        public IntPtr Vertices;

        /// <summary>
        /// aiVector3D*, array of normals.
        /// </summary>
        public IntPtr Normals;

        /// <summary>
        /// aiVector3D*, array of tangents.
        /// </summary>
        public IntPtr Tangents;

        /// <summary>
        /// aiVector3D*, array of bitangents.
        /// </summary>
        public IntPtr BiTangents;

        /// <summary>
        /// aiColor*[Max_Value], array of arrays of vertex colors. Max_Value is a defined constant.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = AiDefines.AI_MAX_NUMBER_OF_COLOR_SETS, ArraySubType = UnmanagedType.SysUInt)]
        public IntPtr[] Colors;

        /// <summary>
        /// aiColor*[Max_Value], array of arrays of texture coordinates. Max_Value is a defined constant.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = AiDefines.AI_MAX_NUMBER_OF_TEXTURECOORDS, ArraySubType = UnmanagedType.SysUInt)]
        public IntPtr[] TextureCoords;

        /// <summary>
        /// unsigned int[4], array of ints denoting the number of components for texture coordinates - UV (2), UVW (3) for example.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = AiDefines.AI_MAX_NUMBER_OF_TEXTURECOORDS, ArraySubType = UnmanagedType.U4)]
        public uint[] NumUVComponents;

        /// <summary>
        /// aiFace*, array of faces.
        /// </summary>
        public IntPtr Faces;

        /// <summary>
        /// Number of bones in the mesh.
        /// </summary>
        public uint NumBones;

        /// <summary>
        /// aiBone**, array of bones.
        /// </summary>
        public IntPtr Bones;

        /// <summary>
        /// Material index referencing the material in the scene.
        /// </summary>
        public uint MaterialIndex;

        /// <summary>
        /// Optional name of the mesh.
        /// </summary>
        public AiString Name;

        /// <summary>
        /// NOT CURRENTLY IN USE.
        /// </summary>
        public uint NumAnimMeshes;

        /// <summary>
        /// NOT CURRENTLY IN USE.
        /// </summary>
        public IntPtr AnimMeshes;
    }

    /// <summary>
    /// Represents an aiTexture struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiTexture {
        /// <summary>
        /// Width of the texture.
        /// </summary>
        public uint Width;

        /// <summary>
        /// Height of the texture.
        /// </summary>
        public uint Height;

        /// <summary>
        /// char[4], format extension hint.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst=4)]
        public String FormatHint;

        /// <summary>
        /// aiTexel*, array of texel data.
        /// </summary>
        public IntPtr Data;
    }

    /// <summary>
    /// Represents an aiFace struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiFace {
        /// <summary>
        /// Number of indices in the face.
        /// </summary>
        public uint NumIndices;

        /// <summary>
        /// unsigned int*, array of indices.
        /// </summary>
        public IntPtr Indices;
    }

    /// <summary>
    /// Represents an aiBone struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiBone {
        /// <summary>
        /// Name of the bone.
        /// </summary>
        public AiString Name;

        /// <summary>
        /// Number of weights.
        /// </summary>
        public uint NumWeights;

        /// <summary>
        /// VertexWeight*, array of vertex weights.
        /// </summary>
        public IntPtr Weights;

        /// <summary>
        /// Matrix that transforms the vertex from mesh to bone space in bind pose
        /// </summary>
        public Matrix4x4 OffsetMatrix;
    }

    /// <summary>
    /// Represents an aiMaterialProperty struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiMaterialProperty {
        /// <summary>
        /// Name of the property (key).
        /// </summary>
        public AiString Key;

        /// <summary>
        /// Textures: Specifies texture usage. None texture properties
        /// have this zero (or None).
        /// </summary>
        public TextureType Semantic;

        /// <summary>
        /// Textures: Specifies the index of the (embedded) texture. For non-texture properties
        /// this is always one.
        /// </summary>
        public uint Index;

        /// <summary>
        /// Size of the buffer data in bytes. This value may not be zero.
        /// </summary>
        public uint DataLength;

        /// <summary>
        /// Type of value contained in the buffer.
        /// </summary>
        public PropertyTypeInfo Type;

        /// <summary>
        /// char*, byte buffer to hold the property's value.
        /// </summary>
        public IntPtr Data;
    }

    /// <summary>
    /// Represents an aiMaterial struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiMaterial {
        /// <summary>
        /// aiMaterialProperty**, array of material properties.
        /// </summary>
        public IntPtr Properties;

        /// <summary>
        /// Number of key-value properties.
        /// </summary>
        public uint NumProperties;

        /// <summary>
        /// Storage allocated for key-value properties.
        /// </summary>
        public uint NumAllocated;
    }

    /// <summary>
    /// Represents an aiNodeAnim struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiNodeAnim {
        /// <summary>
        /// Name of the node affected by the animation. The node must exist
        /// and be unique.
        /// </summary>
        public AiString NodeName;

        /// <summary>
        /// Number of position keys.
        /// </summary>
        public uint NumPositionKeys;

        /// <summary>
        /// VectorKey*, position keys of this animation channel. Positions
        /// are 3D vectors and are accompanied by at least one scaling and one rotation key.
        /// </summary>
        public IntPtr PositionKeys;

        /// <summary>
        /// The number of rotation keys.
        /// </summary>
        public uint NumRotationKeys;

        /// <summary>
        /// QuaternionKey*, rotation keys of this animation channel. Rotations are 4D vectors (quaternions).
        /// If there are rotation keys there will be at least one scaling and one position key.
        /// </summary>
        public IntPtr RotationKeys;

        /// <summary>
        /// Number of scaling keys.
        /// </summary>
        public uint NumScalingKeys;

        /// <summary>
        /// VectorKey*, scaling keys of this animation channel. Scalings are specified as a
        /// 3D vector, and if there are scaling keys, there will at least be one position
        /// and one rotation key.
        /// </summary>
        public IntPtr ScalingKeys;

        /// <summary>
        /// Defines how the animation behaves before the first key is encountered.
        /// </summary>
        public AnimationBehaviour Prestate;

        /// <summary>
        /// Defines how the animation behaves after the last key was processed.
        /// </summary>
        public AnimationBehaviour PostState;
    }

    /// <summary>
    /// Represents an aiMeshAnim struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiMeshAnim {
        /// <summary>
        /// Name of the mesh to be animated. Empty string not allowed.
        /// </summary>
        public AiString Name;

        /// <summary>
        /// Number of keys, there is at least one.
        /// </summary>
        public uint NumKeys;

        /// <summary>
        /// aiMeshkey*, the key frames of the animation. There must exist at least one.
        /// </summary>
        public IntPtr Keys;
    }

    /// <summary>
    /// Represents an aiAnimation struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiAnimation {
        /// <summary>
        /// Name of the animation.
        /// </summary>
        public AiString Name;

        /// <summary>
        /// Duration of the animation in ticks.
        /// </summary>
        public double Duration;

        /// <summary>
        /// Ticks per second, 0 if not specified in imported file.
        /// </summary>
        public double TicksPerSecond;

        /// <summary>
        /// Number of bone animation channels, each channel affects a single node.
        /// </summary>
        public uint NumChannels;

        /// <summary>
        /// aiNodeAnim**, node animation channels. Each channel affects a single node.
        /// </summary>
        public IntPtr Channels;

        /// <summary>
        /// Number of mesh animation channels. Each channel affects a single mesh and defines
        /// vertex-based animation.
        /// </summary>
        public uint NumMeshChannels;

        /// <summary>
        /// aiMeshAnim**, mesh animation channels. Each channel affects a single mesh. 
        /// </summary>
        public IntPtr MeshChannels;
    }

    /// <summary>
    /// Represents an aiLight struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiLight {
        /// <summary>
        /// Name of the light.
        /// </summary>
        public AiString Name;

        /// <summary>
        /// Type of light.
        /// </summary>
        public LightSourceType Type;

        /// <summary>
        /// Position of the light.
        /// </summary>
        public Vector3D Position;

        /// <summary>
        /// Direction of the spot/directional light.
        /// </summary>
        public Vector3D Direction;

        /// <summary>
        /// Attenuation constant value.
        /// </summary>
        public float AttenuationConstant;

        /// <summary>
        /// Attenuation linear value.
        /// </summary>
        public float AttenuationLinear;

        /// <summary>
        /// Attenuation quadratic value.
        /// </summary>
        public float AttenuationQuadratic;

        /// <summary>
        /// Diffuse color.
        /// </summary>
        public Color3D ColorDiffuse;

        /// <summary>
        /// Specular color.
        /// </summary>
        public Color3D ColorSpecular;

        /// <summary>
        /// Ambient color.
        /// </summary>
        public Color3D ColorAmbient;

        /// <summary>
        /// Spot light inner angle.
        /// </summary>
        public float AngleInnerCone;

        /// <summary>
        /// Spot light outer angle.
        /// </summary>
        public float AngleOuterCone;
    }

    /// <summary>
    /// Represents an aiCamera struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiCamera {
        /// <summary>
        /// Name of the camera.
        /// </summary>
        public AiString Name;

        /// <summary>
        /// Position of the camera.
        /// </summary>
        public Vector3D Position;

        /// <summary>
        /// Up vector of the camera.
        /// </summary>
        public Vector3D Up;

        /// <summary>
        /// Viewing direction of the camera.
        /// </summary>
        public Vector3D LookAt;

        /// <summary>
        /// Field Of View of the camera.
        /// </summary>
        public float HorizontalFOV;

        /// <summary>
        /// Near clip plane distance.
        /// </summary>
        public float ClipPlaneNear;

        /// <summary>
        /// Far clip plane distance.
        /// </summary>
        public float ClipPlaneFar;

        /// <summary>
        /// The Aspect ratio.
        /// </summary>
        public float Aspect;
    }

    /// <summary>
    /// Represents an aiString struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct AiString {
        /// <summary>
        /// Byte length of the UTF-8 string.
        /// </summary>
        public uint Length;

        /// <summary>
        /// Actual string.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = AiDefines.MAX_LENGTH)]
        public String Data;
    }

    /// <summary>
    /// Represents the memory requirements for the different components of an imported
    /// scene. All sizes in in bytes.
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiMemoryInfo {

        /// <summary>
        /// Size of the storage allocated for texture data, in bytes.
        /// </summary>
        public uint Textures;

        /// <summary>
        /// Size of the storage allocated for material data, in bytes.
        /// </summary>
        public uint Materials;

        /// <summary>
        /// Size of the storage allocated for mesh data, in bytes.
        /// </summary>
        public uint Meshes;

        /// <summary>
        /// Size of the storage allocated for node data, in bytes.
        /// </summary>
        public uint Nodes;

        /// <summary>
        /// Size of the storage allocated for animation data, in bytes.
        /// </summary>
        public uint Animations;

        /// <summary>
        /// Size of the storage allocated for camera data, in bytes.
        /// </summary>
        public uint Cameras;

        /// <summary>
        /// Size of the storage allocated for light data, in bytes.
        /// </summary>
        public uint Lights;

        /// <summary>
        /// Total storage allocated for the imported scene, in bytes.
        /// </summary>
        public uint Total;
    }

    /// <summary>
    /// Represents an aiAnimMesh struct.
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct AiAnimMesh {

        /// aiVector3D*, replacement position array.
        public IntPtr Vertices;

        /// aiVector3D*, replacement normal array.
        public IntPtr Normals;

        /// aiVector3D*, replacement tangent array.
        public IntPtr Tangents;

        /// aiVector3D*, replacement bitangent array.
        public IntPtr Bitangents;

        /// aiColor4D*[4], replacement vertex colors.
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = AiDefines.AI_MAX_NUMBER_OF_COLOR_SETS, ArraySubType = UnmanagedType.SysUInt)]
        public IntPtr[] Colors;

        /// aiVector3D*[4], replacement texture coordinates.
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = AiDefines.AI_MAX_NUMBER_OF_TEXTURECOORDS, ArraySubType = UnmanagedType.SysUInt)]
        public IntPtr[] TextureCoords;

        /// unsigned int, number of vertices.
        public uint NumVertices;
    }
}
