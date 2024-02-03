using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColectablePlanets : ItemCollectableBase
{
    public Collider2D collider;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddPlanets();
        collider.enabled = false;
    }
}
