using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hpui : MonoBehaviour
{
    public GameObject Astronaut;

    public TMP_Text hptext;


    void Start()
    {
    }

    void Update()
    {
        hptext.text = Astronaut.GetComponent<playerhealth>().maxHealth.ToString();
    }
}