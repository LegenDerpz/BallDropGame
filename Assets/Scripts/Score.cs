using System.Collections;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshPro pointLabel;
    public TextMeshProUGUI score;

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Coin")){
            Debug.Log("Scored " + pointLabel.text + " points!");
            score.text = "Score: " + int.Parse(pointLabel.text);
            StartCoroutine(labelGlow());

            Destroy(collider.gameObject, 2f);
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
}
