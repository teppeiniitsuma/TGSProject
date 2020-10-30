using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioMessageModel : MonoBehaviour
{
    [SerializeField] Prologue prologue;
    [SerializeField] Epilogue epilogue;
    public Prologue GetPrologue { get => prologue; }
    public Epilogue GetEpilogue { get => epilogue; }

}
