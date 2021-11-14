using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSetLol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetSpeed(float speed)
    {
        Time.timeScale = speed;
    }
    public void SpeedSuperSlow()
    {
        SetSpeed(0.05f);
    }
    public void Speed25x()
    {
        SetSpeed(0.25f);
    }
    public void Speed1x()
    {
        SetSpeed(1f);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
