
public class RankSetter
{
    int total = 0; // 5つのリザルトデータの合計値 100がマックス
    int rank = 0;  // 0, S rank 1, A rank  2, B rank  3, C rank


    enum Rank 
    {
        rankS = 0,
        rankA,
        rankB,
        rankC,
    }

    /// <summary>
    /// ランクを計算し返す
    /// </summary>
    /// <param name="data">リザルト画面用のデータ</param>
    public int RankCalculation(ResultData data)
    {
        // クリア時間
        if (data.playTime <= 120) { total += 20; }
        else if (data.playTime <= 240) { total += 15; }
        else if (data.playTime <= 360) { total += 10; }
        else if (360 < data.playTime) { total += 5; }

        // 解いた石碑の数（数値は適当）
        if (3 <= data.stoneMonumentCount) { total += 20; }
        else if (2 <= data.stoneMonumentCount) { total += 15; }
        else if (1 <= data.stoneMonumentCount) { total += 10; }
        else if (0 <= data.stoneMonumentCount) { total += 5; }

        // 倒したエネミーの数（数値は適当）
        if (3 <= data.killEnemyCount) { total += 20; }
        else if (2 <= data.killEnemyCount) { total += 15; }
        else if (1 <= data.killEnemyCount) { total += 10; }
        else if (0 <= data.killEnemyCount) { total += 5; }
        
        // 集めたハーブの数
        if (5 <= data.ownHerb) { total += 20; }
        else if (3 <= data.ownHerb) { total += 15; }
        else if (1 <= data.ownHerb) { total += 10; }
        else if (0 <= data.ownHerb) { total += 5; }

        // 死んだ回数
        if (data.deadCount <= 3) { total += 20; }
        else if (4 <= data.deadCount) { total += 15; }
        else if (6 <= data.deadCount) { total += 10; }
        else if (10 <= data.deadCount) { total += 5; }
        
        // トータルの数値でランクを決める
        if (90 <= total) { rank = (int)Rank.rankS; }
        else if (70 <= total) { rank = (int)Rank.rankA; }
        else if (40 <= total) { rank = (int)Rank.rankB; }
        else if(total < 40){ rank = (int)Rank.rankC; }

        return rank;
    }

}
