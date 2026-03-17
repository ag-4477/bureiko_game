using System;
using System.Collections.Generic;

// [Serializable] をつけることで、Unityが「これはデータ保存用のクラスだ」と認識します
[Serializable]
public class OptionData {
    public string text;
    public int breikoScore;
}

[Serializable]
public class OptionItem {
    public int id;
    public OptionData data;
}

[Serializable]
public class QuestionNode {
    public int questionId;
    public List<OptionItem> questiondata;
}

// これが「外箱」となるクラスです
[Serializable]
public class GameDataWrapper {
    public List<QuestionNode> questions; // JSONのキー "questions" と名前を合わせる
}