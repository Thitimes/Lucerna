using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    public float Mspeed;
    public float BaseSpeed;
    public bool IsSlow = false;
    public void SlowDown()
    {
        Mspeed = Mspeed / 2;
    }
    public void NormalSpeed()
    {
        Mspeed = BaseSpeed;
    }

}
