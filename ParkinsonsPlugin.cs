using OpenTabletDriver.Plugin;
using OpenTabletDriver.Plugin.Attributes;
using OpenTabletDriver.Plugin.Tablet;
using System;
using System.Numerics;

namespace Parkinsons
{
    [PluginName("Parkinsons")]
    public class ParkinsonsPlugin : IFilter
    {
        private static readonly Random seed = new Random();

        public Vector2 Filter(Vector2 point)
        {
            point.X += seed.Next(intensity) - offset;
            point.Y += seed.Next(intensity) - offset;
            return point;
        }

        public FilterStage FilterStage => FilterStage.PostTranspose;
        
        private int intensity;
        private int offset;
        [Property("Intensity")]
        public int Intensity {
            get => intensity;
            set {
                intensity = value;
                offset = value / 2;
            }
        }
    }
}
