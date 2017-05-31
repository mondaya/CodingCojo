using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    public Text scoreText;
    public Text hiscoreText;

    // the variables
    int score = 0;
    int hiscore;

    // Use this for initialization
    void Start()
    {
        hiscore = PlayerPrefs.GetInt("hiscore", 0);

        scoreText.text = "Score:" + score;
        hiscoreText.text = "HiScore:" + hiscore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void incrementScore()
    {

        // Add to the score
        score++;

        // Update the score text
        scoreText.text = "Score:" + score;

        // Is there a new hiscore?
        if (score > hiscore)
        {

            // Set the new hiscore
            hiscore = score;

            // Save the new hiscore
            PlayerPrefs.SetInt("hiscore", hiscore);

            // Update the hiscore text
            hiscoreText.text = "Hiscore:" + hiscore;
        }
    }
}