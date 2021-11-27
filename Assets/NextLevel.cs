using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public Animator circle;
    public static bool isMethod = false;
    public NewBehaviourScript nbs;
    public bool insane = false;
    public int move = 1;
    private static bool erase;
    // Start is called before the first frame update
    void Start()
    {
        nbs = FindObjectOfType<NewBehaviourScript>();
        circle = GameObject.FindGameObjectWithTag("Canvas").GetComponent<FillNSlider>().circle;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!insane)
            {
                SaveAndLeave(SceneManager.GetActiveScene().buildIndex + move);
            }
            else
            {
                SaveAndLeave(SceneManager.GetActiveScene().buildIndex + move + 1);
            }
        }
    }
    public void SaveAndLeave(int index)
    {
        PlayerPrefs.Save();
        erase = false;
        Trigger(index);
    }
    public void Trigger(int index)
    {
        StartCoroutine(Stuff(index));
    }
    public static void Static(bool _erase = false)
    {
        isMethod = true;
        erase = _erase;
    }
    IEnumerator Stuff(int index)
    {

        circle.SetTrigger("EndLevel");
        if (!erase)
        {
            PlayerPrefs.SetInt("level" + index, 1);
            PlayerPrefs.SetInt("gold", nbs.gold);
            PlayerPrefs.Save();
        }


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
