using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILives : MonoBehaviour
{
    [SerializeField]
    private Entity _playerEntity;

    private List<GameObject> _list = new List<GameObject>();

    private Transform[] allChildren;

    private int _initialCount;

    private void Awake()
    {
        if (_playerEntity == null) Debug.LogError("UILives playerEntity is null.");
        _playerEntity.LivesCountUpdated += OnLivesCountUpdated;
    }

    private void OnDestroy()
    {
        _playerEntity.LivesCountUpdated -= OnLivesCountUpdated;
    }

    // Start is called before the first frame update
    void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            if (child.gameObject.CompareTag("Life"))
                _list.Add(child.gameObject);
        }
    }

    private void OnLivesCountUpdated(int currentLives)
    {
        var activeChildren = _list.FindAll(x => x.activeSelf);
        var numberOfChildrenToRemove = activeChildren.Count - currentLives;

        for (int i = 0; i < numberOfChildrenToRemove; i++)
        {
            _list.FindLast(x => x.activeSelf)?.SetActive(false);
        }
    }
}
