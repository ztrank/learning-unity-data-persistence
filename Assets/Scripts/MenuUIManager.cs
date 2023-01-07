using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    public InputField NameInput;

    // Start is called before the first frame update
    void Start()
    {
        if (!string.IsNullOrWhiteSpace(DataManager.Instance.Name))
        {
            // Get the name text box and set the name
            this.NameInput.text = DataManager.Instance.Name;
        }

        this.NameInput.onValueChanged.AddListener(value =>
        {
            DataManager.Instance.Name = value;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (!string.IsNullOrWhiteSpace(this.NameInput.text))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
        DataManager.Instance.Save();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
