using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public float balance;
    public float currentBet;
    public float additionalBet;
    public float randomTarget;
    public bool inGame;
    public bool startBet,endGame;
    public float winOdd;
    public float countDown;
    public float counter;
    public float timeToResetGame;
    public float newCounter;
    public GameObject explosionFx,playerMesh;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        counter = countDown;
        currentBet = 0;
        RandomTheTarget();

        balance = Mathf.Round(balance * 100.0f) * 0.01f;
        UIManager.instance.balanceText.text = balance.ToString() + " TND";
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
        GamePlay();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
    }

    public void plus ()
    {
        if (balance>=additionalBet)
        {
            if (currentBet + additionalBet <= balance)
            {
                currentBet += additionalBet;
                UIManager.instance.inputBet.text = currentBet.ToString();
            }
            else
            {
                currentBet = balance;
                UIManager.instance.inputBet.text = currentBet.ToString();
            }
        }
        
    }

    public void Moins()
    {
        if (balance >= additionalBet)
        {
            if (currentBet - additionalBet > 0)
            {
                currentBet -= additionalBet;
                UIManager.instance.inputBet.text = currentBet.ToString();
            }
            else
            {
                currentBet = additionalBet;
                UIManager.instance.inputBet.text = currentBet.ToString();
            }
        }
    }

    public void MinValue()
    {
        if (balance >= additionalBet)
        {
            currentBet = additionalBet;
            UIManager.instance.inputBet.text = currentBet.ToString();
        }
    }

    public void MaxValue()
    {
        if (currentBet >= additionalBet)
        {
            currentBet = balance;
            UIManager.instance.inputBet.text = currentBet.ToString();
        }
    }

    public void X2Value()
    {
        if (currentBet>0)
        {
            if (currentBet *2<=balance)
            {
                currentBet *= 2;
                UIManager.instance.inputBet.text = currentBet.ToString();
            }
            else
            {
                currentBet = balance;
                UIManager.instance.inputBet.text = currentBet.ToString();
            }
            
        }
    }

    public void X3Value()
    {
        if (currentBet > 0)
        {
            if (currentBet * 3 <= balance)
            {
                currentBet *= 3;
                UIManager.instance.inputBet.text = currentBet.ToString();
            }
            else
            {
                currentBet = balance;
                UIManager.instance.inputBet.text = currentBet.ToString();
            }

        }
    }

    public void ConvertBet ()
    {
        float.TryParse(UIManager.instance.inputBet.text, out float x);
        currentBet = x;
        Debug.Log("X : " + x);
    }

    public void RandomTheTarget ()
    {
        int x = Random.Range(0, 10);
        if (x<=8)
        {
            randomTarget = Random.Range(1.0f, 2f);
            
        }
        else
        {
            randomTarget = Random.Range(2.0f, 3f);
        }

        randomTarget = Mathf.Round(randomTarget * 10.0f) * 0.1f;

    }

    public void PlaceBet ()
    {
        if (!inGame)
        {
            UIManager.instance.placeBetBtn.gameObject.SetActive(false);
            UIManager.instance.startBetBtn.gameObject.SetActive(true);
            startBet = true;
            balance -= currentBet;

            //balance = Mathf.Round(balance * 100.0f) * 0.01f;
            UIManager.instance.balanceText.text = balance.ToString() + " TND";
        }
        
    }

    public void StartBetting ()
    {
        winOdd = currentBet * Player.instance.RoundedScore;
        balance += winOdd;

        balance = Mathf.Round(balance * 100.0f) * 0.01f;
        UIManager.instance.balanceText.text = balance.ToString() + " TND";
        UIManager.instance.startBetBtn.interactable = false;
        startBet = false;
    }

    public void EndGame ()
    {
        
    }

    public void ResetGame ()
    {
        UIManager.instance.countDownText.gameObject.SetActive(true);
        Player.instance.score = 1;
        Player.instance.RoundedScore = 1;
        UIManager.instance.ScoreText.text = "X"+Player.instance.RoundedScore.ToString();
        UIManager.instance.betMultiplierText.text = "";
        winOdd = 0;
        endGame = false;
        playerMesh.SetActive(true);
        explosionFx.SetActive(false);
        BGScrolling.instance.resetPos();
        UIManager.instance.placeBetBtn.gameObject.SetActive(true);
        UIManager.instance.startBetBtn.gameObject.SetActive(false);
        RandomTheTarget();
    }

    public void CountDown()
    {
        if (!inGame && !endGame)
        {
            counter -= Time.deltaTime;
            UIManager.instance.countDownText.text = ((int)counter).ToString();
            if (counter<=0)
            {
                inGame = true;
                UIManager.instance.countDownText.gameObject.SetActive(false);
                UIManager.instance.startBetBtn.interactable = true;
                counter = countDown;
            }
        }
        
    }

    public void GamePlay ()
    {
        if (!endGame)
        {
            if (inGame)
            {
                Player.instance.CalculateScore();
                BGScrolling.instance.Scrolling();
            }
        }
    }


    IEnumerator delayResetGame ()
    {
        yield return new WaitForSeconds(2);
        ResetGame();
    }

    public void ResetDelayedGame ()
    {
        StartCoroutine(delayResetGame());
    }

    public void place1Bet ()
    {
        if (balance >= 1)
        {
            currentBet = 1;
            UIManager.instance.inputBet.text = currentBet.ToString();

        }
    }

    public void place5Bet()
    {
        if (balance >= 5)
        {
            currentBet = 5;
            UIManager.instance.inputBet.text = currentBet.ToString();

        }
    }

    public void place10Bet()
    {
        if (balance >= 10)
        {
            currentBet = 10;
            UIManager.instance.inputBet.text = currentBet.ToString();

        }
    }

    public void place15Bet()
    {
        if (balance >= 15)
        {
            currentBet = 15;
            UIManager.instance.inputBet.text = currentBet.ToString();

        }
    }

    public void place20Bet()
    {
        if (balance >= 20)
        {
            currentBet = 20;
            UIManager.instance.inputBet.text = currentBet.ToString();

        }
    }

}
