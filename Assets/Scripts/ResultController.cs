using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    public Text trashText;
    public Text feedText;
    public Text animalText;
    public Text satisfactionLevelText;
    float satisfactionLevel;
    public Image satisfactionLevelGaude;

    public int trash;
    public int feed;
    public int animals;


    // Start is called before the first frame update
    void Start()
    {
        trashText.text = "ゴミひろい : " + trash.ToString() + " / 10";
        feedText.text = "えさやり : " + feed.ToString() + " / 5";

        satisfactionLevel = (trash + feed) / 15f;
        //Debug.Log(satisfactionLevel);
        satisfactionLevelText.text = (satisfactionLevel * 100).ToString("f1") + "%";
        satisfactionLevelGaude.fillAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        satisfactionLevelGaude.fillAmount += 0.2f * Time.deltaTime;
        if(satisfactionLevelGaude.fillAmount >= satisfactionLevel)
        {
            satisfactionLevelGaude.fillAmount = satisfactionLevel;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Stage_1");
        }
    }
}
