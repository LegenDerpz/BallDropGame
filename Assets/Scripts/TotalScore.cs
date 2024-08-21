using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    int totalScore;
    int tries = 0;

    public Button leftButton;
    public void AddTotalScore(int score){
        totalScore += score;
    }

    public int GetTotalScore(){
        return totalScore;
    }
    public void AddTotalBallDrops(){
        tries++;
    }
    public int GetTries(){
        return tries;
    }
}
