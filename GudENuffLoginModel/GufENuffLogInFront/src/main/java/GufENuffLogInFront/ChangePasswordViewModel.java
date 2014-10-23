package GufENuffLogInFront;

public class ChangePasswordViewModel
{
	public String Username;
	public String OldPassword;
	public String NewPassword;

	public ChangePasswordViewModel(String Username, String OldPassword, String NewPassword)
	{
		this.Username = Username;
		this.OldPassword = OldPassword;
		this.NewPassword = NewPassword;
	}

	public String toJson()
	{
		return "{ Username: " + Username + ", OldPassword: " + OldPassword + ", NewPassword: " + NewPassword + " }";
	}
}
