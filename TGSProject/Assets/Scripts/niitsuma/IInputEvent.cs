/*
input関連のインターフェース
 */
using UnityEngine;

public interface IInputEvent
{
    bool circleButton   { get; set; }    // 丸ボタン
    bool squareButton   { get; set; }    // 四角ボタン
    bool triangleButton { get; set; }    // 三角ボタン

    Vector2 vector      { get; set; }
}
