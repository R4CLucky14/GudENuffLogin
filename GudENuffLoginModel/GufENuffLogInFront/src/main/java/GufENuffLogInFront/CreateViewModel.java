package GufENuffLogInFront;

public class CreateViewModel
{
	public String Email;
	public String Password;
	public String ConfirmPassword;

	public CreateViewModel(String Email, String Password, String ConfirmPassword)
	{
		this.Email = Email;
		this.Password = Password;
		this.ConfirmPassword = ConfirmPassword;
	}

	public String toJson()
	{
		return "{ Email: " + Email + ", Password: " + Password + ", ConfirmPassword: " + ConfirmPassword + " }";
	}
}
