namespace LOZ.Collision
{
    public static class TypeC
    {
        public static bool Check(object object_o, System.Type comparisonType)
        {
            System.Type actualType = object_o.GetType();
            if (actualType.IsAssignableFrom(comparisonType)) return true;
            if (actualType.IsSubclassOf(comparisonType)) return true;

            System.Type[] interfaces = actualType.GetInterfaces();
            foreach (System.Type type in interfaces)
            {
                if (type == comparisonType) return true;
            }
            return false;
        }

        public static bool CheckPair(object o1, System.Type t1, object o2, System.Type t2)
        {
            return (Check(o1, t1) && Check(o2, t2));
        }
    }
}
