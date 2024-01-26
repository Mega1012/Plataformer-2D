using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColectableCoin : ItemColectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();


    }





}
