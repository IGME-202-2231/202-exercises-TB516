using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField]
    SpriteRenderer _animalPrefab;

    [SerializeField]
    Sprite[] _sprites;

    List<SpriteRenderer> _animals = new();

    GameObject _animalStorage;

    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    private void Start()
    {
        _animalStorage = new() { name = "Zoo" };
        _animalStorage.AddComponent<Transform>();
    }

    public void Spawn()
    {
        ClearAnimals();

        for (int i = Random.Range(4, 11) - 1; i >= 0; i--)
        {
            _animals.Add(SpawnAnimal());
        }
    }

    private SpriteRenderer SpawnAnimal()
    {
        SpriteRenderer animal = Instantiate(_animalPrefab, _animalStorage.transform);

        animal.transform.position = new(Gaussian(0, 1.2f), Gaussian(0, 1.2f), 0);
        animal.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);

        switch (Random.value)
        {
            // >= 0 && <= 10
            case <= .10f:
                animal.sprite = _sprites[2];
                break;
            // > 10 && <= 25
            case <= .25f:
                animal.sprite = _sprites[3];
                break;
            // > 25 && <= 45
            case <= .45f:
                animal.sprite = _sprites[4];
                break;
            // > 45 && <= 75
            case <= .75f:
                animal.sprite = _sprites[1];
                break;
        }

        return animal;
    }

    private void ClearAnimals()
    {
        for (int i = 0; i < _animals.Count; i++)
        {
            Destroy(_animals[i].gameObject);
        }
        _animals.Clear();
    }

    private float Gaussian(float mean, float stdDev)
    {
        return mean + stdDev * (Mathf.Sqrt(-2.0f * Mathf.Log(Random.Range(0f, 1f))) * Mathf.Sin(2.0f * Mathf.PI * Random.Range(0f, 1f)));
    }

}
