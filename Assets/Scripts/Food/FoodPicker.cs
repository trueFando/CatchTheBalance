using UnityEngine;

public class FoodPicker : MonoBehaviour
{
    [SerializeField] private Food[] _foodPrefabs;

    private void Start()
    {
        PickFood();
    }

    private void PickFood()
    {
        int index = PlayerPrefs.GetInt("selected_item");
        Instantiate(_foodPrefabs[index], transform.position, Quaternion.identity);
    }
}
