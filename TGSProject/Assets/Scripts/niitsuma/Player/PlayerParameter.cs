using System;

[Serializable]
public struct PlayerParameter
{
    public float moveSpeed;

    [NonSerialized] public int hp;
    [NonSerialized] public int direction;
    [NonSerialized] public bool actSwitch;
}
