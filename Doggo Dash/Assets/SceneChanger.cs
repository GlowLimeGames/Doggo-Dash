using System.Collections;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

    public void ChangeToScene(int sceneToChangeTo)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToChangeTo);
    }

}

