using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMediumState : MonoBehaviour {

    public delegate void DiedHandler();
    public event DiedHandler Died;


}
