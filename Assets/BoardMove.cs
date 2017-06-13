using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMove : MonoBehaviour {

    //時間管理//
    public float time;


	// Use this for initialization
	void Start () {
  	
	}
	
	// Update is called once per frame
	void Update () {

        //時間の更新//
        time += Time.deltaTime;

        transform.localPosition = new Vector3(0,  - TimeManager.time * 100, 0);

	}
}
