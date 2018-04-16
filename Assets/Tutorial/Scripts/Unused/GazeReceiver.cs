using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GazeReceiver {
    // Modified from http://www.immersivelimit.com/detect-when-looking-at-object/

    /// <summary>
    /// Should be called when the object is being looked at
    /// </summary>
    void GazingUpon();

    /// <summary>
    /// Should be called when the object is no longer being looked at
    /// </summary>
    void NotGazingUpon();
}
