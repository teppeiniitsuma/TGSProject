/*
input関連のインターフェース
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputEvent
{
    bool decisionButton { get; set; }    // 決定ボタン
    bool cancelButton   { get; set; }    // キャンセルボタン
}
