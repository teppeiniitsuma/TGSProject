using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    public bool isSwitchUp,isLevel;
    public bool isLever = false;
    [SerializeField] int rotsSpeed = 180 ;
    public float startRotsZ;

    void Start()
    {
    }

    void Update()
    {
        if (this.transform.rotation.z < 0 && isSwitchUp) {
            this.transform.Rotate(0, 0, this.rotsSpeed * Time.deltaTime);
            if (this.transform.rotation.z > 0) {
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                if (isLevel) { 
                //spot
                }
            }
        } else if (this.transform.rotation.z> -40.0f && !isSwitchUp) {
            this.transform.Rotate(0, 0, this.rotsSpeed * -Time.deltaTime);
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
