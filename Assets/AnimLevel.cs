using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimLevel : MonoBehaviour
{
    public Animator circle;
    public static bool isMethod = false;
    public string level;
    public bool load = false;

    // Start is called before the first frame update
    void Start()
    {
        circle = GameObject.FindGameObjectWithTag("Canvas").GetComponent<FillNSlider>().circle;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            SaveAndLeave(level);

        }
    }
    public void SaveAndLeave(string levely)
    {
        PlayerPrefs.Save();
        Trigger(levely);
    }
    public void Trigger(string levely)

    {
        StartCoroutine(Stuff(levely));
    }

    IEnumerator Stuff(string levely)
    {

        circle.SetTrigger("EndLevel");
        PlayerPrefs.Save();



        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levely);
    }
    // Update is called once per frame
    void Update()
    {
        if (load)
        {
            SaveAndLeave(level);
            load = false;
        }

    }
}
