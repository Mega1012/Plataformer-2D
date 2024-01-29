using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Plataformer.Core.Singleton;

public class UiInGameManager : Singleton<UiInGameManager>
{
    public TextMeshProUGUI uiTextCoins;

    public void UpdateTextCoins(string s)
    {
        uiTextCoins.text = s;
    }
    
    
}
