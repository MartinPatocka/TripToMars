﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rocket", menuName = "Rocket")]
public class RocketScriptableObject : ScriptableObject
{
    public Sprite rocketImage;
    public PolygonCollider2D rocketCollider;
    public int maxFuel;
}
