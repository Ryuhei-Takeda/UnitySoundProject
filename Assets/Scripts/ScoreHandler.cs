using UnityEngine;
using System.Collections;

public class ScoreHandler : MonoBehaviour {
	
	// タッチエフェクトプレハブ //
	// Prefab of TouchRing //
	public GameObject touchRingPrefab;

	// ポイントテキストプレハブ //
	// Prefab of Point Text //
	public GameObject pointText;

	// 各ポイント評価用のテキストスプライト //
	// TextSprite of each point value //
	public Sprite[] textSprite;
	
	// 各ポイントのスプライト用変数 //
	// enum for text sprite //
	public enum PointTextKey {
		Miss, Bad, Good, Great, Perfect
	}
	
	// PointHandlerのセット //
	// Set PointHandler //
	public PointHandler pointHandler;
	
	// PointHandlerのセット //
	// Set PointHandler //
	public GageHandler gageHandler;
	
	// TouchBarのセット //
	// TouchBar object //
	public GameObject touchBar;
	
	// Use this for initialization
	void Start () {
		
		// 生成されてから削除されるまでのTick //
		// Tick until delete //
		int tick = 3140;
		
		// AutoDestroyをインボーク //
		// Invoke "AutoDestroy" //
		Invoke(
			"AutoDestroy",
			60f * tick / (TimeManager.tempo * 480f)
		);
		
		// PointHandlerのセット //
		// Set PointHandler //
		pointHandler = FindObjectOfType<PointHandler>();
		
		// PointHandlerのセット //
		// Set PointHandler //
		gageHandler  = FindObjectOfType<GageHandler>();

	}
	
	// Update is called once per frame
	void Update () {
		
		// Y軸に合わせて表示順を移動させる //
		// Move SiblingIndex with Y axis //
		//transform.SetSiblingIndex( (int)transform.localPosition.y );
		
	}
	
	// スコアがクリックされた時実行 //
	// PlayOnScoreClick //
	public void OnScoreClick(){
	
		// Board外の位置を計算 //
		// Calculate position outside Board //
		Vector3 PositionInGame = GetComponentInParent<BoardMove>().transform.localPosition + transform.localPosition;
		
		// 距離を計算 //
		// Calculate distance //
		int Distance = (int)Mathf.Abs( PositionInGame.y - ( - 300 ) );
		
		// ポイントを計算し正規化 //
		// Calculate point and normalize //
		float distancePoint = ( 100 - Distance ) / 100f;
		
		// ポイントが０以下の場合はポイントを0にする //
		// if point is less than 0, point is 0 //
		if( distancePoint < 0 ) distancePoint = 0;
		
		// ポイントを加算 //
		// Adding point to GameData //
		GameData.score += (int)( distancePoint * 1000 );
		
		// ゲージを加算 //
		// Adding GagePoint to GameData //
		GameData.GagePoint += distancePoint * 2;
		
		// ゲージを制限 //
		// Limit gage point //
		if( GameData.GagePoint > 100 ) GameData.GagePoint = 100;
		
		// ポイントを確認 //
		// Check the point //
		//Debug.Log( GameData.score );
		
		// TouchBarをアニメーション //
		// Animation TouchBar //
		touchBar.GetComponent<Animator>().SetTrigger( "Touch" );
		
		// ポイントが0以下のときは譜面を消さない //
		// if point is less than 0, score don't delete //
		if( distancePoint > 0 ) {
			
			// 譜面を削除 //
			// Destroy this object //
			Destroy( gameObject );
			
			// エフェクトオブジェクトを生成 //
			GameObject touchObject = Instantiate( touchRingPrefab );
			
			// エフェクトの位置の移動とサイズをリセット //
			// Move Object Position //
			//touchObject.transform.position   = transform.position;
			touchObject.transform.position   = touchBar.transform.position;
			touchObject.transform.localScale = Vector3.one;
			
			// アニメーションを開始 //
			touchObject.GetComponent<Animator>().Play( 0 );

			// 評価用テキスト表示 //
			// Show point text //
			showText( distancePoint );
			
			// スコアを更新 //
			// Update point hander //
			pointHandler.setPoint( GameData.score );
			
			// ゲージを更新 //
			// Update gage hander //
			gageHandler.setGage( GameData.GagePoint );

		}
		
	}
	
	// 評価用テキスト作成 //
	// Show point text //
	private void showText( float point ){
		
		// エフェクトオブジェクトを生成 //
		GameObject pointObject = Instantiate( pointText );
		
		// エフェクトの位置の移動とサイズをリセット //
		// Move Object Position //
		//pointObject.transform.position   = transform.position + new Vector3( 0, 1f, 0 );
		pointObject.transform.position   = touchBar.transform.position + new Vector3( 0, 1f, 0 );
		pointObject.transform.localScale = Vector3.one;
		
		// ポイントに応じて画像を入替え //
		// Change sprite due to point //
		if( point > 0.8f )
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Perfect];
		else if( point > 0.6f )
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Great];
		else if( point > 0.4f )
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Great];
		else if( point > 0.2f )
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Good];
		else if( point > 0 )
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Bad];
		else
			pointObject.GetComponentInChildren<SpriteRenderer>().sprite = textSprite[(int)PointTextKey.Miss];
		
		// アニメーションを開始 //
		pointObject.GetComponentInChildren<Animator>().Play( 0 );
		
	}
	
	// 自動で削除する //
	// Auto Destroy //
	public void AutoDestroy(){

		// 譜面を削除 //
		// Destroy this object //
		Destroy( gameObject );

		// 自動で削除時はshowTextに0を渡す //
		// Excecute showText( 0 ) when this time //
		showText( 0 );
		
		// ゲージを減算 //
		// Reducing GagePoint to GameData //
		GameData.GagePoint -= 2;
		
		// ゲージを制限 //
		// Limit gage point //
		if( GameData.GagePoint < 0 ) GameData.GagePoint = 0;
		
		// ゲージを更新 //
		// Update gage hander //
		gageHandler.setGage( GameData.GagePoint );
		
		// 効果音を鳴らす　//
		// Play sound effect //
		FindObjectOfType<AudioManager>().GetComponent<AudioSource>().PlayOneShot(
			FindObjectOfType<AudioManager>().onMissSound
		);
	}
	
}
