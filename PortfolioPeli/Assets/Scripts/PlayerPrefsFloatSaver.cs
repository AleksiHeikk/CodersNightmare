using UnityEngine;

public class PlayerPrefsFloatSaver : MonoBehaviour
{
    [SerializeField] private string key;

    public void SetFloat(float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }
}