using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [System.Serializable] class ShopItem
    {
        public Sprite image;
        public int price;
        public bool isPurchased;
    }


}
