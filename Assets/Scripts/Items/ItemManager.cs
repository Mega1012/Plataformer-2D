using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Plataformer.Core.Singleton;
using System;

public class ItemManager : Singleton<ItemManager>
{
    public static ItemManager Instance;
    public SOInt coins;
    public SOInt Planets;
    public TextMeshProUGUI uiTextPlanets;
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
        Planets.value = 0;
        UpdateUI();
    }


    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }

    public void AddPlanets(int amount = 1)
    {
        Planets.value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //uiTextPlanets.text = Planets.ToString();
        //UiInGameManager.instance.UpdateTextPlanets(coins.value.ToString());
    }


}
