using UnityEngine;

//Singleton Pattern
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
//When defining a new singleton, T (or type) can be any other monobehavior
//This helps us seperate one type of singleton from any other
{
    
    //static = the value of the variable is synced between all instances of this script
    private static T instance;
    //A private variable to hold the instance of the singleton
    
    public static T Instance => instance;
    //A public variable which returns the instance
    
    protected void Awake()
    //Before OnEnable() and Start() - this will likely be the first code run for any script
    {
        if (instance == null)
        {
            instance = this as T;
        }
        //if no instance has been set yet, set the current instance as "The Instance"
        else if (instance != this)
        {
            Debug.LogWarning("Multiple instances of the singleton type '" + instance.GetType() + "' were found. Deleting this instance");
            Destroy(gameObject);
        }
        //If multiples are detected, delete multiple
    }
}