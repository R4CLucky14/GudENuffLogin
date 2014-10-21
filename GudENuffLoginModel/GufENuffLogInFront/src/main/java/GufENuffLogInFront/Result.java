package GufENuffLogInFront;

public class Result
{
	public int StatusCode;
	public String StatusMessage;
	
	public Boolean Success()
	{
		return StatusCode == 200;
	}
}
