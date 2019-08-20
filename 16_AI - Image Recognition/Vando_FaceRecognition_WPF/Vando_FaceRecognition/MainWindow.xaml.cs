using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace Vando_FaceRecognition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string noneStatus = "Status: none";
        private const string m_strPersonName = "VANDO";
        public MainWindow()
        {
            InitializeComponent();
            this.endpoint.Text = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0";
            this.subcriptionkey.Text = "9fd3f45119954d98a93d90eebfc905f0";
        }

        private byte[] GetImageAsByteArray(string filePath)
        {
            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(file);
            return reader.ReadBytes((int)file.Length);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }

            string strFileFullPath = op.FileName;
            stringgambar.Text = strFileFullPath;
                        
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            byte[] imageData = this.GetImageAsByteArray(stringgambar.Text);
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            // Request parameters
            //queryString["userData"] = "{string}";
            //queryString["targetFace"] = "{string}";
            queryString["returnFaceId"] = "true";
            var uri = endpoint.Text + "/detect?" + queryString;

            HttpResponseMessage response;

            // Request body
            //Button btn = (Button)sender;
            byte[] byteData = imageData;//Encoding.UTF8.GetBytes("{\"url\":\"https://i.imgur.com/" + btn.Name + ".jpg\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                //string contentString = await response.Content.ReadAsStringAsync();
                //txt_personID.Text = contentString;
                //string contentString = await response.Content.ReadAsStringAsync();
                //txt_personID.Text = contentString;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = await response.Content.ReadAsStringAsync();
                    faceDetect face = JsonConvert.DeserializeObject<faceDetect>(str.Substring(1, str.Length - 2));
                    this.faceIdentify(face.faceId);
                }
                else
                {
                    this.txt_doRecognize.Text = "Status: Error, " + response.ReasonPhrase;
                }
            }
        }
        private async void faceIdentify(string faceID)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            var uri = endpoint.Text + "/identify?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"faceIds\":[\"" + faceID + "\"],\"personGroupId\":\"" + this.groupID + "\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string str = await response.Content.ReadAsStringAsync();
                    faceIdentify face = JsonConvert.DeserializeObject<faceIdentify>(str.Substring(1, str.Length - 2));
                    if (face.candidates.Count > 0)
                    {
                        this.GetPerson(face.candidates[0].personId, face.candidates[0].confidence);
                    }
                    else
                    {
                        this.txt_doRecognize.Text = "Status: success.";
                        this.result.Text = "no one person match!";
                        //MessageBox.Show("no match person found", "Identify Result");
                    }
                }
                else
                {
                    this.txt_doRecognize.Text = "Status: Error, " + response.ReasonPhrase;
                    Console.WriteLine(response.ToString());
                }
            }
        }

        private async void GetPerson(string personID, float confidence)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            var uri = endpoint.Text + "/persongroups/" + this.groupID + "/persons/" + personID + "?" + queryString;

            var response = await client.GetAsync(uri);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string str = await response.Content.ReadAsStringAsync();
                Person person = JsonConvert.DeserializeObject<Person>(str);
                this.txt_doRecognize.Text = "Status: success.";
                //MessageBox.Show("Person Detected!\nIt's : " + person.name + "\nConfidence : " + confidence, "Identify Result");
                this.result.Text = "Name: " + person.name + "\n" + "Confidence: " + confidence;
            }
            else
            {
                this.txt_doRecognize.Text = "Status: Error, " + response.ReasonPhrase;
                MessageBox.Show("Error, " + response.ReasonPhrase, "Identify Result");
            }
        }

        private async void Vando1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                img1.Source = new BitmapImage(new Uri(op.FileName));
            }

            string strFileFullPath = op.FileName;
            byte[] imageData = this.GetImageAsByteArray(strFileFullPath);
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            // Request parameters
            //queryString["userData"] = "{string}";
            //queryString["targetFace"] = "{string}";
            var uri = endpoint.Text + "/persongroups/" + groupID + "/persons/" + personID + "/persistedFaces?" + queryString;

            HttpResponseMessage response;

            // Request body
            //Button btn = (Button)sender;
            byte[] byteData = imageData;//Encoding.UTF8.GetBytes("{\"url\":\"https://i.imgur.com/" + btn.Name + ".jpg\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                //string contentString = await response.Content.ReadAsStringAsync();
                //txt_personID.Text = contentString;
                //string contentString = await response.Content.ReadAsStringAsync();
                //txt_personID.Text = contentString;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    /*string str = await response.Content.ReadAsStringAsync();
                    FaceId id = JsonConvert.DeserializeObject<FaceId>(str);

                    Console.WriteLine(id.persistedFaceId);*/
                    //MessageBox.Show("success, face is added", "Add Face");
                    //btn.IsEnabled = false;
                }
                else
                {
                    //Console.WriteLine(response.ToString());
                    MessageBox.Show("errer : " + response.ToString(), "Add Face");

                }
            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                img2.Source = new BitmapImage(new Uri(op.FileName));
            }

            string strFileFullPath = op.FileName;
            byte[] imageData = this.GetImageAsByteArray(strFileFullPath);
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            // Request parameters
            //queryString["userData"] = "{string}";
            //queryString["targetFace"] = "{string}";
            var uri = endpoint.Text + "/persongroups/" + groupID + "/persons/" + personID + "/persistedFaces?" + queryString;

            HttpResponseMessage response;

            // Request body
            //Button btn = (Button)sender;
            byte[] byteData = imageData;//Encoding.UTF8.GetBytes("{\"url\":\"https://i.imgur.com/" + btn.Name + ".jpg\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                //string contentString = await response.Content.ReadAsStringAsync();
                //txt_personID.Text = contentString;
                //string contentString = await response.Content.ReadAsStringAsync();
                //txt_personID.Text = contentString;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    /*string str = await response.Content.ReadAsStringAsync();
                    FaceId id = JsonConvert.DeserializeObject<FaceId>(str);

                    Console.WriteLine(id.persistedFaceId);*/
                    //MessageBox.Show("success, face is added", "Add Face");
                    //btn.IsEnabled = false;
                }
                else
                {
                    //Console.WriteLine(response.ToString());
                    MessageBox.Show("errer : " + response.ToString(), "Add Face");

                }
            }
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                img3.Source = new BitmapImage(new Uri(op.FileName));
            }

            string strFileFullPath = op.FileName;
            byte[] imageData = this.GetImageAsByteArray(strFileFullPath);
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            // Request parameters
            //queryString["userData"] = "{string}";
            //queryString["targetFace"] = "{string}";
            var uri = endpoint.Text + "/persongroups/" + groupID + "/persons/" + personID + "/persistedFaces?" + queryString;

            HttpResponseMessage response;

            // Request body
            //Button btn = (Button)sender;
            byte[] byteData = imageData;//Encoding.UTF8.GetBytes("{\"url\":\"https://i.imgur.com/" + btn.Name + ".jpg\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                //string contentString = await response.Content.ReadAsStringAsync();
                //txt_personID.Text = contentString;
                //string contentString = await response.Content.ReadAsStringAsync();
                //txt_personID.Text = contentString;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    /*string str = await response.Content.ReadAsStringAsync();
                    FaceId id = JsonConvert.DeserializeObject<FaceId>(str);

                    Console.WriteLine(id.persistedFaceId);*/
                    //MessageBox.Show("success, face is added", "Add Face");
                    //btn.IsEnabled = false;
                }
                else
                {
                    //Console.WriteLine(response.ToString());
                    MessageBox.Show("errer : " + response.ToString(), "Add Face");

                }
            }
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                img4.Source = new BitmapImage(new Uri(op.FileName));
            }

            string strFileFullPath = op.FileName;
            byte[] imageData = this.GetImageAsByteArray(strFileFullPath);
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            // Request parameters
            //queryString["userData"] = "{string}";
            //queryString["targetFace"] = "{string}";
            var uri = endpoint.Text + "/persongroups/" + groupID + "/persons/" + personID + "/persistedFaces?" + queryString;

            HttpResponseMessage response;

            // Request body
            //Button btn = (Button)sender;
            byte[] byteData = imageData;//Encoding.UTF8.GetBytes("{\"url\":\"https://i.imgur.com/" + btn.Name + ".jpg\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                //string contentString = await response.Content.ReadAsStringAsync();
                //txt_personID.Text = contentString;
                //string contentString = await response.Content.ReadAsStringAsync();
                //txt_personID.Text = contentString;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    /*string str = await response.Content.ReadAsStringAsync();
                    FaceId id = JsonConvert.DeserializeObject<FaceId>(str);

                    Console.WriteLine(id.persistedFaceId);*/
                    //MessageBox.Show("success, face is added", "Add Face");
                    //btn.IsEnabled = false;
                }
                else
                {
                    //Console.WriteLine(response.ToString());
                    MessageBox.Show("errer : " + response.ToString(), "Add Face");

                }
            }
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            var uri = this.endpoint.Text + "/persongroups/" + this.groupID + "?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"name\": \"" + input_CreatePersonGroup.Text.ToString() + "\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    this.txt_CreatePersonGroup.Text = "Status: Success !";
                    this.txt_groupID.Text = input_CreatePersonGroup.Text.ToString();
                    //this.btn_CreatePersonGroup.IsEnabled = false;
                }
                else
                {
                    this.txt_CreatePersonGroup.Text = "Status: Error";
                    Console.WriteLine(response);
                }
            }
        }
        private string groupID
        {
            get
            {
                return txt_groupID.Text.ToString().Equals("") ? input_CreatePersonGroup.Text.ToString() : txt_groupID.Text.ToString();
            }
        }
        private string personID
        {
            get
            {
                return txt_personID.Text.ToString().Equals("") ? input_CreatePerson.Text.ToString() : txt_personID.Text.ToString();
            }

            set
            {
                this.txt_personID.Text = value;
            }
        }

        private async void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            string groupID = txt_groupID.Text.ToString().Equals("") ? txt_CreatePersonGroup.Text.ToString() : txt_groupID.Text.ToString();
            var uri = endpoint.Text + "/persongroups/" + this.groupID + "/persons?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"name\": \"" + m_strPersonName + "\"}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    this.txt_CreatePerson.Text = "Status: Success !";
                    //this.btn_CreatePerson.IsEnabled = false;
                    string str = await response.Content.ReadAsStringAsync();

                    PersonId id = JsonConvert.DeserializeObject<PersonId>(str);
                    this.personID = id.personId;
                }
                else
                {
                    this.txt_CreatePerson.Text = "Status: Error, " + response.ReasonPhrase;
                }
            }
        }

        private async void Button_Click_Train(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            var uri = endpoint.Text + "/persongroups/" + this.groupID + "/train";

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    this.txt_StartTrain.Text = "Status: request accepted, train has started.";
                }
                else
                {
                    this.txt_StartTrain.Text = "Status: Error, " + response.ReasonPhrase;
                    Console.WriteLine(response.ToString());
                }
            }
            gettrain();
        }
        private async void gettrain()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.subcriptionkey.Text);

            var uri = endpoint.Text + "/persongroups/" + groupID + "/training?" + queryString;

            var response = await client.GetAsync(uri);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string str = await response.Content.ReadAsStringAsync();
                trainningStatus sta = JsonConvert.DeserializeObject<trainningStatus>(str);
                this.txt_CheckTrain.Text = sta.status;
            }
            else
            {
                this.txt_CheckTrain.Text = "Status: Error, " + response.ReasonPhrase;
                Console.WriteLine(response.ToString());
            }
        }
    }
}
public class PersonId
{
    public string personId { get; set; }
}

public class trainningStatus
{
    public string status { get; set; }
}

public class faceDetect
{
    public string faceId { get; set; }
}

public class faceIdentify
{
    public string faceId { get; set; }
    public List<faceIdentifyCandidates> candidates { get; set; }
}
public class faceIdentifyCandidates
{
    public string personId { get; set; }
    public float confidence { get; set; }
}

public class Person
{
    public string personId { get; set; }
    public List<string> persistedFaceIds { get; set; }
    public string name { get; set; }
    public string userData { get; set; }
}
