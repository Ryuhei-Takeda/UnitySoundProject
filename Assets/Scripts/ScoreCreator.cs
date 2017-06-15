using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class ScoreCreator : MonoBehaviour {

	// Scoreのプレハブ //
	// Prefab of "Score" //
	public GameObject scorePrefab;

	// タイマー //
	// Timer //
	//private float timer;
	
	// Jsonテキストデータ //
	// JsonTextData //
	public TextAsset jsonData;
	
	// 音楽データを格納する構造体の配列　//
	// Array for score data //
	public List<MusicData> scoreData;
	
	// TouchBar格納メンバ //
	// Touchbar object //
	public GameObject[] touchBars;
	
	// スコアのXの位置 //
	// Position X of Score //
	private static float[] ScorePositionXList = new float[]{
		-480, -160, 160, 480
	};

	// Use this for initialization
	void Start () {
	
		// scoreDataを初期化 //
		// Initialize the scoreData //
		scoreData = new List<MusicData>();
	
		// ランダム生成のシードをセット //
		// Set a seed //
		Random.seed = 100;
	
		// タイマーを初期化 //
		// Initialize the timer //
		//timer = TimeManager.time + 1f;
		
		// テキストデータを配列に変換 //
		// Change from text data to array data //
		IDictionary tmpData = (IDictionary)Json.Deserialize( jsonData.text );
		
		// 値「”score”」に配列が格納されている //
		// Array data in "score" value //
		List<object> arrayData = (List<object>)tmpData["score"];
		
		// arrayDataを解析 //
		// Analyze arrayData //
		foreach( IDictionary val in arrayData ){
			
			// eventがnote_onの時のみ格納 //
			if( (string)val["event"] == "note_on" ){
				
				scoreData.Add(
					new MusicData(
						(long)val["tick"],
						(int)(long)val["value"]
					)
				);

			}
			
			// eventがset_tempoの時はテンポ情報 //
			// when "event" value is "set_tempo", "value" is tempo infomation. //
			if( (string)val["event"] == "set_tempo" ){

				TimeManager.tempo = (int)(long)val["value"];
			
			}
			
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// 一定時間(1s)ごとに譜面をランダム生成 //
		// Random create a score every 1s time //
		//if(timer < TimeManager.time){
		
		// scoreDataをチェック //
		// Check the scoreData //
		foreach( MusicData tmp in scoreData ){
			
			// 指定したTickを超えたものから生成 //
			// Create score as over tick time //
			if( !tmp.isCreated && TimeManager.tick > tmp.tick ){
								
				// 譜面を生成 //
				// Create a object //
				GameObject scoreObject = Instantiate( scorePrefab );
				
				// 譜面のヒエラルキーを移動 //
				// Move Hierarchy a object //
				scoreObject.transform.parent = transform;
				
				// 譜面のXの位置を決定 //
				// Get a score position x //
				int rand = Random.Range( 0, ScoreCreator.ScorePositionXList.Length );
				float x  = ScoreCreator.ScorePositionXList[rand];
				
				// 譜面のYの位置を決定 //	
				// Get a score position y //
				float y  = tmp.tick * 0.5f + 950; 
					
				// 譜面の位置を移動 //
				// Move Score Position //
				scoreObject.transform.localPosition = new Vector3(
					x,
					//TimeManager.time * 300 + 500,
					y,
					0
				);
				
				// 譜面のスケールをリセット //
				// Reset a score scale //
				scoreObject.transform.localScale = Vector3.one;
				
				// 出現したものの表示順を最奥に設定 //
				// Move FirstSibling the score //
				scoreObject.transform.SetAsFirstSibling();
				
				// TouchBarを渡す //
				// set touchbar object //
				scoreObject.GetComponent<ScoreHandler>().touchBar = touchBars[rand];
				
				// 次の時間をセット //
				// Set a next time //
				//timer = TimeManager.time + 1f;

				// 生成フラグをセット //
				// set true the "isCreated" flag //
				tmp.isCreated = true;

			}
		}
		
	}
}
