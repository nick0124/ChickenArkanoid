using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILevelScore : MonoBehaviour {

    public Text scoreText;

    void Awake()
    {
        scoreText.text = "Level score: " + PlayerPrefs.GetInt("CurrentScore").ToString();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
