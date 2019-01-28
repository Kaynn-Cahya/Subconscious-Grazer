﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayShooter : TargettingShooter {

    [Separator("SprayShooter Properties", true)]
    [Range(0, 360), SerializeField, Tooltip("The angle which it will spray around the target point.")]
    private float sprayingAngle;

    protected override void OnShootInvoked() {
        float halfOfSprayingAngle = sprayingAngle / 2f;

        InitBullet(FindShootDirection().Rotate(Random.Range(-halfOfSprayingAngle, halfOfSprayingAngle)));
    }
}