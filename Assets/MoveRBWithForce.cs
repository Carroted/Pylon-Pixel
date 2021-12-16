using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRBWithForce : MonoBehaviour
{
    public Vector3 move;
    private Rigidbody2D rb;
    public ForceMode2D forceMode;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetMove(Vector3 move)
    {
        this.move = move;
    }
    public void MultiplyMove(float multiplier)
    {
        this.move *= multiplier;
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(move, forceMode);
    }
}
