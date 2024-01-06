using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void ActivateEndGame()
    {
        gameOverPanel.SetActive(true);
        Cursor.visible = true;
    }
}
