using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private int score;
    private int multi;
    private int hitCount;

    public Text scoreText;
    public Text multiText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        multi = 1;
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit() {
        score += multi;
        scoreText.text = score.ToString("00000");
        if(hitCount > 10) {
            multi++;
            multiText.text = "x" + multi.ToString();
            hitCount = 0;
        }
        hitCount++;
    }

    public void Miss() {
        multi = 1;
        hitCount = 0;
        multiText.text = "x" + multi.ToString();
    }
}
