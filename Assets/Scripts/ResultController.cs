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
        animals = Area_1_Manager.animal1 + Area_2_Manager.animal2 + Area_3_Manager.animal3 + Area_4_Manager.animal4 + Area_5_Manager.animal5;
        trashText.text = "ゴミひろい : " + trash.ToString() + " / 10";
        feedText.text = "えさやり : " + feed.ToString() + " / 5";
        animalText.text = "どうぶつ : " + animals.ToString() + " / 28";

        satisfactionLevel = (trash + feed + animals) / 43f;
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
            SceneManager.LoadScene("Title");
        }
    }
}
