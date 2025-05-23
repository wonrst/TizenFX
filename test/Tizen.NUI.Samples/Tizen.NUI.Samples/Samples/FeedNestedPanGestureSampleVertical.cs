using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class FeedNestedPanGestureSampleVertical : IExample
    {
        private View root;

        public class MyScrollView : View {
            public enum Direction
            {
                Horizontal,
                Vertical
            }
            public View ContentContainer { get; set; }

            private PanGestureDetector mPanGestureDetector;
            private Direction mScrollDirection = Direction.Vertical;
            private float maxScrollDistance;
            private float childTargetPosition = 0.0f;

            public MyScrollView() : base()
            {
                Tizen.Log.Error("NUI", $"MyScrollView\n");
                ClippingMode = ClippingModeType.ClipToBoundingBox;
                base.Layout = new AbsoluteLayout();
                ContentContainer = new View()
                {
                    BackgroundColor = Color.Grey,
                };

                ContentContainer.Relayout += OnScrollingChildRelayout;
                base.Add(ContentContainer);
                base.Relayout += OnScrollingChildRelayout;
                this.TouchEvent += OnTouchEvent;
                mPanGestureDetector = new PanGestureDetector();
                mPanGestureDetector.Detected += OnPanGestureDetected;
            }

            public override void Add(View view)
            {
                ContentContainer.Add(view);
            }

            public void SetDirection(Direction direction)
            {
                mScrollDirection = direction;
                mPanGestureDetector.ClearAngles();
                mPanGestureDetector.AddDirection(direction == Direction.Horizontal ?
                        PanGestureDetector.DirectionHorizontal : PanGestureDetector.DirectionVertical);
            }

            private bool OnTouchEvent(object source, View.TouchEventArgs e)
            {
                bool ret = mPanGestureDetector.HandleEvent(source as View, e.Touch);
                Tizen.Log.Error("NUI", $"OnTouchEvent {e.Touch.GetState(0)} : {ret}\n");
                return ret;
            }

            private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
            {
                if(e.PanGesture.State == Gesture.StateType.Started)
                {
                    var checkDisplacement = (mScrollDirection == Direction.Horizontal) ? e.PanGesture.Displacement.X : e.PanGesture.Displacement.Y;
                    var checkChildCurrentPosition = (mScrollDirection == Direction.Horizontal) ? ContentContainer.PositionX : ContentContainer.PositionY;
                    var checkChildTargetPosition = checkChildCurrentPosition + checkDisplacement;
                    var checkFinalTargetPosition = BoundScrollPosition(checkChildTargetPosition);
                    bool handled = !((int)checkFinalTargetPosition == 0 || -(int)checkFinalTargetPosition == (int)maxScrollDistance);
                    Tizen.Log.Error("NUI", $"OnPanGestureDetected Started {checkFinalTargetPosition} {maxScrollDistance} {handled}\n");
                    // If you propagate a gesture event, return;
                    if (!handled)
                    {
                        e.Handled = handled;
                        return;
                    }
                }
                else if (e.PanGesture.State == Gesture.StateType.Continuing)
                {
                    Tizen.Log.Error("NUI", $"OnPanGestureDetected mScrollDirection : {mScrollDirection} \n");
                    if(mScrollDirection == Direction.Horizontal)
                    {
                        ScrollBy(e.PanGesture.Displacement.X);
                    }
                    else
                    {
                        ScrollBy(e.PanGesture.Displacement.Y);
                    }

                }
                else if (e.PanGesture.State == Gesture.StateType.Finished || e.PanGesture.State == Gesture.StateType.Cancelled)
                {
                    Tizen.Log.Error("NUI", $"OnPanGestureDetected Finished or Cancelled\n");
                }
            }

            private void OnScrollingChildRelayout(object source, EventArgs args)
            {
                maxScrollDistance = CalculateMaximumScrollDistance();
            }

            private float CalculateMaximumScrollDistance()
            {
                float scrollingChildLength = 0;
                float scrollerLength = 0;
                if (mScrollDirection == Direction.Horizontal)
                {
                    scrollingChildLength = ContentContainer.Size.Width;
                    scrollerLength = Size.Width;
                }
                else
                {
                    scrollingChildLength = ContentContainer.Size.Height;
                    scrollerLength = Size.Height;
                }
                return Math.Max(scrollingChildLength - scrollerLength, 0);
            }

            private void ScrollBy(float displacement)
            {
                float childCurrentPosition = (mScrollDirection == Direction.Horizontal) ? ContentContainer.PositionX : ContentContainer.PositionY;
                childTargetPosition = childCurrentPosition + displacement;
                float finalTargetPosition = BoundScrollPosition(childTargetPosition);

                if (mScrollDirection == Direction.Horizontal)
                {
                    ContentContainer.PositionX = finalTargetPosition;
                }
                else
                {
                    ContentContainer.PositionY = finalTargetPosition;
                }
            }

            private float BoundScrollPosition(float targetPosition)
            {
                targetPosition = Math.Min(0, targetPosition);
                targetPosition = Math.Max(-maxScrollDistance, targetPosition);
                return targetPosition;
            }

        }
        public void Activate()
        {
            NUIApplication.SetGeometryHittestEnabled(true);
            Window window = NUIApplication.GetDefaultWindow();
            root = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            var myScrollView01 = new MyScrollView()
            {
                Size2D = new Size2D(1000,1000),
            };
            myScrollView01.ContentContainer.Size2D = new Size2D(1000, 2000);
            myScrollView01.SetDirection(MyScrollView.Direction.Vertical);
            myScrollView01.ContentContainer.Layout = new LinearLayout
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                CellPadding = new Size2D(20, 20),
            };


            myScrollView01.Add(GetNewScrollView(Color.Orange));
            myScrollView01.Add(GetNewScrollView(Color.Blue));
            myScrollView01.Add(GetNewScrollView(Color.Red));
            myScrollView01.Add(GetNewScrollView(Color.Cyan));
            myScrollView01.Add(GetNewScrollView(Color.DarkOrange));
            myScrollView01.Add(GetNewScrollView(Color.DarkBlue));


            root.Add(myScrollView01);

            window.Add(root);
        }

        public View GetNewScrollView(Color color)
        {
            var scrollView = new MyScrollView()
            {
                Size2D = new Size2D(900, 500),
            };
            scrollView.ContentContainer.Size2D = new Size2D(900, 1000);
            scrollView.ContentContainer.BackgroundColor = color;
            scrollView.SetDirection(MyScrollView.Direction.Vertical);
            scrollView.ContentContainer.Layout = new LinearLayout
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                // VerticalAlignment = VerticalAlignment.Center,
                CellPadding = new Size2D(50, 50),
            };
            for (int i=0; i<20; i++)
            {
                var item = new View()
                {
                    Size2D = new Size2D(100, 100),
                    BackgroundColor = Color.DarkBlue,
                };
                scrollView.Add(item);
            }
            return scrollView;
        }


        public void Deactivate()
        {
            NUIApplication.SetGeometryHittestEnabled(false);
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
