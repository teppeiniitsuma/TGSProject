using UnityEngine;

public class NormalEndPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
