using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button plusBtn, moinsBtn, minBtn, maxBtn, X2Btn, X3Btn,placeBetBtn,startBetBtn;
    public InputField inputBet;
    public Text currentBetText,ScoreText,betMultiplierText,countDownText,balanceText;
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    
}
