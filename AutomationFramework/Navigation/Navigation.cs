using System;

namespace AutomationFramework
{
    public class Navigation
    {
        public class ChooseDoc
        {
            public static void Select()
            {
                MenuSelector.Select("ИЗБЕРИ РЕФЕРАТ");
            }
        }

        public class UploadDoc
        {
            public static void Select()
            {
                MenuSelector.Select("КАЧИ РЕФЕРАТ");
            }
        }

        public class MakeReview
        {
            public static void Select()
            {
                MenuSelector.Select("НАПРАВИ РЕЦЕНЗИЯ");
            }
        }

        public class Logout
        {
            public static void Select()
            {
                MenuSelector.Select("ИЗХОД");
            }
        }
    }
}
