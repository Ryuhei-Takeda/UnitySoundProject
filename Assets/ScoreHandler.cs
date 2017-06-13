using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //　表示順の移動 //
        transform.SetSiblingIndex( (int) transform.localPosition.y);
		
	}

    // ゲームオブジェクトを削除する
    public void OnScoreClick()
    {
        //削除//
        Destroy(gameObject); 
    }
}
