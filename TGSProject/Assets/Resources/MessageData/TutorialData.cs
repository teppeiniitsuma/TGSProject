
[System.Serializable]
public class TutorialData
{
    public int id;
    public string name;
    public string message;
    public string balloonPos;
    public string balloonSize;
    public bool balloonType;
    public BalloonColor balloonColor;
}

public enum BalloonColor
{
    RED,
    GREEN,
}
