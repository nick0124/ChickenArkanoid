using UnityEngine;
using System.Collections;

public class RacketController : MonoBehaviour {

    public bool collideLeft = false;
    public bool collideRight = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)&& collideLeft==false)
            gameObject.transform.position -= new Vector3(0.1f, 0);

        if (Input.GetKey(KeyCode.D)&&collideRight==false)
            gameObject.transform.position += new Vector3(0.1f, 0);
	}

    void OnCollisionEnter2D(Collision2D coll) 
    {
        if(coll.gameObject.name=="WallLeft")
        {
            collideLeft = true;
        }

        if (coll.gameObject.name == "WallRight")
        {
            collideRight = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.name == "WallLeft")
        {
            collideLeft = false;
        }

        if (coll.gameObject.name == "WallRight")
        {
            collideRight = false;
        }
    }
}
