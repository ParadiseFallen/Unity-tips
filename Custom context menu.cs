[InitializeOnLoad]
public static class InjectMenuItems
{
//add item
    static InjectMenuItems()
    {
        MethodInfo addMenuItem = typeof(Menu).GetMethod("AddMenuItem", BindingFlags.Static | BindingFlags.NonPublic);
        typeof(Menu).GetMethods(BindingFlags.Static | BindingFlags.NonPublic).ToList().ForEach(i => Debug.Log(i)) ;
        for (int i = 0; i < 10; i++)
        {
            int j = i;
            addMenuItem.Invoke(null, new object[]
            {
                $"GameObject/Room/Components/c {i}", //path+name
                string.Empty,   //?
                true,  //?
                -i, //order
                (Action) (() => Debug.Log(j)), //action on press
                (Func<bool>) (() => true)  //can execute
            });
        }
      //remove item
        MethodInfo rm = typeof(Menu).GetMethod("RemoveMenuItem", BindingFlags.Static | BindingFlags.NonPublic);
        rm.Invoke(null, new object[]
            {
            "GameObject/Room/Components/c 3"
            });
        //internal static extern void AddMenuItem(string name, string shortcut, bool @checked, int priority, System.Action execute, System.Func<bool> validate);
    }
}
