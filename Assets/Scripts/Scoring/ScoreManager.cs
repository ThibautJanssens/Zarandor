using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreManager : ScriptableObject {

    public ListenableInt score;
    public ListenableInt highscore;

    private void OnEnable() {
        ResetScore();
    }

    private void OnDisable() {
        PlayerPrefs.SetInt(highscore.name, highscore.Value);
    }

    public void AddScore(int delta){
        score.Value += delta;
        UpdateHighscore();
    }

    public void UpdateHighscore(){
        if(score.Value > highscore.Value){
            highscore.Value = score.Value;
        }
    }

    public void ResetScore(){
        score.Value = 0;
        highscore.Value = PlayerPrefs.GetInt(highscore.name, 0);
    }

    public void resetHighscore(){
        highscore.Value = 0;
    }
}
