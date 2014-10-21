package GufENuffLogInFront;

import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URI;
import java.net.URL;
import java.io.IOException;
import java.io.File;

import org.apache.http.HttpEntity;
import org.apache.http.HttpHost;
import org.apache.http.HttpVersion;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.fluent.Request;
import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.methods.HttpUriRequest;
import org.apache.http.client.methods.RequestBuilder;
import org.apache.http.entity.ContentType;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;

public class Connection
{
	private String BaseUrl;

	public Connection()
	{
		this.BaseUrl = "http://localhost:18635/api/Account/";
	}
	public Connection(String BaseUrl)
	{
		this.BaseUrl = BaseUrl;
	}

	public Result Status() throws IOException
	{
		//String requestUrl = "Status/";
		String requestUrl = "";
        Result result = new Result();

        CloseableHttpClient httpclient = HttpClients.createDefault();
        try
        {
			HttpGet httpGet = new HttpGet(this.BaseUrl + requestUrl);
	        CloseableHttpResponse response = httpclient.execute(httpGet);
        
	        try
	        {
	            result.StatusCode = response.getStatusLine().getStatusCode();
	            result.StatusMessage = response.getStatusLine().getReasonPhrase();
	        }
	        finally
	        {
	        	response.close();
	        }
		}
        finally
        {
            httpclient.close();
    		return result;
        }
	}

	public Result Login( LogInViewModel model)
	{
		String requestUrl = "Login/";

		//connection
		return new Result();
	}
	public Result Create( CreateViewModel model) throws IOException
	{
		String requestUrl = "Create/";
        Result result = new Result();

        CloseableHttpClient httpclient = HttpClients.createDefault();
        try
        {
        	HttpUriRequest httpPost = RequestBuilder.post()
                    .setUri(new URI(this.BaseUrl + requestUrl))
                    .addParameter("Email", model.Email)
                    .addParameter("Password", model.Password)
                    .addParameter("ConfirmPassword", model.ConfirmPassword)
                    .build();
			
	        CloseableHttpResponse response = httpclient.execute(httpPost);
        
	        try
	        {
	            result.StatusCode = response.getStatusLine().getStatusCode();
	            result.StatusMessage = response.getStatusLine().getReasonPhrase();
	        }
	        finally
	        {
	        	response.close();
	        }
		}
        finally
        {
            httpclient.close();
    		return result;
        }
	}
	public Result Change( ChangePasswordViewModel model)
	{
		String requestUrl = "Change/";


		return new Result();
	}
}
