using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _startingSong;
    [SerializeField] Text _highScoreTextView;

    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
        if(_startingSong != null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }        
    }

    public void ResetData()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
        Debug.Log("Data Reset");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
