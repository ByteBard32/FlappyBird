using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class GameManager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI ScoreText;
    public GameObject Button;
    public GameObject gameOver;
    private int score;
    public AudioClip scoreIncreaseSound;
    public AudioClip HitGameovr;

    private string scoreFilePath;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
        string customDirectoryPath = @"C:\Users\sparta\Desktop\Unityscore\";
        string fileName = "score.txt";
        scoreFilePath = Path.Combine(customDirectoryPath, fileName);
    }

    public void Play()
{
   score = 0;
   ScoreText.text = score.ToString();

   Button.SetActive(false);
   gameOver.SetActive(false);

   Time.timeScale = 1f;
   player.enabled = true;

   // Call the ResetPlayer() method on the player object
   
}


    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        Button.SetActive(true);
        gameOver.SetActive(true);
        AudioSource.PlayClipAtPoint(HitGameovr, transform.position);
        SaveScore(score);   
        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        ScoreText.text = score.ToString();

         AudioSource.PlayClipAtPoint(scoreIncreaseSound, transform.position);
        
    }

    private void SaveScore(int finalScore)
    {
        // Create or overwrite the file with the final score
        using (StreamWriter writer = new StreamWriter(scoreFilePath, false))
        {
            writer.WriteLine(finalScore.ToString());
        }
       
    }
}
