using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public string constText;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();    
    }


    void Update()
    {
        text.text = constText + PlayerVariable.score;
    }
}
