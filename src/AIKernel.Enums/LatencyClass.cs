namespace AIKernel.Enums;

/// <summary>
/// レイテンシクラスを定義します。
/// パフォーマンスプロファイリングと制約に使用されます。
/// </summary>
public enum LatencyClass
{
    /// <summary>
    /// リアルタイム（0-10ms）
    /// </summary>
    RealTime = 1,

    /// <summary>
    /// 即座（10-100ms）
    /// </summary>
    Interactive = 2,

    /// <summary>
    /// 高速（100-1000ms）
    /// </summary>
    Fast = 3,

    /// <summary>
    /// 標準（1-10秒）
    /// </summary>
    Normal = 4,

    /// <summary>
    /// 低速（10秒以上）
    /// </summary>
    Slow = 5
}

/// <summary>
/// モデルタイプを定義します。
/// 言語モデル、画像モデルなどの種類を区別します。
/// </summary>
public enum ModelType
{
    /// <summary>
    /// 言語モデル
    /// </summary>
    LanguageModel = 1,

    /// <summary>
    /// 画像生成モデル
    /// </summary>
    ImageGeneration = 2,

    /// <summary>
    /// 画像認識モデル
    /// </summary>
    ImageRecognition = 3,

    /// <summary>
    /// 音声認識モデル
    /// </summary>
    SpeechRecognition = 4,

    /// <summary>
    /// 音声合成モデル
    /// </summary>
    TextToSpeech = 5,

    /// <summary>
    /// マルチモーダルモデル
    /// </summary>
    MultiModal = 6,

    /// <summary>
    /// 埋め込みモデル
    /// </summary>
    Embedding = 7,

    /// <summary>
    /// 分類モデル
    /// </summary>
    Classification = 8,

    /// <summary>
    /// カスタムモデル
    /// </summary>
    Custom = 9
}

/// <summary>
/// モダリティを定義します。
/// 入出力データの形式を表現します。
/// </summary>
public enum Modality
{
    /// <summary>
    /// テキスト
    /// </summary>
    Text = 1,

    /// <summary>
    /// 画像
    /// </summary>
    Image = 2,

    /// <summary>
    /// 音声
    /// </summary>
    Audio = 3,

    /// <summary>
    /// ビデオ
    /// </summary>
    Video = 4,

    /// <summary>
    /// 構造化データ（JSON、XML など）
    /// </summary>
    StructuredData = 5,

    /// <summary>
    /// バイナリデータ
    /// </summary>
    Binary = 6,

    /// <summary>
    /// 時系列データ
    /// </summary>
    TimeSeries = 7
}
