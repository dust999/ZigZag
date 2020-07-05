using System.Collections.Generic;
using UnityEngine;

public class DiamondsGenerator : MonoBehaviour, IDifficultChangeable
{
    [SerializeField] private ObjectPool _collectablePool = null;
    [SerializeField] private int _maxPlacesInStack = 5;
    private List<Vector3> _diamondsPositions = null;

    [SerializeField] private PlaceOrder _placeRule = PlaceOrder.Random;
    private int _lastIndex = 0;

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        _diamondsPositions = new List<Vector3>();
        _lastIndex = 0;
    }

    public void AddDiamondPositionInStack(Vector3 diamondPosition)
    {
        _diamondsPositions.Add(diamondPosition);
        
        if( _diamondsPositions.Count >= _maxPlacesInStack )
            PlaceDiamonds(_placeRule);
    }

    private void PlaceDiamonds(PlaceOrder rule = PlaceOrder.Random)
    {
        IPlaceable placeObject;

        if( rule == PlaceOrder.Oredered)
            placeObject = new OrderPlace();
        else
            placeObject = new RandomPlace();

        placeObject.Place(_diamondsPositions, _collectablePool, _lastIndex);

        _lastIndex++;
        _lastIndex = ( _lastIndex  >= _maxPlacesInStack ) ? 0 : _lastIndex ;
        
        _diamondsPositions = new List<Vector3>();
    }
    
    public void DifficultChange(DifficultLevel difficultLevel)
    {
        _placeRule = difficultLevel.DiamonPlace;
        _maxPlacesInStack = difficultLevel.MaxPlacesInStack;
    }
}
