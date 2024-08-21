using System.Collections;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TextMeshPro pointLabel;
    public TextMeshProUGUI totalScoreGUI;
    public TotalScore totalScore;
    public Ball ballPos;
    public GameObject ball;
    public CinemachineVirtualCamera cam;

    void Start(){
        ChangeCamTarget();
    }

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Coin")){
            totalScore.AddTotalBallDrops();
            Debug.Log("Scored " + pointLabel.text + " points!");
            int score = int.Parse(pointLabel.text);
            totalScore.AddTotalScore(score);
            totalScoreGUI.text = "Score: " + totalScore.GetTotalScore().ToString();
            StartCoroutine(labelGlow());

            //Destroy(collider.gameObject, 2f);

            StartCoroutine(ResetBall());
        }
    }

    IEnumerator labelGlow(){
        pointLabel.color = Color.green;
        pointLabel.outlineColor = Color.green;
        pointLabel.outlineWidth = 2;

        yield return new WaitForSeconds(1f);

        pointLabel.color = Color.white;
        pointLabel.outlineColor = Color.white;
        pointLabel.outlineWidth = 0;
    }

    void ChangeCamTarget(){
        cam.m_Follow = FindObjectOfType<Ball>().transform;
        cam.m_LookAt = FindObjectOfType<Ball>().transform;
    }

    IEnumerator ResetBall(){
        yield return new WaitForSeconds(2.1f);

        if(totalScore.GetTries() < 3){
            ballPos.rb.velocity = Vector3.zero;
            ballPos.transform.position = new Vector3(0.05f, 19.96f, 4.43f);
            ballPos.transform.rotation = Quaternion.identity;
            ballPos.GetComponent<PlayerInput>().enabled = true;
            ballPos.rb.useGravity = false;
            ChangeCamTarget();
        }else{
            Debug.Log("No more tries!");
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("MainMenu");
        }
    }

}
