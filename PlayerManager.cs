using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;
    public static PlayerManager Instance { get { return _instance; } private set { } }

    [SerializeField] private BaseOwner _baseOwner;
    [SerializeField] private GameObject _getPoint;

    private TPPlayerController _tPPlayer;
    public BaseOwner BaseOwner { get { return _baseOwner; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _tPPlayer = GetComponent<TPPlayerController>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetItem(Transform item,Item itemType = Item.Egg)
    {
        item.SetParent(_getPoint.transform);
        item.localPosition = Vector3.up;
        item.localRotation = Quaternion.Euler(0f, 90f, 0f);
        _tPPlayer.SetHolding(true);
    }
    public void RemoveItem()
    {
        _tPPlayer.SetHolding(false);
    }
    
}
