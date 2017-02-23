using UnityEngine;
using System.Collections;

public class ExplosionRemover : MonoBehaviour {

	public void RemoveExplosion()
    {
        Destroy(gameObject);
    }
}
