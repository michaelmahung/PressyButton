using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	void Start () {

		Invoke ("Destruct", 2f);

	}

	void Destruct ()
	{
		Destroy (gameObject);
	}

}
