using System;
using System.Collections.Generic;

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
public class QuestionSet {
    public string bossText;
    public List<OptionItem> questiondata;
}


[Serializable]
public class QuestionNode {
    public int questionId;
    public QuestionSet questionSet;
}

[Serializable]
public class TextInfo {
    public string text;
    public string person;
}

[Serializable]
public class StageText {
    public int textId;
    public List<TextInfo> data;
}

[Serializable]
public class TextNode {
    public int questionId;
    public List<StageText> textData;

}

// これが「外箱」となるクラス
[Serializable]
public class GameDataWrapper {
    public List<QuestionNode> questions; // JSONのキー "questions" と名前を合わせる
    public List<TextNode> maefuri;
    public List<TextNode> result; 
}