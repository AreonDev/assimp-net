﻿/*
* Copyright (c) 2012-2014 AssimpNet - Nicholas Woodfield
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
using Assimp.Unmanaged;
using FreezingArcher.Math;

namespace Assimp
{
    /// <summary>
    /// Describes a right-handed camera in the scene. An important aspect is that
    /// the camera itself is also part of the scenegraph, meaning any values such
    /// as the direction vector are not *absolute*, they can be relative to the coordinate
    /// system defined by the node which corresponds to the camera. This allows for camera
    /// animations.
    /// </summary>
    public sealed class Camera : IMarshalable<Camera, AiCamera>
    {
        private String m_name;
        private Vector3 m_position;
        private Vector3 m_up;
        private Vector3 m_direction;
        private float m_fieldOfView;
        private float m_clipPlaneNear;
        private float m_clipPlaneFar;
        private float m_aspectRatio;

        /// <summary>
        /// Gets or sets the name of the camera. This corresponds to a node in the
        /// scenegraph with the same name. This node specifies the position of the
        /// camera in the scene hierarchy and can be animated.
        /// </summary>
        public String Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        /// <summary>
        /// Gets or sets the position of the camera relative to the coordinate space defined by
        /// the corresponding node. THe default value is 0|0|0.
        /// </summary>
        public Vector3 Position
        {
            get
            {
                return m_position;
            }
            set
            {
                m_position = value;
            }
        }

        /// <summary>
        /// Gets or sets the 'up' vector of the camera, relative to the coordinate space defined by the
        /// corresponding node. The 'right' vector of the camera is the cross product of the up
        /// and direction vectors. The default value is 0|1|0.
        /// </summary>
        public Vector3 Up
        {
            get
            {
                return m_up;
            }
            set
            {
                m_up = value;
            }
        }

        /// <summary>
        /// Gets or sets the viewing direction of the camera, relative to the coordinate space defined by the corresponding node.
        /// The default value is 0|0|1.
        /// </summary>
        public Vector3 Direction
        {
            get
            {
                return m_direction;
            }
            set
            {
                m_direction = value;
            }
        }

        /// <summary>
        /// Gets or sets the half horizontal field of view angle, in radians. The FoV angle is
        /// the angle between the center line of the screen and the left or right border. The default
        /// value is 1/4PI.
        /// </summary>
        public float FieldOfview
        {
            get
            {
                return m_fieldOfView;
            }
            set
            {
                m_fieldOfView = value;
            }
        }

        /// <summary>
        /// Gets or sets the distance of the near clipping plane from the camera. The value may not
        /// be 0.0f for arithmetic reasons to prevent a division through zero. The default value is 0.1f;
        /// </summary>
        public float ClipPlaneNear
        {
            get
            {
                return m_clipPlaneNear;
            }
            set
            {
                m_clipPlaneNear = value;
            }
        }

        /// <summary>
        /// Gets or sets the distance of the far clipping plane from the camera. The far clippling plane must
        /// be further than the near clippling plane. The default value is 1000.0f. The ratio between
        /// the near and far plane should not be too large (between 1000 - 10000 should be ok) to avoid
        /// floating-point inaccuracies which can lead to z-fighting.
        /// </summary>
        public float ClipPlaneFar
        {
            get
            {
                return m_clipPlaneFar;
            }
            set
            {
                m_clipPlaneFar = value;
            }
        }

        /// <summary>
        /// Gets or sets the screen aspect ratio. This is the ratio between the width and height of the screen. Typical
        /// values are 4/3, 1/2, or 1/1. This value is 0 if the aspect ratio is not defined in the source file.
        /// The default value is zero.
        /// </summary>
        public float AspectRatio
        {
            get
            {
                return m_aspectRatio;
            }
            set
            {
                m_aspectRatio = value;
            }
        }

        /// <summary>
        /// Gets a right-handed view matrix.
        /// </summary>
        public Matrix ViewMatrix
        {
            get
            {
                Vector3 zAxis = m_direction;
                zAxis.Normalize();
                Vector3 yAxis = m_up;
                yAxis.Normalize();
                Vector3 xAxis = Vector3.Cross(m_up, m_direction);
                zAxis.Normalize();

                //Assimp docs *say* they deal with Row major matrices,
                //but aiCamera.h has this calc done with translation in the 4th column
                return new Matrix (
                                 xAxis.X,
                                 xAxis.Y,
                                 xAxis.Z,
                                 0,

                                 yAxis.X,
                                 yAxis.Y,
                                 yAxis.Z,
                                 0,

                                 zAxis.X,
                                 zAxis.Y,
                                 zAxis.Z,
                                 0,

                                 -(Vector3.Dot (xAxis, m_position)),
                                 -(Vector3.Dot (yAxis, m_position)),
                                 -(Vector3.Dot (zAxis, m_position)),
                                 1.0f);

            }
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="Camera"/> class.
        /// </summary>
        public Camera()
        {
            m_name = String.Empty;
        }

        #region IMarshalable Implementation

        /// <summary>
        /// Gets if the native value type is blittable (that is, does not require marshaling by the runtime, e.g. has MarshalAs attributes).
        /// </summary>
        bool IMarshalable<Camera, AiCamera>.IsNativeBlittable
        {
            get { return true; }
        }

        /// <summary>
        /// Writes the managed data to the native value.
        /// </summary>
        /// <param name="thisPtr">Optional pointer to the memory that will hold the native value.</param>
        /// <param name="nativeValue">Output native value</param>
        void IMarshalable<Camera, AiCamera>.ToNative(IntPtr thisPtr, out AiCamera nativeValue)
        {
            nativeValue.Name = new AiString(m_name);
            nativeValue.Position = m_position;
            nativeValue.LookAt = m_direction;
            nativeValue.Up = m_up;
            nativeValue.HorizontalFOV = m_fieldOfView;
            nativeValue.ClipPlaneFar = m_clipPlaneFar;
            nativeValue.ClipPlaneNear = m_clipPlaneNear;
            nativeValue.Aspect = m_aspectRatio;
        }

        /// <summary>
        /// Reads the unmanaged data from the native value.
        /// </summary>
        /// <param name="nativeValue">Input native value</param>
        void IMarshalable<Camera, AiCamera>.FromNative(ref AiCamera nativeValue)
        {
            m_name = nativeValue.Name.GetString();
            m_position = nativeValue.Position;
            m_direction = nativeValue.LookAt;
            m_up = nativeValue.Up;
            m_fieldOfView = nativeValue.HorizontalFOV;
            m_clipPlaneFar = nativeValue.ClipPlaneFar;
            m_clipPlaneNear = nativeValue.ClipPlaneNear;
            m_aspectRatio = nativeValue.Aspect;
        }

        /// <summary>
        /// Frees unmanaged memory created by <see cref="IMarshalable{Camera, AiCamera}.ToNative"/>.
        /// </summary>
        /// <param name="nativeValue">Native value to free</param>
        /// <param name="freeNative">True if the unmanaged memory should be freed, false otherwise.</param>
        public static void FreeNative(IntPtr nativeValue, bool freeNative)
        {
            if(nativeValue != IntPtr.Zero && freeNative)
                MemoryHelper.FreeMemory(nativeValue);
        }

        #endregion
    }
}
