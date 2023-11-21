# Public class GameMain:MonoBehaviour 

人生ゲーム全体の進行を行う。ターンの進行や強制イベントの発生、季節の変更などを行う。 

## フィールド 
- public static GameMain gameMain 
  - どこからでもgameMainを参照できるようにするため 
- public Player playerObject 
  - playerのプレハブをインスペクタータブから取得するための変数 
- public Player currentPlayer
  - 現在待機中のプレイヤー
- public const bool english
  - 英語表記にするか否か
- private Year year = new Year()
  - 年のクラス。たぶん今回は使わない。
- Private Season season
- private Round round = new Round()
- private Turn turn = new Turn( Players.numberOfPlayer )
- private Dice dice = new Dice()
- private ForcedEvents fevents;

## 関数
- private void Awake() 
  - 各種変数の初期化 
- void Start() 
  - ゲーム開始の関数
- private void startGame() 
  - 始めの各種設定を行っている関数 
- public void turnStart() 
  - ターン開始時に呼び出される関数
  public void turnEnd()
    マス目の効果が終了した時に呼び出される関数
- private void changeSeason()
- private void diceCallback()
- private void generatePlayer() 
  - プレイヤーを生成する関数 

# public class Players

## フィールド
- private List<Player> players;
- public Player playerObject;
- public const int numberOfPlayer
- private List<int> order

## 関数
- public Players()
- public void setOrder()
- public Player getPlayer(in Turn turn)
- public List<Player> getAllPlayers()
- public void add(Player player)
- public bool setOrder(List<int> o)
  - プレイヤーの順番を渡して適応可能かをboolで返す 
- public Player getPlayer(int id) 

# public class Map:MonoBehaviour 

マップ情報を管理するクラス 

## フィールド 

- public static Map map 
  - mapをどこからでも参照するための変数 
- public RealSquare squareObject 
  - マス目を生成するためのプレハブ 
- private List<Vector3>route 
  - マス目の描き方を記すリスト 
- private List<RealSquare>realSquares 
  - RealSquareを格納するリスト 
- private List<Square> nowSquare 
  - 現在のまっぷのSquareを格納するList 
- private List<int>positions 
  - 全てのプレイヤーの位置情報をallPlayersの引数を引数として現在のマス目の番号を返す 
- private List<List<int>> arragement 
  - どのマスに誰がどの順番で所属しているかを示すリスト 

## 関数 

- private void generateSquare() 
  - マス目のプレハブを生成する関数 
- private async void changeOfSeason(Season season) 
  - すべてのマスの画像をseasonに対応して変換して、nowSquareをseasonに合わせて変換する関数 
- public List<RealSquare>getRealSquares() 
  - realSquaresを返す 
- public Square getSquare(int n) 
  - 特定のマス目のSquareを取得する関数 
- public void addPosition(int id) 
  - ゲーム開始時にarragementとpositionsにプレイヤーを追加する関数 
- public int getPosition(int id) 
  - idが指定するプレイヤーの位置を返す関数 
- public int getArragement(int id) 
  - idが指定するプレイヤーが止まっているマス目の何番目に止まったかを返す関数 
- public void setPosition(int id,int n) 
  - idが指定するプレイヤーの止まっているマス目を更新する関数 
- public int getSquarePeople(int n) 
  - 特定のマス目に滞在している人数を返す関数 
- public Vector3 getRoute(int n) 
  - 特定のマス目のTransform.positionにおける位置情報を返す関数 


# public class Player:MonoBehaviour 

プレイヤーの情報を格納するクラス 

## フィールド 
- public SpriteRenderer sr;
  - プレイヤーの地図上でのアイコンのSpriterendererを格納する変数 
- public int id; 
  - GameMainのgetPlayer、getPlayerOrderの引数となる変数 
- public int position;
- public float speed;
- public float error;
  - マス目の間をプレイヤーが移動する速度と、その誤差の許容範囲 
- private bool move;
  - プレイヤーが移動中かどうかを判定
- private Vector3 dst;
  - プレイヤーが移動する目的座標 
- private Vector3 dir;
  - プレイヤーが移動する向き 
- public PlayerInformation pi;
  - Playerの各種情報を格納する変数 

## 関数

- public void initialization(int id) 
  - 初期化を行い、マス目の正しい位置に配置する関数 
- public void resetPosition() 
  - 一つの季節が終わって次の季節に移るときプレイヤーの位置を初期化する関数 
- private void arrange() 
  - 自信をマス目の正しい位置に配置する関数 
- public void proceed(int number) 
  - 自分のマス目を進め、マス目の効果を発動する関数 


# public class PlayerInformation

## フィールド
- public string name 
  - このプレイヤーの名前を保持する変数 
- public Sprite sprite;
  - プレイヤーがはじめ選択した画像を格納する変数 
- public Gender gender = Gender.UNDEFINED;
  - 性別 
- public Academic academic = Academic.UNDEFINED_ACADEMIC;
  - 学力 
- public Appearance appearance = Appearance.UNDEFINED_APPEARANCE;
  - 容姿 
- public Luck luck = Luck.UNDEFINED_LUCK;
  - 運 
- public Gender loveInterest = Gender.UNDEFINED;
  - 愛する人の性別 
- public Lovers lovers = new Lovers();
  - プレイヤーが選択できるすべてのヒロイン 
- public Lover lover = Lover.UNDEFINED;
  - プレイやーが付き合っている人 
- public Activity activity = new PartTime();


## 関数 

- public PlayerInformation() 
  - 空のPlayerInformationのコンストラクタ 
- public PlayerInformation(string ...) 
  - PlayerInformationを初期化するコンストラクタ 
- public static PlayerInformation getInformation(int id) 
  - Listからidで指定したPlayerInformationを取得する 
- Public void setActivity( int activityID ) 
  - アクティビティIDを指定し、あくてぃびてぃを入れる。 
  

# public abstract class Square:MonoBehaviour 

すべてのマスの親クラス 

## フィールド 
- public SpriteRenderer sr 
  - このマス目のSpriteRenderer 
- public TextMeshPro text 
  - このマス目のTextMeshPro 


## 関数 
- public abstract void execute(Player player) 
  - マス目の効果を記述する 
- protected void finish() 
  - マス目の効果が終了したときに必ず呼び出す必要のある関数 


# public class RealSquare:MonoBehaviour 
マスのプレハブにアタッチして各種コンポーネントを保持してMapが取得できるようにするもの 

## フィールド 
- public SpriteRenderer sr 
  - 自分のインスペクタータブからコンポーネントをアタッチするためのSpriteRendererのための変数 
- public TextMeshPro text 
  - 自分のインスペクタータブからコンポーネントをアタッチするためのTextMeshProのための変数 


# public abstract class SeasonSquares:MonoBehaviour 

すべての季節マスをまとめたクラスの親クラス 

## 関数 

- public abstract List<Square> changeOfSquare(List<RealSquare>rsquares) 
  - すべてのマス目のコンストラクタをここで行いリストにして出力する 

# public class SpringSquares:SeasonSquares 

春のすべてのマス目を管理するクラス 

# public class SummerSquares:SeasonSquares 

夏のすべてのマス目を管理するクラス 

# public class KeyManager:MonoBehaviour 

このゲームにおけるすべてのキー入力に対する関数を管理するクラス 

## フィールド 
- public static KeyManager keyManager 
  - KeyManagerをどこからでも参照できるようにするための変数 
- public delegate void DownSpace() 
  - スペースキーが押された瞬間に呼び出される関数を格納するためのデリゲート 
- private List<DownSpace>downSpace 
  - スペースキーが押されたときに実行する予定のすべての関数を格納するリスト 
- private bool downSpaceBool 
  - スペースキーが押された時に関数を呼び出すべきか否かを格納する変数 
  - 以下DownUpArrow,downUpArrow,downUpArrowBool, DownDownArrow,downDownArrow,downDownArrowBoolについても同じ 
  

## 関数 

- private void Update() 
  - 設定されてるキーの入力を確認し、対応した関数を実行、管理する関数 
- public void setDownSpace(DownSpace ds) 
  - スペースキーが押された時に実行する関数を設定する関数 
  - 以下setDownUpArrow,setDownDownArrowについても同じ 

 

# public abstract class ForcedEvent

すべての強制イベントの親クラス 

## フィールド
- public delegate void Finish()
    強制イベント終了時に呼び出す関数を格納するためのメソッドを定義している
- protected Finish fin
    強制イベント終了時に呼び出す関数を格納する変数

## 関数 
- public abstract void execution(Season season,int round) 
  - seasonとroundなどから強制イベントの発生条件を満たすと効果を発動する関数 public void added(Finish f)
  - 強制イベント終了時に呼び出す関数を設定する関数
  protected void finsh()
    強制イベント終了時に呼び出す必要がある関数

# public class ForcedEvents 

##フィールド
- private List<ForcedEvent> fevents = new List<ForcedEvent>()
- private int evenIndex
    現在実行中の強制イベントの引数
- private Season season
- private Round round

##関数
- public ForcedEvents()
- public void add(ForecedEvent fe)
    強制イベントを追加する関数
- public void execute(in Season season, in Round round)
- private void eventFinish()
    各強制イベント終了時に呼び出される関数


# public class ProgressUI:MonoBehaviour 

ゲーム全体の進行に関するUIを司るクラス 

## フィールド 

- public static ProgressUI progressUI 
  - 自身をどこからでも参照可能にするため 
- public TextMeshProUGUI,nowText,academicText,apperanceText,luckText,affiliationText diceText,spaceText 
  - サイコロの目を表示するUIとスペースを押してサイコロを振るよう促すUI 

  
## 関数 
- public void changeOfTurn(in Player player, in Round round, in Season season)
  - idで指定されたプレイヤーに操作するプレイヤーが切り替わった時の各UIの変更を行う関数 
- public void setDiceNumber(int dice)
- public void setSpaceTextEnabled()

 

# Public class Season 

季節に関するクラス。 

## フィールド 

- public const int SPRING = 0; 
- Public const int SUMMER  = 1; 
- Public const int AUTUMN = 2; 
- Public const int WINTER = 3; 
- Public const int UNDEFINED = -1; 
- Public int season = UNDEFINED;  

## 関数 
- Season( int s )  
  - コンストラクタ 
- GetNexteason() 
  - season 変数から次のシーズンを判断して次のシーズンを戻す関数。 
 

# Public class Gender 

性別に関する構造体


# Public class Academic 
学力に関するクラス 


## フィールド 
- Public static readonly Academic UNDEFINED_ACADEMIC  
  - 状態未定義状態 
- Public const int MIN = 0; 
  - 最小値 
- Public const int MAX = 100; 
  - 最大値 
- public const int UNDEFINED = -1 
  - 未定義値 
- Private int value; 
  - 学力値 

## 関数 
- Public Academic( int value ) 
  - コンストラクタ 
- Public void add( Deviation dev ) 
  - 加算減算する 
- public void add( int value ) 
  - 値を加算する 
- public void sub( int value ) 
  - 値を減算する。 
- Public int getValue() 
  - 値を返す。  
  

# Public class Appearance 

容姿に関するクラス 
 
## フィールド 

- Public static readonly Academic UNDEFINED_APPEARANCE  
  - 状態未定義状態 
- Public const int MIN = 0; 
  - 最小値 
- Public const int MAX = 100; 
  - 最大値 
- public const int UNDEFINED = -1 
  - 未定義値 
- Private int value; 
  - 学力値 

## 関数 
- Public Appearance( int value ) 
  - コンストラクタ 
- Public void add( Deviation dev ) 
  - 加算減算する 
- public void add( int value ) 
  - 値を加算する 
- public void sub( int value ) 
  - 値を減算する。 
- Public int getValue() 
  - 値を返す。 
 

# Public class Favorability 

好感度に関するクラス 
 

## フィールド 
Public static readonly Academic UNDEFINED_UNDEFINED_FAVORABILITY  
状態未定義状態 
Public const int MIN = 0; 
最小値 
Public const int MAX = 100; 
最大値 
public const int UNDEFINED = -1 
未定義値 
Private int value; 
好感度の値
 

## 関数 
- Public Favorability( int value, Lover partner ) 
  - コンストラクタ 
- Public void add( Deviation dev ) 
  - 加算減算する。 
- public void add( int value ) 
  - 値を加算する 
- public void sub( int value ) 
  - 値を減算する。 
- Public int getValue() 
  - 値を返す。 

 

# Public class Luck 

運に関するクラス 

 

## フィールド 

- Public static readonly Academic UNDEFINED_LUCK  
  - 状態未定義状態 
- Public const int MIN = 0; 
  - 最小値 
- Public const int MAX = 100; 
  - 最大値 
- public const int UNDEFINED = -1 
  - 未定義値 
- Private int value; 
  - 値 

## 関数 

- Public Luck( int value ) 
  - コンストラクタ 
- Public void add( Deviation dev ) 
  - 加算減算する 
- public void add( int value ) 
  - 値を加算する 
- public void sub( int value ) 
  - 値を減算する。 
- Public int getValue() 
  - 値を返す。 

# public class Lovers
主人公が付き合うことが可能な恋愛対象をまとめたクラス。

## フィールド
- private List<Lover>lovers = new List<Lover>();
  - 恋愛対象たちを格納する変数。

## 関数
- public Lovers()
  - コンストラクタ
- public void add(Lover l)
  - 恋人を追加する関数。
- public Lover getLoverByName(in string name)
  - 恋愛対象の名前検索をする。
- public Lover getHightestLover()
  - 一番好感度の高い恋愛対象を返す。

# public class Dice   
さいころ処理のクラス。

## フィールド
- public delegate void DiceCallback(int dice);
- private DiceCallback diceCallback;
  - スペースキーが押されたときに呼び出すコールバック関数を格納。

## 関数
- public Dice()
  - コンストラクタ
- public void setCallback(DiceCallback callback)
  - スペースキーが押されたときに呼び出すコールバック関数をセットする。
- private void spacekeyCallback()
  - スペースキーが押されたときに呼び出される関数。今のところ1-6のランダムな値を生成し、diceCallback関数に渡して実行させている。

# public class Language
# public class Round

## フィールド
- private const int maxNumberOfRound = 5;
- private int value; 

## 関数
- public Round()
- public int getRound()
- public bool checkIsFinished()
- public void increment()
- public void reset()
- public string getRoundInStr()

# public class Turn
各ラウンドにおけるターン数を管理するクラス。

## フィールド
- private int maxNumberOfTurn = 5;
  - 何ターンまわすか。プレイヤーの数。
- private int value; 
  - ターン数

## 関数
- public Turn( int playerNumber )
  - コンストラクタ。プレイヤー数でmaxNumberOfTurnを初期化
- public int getTurn()
- public bool checkIsFinished()
  - valueとmaxNumberOfTurnを比較し、一ラウンド終わったかどうかを確認する。
- public void increment()
  - ターン数をインクリメントする。
- public void reset()
  - ターン数をリセットする。

# public class Year
年を管理するクラス。

## フィールド
- private const int maxYear = 1;
- private int value; 

## 関数
- public Year()
- public int getYear()
- public bool checkIsFinished()
- public void increment()
- public void reset()