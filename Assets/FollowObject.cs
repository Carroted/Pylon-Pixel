using UnityEngine;
using System.Collections;

namespace CutsceneToolkit {

public class FollowObject : MonoBehaviour
{

    public GameObject objectToFollow;

    public float speed = 2.0f;

    public bool lerp = true;

    void Update()
    {
        if (lerp)
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);

            this.transform.position = position;
        }

        else
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.y = (this.transform.position.y - objectToFollow.transform.position.y);
            position.x = (this.transform.position.x - objectToFollow.transform.position.x);

            transform.position -= position.normalized;
        }

    }
}

}