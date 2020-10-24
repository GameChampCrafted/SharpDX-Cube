using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX1
{
    static class Fonts
    {
        public static FontDescription fonArial = new FontDescription()
        {
            Height = 15,
            Italic = false,
            CharacterSet = FontCharacterSet.Ansi,
            FaceName = "Arial",
            MipLevels = 0,
            OutputPrecision = FontPrecision.TrueType,
            PitchAndFamily = FontPitchAndFamily.Default,
            Quality = FontQuality.ClearType,
            Weight = FontWeight.Bold
        };
    }
}
