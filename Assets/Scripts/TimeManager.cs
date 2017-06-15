using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
	
	// 時間管理用 //
	// For managing time //
	public static float time;
	
	// テンポ情報 //
	// infomation of tempo(BPM) //
	public static int tempo;
	
	// MIDI時間管理用 //
	// For managing midi time //
	public static long tick;


	// Use this for initialization
	void Awake () {
		
		// timeを初期化 //
		// Initialize "time" value //
		TimeManager.time = 0;

		// tickを初期化 //
		// Initialize "tick" value //
		TimeManager.tick = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
		// timeを更新 //
		// Update the time //
		TimeManager.time += Time.deltaTime;

		// timeからtickを計算 //
		// calculate tick from time //
		TimeManager.tick = (long)(
			TimeManager.time * (TimeManager.tempo * 480f) / 60f
		);

	}
}
