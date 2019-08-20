using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using System.IO;

namespace Face_Recognition
{
    static class Program
    {
        const string subscriptionKey = "9fd3f45119954d98a93d90eebfc905f0";

        const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0";

        private static String perID, faceID, getperID;
        static void Main(string[] args)
        {
            // Get the path and filename to process from the user.
            //Console.WriteLine("Face Detection:");
            Console.Write(
                "Enter the path to an image with faces: ");
            string imageFilePath = Console.ReadLine();

            if (File.Exists(imageFilePath))
            {
                // Execute the REST API call.
                try
                {
                    MakeRequest(imageFilePath);
                    Console.WriteLine("\nWait a moment..\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n" + e.Message + "\nPress Enter to exit...\n");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid file path!\nPress Enter to exit...\n");
            }

            Console.ReadLine();
        }

        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }

        static async void MakeRequest(string imageFilePath)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            // Request parameters
            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "true";
            queryString["returnFaceAttributes"] = "age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
            queryString["recognitionModel"] = "recognition_01";
            queryString["returnRecognitionModel"] = "false";
            queryString["detectionModel"] = "detection_01";
            var uri = uriBase + "/detect?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = GetImageAsByteArray(imageFilePath);

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                string contentString = await response.Content.ReadAsStringAsync();

                Console.WriteLine("\nDetect Response:\n");
                Console.WriteLine(JsonPrettyPrint(contentString));

                String outprint = JsonPrettyPrint(contentString);
                String[] donwant = { "\"", ":", " ", "faceId", "faceRectangle", "top", "left", "width", "height", "{", "}", "," };
                String[] data = outprint.Split(donwant, StringSplitOptions.RemoveEmptyEntries);
                faceID = data[2];
                create();
                gettrain();
            }
            //Console.WriteLine(faceID);
        }

        static async void create()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = uriBase + "/persongroups/vandohakim?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"name\":\"group1\",\"userData\":\"Vando\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(uri, content);
            }
            string contentString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("\nCreate PersonGroup Response:\n");
            Console.WriteLine(JsonPrettyPrint(contentString));
            pgcreate();
        }

        static async void pgcreate()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = uriBase + "/persongroups/vandohakim/persons?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"name\":\"person1\",\"userData\":\"Vando\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }
            string contentString = await response.Content.ReadAsStringAsync();
            String outprint = JsonPrettyPrint(contentString);
            Console.WriteLine("\nCreate Person Response:\n");
            Console.WriteLine(outprint);

            String[] donwant = { "\"", ":", " " };
            String[] data = outprint.Split(donwant, StringSplitOptions.RemoveEmptyEntries);
            perID = data[2];
            addface();
        }

        static async void addface()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            // Request parameters
            var uri = uriBase + "/persongroups/vandohakim/persons/" + perID + "/persistedFaces?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = GetImageAsByteArray("D://Vando_Hakim.jpg");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
            }
            string contentString = await response.Content.ReadAsStringAsync();
            String outprint = JsonPrettyPrint(contentString);
            Console.WriteLine("\nAddface Response:\n");
            Console.WriteLine(outprint);
            train();
        }

        static async void train()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = uriBase + "/persongroups/vandohakim/train?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }
            gettrain();
        }

        static async void gettrain()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = uriBase + "/persongroups/vandohakim/training?" + queryString;

            var response = await client.GetAsync(uri);

            string contentString = await response.Content.ReadAsStringAsync();
            String outprint = JsonPrettyPrint(contentString);
            Console.WriteLine("\nTraining Status:\n");
            Console.WriteLine(outprint);
            identify();
        }

        static async void identify()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = uriBase + "/identify?" + queryString;

            HttpResponseMessage response;

            String bd = "{\"personGroupId\":\"vandohakim\",\"faceIds\":[\"" + faceID + "\"]}";

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(bd);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }
            string contentString = await response.Content.ReadAsStringAsync();
            String outprint = JsonPrettyPrint(contentString);
            Console.WriteLine("\nIdentify Response:\n");
            Console.WriteLine(outprint);

            String[] donwant = { "\"", ":", " ", "faceId", "candidates", "personId", "confidence", "[", "]", "{", "}", "," };
            String[] data = outprint.Split(donwant, StringSplitOptions.RemoveEmptyEntries);
            getperID = data[6];
            personget();
        }

        static async void personget()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = uriBase + "/persongroups/vandohakim/persons/" + getperID + "?" + queryString;

            var response = await client.GetAsync(uri);

            string contentString = await response.Content.ReadAsStringAsync();
            String outprint = JsonPrettyPrint(contentString);
            Console.WriteLine("\nPerson Get Response:\n");
            Console.WriteLine(outprint);
        }
        static async void delete(String pid)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var uri = uriBase + "/persongroups/vandohakim/persons/" + pid + "?" + queryString;

            var response = await client.DeleteAsync(uri);
            Console.WriteLine(response);
        }

        static string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            StringBuilder sb = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            int offset = 0;
            int indentLength = 3;

            foreach (char ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\'':
                        if (quote) ignore = !ignore;
                        break;
                }

                if (quote)
                    sb.Append(ch);
                else
                {
                    switch (ch)
                    {
                        case '{':
                        case '[':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case '}':
                        case ']':
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', --offset * indentLength));
                            sb.Append(ch);
                            break;
                        case ',':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', offset * indentLength));
                            break;
                        case ':':
                            sb.Append(ch);
                            sb.Append(' ');
                            break;
                        default:
                            if (ch != ' ') sb.Append(ch);
                            break;
                    }
                }
            }

            return sb.ToString().Trim();
        }

    }
}