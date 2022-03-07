namespace BadgeClass;

public class BadgeRepository
{
protected readonly Dictionary<int, List<string>> _badgeDataBase = new Dictionary<int, List<string>>(){};

public bool AddToDictionary(Badge badge)
{
    int startingCount = _badgeDataBase.Count;
    _badgeDataBase.Add(badge.BadgeID, badge.AccessDoors);

    bool wasAdded = (_badgeDataBase.Count > startingCount) ? true : false;
    return wasAdded;
}

public Dictionary<int, List<string>> GetBadges(){
    return _badgeDataBase;
}

public List<string> GetBadgeByID(int badgeID) {
    return _badgeDataBase[badgeID];
}

}