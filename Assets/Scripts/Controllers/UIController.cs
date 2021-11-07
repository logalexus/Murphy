using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField] private List<IteractPanel> _screens = new List<IteractPanel>();

    private IteractPanel _activeScreen;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
    }
    

    //public void OpenScreen(IteractPanel screen)
    //{
    //    _activeScreen.Close();
    //    screen.Open();
    //    _activeScreen = screen;
    //}

    public T GetScreen<T>() where T : IteractPanel
    {
        return _screens.OfType<T>().FirstOrDefault();
    }
   
    
}
