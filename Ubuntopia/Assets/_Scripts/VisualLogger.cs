using UnityEngine;
using UnityEngine.UI;

public class VisualLogger : MonoBehaviour
{
    [SerializeField] private Text debugText;
    private void TestMessage()
    {
        debugText.text = "This works";
    }

    public void TestMessage(string text)
    {
        debugText.text = " " + text + " ";
    }
}
