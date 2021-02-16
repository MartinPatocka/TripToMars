using UnityEngine;
using System;

public enum ESkinId
{
    Default = 0,
    First = 1,
    Second = 2,
    Third = 3
}

[CreateAssetMenu(fileName = "New Rocket", menuName = "Rocket")]
public class RocketScriptableObject : ScriptableObject
{
    public RocketSkin[] rocketSkins;

    public RocketSkin GetSkin(ESkinId skinId)
    {
        for(int i = 0; i < rocketSkins.Length; i++)
        {
            if (skinId == rocketSkins[i].rocketId)
            {
                return rocketSkins[i];
            }
        }
        return rocketSkins[0];   
    }
}

[Serializable]
public class RocketSkin
{
    public ESkinId rocketId;
    public int rocketPrice;
    public Sprite rocketImage;
    public int maxFuel;
}
