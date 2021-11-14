using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel1 : MonoBehaviour
{
    public bool health0 = false;
    public Animator circle;
    public static bool isMethod = false;
    // Start is called before the first frame update
    void Start()
    {
        circle = GameObject.FindGameObjectWithTag("Canvas").GetComponent<FillNSlider>().circle;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (health0)
            {
                collision.gameObject.GetComponent<Health>().health = 0;
            }
            StartCoroutine(Stuff(SceneManager.GetActiveScene().buildIndex));
        }
    }
    public void Trigger(int index)
    {
        StartCoroutine(Stuff(index));
    }
    public static void Static()
    {
        isMethod = true;
    }
    IEnumerator Stuff(int index)
    {
        circle.SetTrigger("EndLevel");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }
    // Update is called once per frame
    void Update()
    {
        if (isMethod)
        {
            isMethod = false;
            Trigger(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
