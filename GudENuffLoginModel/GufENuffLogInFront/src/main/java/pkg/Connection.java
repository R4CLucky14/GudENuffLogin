package GufENuffLogInFront;

import java.net.URL;

public class Connection
{
	private String BaseUrl;

	public Connection()
	{
		this.BaseUrl = "http://localhost:18635/";
	}
	public Connection(String BaseUrl)
	{
		this.BaseUrl = BaseUrl;
	}


	public Result Login( LogInViewModel model)
	{
		String requestUrl = "Login/";

		String url = new Url(this.BaseUrl + requestUrl);

		HttpUrlConnection connection = new HttpUrlConnection(url);


		//connection
		return new Result();
	}
	public Result Create( CreateViewModel model)
	{
		String requestUrl = "Create/";


		return new Result();
	}
	public Result Create( ChangePasswordViewModel model)
	{
		String requestUrl = "Change/";


		return new Result();
	}
}
