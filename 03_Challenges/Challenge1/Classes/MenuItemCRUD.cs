namespace Classes;

public class MenuItemList {
    public List<MenuItem> _fullmenu = new List<MenuItem>();

    public bool AddItemToMenu(MenuItem item){
        int numberOfItems = _fullmenu.Count;
        _fullmenu.Add(item);
        bool itemAdded = (_fullmenu.Count > numberOfItems) ? true : false;
        return itemAdded;
    }

    public List<MenuItem> ReadMenu(){
        return _fullmenu;
    }

    public bool UpdateMenuItem(string originalName, MenuItem newItem){
        MenuItem oldItem = GetMealByName(originalName);

        if (oldItem != null){
            oldItem.Name = newItem.Name;
            oldItem.Description = newItem.Description;
            oldItem.MealNumber = newItem.MealNumber;
            oldItem.Price = newItem.Price;
            oldItem.Ingredients = newItem.Ingredients;
            return true;}
            return false;
        }
    

    public MenuItem GetMealByName(string name){
        foreach (MenuItem item in _fullmenu){
            if (item.Name.ToLower() == name.ToLower()){
                return item;
            }
        }
            return null;
    }

    public bool DeleteMenuItem(MenuItem existingItem){
        bool deleteResult = _fullmenu.Remove(existingItem);
        return deleteResult;
    }
}



