﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : Bullet
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
