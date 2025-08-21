/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using System.Buffers;
using System.Runtime.InteropServices;
using System.Text;

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal static class PropertyBridge
    {
        private static StringGetterDelegate _stringGetterDelegate;

        /// <summary>
        /// NUI <-> DALi contract (two-pass, UTF-8, null-terminated):
        /// return 0 : no value (null)
        /// return 1 : empty string ("") -> only the null terminator required
        /// return N : required byte length INCLUDING the trailing null (N = utf8ByteCount + 1)
        ///
        /// Pass-1 (probe): buffer == IntPtr.Zero OR bufferSize <= 0 -> return required only, do not write.
        /// Pass-2 (write): buffer != IntPtr.Zero AND bufferSize > 0 -> write up to bufferSize-1 bytes, then write '\0'.
        /// Both passes return the same 'required' for the same underlying value.
        /// Encoding: UTF-8. Always null-terminate on write.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int StringGetterDelegate(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string propertyName, IntPtr buffer, int bufferSize);

        public static void RegisterStringGetter()
        {
            _stringGetterDelegate = InternalStringGetter;
            IntPtr funcPtr = Marshal.GetFunctionPointerForDelegate(_stringGetterDelegate);
            Interop.PropertyBridge.RegisterStringGetter(funcPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private static int InternalStringGetter(IntPtr obj, string propertyName, IntPtr buffer, int bufferSize)
        {
            try
            {
                if (obj == IntPtr.Zero || string.IsNullOrEmpty(propertyName))
                    return 0;

                if (Registry.GetManagedBaseHandleFromRefObject(obj) is not View view)
                    return 0;

                if (view is not IPropertyProvider provider)
                    return 0;

                string value = provider.GetStringProperty(propertyName);
                Tizen.Log.Info("NUI", $"Property:{propertyName}, value:{value}");

                // Null -> no value
                if (value is null)
                    return 0;

                // Empty -> only null terminator required
                if (value.Length == 0)
                {
                    if (buffer != IntPtr.Zero && bufferSize > 0)
                        Marshal.WriteByte(buffer, 0, 0); // write '\0'
                    return 1;
                }

                // Required size = UTF-8 byte count + 1 (for '\0')
                int byteCount = Encoding.UTF8.GetByteCount(value);
                int required = checked(byteCount + 1);

                // Write pass: if a valid buffer is provided, write up to bufferSize - 1 bytes,
                // then always null-terminate at the last written position.
                if (buffer != IntPtr.Zero && bufferSize > 0)
                {
                    byte[] tmp = new byte[byteCount];
                    int written = Encoding.UTF8.GetBytes(value, 0, value.Length, tmp, 0);

                    // Copy at most bufferSize - 1 bytes (reserve 1 for '\0').
                    int writable = Math.Max(0, bufferSize - 1);
                    int copyLen = Math.Min(written, writable);

                    // Copy to the native buffer and null-terminate.
                    Marshal.Copy(tmp, 0, buffer, copyLen);
                    Marshal.WriteByte(buffer, copyLen, 0);
                }

                // Return the required size (payload bytes + 1 for null).
                return required;
            }
            catch (Exception ex)
            {
                Tizen.Log.Error("NUI", $"InternalStringGetter error for {propertyName}:{ex}");
                return 0;
            }
        }
    }
}
