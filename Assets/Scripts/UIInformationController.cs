using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInformationController : MonoBehaviour {
    public GameObject m_Astronaut;
    AstronautController m_AstronautController;
    public Text OxygenValue;
    public Text GameOver;
    // Use this for initialization
    void Start () {
        m_AstronautController = m_Astronaut.GetComponent<AstronautController>();
        ResetUI();
        DisplayCurrentOxygen();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void DisplayCurrentOxygen()
    {
        OxygenValue.text = m_AstronautController.GetCurrentOxygen().ToString();
    }

    public void DisplayGameOver()
    {
        GameOver.gameObject.SetActive(true);
    }

    public void ResetUI()
    {
        GameOver.gameObject.SetActive(false);
    }
}
