using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacMan
{
    /// <summary>
    /// Specifies the variations of GhostMode 
    /// </summary>
    public enum GhostMode : byte
    {
        Aggressive = 0,
        Frightened,
        Eaten,
        Random
    }
}
