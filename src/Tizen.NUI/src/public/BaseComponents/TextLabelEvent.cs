/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A text label.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextLabel
    {
        private EventHandler<AnchorTouchedEventArgs> _textLabelAnchorTouchedEventHandler;
        private AnchorTouchedCallbackDelegate _textLabelAnchorTouchedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AnchorTouchedCallbackDelegate(IntPtr textLabel, IntPtr href, uint hrefLength);

        /// <summary>
        /// The AnchorTouched event.
        /// </summary>
        public event EventHandler<AnchorTouchedEventArgs> AnchorTouched
        {
            add
            {
                if (_textLabelAnchorTouchedEventHandler == null)
                {
                    _textLabelAnchorTouchedCallbackDelegate = (OnAnchorTouched);
                    AnchorTouchedSignal().Connect(_textLabelAnchorTouchedCallbackDelegate);
                }
                _textLabelAnchorTouchedEventHandler += value;
            }
            remove
            {
                _textLabelAnchorTouchedEventHandler -= value;
                if (_textLabelAnchorTouchedEventHandler == null && AnchorTouchedSignal().Empty() == false)
                {
                    AnchorTouchedSignal().Disconnect(_textLabelAnchorTouchedCallbackDelegate);
                }
            }
        }

        internal TextLabelSignal AnchorTouchedSignal()
        {
            TextLabelSignal ret = new TextLabelSignal(Interop.TextLabel.AnchorTouchedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnAnchorTouched(IntPtr textLabel, IntPtr href, uint hrefLength)
        {
            AnchorTouchedEventArgs e = new AnchorTouchedEventArgs();

            // Populate all members of "e" (AnchorTouchedEventArgs) with real data
            e.TextLabel = Registry.GetManagedBaseHandleFromNativePtr(textLabel) as TextLabel;
            e.Href = Marshal.PtrToStringAnsi(href);
            e.HrefLength = hrefLength;

            if (_textLabelAnchorTouchedEventHandler != null)
            {
                //here we send all data to user event handlers
                _textLabelAnchorTouchedEventHandler(this, e);
            }
        }

        /// <summary>
        /// The AnchorChanged event arguments.
        /// </summary>
        public class AnchorTouchedEventArgs : EventArgs
        {
            private TextLabel _textLabel;
            private string _href;
            private uint _hrefLength;

            /// <summary>
            /// TextLabel.
            /// </summary>
            public TextLabel TextLabel
            {
                get
                {
                    return _textLabel;
                }
                set
                {
                    _textLabel = value;
                }
            }
            /// <summary>
            /// Anchor href.
            /// </summary>
            public string Href
            {
                get
                {
                    return _href;
                }
                set
                {
                    _href = value;
                }
            }
            /// <summary>
            /// Anchor href length.
            /// </summary>
            public uint HrefLength
            {
                get
                {
                    return _hrefLength;
                }
                set
                {
                    _hrefLength = value;
                }
            }
        }
    }
}
