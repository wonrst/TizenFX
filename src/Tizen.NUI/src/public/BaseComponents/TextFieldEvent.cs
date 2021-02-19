/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    /// A control which provides a single line editable text field.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextField
    {
        private EventHandler<TextChangedEventArgs> _textFieldTextChangedEventHandler;
        private TextChangedCallbackDelegate _textFieldTextChangedCallbackDelegate;
        private EventHandler<MaxLengthReachedEventArgs> _textFieldMaxLengthReachedEventHandler;
        private MaxLengthReachedCallbackDelegate _textFieldMaxLengthReachedCallbackDelegate;
        private EventHandler<AnchorTouchedEventArgs> _textFieldAnchorTouchedEventHandler;
        private AnchorTouchedCallbackDelegate _textFieldAnchorTouchedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TextChangedCallbackDelegate(IntPtr textField);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void MaxLengthReachedCallbackDelegate(IntPtr textField);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AnchorTouchedCallbackDelegate(IntPtr textField, IntPtr href, uint hrefLength);

        /// <summary>
        /// The TextChanged event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<TextChangedEventArgs> TextChanged
        {
            add
            {
                if (_textFieldTextChangedEventHandler == null)
                {
                    _textFieldTextChangedCallbackDelegate = (OnTextChanged);
                    TextChangedSignal().Connect(_textFieldTextChangedCallbackDelegate);
                }
                _textFieldTextChangedEventHandler += value;
            }
            remove
            {
                _textFieldTextChangedEventHandler -= value;
                if (_textFieldTextChangedEventHandler == null && TextChangedSignal().Empty() == false)
                {
                    TextChangedSignal().Disconnect(_textFieldTextChangedCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// The MaxLengthReached event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<MaxLengthReachedEventArgs> MaxLengthReached
        {
            add
            {
                if (_textFieldMaxLengthReachedEventHandler == null)
                {
                    _textFieldMaxLengthReachedCallbackDelegate = (OnMaxLengthReached);
                    MaxLengthReachedSignal().Connect(_textFieldMaxLengthReachedCallbackDelegate);
                }
                _textFieldMaxLengthReachedEventHandler += value;
            }
            remove
            {
                if (_textFieldMaxLengthReachedEventHandler == null && MaxLengthReachedSignal().Empty() == false)
                {
                    this.MaxLengthReachedSignal().Disconnect(_textFieldMaxLengthReachedCallbackDelegate);
                }
                _textFieldMaxLengthReachedEventHandler -= value;
            }
        }

        /// <summary>
        /// The AnchorTouched event.
        /// </summary>
        public event EventHandler<AnchorTouchedEventArgs> AnchorTouched
        {
            add
            {
                if (_textFieldAnchorTouchedEventHandler == null)
                {
                    _textFieldAnchorTouchedCallbackDelegate = (OnAnchorTouched);
                    AnchorTouchedSignal().Connect(_textFieldAnchorTouchedCallbackDelegate);
                }
                _textFieldAnchorTouchedEventHandler += value;
            }
            remove
            {
                _textFieldAnchorTouchedEventHandler -= value;
                if (_textFieldAnchorTouchedEventHandler == null && AnchorTouchedSignal().Empty() == false)
                {
                    AnchorTouchedSignal().Disconnect(_textFieldAnchorTouchedCallbackDelegate);
                }
            }
        }

        internal TextFieldSignal TextChangedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(Interop.TextField.TextChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextFieldSignal MaxLengthReachedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(Interop.TextField.MaxLengthReachedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TextFieldSignal AnchorTouchedSignal()
        {
            TextFieldSignal ret = new TextFieldSignal(Interop.TextField.AnchorTouchedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnTextChanged(IntPtr textField)
        {
            TextChangedEventArgs e = new TextChangedEventArgs();

            // Populate all members of "e" (TextChangedEventArgs) with real data
            e.TextField = Registry.GetManagedBaseHandleFromNativePtr(textField) as TextField;

            if (_textFieldTextChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                _textFieldTextChangedEventHandler(this, e);
            }
        }

        private void OnMaxLengthReached(IntPtr textField)
        {
            MaxLengthReachedEventArgs e = new MaxLengthReachedEventArgs();

            // Populate all members of "e" (MaxLengthReachedEventArgs) with real data
            e.TextField = Registry.GetManagedBaseHandleFromNativePtr(textField) as TextField;

            if (_textFieldMaxLengthReachedEventHandler != null)
            {
                //here we send all data to user event handlers
                _textFieldMaxLengthReachedEventHandler(this, e);
            }
        }

        private void OnAnchorTouched(IntPtr textField, IntPtr href, uint hrefLength)
        {
            AnchorTouchedEventArgs e = new AnchorTouchedEventArgs();

            // Populate all members of "e" (AnchorTouchedEventArgs) with real data
            e.TextField = Registry.GetManagedBaseHandleFromNativePtr(textField) as TextField;
            e.Href = Marshal.PtrToStringAnsi(href);
            e.HrefLength = hrefLength;

            if (_textFieldAnchorTouchedEventHandler != null)
            {
                //here we send all data to user event handlers
                _textFieldAnchorTouchedEventHandler(this, e);
            }
        }

        /// <summary>
        /// The TextChanged event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class TextChangedEventArgs : EventArgs
        {
            private TextField _textField;

            /// <summary>
            /// TextField.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TextField TextField
            {
                get
                {
                    return _textField;
                }
                set
                {
                    _textField = value;
                }
            }
        }

        /// <summary>
        /// The MaxLengthReached event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class MaxLengthReachedEventArgs : EventArgs
        {
            private TextField _textField;

            /// <summary>
            /// TextField.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public TextField TextField
            {
                get
                {
                    return _textField;
                }
                set
                {
                    _textField = value;
                }
            }
        }

        /// <summary>
        /// The AnchorChanged event arguments.
        /// </summary>
        public class AnchorTouchedEventArgs : EventArgs
        {
            private TextField _textField;
            private string _href;
            private uint _hrefLength;

            /// <summary>
            /// TextField.
            /// </summary>
            public TextField TextField
            {
                get
                {
                    return _textField;
                }
                set
                {
                    _textField = value;
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
