using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	// GameClearアニメーション //
	// Animation of GameClear //
	public GameObject GameClear;
	
	// GameOverアニメーション //
	// Animation of GameOver //
	public GameObject GameOver;

	// 効果音 //
	// SoundEffect //
	
	// Miss時効果音 //
	// SE　when miss //
	public AudioClip onMissSound;
	
	// ゲームクリアー時効果音 //
	// SE when game clear //
	public AudioClip onGameClear;
	
	// ゲームオーバー時効果音 //
	// SE when game over //
	public AudioClip onGameOver;


	// Use this for initialization
	void Start () {
	
		// オーディオを遅延させて再生 //
		// Play audio with delay //
		gameObject.GetComponent<AudioSource>().PlayDelayed( 2.4f );
		
		// デバッグ用 再生位置を移動 //
		// for debug. move play position //
		//GameData.GagePoint = 100;
		//gameObject.GetComponent<AudioSource>().time = gameObject.GetComponent<AudioSource>().clip.length - 1f;		
		
	}
	
	// Update is called once per frame
	void Update () {
	
		// オーディオが止まった時 ゲーム終了 //
		// When audio will be stop, game is finished // 
		if( !gameObject.GetComponent<AudioSource>().isPlaying ){
			
			// ゲージが75以上だった場合はクリア //
			// If gage is more than 75, clear // 
			if( GameData.GagePoint >= 75 ){
			
				// 効果音を鳴らす　//
				// Play sound effect //
				GetComponent<AudioSource>().PlayOneShot(
					onGameClear
				);
			
				// GameClearを表示 //
				// Show Game Clear //
				GameClear.SetActive( true );
			
			// それ以外ならゲームオーバー //
			} else {
				
				// 効果音を鳴らす　//
				// Play sound effect //
				GetComponent<AudioSource>().PlayOneShot(
					onGameOver
				);

				// GameOverを表示 //
				// Show Game Over //
				GameOver.SetActive( true );

			}
			
			// 自身を停止してループを防ぐ //
			// Stop this script and Prevent loop. //
			enabled = false;
			
		}

	}
}
