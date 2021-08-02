using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomKeyScript : MonoBehaviour
{
    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;
    // Start is called before the first frame update
    void Start()
    {
        menuPanel = transform.GetChild(1);
        //menuPanel.gameObject.SetActive(true);
        waitingForKey = false;

    
        for (int i = 0; i < 6; i++)
        {
            if (menuPanel.GetChild(i).name == "BackwardKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeyBindingManager.KM.backward.ToString();
            else if (menuPanel.GetChild(i).name == "ForwardKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeyBindingManager.KM.forward.ToString();
            else if (menuPanel.GetChild(i).name == "LeftKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeyBindingManager.KM.left.ToString();
            else if (menuPanel.GetChild(i).name == "RightKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeyBindingManager.KM.right.ToString();
            else if (menuPanel.GetChild(i).name == "JumpKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeyBindingManager.KM.jump.ToString();
            else if (menuPanel.GetChild(i).name == "AttackKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = KeyBindingManager.KM.attack.ToString();

        }

     //   menuPanel.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
            
        if (Input.GetKeyDown(KeyCode.Escape) && !menuPanel.gameObject.activeSelf)
            menuPanel.gameObject.SetActive(true);
        else if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.gameObject.activeSelf)
            menuPanel.gameObject.SetActive(false);
            
    }

    private void OnGUI()
    {
        keyEvent = Event.current;
        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssign(string keyName)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    public void SendText(Text text)
    {
        buttonText = text;

    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;
        yield return WaitForKey();

        switch (keyName)
        {
            case "forward":
                KeyBindingManager.KM.forward = newKey;
                buttonText.text = KeyBindingManager.KM.forward.ToString();
                PlayerPrefs.SetString("forwardKey", KeyBindingManager.KM.forward.ToString());
                break;
            case "backward":
                KeyBindingManager.KM.backward = newKey;
                buttonText.text = KeyBindingManager.KM.backward.ToString();
                PlayerPrefs.SetString("backwardKey", KeyBindingManager.KM.backward.ToString());
                break;
            case "left":
                KeyBindingManager.KM.left = newKey;
                buttonText.text = KeyBindingManager.KM.left.ToString();
                PlayerPrefs.SetString("leftKey", KeyBindingManager.KM.left.ToString());
                break;
            case "right":
                KeyBindingManager.KM.right = newKey;
                buttonText.text = KeyBindingManager.KM.right.ToString();
                PlayerPrefs.SetString("rightKey", KeyBindingManager.KM.right.ToString());
                break;
            case "jump":
                KeyBindingManager.KM.jump = newKey;
                buttonText.text = KeyBindingManager.KM.jump.ToString();
                PlayerPrefs.SetString("jumpKey", KeyBindingManager.KM.jump.ToString());
                break;
            case "attack":
                KeyBindingManager.KM.attack = newKey;
                buttonText.text = KeyBindingManager.KM.attack.ToString();
                PlayerPrefs.SetString("attackKey", KeyBindingManager.KM.attack.ToString());
                break;
        }

        yield return null;

    }
}
