using UnityEngine;

public class exit : MonoBehaviour
{
    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

