using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{

    public GameObject PingouaIdle;

    public float speed = 2.0f;

    public bool lerp = true;

    private void Awake()
    {
        if (PingouaIdle == null)
        {
            PingouaIdle = GameObject.FindGameObjectWithTag("Player");
        }
    }
    void Update()
    {
        if (lerp)
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, PingouaIdle.transform.position.y, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, PingouaIdle.transform.position.x, interpolation);

            this.transform.position = position;
        }

        else
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.y = (this.transform.position.y - PingouaIdle.transform.position.y);
            position.x = (this.transform.position.x - PingouaIdle.transform.position.x);

            transform.position -= position.normalized;
        }

    }
}