using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        trashText.text = "ごみ拾い : " + trash + " / 10";
        feedText.text = "えさやり : " + feed + " / 5";

        satisfactionLevel = (trash + feed) / 15;
        satisfactionLevelText.text = (satisfactionLevel * 100) + "%";

        satisfactionLevelGaude.fillAmount = satisfactionLevel;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
