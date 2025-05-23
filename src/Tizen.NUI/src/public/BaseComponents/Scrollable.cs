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
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Base class for derived Scrollable that contains actors that can be scrolled manually
    /// (via touch) or automatically.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This has been deprecated in API12")]
    public class Scrollable : View
    {
        static Scrollable()
        {
            if (NUIApplication.IsUsingXaml)
            {
                OvershootEffectColorProperty = BindableProperty.Create(nameof(OvershootEffectColor), typeof(Vector4), typeof(Scrollable), null, propertyChanged: SetInternalOvershootEffectColorProperty, defaultValueCreator: GetInternalOvershootEffectColorProperty);

                OvershootAnimationSpeedProperty = BindableProperty.Create(nameof(OvershootAnimationSpeed), typeof(float), typeof(Scrollable), default(float), propertyChanged: SetInternalOvershootAnimationSpeedProperty, defaultValueCreator: GetInternalOvershootAnimationSpeedProperty);

                OvershootEnabledProperty = BindableProperty.Create(nameof(OvershootEnabled), typeof(bool), typeof(Scrollable), false, propertyChanged: SetInternalOvershootEnabledProperty, defaultValueCreator: GetInternalOvershootEnabledProperty);

                OvershootSizeProperty = BindableProperty.Create(nameof(OvershootSize), typeof(Vector2), typeof(Scrollable), null, propertyChanged: SetInternalOvershootSizeProperty, defaultValueCreator: GetInternalOvershootSizeProperty);

                ScrollToAlphaFunctionProperty = BindableProperty.Create(nameof(ScrollToAlphaFunction), typeof(int), typeof(Scrollable), default(int), propertyChanged: SetInternalScrollToAlphaFunctionProperty, defaultValueCreator: GetInternalScrollToAlphaFunctionProperty);

                ScrollRelativePositionProperty = BindableProperty.Create(nameof(ScrollRelativePosition), typeof(Vector2), typeof(Scrollable), null, propertyChanged: SetInternalScrollRelativePositionProperty, defaultValueCreator: GetInternalScrollRelativePositionProperty);

                ScrollPositionMinProperty = BindableProperty.Create(nameof(ScrollPositionMin), typeof(Vector2), typeof(Scrollable), null, propertyChanged: SetInternalScrollPositionMinProperty, defaultValueCreator: GetInternalScrollPositionMinProperty);

                ScrollPositionMaxProperty = BindableProperty.Create(nameof(ScrollPositionMax), typeof(Vector2), typeof(Scrollable), null, propertyChanged: SetInternalScrollPositionMaxProperty, defaultValueCreator: GetInternalScrollPositionMaxProperty);

                CanScrollVerticalProperty = BindableProperty.Create(nameof(CanScrollVertical), typeof(bool), typeof(Scrollable), false, propertyChanged: SetInternalCanScrollVerticalProperty, defaultValueCreator: GetInternalCanScrollVerticalProperty);

                CanScrollHorizontalProperty = BindableProperty.Create(nameof(CanScrollHorizontal), typeof(bool), typeof(Scrollable), false, propertyChanged: SetInternalCanScrollHorizontalProperty, defaultValueCreator: GetInternalCanScrollHorizontalProperty);
            }
        }


        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public static readonly BindableProperty OvershootEffectColorProperty = null;

        internal static void SetInternalOvershootEffectColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var scrollable = (Scrollable)bindable;
                scrollable.SetInternalOvershootEffectColor((Color)newValue);
            }
        }
        internal static object GetInternalOvershootEffectColorProperty(BindableObject bindable)
        {
            var scrollable = (Scrollable)bindable;
            return scrollable.GetInternalOvershootEffectColor();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public static readonly BindableProperty OvershootAnimationSpeedProperty = null;

        internal static void SetInternalOvershootAnimationSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var scrollable = (Scrollable)bindable;
                scrollable.SetInternalOvershootAnimationSpeed((float)newValue);
            }
        }
        internal static object GetInternalOvershootAnimationSpeedProperty(BindableObject bindable)
        {
            var scrollable = (Scrollable)bindable;
            return scrollable.GetInternalOvershootAnimationSpeed();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public static readonly BindableProperty OvershootEnabledProperty = null;

        internal static void SetInternalOvershootEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var scrollable = (Scrollable)bindable;
                scrollable.SetInternalOvershootEnabled((bool)newValue);
            }
        }
        internal static object GetInternalOvershootEnabledProperty(BindableObject bindable)
        {
            var scrollable = (Scrollable)bindable;
            return scrollable.GetInternalOvershootEnabled();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public static readonly BindableProperty OvershootSizeProperty = null;

        internal static void SetInternalOvershootSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var scrollable = (Scrollable)bindable;
                scrollable.SetInternalOvershootSize((Vector2)newValue);
            }
        }
        internal static object GetInternalOvershootSizeProperty(BindableObject bindable)
        {
            var scrollable = (Scrollable)bindable;
            return scrollable.GetInternalOvershootSize();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public static readonly BindableProperty ScrollToAlphaFunctionProperty = null;

        internal static void SetInternalScrollToAlphaFunctionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var scrollable = (Scrollable)bindable;
                scrollable.SetInternalScrollToAlphaFunction((int)newValue);
            }
        }
        internal static object GetInternalScrollToAlphaFunctionProperty(BindableObject bindable)
        {
            var scrollable = (Scrollable)bindable;
            return scrollable.GetInternalScrollToAlphaFunction();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public static readonly BindableProperty ScrollRelativePositionProperty = null;

        internal static void SetInternalScrollRelativePositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var scrollable = (Scrollable)bindable;
                scrollable.SetInternalScrollRelativePosition((Vector2)newValue);
            }
        }
        internal static object GetInternalScrollRelativePositionProperty(BindableObject bindable)
        {
            var scrollable = (Scrollable)bindable;
            return scrollable.GetInternalScrollRelativePosition();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public static readonly BindableProperty ScrollPositionMinProperty = null;

        internal static void SetInternalScrollPositionMinProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var scrollable = (Scrollable)bindable;
                scrollable.SetInternalScrollPositionMin((Vector2)newValue);
            }
        }
        internal static object GetInternalScrollPositionMinProperty(BindableObject bindable)
        {
            var scrollable = (Scrollable)bindable;
            return scrollable.GetInternalScrollPositionMin();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public static readonly BindableProperty ScrollPositionMaxProperty = null;

        internal static void SetInternalScrollPositionMaxProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var scrollable = (Scrollable)bindable;
                scrollable.SetInternalScrollPositionMax((Vector2)newValue);
            }
        }
        internal static object GetInternalScrollPositionMaxProperty(BindableObject bindable)
        {
            var scrollable = (Scrollable)bindable;
            return scrollable.GetInternalScrollPositionMax();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public static readonly BindableProperty CanScrollVerticalProperty = null;

        internal static void SetInternalCanScrollVerticalProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var scrollable = (Scrollable)bindable;
                scrollable.SetInternalCanScrollVertical((bool)newValue);
            }
        }
        internal static object GetInternalCanScrollVerticalProperty(BindableObject bindable)
        {
            var scrollable = (Scrollable)bindable;
            return scrollable.GetInternalCanScrollVertical();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public static readonly BindableProperty CanScrollHorizontalProperty = null;

        internal static void SetInternalCanScrollHorizontalProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var scrollable = (Scrollable)bindable;
                scrollable.SetInternalCanScrollHorizontal((bool)newValue);
            }
        }
        internal static object GetInternalCanScrollHorizontalProperty(BindableObject bindable)
        {
            var scrollable = (Scrollable)bindable;
            return scrollable.GetInternalCanScrollHorizontal();
        }

        private DaliEventHandler<object, StartedEventArgs> scrollableStartedEventHandler;
        private StartedCallbackDelegate scrollableStartedCallbackDelegate;
        private DaliEventHandler<object, UpdatedEventArgs> scrollableUpdatedEventHandler;
        private UpdatedCallbackDelegate scrollableUpdatedCallbackDelegate;
        private DaliEventHandler<object, CompletedEventArgs> scrollableCompletedEventHandler;
        private CompletedCallbackDelegate scrollableCompletedCallbackDelegate;

        /// <summary>
        /// Create an instance of scrollable.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public Scrollable() : this(Interop.Scrollable.NewScrollable(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Scrollable(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void StartedCallbackDelegate(IntPtr vector2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void UpdatedCallbackDelegate(IntPtr vector2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void CompletedCallbackDelegate(IntPtr vector2);

        /// <summary>
        /// The ScrollStarted event emitted when the Scrollable has moved (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public event DaliEventHandler<object, StartedEventArgs> ScrollStarted
        {
            add
            {
                // Restricted to only one listener
                if (scrollableStartedEventHandler == null)
                {
                    scrollableStartedEventHandler += value;

                    scrollableStartedCallbackDelegate = new StartedCallbackDelegate(OnStarted);
                    using var signal = ScrollStartedSignal();
                    signal.Connect(scrollableStartedCallbackDelegate);
                }
            }

            remove
            {
                if (scrollableStartedEventHandler != null)
                {
                    using var signal = ScrollStartedSignal();
                    signal.Disconnect(scrollableStartedCallbackDelegate);
                }

                scrollableStartedEventHandler -= value;
            }
        }

        /// <summary>
        /// The ScrollUpdated event emitted when the Scrollable has moved (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public event DaliEventHandler<object, UpdatedEventArgs> ScrollUpdated
        {
            add
            {
                // Restricted to only one listener
                if (scrollableUpdatedEventHandler == null)
                {
                    scrollableUpdatedEventHandler += value;

                    scrollableUpdatedCallbackDelegate = new UpdatedCallbackDelegate(OnUpdated);
                    using var signal = ScrollUpdatedSignal();
                    signal.Connect(scrollableUpdatedCallbackDelegate);
                }
            }

            remove
            {
                if (scrollableUpdatedEventHandler != null)
                {
                    using var signal = ScrollUpdatedSignal();
                    signal.Disconnect(scrollableUpdatedCallbackDelegate);
                }

                scrollableUpdatedEventHandler -= value;
            }
        }

        /// <summary>
        /// The ScrollCompleted event emitted when the Scrollable has completed movement
        /// (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public event DaliEventHandler<object, CompletedEventArgs> ScrollCompleted
        {
            add
            {
                // Restricted to only one listener
                if (scrollableCompletedEventHandler == null)
                {
                    scrollableCompletedEventHandler += value;

                    scrollableCompletedCallbackDelegate = new CompletedCallbackDelegate(OnCompleted);
                    using var signal = ScrollCompletedSignal();
                    signal.Connect(scrollableCompletedCallbackDelegate);
                }
            }

            remove
            {
                if (scrollableCompletedEventHandler != null)
                {
                    using var signal = ScrollCompletedSignal();
                    signal.Disconnect(scrollableCompletedCallbackDelegate);
                }

                scrollableCompletedEventHandler -= value;
            }
        }

        /// <summary>
        /// Sets and Gets the color of the overshoot effect.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public Vector4 OvershootEffectColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector4)GetValue(OvershootEffectColorProperty);
                }
                else
                {
                    return GetInternalOvershootEffectColor();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OvershootEffectColorProperty, value);
                }
                else
                {
                    SetInternalOvershootEffectColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalOvershootEffectColor(Vector4 color)
        {
            if (color != null)
            {
                using var pv = new PropertyValue(color);
                Object.SetProperty(SwigCPtr, Property.OvershootEffectColor, pv);
            }
        }

        private Vector4 GetInternalOvershootEffectColor()
        {
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            using (var prop = Object.GetProperty(SwigCPtr, Property.OvershootEffectColor))
            {
                prop.Get(temp);
            }
            return temp;
        }

        /// <summary>
        /// Sets and Gets the speed of overshoot animation in pixels per second.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public float OvershootAnimationSpeed
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(OvershootAnimationSpeedProperty);
                }
                else
                {
                    return GetInternalOvershootAnimationSpeed();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OvershootAnimationSpeedProperty, value);
                }
                else
                {
                    SetInternalOvershootAnimationSpeed(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalOvershootAnimationSpeed(float speed)
        {
            using var pv = new PropertyValue(speed);
            Object.SetProperty(SwigCPtr, Property.OvershootAnimationSpeed, pv);
        }

        private float GetInternalOvershootAnimationSpeed()
        {
            float temp = 0.0f;
            using var prop = Object.GetProperty(SwigCPtr, Property.OvershootAnimationSpeed);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Checks if scroll overshoot has been enabled or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public bool OvershootEnabled
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(OvershootEnabledProperty);
                }
                else
                {
                    return GetInternalOvershootEnabled();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OvershootEnabledProperty, value);
                }
                else
                {
                    SetInternalOvershootEnabled(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalOvershootEnabled(bool enabled)
        {
            using var pv = new PropertyValue(enabled);
            Object.SetProperty(SwigCPtr, Property.OvershootEnabled, pv);
        }

        private bool GetInternalOvershootEnabled()
        {
            bool temp = false;
            using var prop = Object.GetProperty(SwigCPtr, Property.OvershootEnabled);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Gets and Sets OvershootSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public Vector2 OvershootSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(OvershootSizeProperty);
                }
                else
                {
                    return GetInternalOvershootSize();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OvershootSizeProperty, value);
                }
                else
                {
                    SetInternalOvershootSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalOvershootSize(Vector2 size)
        {
            if (size != null)
            {
                using var pv = new PropertyValue(size);
                Object.SetProperty(SwigCPtr, Property.OvershootSize, pv);
            }
        }

        private Vector2 GetInternalOvershootSize()
        {
            Vector2 temp = new Vector2(0.0f, 0.0f);
            using (var prop = Object.GetProperty(SwigCPtr, Property.OvershootSize))
            {
                prop.Get(temp);
            }
            return temp;
        }

        /// <summary>
        /// Gets and Sets ScrollToAlphaFunction property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public int ScrollToAlphaFunction
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(ScrollToAlphaFunctionProperty);
                }
                else
                {
                    return GetInternalScrollToAlphaFunction();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollToAlphaFunctionProperty, value);
                }
                else
                {
                    SetInternalScrollToAlphaFunction(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScrollToAlphaFunction(int func)
        {
            using var pv = new PropertyValue(func);
            Object.SetProperty(SwigCPtr, Property.ScrollToAlphaFunction, pv);
        }

        private int GetInternalScrollToAlphaFunction()
        {
            int temp = 0;
            using var prop = Object.GetProperty(SwigCPtr, Property.ScrollToAlphaFunction);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Gets and Sets ScrollRelativePosition property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public Vector2 ScrollRelativePosition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(ScrollRelativePositionProperty);
                }
                else
                {
                    return GetInternalScrollRelativePosition();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollRelativePositionProperty, value);
                }
                else
                {
                    SetInternalScrollRelativePosition(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScrollRelativePosition(Vector2 pos)
        {
            if (pos != null)
            {
                using var pv = new PropertyValue(pos);
                Object.SetProperty(SwigCPtr, Property.ScrollRelativePosition, pv);
            }
        }

        private Vector2 GetInternalScrollRelativePosition()
        {
            Vector2 temp = new Vector2(0.0f, 0.0f);
            using (var prop = Object.GetProperty(SwigCPtr, Property.ScrollRelativePosition))
            {
                prop.Get(temp);
            }
            return temp;
        }

        /// <summary>
        /// Gets and Sets ScrollPositionMin property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public Vector2 ScrollPositionMin
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(ScrollPositionMinProperty);
                }
                else
                {
                    return GetInternalScrollPositionMin();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollPositionMinProperty, value);
                }
                else
                {
                    SetInternalScrollPositionMin(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScrollPositionMin(Vector2 pos)
        {
            if (pos != null)
            {
                using var pv = new PropertyValue(pos);
                Object.SetProperty(SwigCPtr, Property.ScrollPositionMin, pv);
            }
        }

        private Vector2 GetInternalScrollPositionMin()
        {
            Vector2 temp = new Vector2(0.0f, 0.0f);
            using (var prop = Object.GetProperty(SwigCPtr, Property.ScrollPositionMin))
            {
                prop.Get(temp);
            }
            return temp;
        }

        /// <summary>
        /// Gets and Sets ScrollPositionMax property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public Vector2 ScrollPositionMax
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector2)GetValue(ScrollPositionMaxProperty);
                }
                else
                {
                    return GetInternalScrollPositionMax();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollPositionMaxProperty, value);
                }
                else
                {
                    SetInternalScrollPositionMax(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScrollPositionMax(Vector2 pos)
        {
            if (pos != null)
            {
                using var pv = new PropertyValue(pos);
                Object.SetProperty(SwigCPtr, Property.ScrollPositionMax, pv);
            }
        }

        private Vector2 GetInternalScrollPositionMax()
        {
            Vector2 temp = new Vector2(0.0f, 0.0f);
            using (var prop = Object.GetProperty(SwigCPtr, Property.ScrollPositionMax))
            {
                prop?.Get(temp);
            }
            return temp;
        }

        /// <summary>
        /// Gets and Sets CanScrollVertical property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public bool CanScrollVertical
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(CanScrollVerticalProperty);
                }
                else
                {
                    return GetInternalCanScrollVertical();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CanScrollVerticalProperty, value);
                }
                else
                {
                    SetInternalCanScrollVertical(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCanScrollVertical(bool scroll)
        {
            using var pv = new PropertyValue(scroll);
            Object.SetProperty(SwigCPtr, Property.CanScrollVertical, pv);
        }

        private bool GetInternalCanScrollVertical()
        {
            bool temp = false;
            using var prop = Object.GetProperty(SwigCPtr, Property.CanScrollVertical);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Gets and Sets CanScrollHorizontal property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public bool CanScrollHorizontal
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(CanScrollHorizontalProperty);
                }
                else
                {
                    return GetInternalCanScrollHorizontal();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CanScrollHorizontalProperty, value);
                }
                else
                {
                    SetInternalCanScrollHorizontal(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCanScrollHorizontal(bool scroll)
        {
            using var pv = new PropertyValue((bool)scroll);
            Object.SetProperty(SwigCPtr, Property.CanScrollHorizontal, pv);
        }

        private bool GetInternalCanScrollHorizontal()
        {
            bool temp = false;
            using var prop = Object.GetProperty(SwigCPtr, Property.CanScrollHorizontal);
            prop.Get(out temp);
            return temp;
        }

        internal ScrollableSignal ScrollStartedSignal()
        {
            ScrollableSignal ret = new ScrollableSignal(Interop.Scrollable.ScrollStartedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ScrollableSignal ScrollUpdatedSignal()
        {
            ScrollableSignal ret = new ScrollableSignal(Interop.Scrollable.ScrollUpdatedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ScrollableSignal ScrollCompletedSignal()
        {
            ScrollableSignal ret = new ScrollableSignal(Interop.Scrollable.ScrollCompletedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (this != null)
            {
                DisConnectFromSignals();
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Scrollable.DeleteScrollable(swigCPtr);
        }

        private void DisConnectFromSignals()
        {
            if (scrollableCompletedCallbackDelegate != null)
            {
                using ScrollableSignal signal = new ScrollableSignal(Interop.Scrollable.ScrollCompletedSignal(GetBaseHandleCPtrHandleRef), false);
                signal?.Disconnect(scrollableCompletedCallbackDelegate);
                scrollableCompletedCallbackDelegate = null;
            }

            if (scrollableUpdatedCallbackDelegate != null)
            {
                using ScrollableSignal signal = new ScrollableSignal(Interop.Scrollable.ScrollUpdatedSignal(GetBaseHandleCPtrHandleRef), false);
                signal?.Disconnect(scrollableUpdatedCallbackDelegate);
                scrollableUpdatedCallbackDelegate = null;
            }

            if (scrollableStartedCallbackDelegate != null)
            {
                using ScrollableSignal signal = new ScrollableSignal(Interop.Scrollable.ScrollStartedSignal(GetBaseHandleCPtrHandleRef), false);
                signal?.Disconnect(scrollableStartedCallbackDelegate);
                scrollableStartedCallbackDelegate = null;
            }
        }

        private void OnStarted(IntPtr vector2)
        {
            if (scrollableStartedEventHandler != null)
            {
                StartedEventArgs e = new StartedEventArgs();

                // Populate all members of "e" (StartedEventArgs) with real data
                e.Vector2 = Tizen.NUI.Vector2.GetVector2FromPtr(vector2);
                //here we send all data to user event handlers
                scrollableStartedEventHandler(this, e);
            }

        }

        private void OnUpdated(IntPtr vector2)
        {
            if (scrollableUpdatedEventHandler != null)
            {
                UpdatedEventArgs e = new UpdatedEventArgs();

                // Populate all members of "e" (UpdatedEventArgs) with real data
                e.Vector2 = Tizen.NUI.Vector2.GetVector2FromPtr(vector2);
                //here we send all data to user event handlers
                scrollableUpdatedEventHandler(this, e);
            }

        }

        private void OnCompleted(IntPtr vector2)
        {
            if (scrollableCompletedEventHandler != null)
            {
                CompletedEventArgs e = new CompletedEventArgs();

                // Populate all members of "e" (CompletedEventArgs) with real data
                e.Vector2 = Tizen.NUI.Vector2.GetVector2FromPtr(vector2);
                //here we send all data to user event handlers
                scrollableCompletedEventHandler(this, e);
            }

        }

        private bool IsOvershootEnabled()
        {
            bool ret = Interop.Scrollable.IsOvershootEnabled(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void SetOvershootEnabled(bool enable)
        {
            Interop.Scrollable.SetOvershootEnabled(SwigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetOvershootEffectColor(Vector4 color)
        {
            Interop.Scrollable.SetOvershootEffectColor(SwigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private Vector4 GetOvershootEffectColor()
        {
            Vector4 ret = new Vector4(Interop.Scrollable.GetOvershootEffectColor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void SetOvershootAnimationSpeed(float pixelsPerSecond)
        {
            Interop.Scrollable.SetOvershootAnimationSpeed(SwigCPtr, pixelsPerSecond);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private float GetOvershootAnimationSpeed()
        {
            float ret = Interop.Scrollable.GetOvershootAnimationSpeed(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The scroll animation started event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public class StartedEventArgs : EventArgs
        {
            private Vector2 vector2;

            /// <summary>
            /// Vector2.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Vector2 Vector2
            {
                get
                {
                    return vector2;
                }
                set
                {
                    vector2 = value;
                }
            }
        }

        /// <summary>
        /// The scrollable updated event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public class UpdatedEventArgs : EventArgs
        {
            private Vector2 vector2;

            /// <summary>
            /// Vector2.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Vector2 Vector2
            {
                get
                {
                    return vector2;
                }
                set
                {
                    vector2 = value;
                }
            }
        }

        /// <summary>
        /// The scroll animation completed event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This has been deprecated in API12")]
        public class CompletedEventArgs : EventArgs
        {
            private Vector2 vector2;

            /// <summary>
            /// Vector2.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Vector2 Vector2
            {
                get
                {
                    return vector2;
                }
                set
                {
                    vector2 = value;
                }
            }
        }

        /// <summary>
        /// Enumeration for the instance of properties belonging to the Scrollable class.
        /// </summary>
        internal new class Property
        {
            /// <summary>
            /// The color of the overshoot effect.
            /// </summary>
            internal static readonly int OvershootEffectColor = Interop.Scrollable.OvershootEffectColorGet();
            /// <summary>
            /// The speed of overshoot animation in pixels per second.
            /// </summary>
            internal static readonly int OvershootAnimationSpeed = Interop.Scrollable.OvershootAnimationSpeedGet();
            /// <summary>
            /// Whether to enables or disable scroll overshoot.
            /// </summary>
            internal static readonly int OvershootEnabled = Interop.Scrollable.OvershootEnabledGet();
            /// <summary>
            /// The size of the overshoot.
            /// </summary>
            internal static readonly int OvershootSize = Interop.Scrollable.OvershootSizeGet();
            /// <summary>
            /// scrollToAlphaFunction.
            /// </summary>
            internal static readonly int ScrollToAlphaFunction = Interop.Scrollable.ScrollToAlphaFunctionGet();
            /// <summary>
            /// scrollRelativePosition
            /// </summary>
            internal static readonly int ScrollRelativePosition = Interop.Scrollable.ScrollRelativePositionGet();
            /// <summary>
            /// scrollPositionMin
            /// </summary>
            internal static readonly int ScrollPositionMin = Interop.Scrollable.ScrollPositionMinGet();
            /// <summary>
            /// scrollPositionMinX.
            /// </summary>
            internal static readonly int ScrollPositionMinX = Interop.Scrollable.ScrollPositionMinXGet();
            /// <summary>
            /// scrollPositionMinY.
            /// </summary>
            internal static readonly int ScrollPositionMinY = Interop.Scrollable.ScrollPositionMinYGet();
            /// <summary>
            /// scrollPositionMax.
            /// </summary>
            internal static readonly int ScrollPositionMax = Interop.Scrollable.ScrollPositionMaxGet();
            /// <summary>
            /// scrollPositionMaxX.
            /// </summary>
            internal static readonly int ScrollPositionMaxX = Interop.Scrollable.ScrollPositionMaxXGet();
            /// <summary>
            /// scrollPositionMaxY.
            /// </summary>
            internal static readonly int ScrollPositionMaxY = Interop.Scrollable.ScrollPositionMaxYGet();
            /// <summary>
            /// canScrollVertical
            /// </summary>
            internal static readonly int CanScrollVertical = Interop.Scrollable.CanScrollVerticalGet();
            /// <summary>
            /// canScrollHorizontal.
            /// </summary>
            internal static readonly int CanScrollHorizontal = Interop.Scrollable.CanScrollHorizontalGet();
        }
    }
}
