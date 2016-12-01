using WAMA.Core.ViewModel.User;

namespace WAMAcut.ViewModel.User
{
    public class UserAccountViewModelHelper
    {
        public const string EMAIL = "";
        public const string FIRST_NAME = "";
        public const string LAST_NAME = "";
        public const string MEMBER_ID = "";

        public static T UserAccountTypeTest<T>() where T : UserAccountViewModel, new()
        {
            return new T
            {
                Email = EMAIL,
                FirstName = FIRST_NAME,
                LastName = LAST_NAME,
                MemberId = MEMBER_ID
            };
        }

        public static T UserAccountTypeTest<T>(string email, string fname, string lname, string memberId)
            where T : UserAccountViewModel, new()
        {
            return new T
            {
                Email = email,
                FirstName = fname,
                LastName = lname,
                MemberId = memberId
            };
        }
    }
}