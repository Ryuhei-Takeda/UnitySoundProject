using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointHandler : MonoBehaviour {

	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// ポイントセット //
	// Set point //
	public void setPoint( long point ){
	
		// ポイント変更 //
		// Change point //
		//GetComponent<Text>().text = point.ToString();
	
		// アニメーションを止める //
		// Stop Animation //
		StopCoroutine( "PointAnimation" );
	
		// アニメーションスタート //
		// Start Animation //
		StartCoroutine(
			PointAnimation(
				long.Parse( GetComponent<Text>().text ),
				point,
				0.2f
			)
		);
	
	}
	
	// ポイントアニメーション //
	// Point Animation //
	private IEnumerator PointAnimation( long start, long end, float time ){
		
		// アニメーション開始時間 //
		// Start time of animation //
		float startTime = TimeManager.time;
		
		// アニメーション終了時間 //
		// End time of animation //
		float endTime   = startTime + time;
		
		// １フレームごとに数値を上昇させる //
		// Point change each per frame //
		do {
		
			// アニメーション中のいまの経過時間を計算 //
			// Caluculate animation time //
			float t = ( TimeManager.time - startTime ) / time;
 
			// 数値を更新 //
			// Update point //
			long updateValue = (long)(
				( end - start ) * t
				+ start
			);
			
			// テキストを更新 //
			// Update value //
			GetComponent<Text>().text = updateValue.ToString();

			// １フレーム待つ //
			// Wait 1 frame //
			yield return null;			
			
		} while( TimeManager.time < endTime );
		
		// 数値を最終値に合わせる //
		// set end value //
		GetComponent<Text>().text = end.ToString();

	}
	
	

}
