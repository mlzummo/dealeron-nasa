using System;
using System.IO;
using System.Text;

public static class RequestBodySplitter
{
    public static string[] Split(string requestBody, char delimiter)
    {
        // Decode the request body.
        byte[] decodedBodyBytes = Convert.FromBase64String(requestBody);
        string decodedBody = Encoding.UTF8.GetString(decodedBodyBytes);

        // Split the request body on the desired character.
        return decodedBody.Split(delimiter);
    }
}