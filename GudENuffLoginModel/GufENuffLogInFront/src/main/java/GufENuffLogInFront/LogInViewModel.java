package GufENuffLogInFront;

public class LogInViewModel
{
	public String Email;
	public String Password;

	public LogInViewModel(String Email, String Password)
	{
		this.Email = Email;
		this.Password = Password;
	}

	public String toJson()
	{
		return "{ Email: " + Email + ", Password: " + Password + " }";
	}
}