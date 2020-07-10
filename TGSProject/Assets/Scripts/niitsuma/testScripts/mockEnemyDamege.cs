using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mockEnemyDamege : MonoBehaviour , IDamager
{
    public void ApplyDamage(int id = 0)
    {
        this.gameObject.SetActive(false);
    }

}
