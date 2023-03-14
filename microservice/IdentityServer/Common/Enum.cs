namespace IdentityServer.Common
{
    public enum TypeMesCreateAccount
    {
        Account_UserName_Null = 1,
        Account_UserName_Exists = 2,
        Account_UserName_Add_Success = 3,
        Account_UserName_Add_False = 4,
        Account_UserName_Add_Exception = 5,
    }

    public enum TypeMesResetPasswordAccount
    {
        Account_UserName_Null = 1,
        Account_UserName_Not_Exists = 2,
        Account_ResetPassword_Success = 3,
        Account_ResetPassword_False = 4,
        Account_ResetPassword_Exception = 5,
    }

    public enum TypeMenu
    {
        menu_subsystems = 0,
        menu_item = 1,
        menu_action = 2
 
    }
}
