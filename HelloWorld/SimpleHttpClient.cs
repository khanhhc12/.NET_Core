using System.Net;
using System.Text;

namespace HelloWorld;

public static class SimpleHttpClient
{
    // string resJson = SimpleHttpClient.GetAsync("http://localhost:5000/api/todo").Result;
    public static async Task<string> GetAsync(string uri)
    {
        try
        {
            using (var httpClient = new HttpClient())
            // deadlock ConfigureAwait(false)
            using (var response = await httpClient.GetAsync(uri).ConfigureAwait(false))
            {
                // will throw an exception if not successful
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        catch (HttpRequestException hre)
        {
            string message = hre.Message;
            if (hre.InnerException != null && !string.IsNullOrEmpty(hre.InnerException.Message))
                message += " >> " + hre.InnerException.Message;
            return message;
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                message += " >> " + ex.InnerException.Message;
            return message;
        }
    }

    public static async Task<string> PostAsync(string uri, string data, string contentType = "application/json")
    {
        try
        {
            var content = new StringContent(data == null ? string.Empty : data, Encoding.UTF8, contentType);
            using (var httpClient = new HttpClient())
            // deadlock ConfigureAwait(false)
            using (var response = await httpClient.PostAsync(uri, content).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        catch (HttpRequestException hre)
        {
            string message = hre.Message;
            if (hre.InnerException != null && !string.IsNullOrEmpty(hre.InnerException.Message))
                message += " >> " + hre.InnerException.Message;
            return message;
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                message += " >> " + ex.InnerException.Message;
            return message;
        }
    }

    public static async Task<string> GetCookieAsync(string uri, string action, List<Cookie> cookies)
    {
        try
        {
            var baseAddress = new Uri(uri);
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                foreach (var cookie in cookies)
                    cookieContainer.Add(baseAddress, cookie);
                // deadlock ConfigureAwait(false)
                using (var response = await client.GetAsync(action).ConfigureAwait(false))
                {
                    // will throw an exception if not successful
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
        catch (HttpRequestException hre)
        {
            string message = hre.Message;
            if (hre.InnerException != null && !string.IsNullOrEmpty(hre.InnerException.Message))
                message += " >> " + hre.InnerException.Message;
            return message;
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                message += " >> " + ex.InnerException.Message;
            return message;
        }
    }

    public static async Task<string> PostCookieAsync(string uri, string action, List<Cookie> cookies, string data, string contentType = "application/x-www-form-urlencoded")
    {
        try
        {
            var baseAddress = new Uri(uri);
            var cookieContainer = new CookieContainer();
            var content = new StringContent(data == null ? string.Empty : data, Encoding.UTF8, contentType);
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                foreach (var cookie in cookies)
                    cookieContainer.Add(baseAddress, cookie);
                // deadlock ConfigureAwait(false)
                using (var response = await client.PostAsync(action, content).ConfigureAwait(false))
                {
                    // will throw an exception if not successful
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
        catch (HttpRequestException hre)
        {
            string message = hre.Message;
            if (hre.InnerException != null && !string.IsNullOrEmpty(hre.InnerException.Message))
                message += " >> " + hre.InnerException.Message;
            return message;
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                message += " >> " + ex.InnerException.Message;
            return message;
        }
    }
}
