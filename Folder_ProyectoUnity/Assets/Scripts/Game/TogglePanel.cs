using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject panel;

    #endregion

    #region Unity Methods

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel != null)
            {
                bool isActive = panel.activeSelf;
                panel.SetActive(!isActive);


                if (!isActive) 
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else 
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }

    #endregion
}
