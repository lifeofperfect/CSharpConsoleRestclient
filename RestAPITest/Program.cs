using Newtonsoft.Json;
using RestSharp;
using System;

namespace RestAPITest
{
    class Program
    {
        static void Main(string[] args)
        {
            //getEmployeeData();
            CreateEmployee();
        }
        public static void getEmployeeData()
        {
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/");
            var request = new RestRequest("employees");
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                Rootobject result = JsonConvert.DeserializeObject<Rootobject>(rawResponse);
            }
        }

        public static void CreateEmployee()
        {
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/");
            var request = new RestRequest("create", Method.POST);
            var response = client.Execute(request);
            
            request.AddParameter("Name", "Test Perfect");
            request.AddParameter("salary", "25000");
            request.AddParameter("age", "21");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                
            }
        }


        public class Rootobject
        {
            public string status { get; set; }
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public string id { get; set; }
            public string employee_name { get; set; }
            public string employee_salary { get; set; }
            public string employee_age { get; set; }
            public string profile_image { get; set; }
        }

    }
}
