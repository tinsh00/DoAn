using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToScene : MonoBehaviour
{
    [SerializeField]
    Scene goToScene;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
       // SoundMN.soundClick();
        SceneMN.LoadScene(goToScene);
    }
}
