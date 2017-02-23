using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public float startSpeed;
    public float speed;
    public float maxSpeed;
    public float increaseSpeed;

    public int score = 0;
    public Text scoreText;

    public GameObject ballImgObj;

    public Vector2 goVelocity;

    public GameObject explosionPrefub;

    public AudioSource audioSound;

    public Sprite fullHP;
    public Sprite middleHP;
    public Sprite lowHP;

    public int maxHPint;
    public int middleHPint;
    public int lowHPint;

    public string winlevelName;
    public string loseLevelName;

	// Use this for initialization
	void Start () {
        speed = startSpeed;
        gameObject.GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;
        score = GameObject.FindGameObjectsWithTag("Brick").Length;
        scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        //goVelocity = gameObject.GetComponent<Rigidbody2D>().a
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Racket")
        {
            Debug.Log("Hello");
            float x = HitFactor(transform.position, coll.gameObject.transform.position, ((BoxCollider2D)coll.collider).size.x);
            Vector2 dir = new Vector2(x, 1).normalized;

            gameObject.GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (coll.gameObject.name == "Racket")
        {
            Debug.Log("Hello");
            float x = HitFactor(transform.position, coll.gameObject.transform.position, ((BoxCollider2D)coll.collider).size.x);
            Vector2 dir = new Vector2(x, 1).normalized;

            gameObject.GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (coll.gameObject.tag == "Brick")
        {
            audioSound.Play();
            GameObject go = (GameObject)Instantiate(explosionPrefub, coll.gameObject.transform.position, Quaternion.identity);
            Destroy(coll.gameObject);
            score--;
            PlayerPrefs.SetInt("CurrentScore", score);
            scoreText.text = score.ToString();

            if (score <= maxHPint && score > middleHPint)
                ballImgObj.GetComponent<SpriteRenderer>().sprite = fullHP;

            if (score <= middleHPint && score > lowHPint)
                ballImgObj.GetComponent<SpriteRenderer>().sprite = middleHP;

            if (score <= lowHPint && score > 0)
                ballImgObj.GetComponent<SpriteRenderer>().sprite = lowHP;
            if(score == 0)
                Application.LoadLevel("lose");
        }

        if(coll.gameObject.name == "GameOver")
        {
            Application.LoadLevel(winlevelName);//("lose");
        }

        if (coll.gameObject.name == "BirdWomen")
        {
            Application.LoadLevel(winlevelName);//("win");
        }
    }

    private float HitFactor(Vector2 ballPos,Vector2 racketPos,float racketWight)
    {
        return (ballPos.x - racketPos.x) / racketWight;
    }
}
