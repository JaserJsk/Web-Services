using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.RestServiceReference;

namespace RestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EvalServiceClient client = new EvalServiceClient("BasicHttpBinding_IEvalService");
            Eval ev = new Eval();

            ev.Id = "1";
            ev.Submitter = "Something";
            ev.Comments = "This is a comment";
            ev.TimeSent = Convert.ToDateTime(DateTime.Now);

            client.SubmitEval(ev);
            var result = client.GetAllEvals();
            foreach (var res in result)
            {
                Console.WriteLine($"ID: {res.Id} - SUBMITTER: {res.Submitter} - COMMENTS: {res.Comments} - DATE: {res.TimeSent}");
            }

            Console.ReadLine();
        }
    }
}
