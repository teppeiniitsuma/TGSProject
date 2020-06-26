using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    [SerializeField] GameObject switch_Head,level;
    public bool isSwitchUp,isLevel;
    [SerializeField] int rotsSpeed = 180 ;
    public float startRotsZ;

    // Start is called before the first frame update
    void Start()
    {
       // startRotsZ = this.transform.rotation.z*120;
    }

    // Update is called once per frame
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
    public void OpenLevel() {

        switch_Head.GetComponent<BridgeSwitchScript>().enabled = false;
        level.GetComponent<BridgeLevelScript>().enabled = false;
        isSwitchUp = true;
        isLevel = true;


    }
}
