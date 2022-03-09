namespace OutingClass;

public class OutingRepository
{
    private readonly List<Outing> _outingList = new List<Outing>();

    public bool AddOutingToList(Outing outing)
    {
        int originalCount = _outingList.Count;
        _outingList.Add(outing);
        bool wasAdded;
        if (_outingList.Count > originalCount)
        {
            wasAdded = true;
        }
        else wasAdded = false;

        return wasAdded;
    }

    public List<Outing> GetOutingList()
    {
        return _outingList;
    }

    public Outing GetOutingByType(Outing.EventType typeOfOuting)
    {
        foreach (Outing outing in _outingList)
        {
            if (outing.TypeOfOuting == typeOfOuting)
            {
                return outing;
            }
        }
        return null;
    }

    public double CostOfAllOutings ()
    {
        double cost = 0;
        foreach (Outing outing in _outingList)
        {
            cost += outing.TotalCost;
        }
        return cost;
    }

    public double CostByType(Outing.EventType typeOfOuting)
    {
        double cost = 0;
        foreach (Outing outing in _outingList)
        {
            if (outing.TypeOfOuting == typeOfOuting)
            {
                cost += outing.TotalCost;
            }
        }
        return cost;
    }

}