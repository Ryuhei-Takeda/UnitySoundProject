using UnityEngine;
using System.Collections;

public class BoardMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// Boardを時間に応じて自動移動 //
		// Auto moving for Board at the time. //
		//transform.localPosition = new Vector3( 0, - TimeManager.time * 300, 0 );
		transform.localPosition = new Vector3( 0, - TimeManager.tick * 0.5f, 0 );

	}
}
