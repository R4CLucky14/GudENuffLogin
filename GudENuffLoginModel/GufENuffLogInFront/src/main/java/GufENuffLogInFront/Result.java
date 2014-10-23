package GufENuffLogInFront;

public class Result
{
	public int StatusCode;
	public String StatusMessage;
	public String BodyMessage;
	
	public Boolean Success()
	{
		return StatusCode == 200;
	}
}
