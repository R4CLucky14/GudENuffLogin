package GufENuffLogInFront;

import java.io.IOException;

public class Program
{
	public static void main(String[] args) throws IOException
	{
		System.out.println("Creating Connection");
		
		Connection connection = new Connection();
		
		System.out.println("Connection Created");
		System.out.println("Attempt Handshaking");
		
		
		Result result = connection.Status();
		
		if(result.Success())
		{
			System.out.println("Handshaking Accepted");
		}
		else
		{
			System.out.println("Handshaking Failed!!!");
		}
		
		result = connection.Create(new CreateViewModel("james0308@outlook.com", "BADPASS", "BADPASS"));
		
		if(result.Success())
		{
			System.out.println("New Account Created!!!");
		}
		else
		{
			System.out.println("Logging In Failed!!!!");
		}
		
	}
}
