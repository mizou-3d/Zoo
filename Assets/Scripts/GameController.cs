using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text timerText;
    float timer = 60;

    public Text taskTx_1;
    public Text taskTx_2;
    int trashNum = 0;
    int feedNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        taskTx_1.text = "ごみ拾い : " + trashNum + " / 10";
        taskTx_2.text = "えさやり : " + feedNum + " / 5";
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("f2");
        if(timer <= 0)
        {
            timerText.text = "00.00";
            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("Result");
        }
    }

    public void PlusTrash()
    {
        trashNum++;
        taskTx_1.text = "ごみ拾い : " + trashNum + " / 10";

    }

    public void PlusFood()
    {
        feedNum++;
        taskTx_2.text = "えさやり : " + feedNum + " / 5";
    }

    public void PlusTime()
    {
        timer += 15;
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        var gameManager = GameObject.Find("ResultCanvas").GetComponent<ResultController>();
        gameManager.trash = trashNum;
        gameManager.feed = feedNum;

        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
