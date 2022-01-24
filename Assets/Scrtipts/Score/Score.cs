using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    //public static GameController instance; 
    public int _score, HightScore;
    public Text ScoreText, HightScoreText;

    void Awake()
    {
        //instance = this;
        if(PlayerPrefs.HasKey("SaveScore"))
        {
        HightScore = PlayerPrefs.GetInt("SaveScore");
        }
    }
    void Update()
    {
        ScoreText.text = ((int)_score).ToString();
        HightScoreText.text = ((int)HightScore).ToString();
    }
     
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //instance.AddScore();
            AddScore();
            HightScore ++;
            Destroy(other.gameObject);
        }
    }
    public void AddScore()
    {
        _score ++;
        AddHightScore();
    }
    public void AddHightScore()
    {
        if(_score> HightScore)
        {
            HightScore= _score;
            PlayerPrefs.SetInt("SaveScore", HightScore);        
        }
    }
    public void ResetScore()
    {
        _score = 0;
    }
}
