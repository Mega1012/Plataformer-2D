using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Plataformer.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public static ItemManager Instance;
    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //uiTextCoins.text = coins.ToString();
        //UiInGameManager.instance.UpdateTextCoins(coins.value.ToString());
    }

}
