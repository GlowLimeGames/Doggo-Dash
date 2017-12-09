using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

	public Text distance;
    public Text endpanelscore;
	public int liveStocks=3;
	public PlayerController pc;
    public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distance.text = Mathf.Round(pc.transform.position.x).ToString ();
	}
	public void Restart(){
        EndPanel();
        AudioController.Instance.PlaySFX("gameOver");
    }

    void EndPanel()
    {
        anim.Play("endpanelfall");
        
        endpanelscore.text = distance.text;
        distance.gameObject.SetActive(false);
    }

    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
}