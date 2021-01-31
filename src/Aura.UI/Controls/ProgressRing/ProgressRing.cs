﻿using Avalonia;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aura.UI.Controls
{
    public partial class ProgressRing : RangeBase
    {
        static ProgressRing()
        {
            MaximumProperty.Changed.Subscribe(CalibrateAngles);
            MinimumProperty.Changed.Subscribe(CalibrateAngles);
            ValueProperty.Changed.Subscribe(CalibrateAngles);

            MaximumProperty.OverrideMetadata<ProgressRing>(new DirectPropertyMetadata<double>(100));
            MinimumProperty.OverrideMetadata<ProgressRing>(new DirectPropertyMetadata<double>(0));
            ValueProperty.OverrideMetadata<ProgressRing>(new DirectPropertyMetadata<double>(25));
            
            AffectsRender<ProgressRing>(XAngleProperty, YAngleProperty);
        }

        private static void CalibrateAngles(AvaloniaPropertyChangedEventArgs<double> e)
        {
            var pr = e.Sender as ProgressRing;

            if(pr != null)
            {
                pr.XAngle = -90;
                var y_ang = Helpers.Maths.Calibrate(pr.Value, pr.Minimum, pr.Maximum);
                Debug.WriteLine($"calibrate val : {y_ang}");
                var y_s = Helpers.Maths.ToSexagesimalDegrees(y_ang) * 4;
                pr.YAngle = y_s;
                Debug.WriteLine($"{y_s} degrees");
            }
        }
    }
}