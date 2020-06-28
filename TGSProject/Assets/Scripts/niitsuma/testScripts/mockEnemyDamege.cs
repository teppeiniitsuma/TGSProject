using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mockEnemyDamege : MonoBehaviour , IDamager
{
    public void ApplyDamage()
    {
        Destroy(gameObject);
    }

}
