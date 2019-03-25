using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public ButtonData[] Buttons;
    public GameObject ButtonPrefab;
    private ButtonHolder holder;

    private void Awake()
    {
        Buttons = Resources.LoadAll<ButtonData>("ButtonObjects");
        
        for (int i = 0; i < Buttons.Length; i++)
        {
            Instantiate(ButtonPrefab, gameObject.transform);
            holder = ButtonPrefab.GetComponent<ButtonHolder>();
            holder.data = Buttons[i];
        }
    }


}
