using IJunior.TypedScenes;
using UnityEngine;

public class EnderLevel : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.Load(new LevelConfiguration(true, true, 0));
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
