using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float score;
    public float RoundedScore;
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void CalculateScore ()
    {
        score += Time.deltaTime *0.1f;

        RoundedScore = Mathf.Round(score * 100.0f) * 0.01f;
        UIManager.instance.ScoreText.text = "X" + RoundedScore.ToString();
        if (GameManager.instance.startBet)
        {
            float win = GameManager.instance.currentBet * RoundedScore;
            float decimalwin = Mathf.Round(win * 100.0f) * 0.01f;
            UIManager.instance.betMultiplierText.text = decimalwin.ToString() + " TND";
        }
        if (RoundedScore>=GameManager.instance.randomTarget)
        {

            GameManager.instance.inGame = false;
            GameManager.instance.endGame = true;
            UIManager.instance.startBetBtn.interactable = false;
            GameManager.instance.playerMesh.SetActive(false);
            GameManager.instance.explosionFx.SetActive(true);
            GameManager.instance.playerMesh.SetActive(false);
            GameManager.instance.ResetDelayedGame();
            RoundedScore = 0;
        }
    }
}
