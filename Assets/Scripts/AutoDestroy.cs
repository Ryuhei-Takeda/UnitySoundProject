using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	// アニメーション終了時のイベント //
	// Event for stopping animation //
	public void OnAnimationStop(){
		
		// 削除 //
		// Destroy //
		Destroy( gameObject );
		
	}
	
	// アニメーション終了時のイベント(親を消す処理) //
	// Event for stopping animation(Destroy parent object) //
	public void OnAnimationStopOnParent(){
		
		// 削除 //
		// Destroy //
		Destroy( transform.parent.gameObject );
		
	}
}
