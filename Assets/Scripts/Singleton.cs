using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Flag to check if the application is shutting down
    private static bool _ShuttingDown = false;
    // Lock object for thread safety
    private static object _Lock = new object();
    // The singleton instance
    private static T _Instance;

    // Public access to the singleton instance
    public static T Instance
    {
        get
        {
            // Check if the application is shutting down
            if (_ShuttingDown)
            {
                Debug.Log("[Singleton] Instance '" + typeof(T) + "' already destroyed. Returning null.");
                return null;
            }

            lock (_Lock)    // Ensure thread safety
            {
                if (_Instance == null)
                {
                    // Check if an instance already exists in the scene
                    _Instance = (T)FindObjectOfType(typeof(T));

                    // If no instance exists, create a new one
                    if (_Instance == null)
                    {
                        // Create a new GameObject and attach the singleton component
                        var singletonObject = new GameObject();
                        _Instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        // Ensure the instance persists across scene loads
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return _Instance;
            }
        }
    }

    protected virtual void Awake()
    {
        lock (_Lock)
        {
            if (_Instance == null)
            {
                _Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else if (_Instance != this as T)
            {
                Debug.Log("[Singleton] An instance of '" + typeof(T) +
                          "' already exists. Replacing with the new instance.");
                Destroy(_Instance.gameObject); // Destroy the old instance's game object
                _Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    // Called when the application is quitting
    private void OnApplicationQuit()
    {
        _ShuttingDown = true;
    }

    // Called when the object is being destroyed
    private void OnDestroy()
    {
        
    }
}