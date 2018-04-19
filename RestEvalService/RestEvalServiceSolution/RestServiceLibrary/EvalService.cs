using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using RestServiceLibrary.Interfaces;
using RestServiceLibrary.Models;

namespace RestServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService : IEval
    {
        public int evalCount = 0;
        List<Eval> evals = new List<Eval>();

        #region GET
        public List<Eval> GetEval()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GET BY ID
        public Eval GetEvalById(string Id)
        {
            var result = evals.First(x => x.Id.Equals(Id));
            return result;
        }
        #endregion

        #region GET BY SUBMITER
        public List<Eval> GetEvalsBySubmitter(string submitter)
        {
            if (submitter == null || submitter.Equals(""))
            {
                Console.WriteLine("parameter: {0}, evalcount: {1}", submitter, evals.Count);
                return evals;
            }
            else
            {
                Console.WriteLine("parameter: {0}, evalcount: {1}", submitter, evals.Count);
                return evals.FindAll(e => e.Submitter.ToLower().Equals(submitter.ToLower()));
            }
        }
        #endregion

        #region GET ALL
        public List<Eval> GetAllEvals()
        {
            return evals;
        }
        #endregion

        #region SUBMIT
        public void SubmitEval(Eval eval)
        {
            eval.Id = (++evalCount).ToString();
            if (eval.Submitter.Equals("Throw"))
            {
                throw new FaultException("Error within SubmitEval");
            }
            evals.Add(eval);
        }
        #endregion

        #region REMOVE
        public void RemoveEval(string Id)
        {
            Eval evalToRemove = evals.Find(e => e.Id.Equals(Id));
            evals.Remove(evalToRemove);
        }
        #endregion
    }
}
