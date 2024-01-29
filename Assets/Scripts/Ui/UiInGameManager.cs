using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Plataformer.Core.Singleton;

public class UiInGameManager : Singleton<UiInGameManager>
{
    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextPlanets;

    public void UpdateTextCoins(string s)
    {
        uiTextCoins.text = s;
    }

    public void UpdateTextPlanets(string s)
    {
        uiTextPlanets.text = s;
    }
}
