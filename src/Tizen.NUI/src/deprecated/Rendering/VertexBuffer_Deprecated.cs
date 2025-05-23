/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// VertexBuffer is a handle to an object that contains a buffer of structured data.<br />
    /// VertexBuffers can be used to provide data to Geometry objects.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public partial class VertexBuffer : BaseHandle
    {
        /// <summary>
        /// Gets the number of elements in the buffer.
        /// </summary>
        /// <returns>Number of elements in the buffer.</returns>
        /// <since_tizen> 8 </since_tizen>
        public uint GetSize()
        {
            uint ret = Interop.VertexBuffer.GetSize(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
