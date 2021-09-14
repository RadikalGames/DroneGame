using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField]
    private Text ScoreText;
    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
    }
}
