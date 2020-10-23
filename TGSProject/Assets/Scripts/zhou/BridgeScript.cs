using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    public bool isSwitchUp,isLevel;
    public bool isLever = false;
    [SerializeField] int rotsSpeed = 40 ;
    public float startRotsZ;

    public bool IsMove { get; private set; } = false;
    bool _endRotate = false;

    void Start()
    {
    }

    void Update()
    {
        if(isSwitchUp && !_endRotate) { IsMove = true; }
        else if(!isSwitchUp || _endRotate) { IsMove = false; }

        if(transform.rotation.z == -40.0f || transform.rotation.z == 0) { _endRotate = true; }
        else { _endRotate = false; }

        if (this.transform.rotation.z < 0 && isSwitchUp) {
            this.transform.Rotate(0, 0, this.rotsSpeed * Time.deltaTime);
            if (this.transform.rotation.z > 0) {
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                if (isLevel) { 
                //spot
                }
            }
        } else if (this.transform.rotation.z> -40.0f && !isSwitchUp) {
            this.transform.Rotate(0, 0, (this.rotsSpeed / 2) * -Time.deltaTime);
            if (this.transform.rotation.z < startRotsZ)
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -40.0f);
            }
        }
    }
    public void OpenLevel()
    {
        isSwitchUp = true;
        isLevel = true;
    }
}
