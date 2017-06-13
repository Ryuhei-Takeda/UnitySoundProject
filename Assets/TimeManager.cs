using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {


    // 時間 //
    public static float time;


	// Use this for initialization
	void Start () {

        //  初期化 //
        TimeManager.time = 0;

	}
	
	// Update is called once per frame
	void Update () {

        //  更新  //
        TimeManager.time += Time.deltaTime;
	}
}
