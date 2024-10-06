using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour gérer les scènes


public class GameManager : MonoBehaviour
{
        private B_PlayerController playerControls;
        public Canvas pauseMenu;

        public Canvas startMenu;

     

    private void Awake()
    {
        playerControls = new B_PlayerController();
        playerControls.PlayerBaseController.Pause.performed += ctx => Pause();
        Debug.Log("Awake");
    }

   


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        startMenu.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        

    }
 
 public void StartGame()
    {
        startMenu.gameObject.SetActive(false);
        UnpauseGame();
    }


    public void Pause()
    {
        //Pause Game
        Debug.Log("Pause");
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.gameObject.SetActive(true);
    }

    public void UnpauseGame()
    {
        //Unpause Game
        Debug.Log("Unpause");
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.gameObject.SetActive(false);
    }


    public void RestartLevel()
    {
        //Restart Game
        Debug.Log("Restart");
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.gameObject.SetActive(false);
        //TODO: Reload Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    



    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

}
