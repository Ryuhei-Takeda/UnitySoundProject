using UnityEngine;
using System.Collections;

public class GageHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// ゲージセット //
	// Set gage //
	public void setGage( float point ){
		
		// ゲージの長さを計算 //
		// Calculate length of gage //
		float length = point / 100f;
		
		// ゲージ変更 //
		// Change gage //
		//transform.localScale = new Vector3( length, 1, 1 );
		
		// アニメーションを止める //
		// Stop Animation //
		StopCoroutine( "GageAnimation" );
		
		// アニメーションスタート //
		// Start Animation //
		StartCoroutine(
			GageAnimation(
			transform.localScale.x,
			length,
			0.2f
			)
		);
	}
	
	// ゲージアニメーション //
	// Gage Animation //
	private IEnumerator GageAnimation( float start, float end, float time ){
		
		// アニメーション開始時間 //
		// Start time of animation //
		float startTime = TimeManager.time;
		
		// アニメーション終了時間 //
		// End time of animation //
		float endTime   = startTime + time;
		
		// １フレームごとに数値を上昇させる //
		// Gage change each per frame //
		do {
			
			// アニメーション中のいまの経過時間を計算 //
			// Caluculate animation time //
			float t = ( TimeManager.time - startTime ) / time;
			
			// 数値を更新 //
			// Update point //
			float updateValue = (
				( end - start ) * t
				+ start
			);
			
			// テキストを更新 //
			// Update value //
			transform.localScale = new Vector3( updateValue, 1, 1 );
			
			// １フレーム待つ //
			// Wait 1 frame //
			yield return null;			
			
		} while( TimeManager.time < endTime );
		
		// 数値を最終値に合わせる //
		// set end value //
		transform.localScale = new Vector3( end, 1, 1 );
		
	}
	
}
