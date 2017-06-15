using UnityEngine;
using System.Collections;

public class MusicData {

	// 音楽譜面データを格納しておく構造体 //
	// Structure for score data //
	
	// Tick //
	public long tick;

	// Value //
	public int value;

	// すでに譜面を生成したかどうかを判別するフラグ //
	// Was Score created? //
	public bool isCreated;

	// コンストラクタ //
	// Constructor //
	public MusicData( long tick, int value ){

		// 値を格納 //
		// Input the value //
		this.tick = tick;
		this.value = value;

		// 初期化 //
		// Initialize //
		this.isCreated = false;

	}

}
