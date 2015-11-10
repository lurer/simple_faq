using s198599_mappe3.Models.DB;
using s198599_mappe3.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace s198599_mappe3.Models.Repository
{
    public class QuestionRepo : IFaqDb<Question>
    {
        DataContext context = new DataContext();

        public bool delete(int id)
        {

            try
            {
                var dbQuestion = context.Questions.FirstOrDefault(q => q.QuestionID == id);
                context.Questions.Remove(dbQuestion);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool edit(Question toEdit)
        {
            var dbQuestion = context.Questions.FirstOrDefault(q => q.QuestionID == toEdit.QuestionID);
            if(dbQuestion == null)
                return false;
            dbQuestion.Heading = toEdit.Heading;
            dbQuestion.Body = toEdit.Body;
            dbQuestion.Answer = toEdit.Answer;
            dbQuestion.RespondEmail = toEdit.RespondEmail;
            dbQuestion.CategoryID = toEdit.CategoryID;

            try
            {
                context.Entry(dbQuestion).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        public Question get(int id)
        {
            DbQuestion dbQ = context.Questions.Find(id);
            var q = convertDbtoDomain(dbQ);
            return q;
        }

        public List<Question> getList()
        {

            List<DbQuestion> dbQuestions = context.Questions.ToList();
            var allQuestions = new List<Question>();
            foreach (var q in dbQuestions)
                allQuestions.Add(convertDbtoDomain(q));    
            return allQuestions;
        }

        public bool save(Question obj)
        {
            var dbQ = convertDomaintoDb(obj);
            try
            {
                context.Questions.Add(dbQ);
                context.SaveChanges();
            }catch(Exception)
            {
                return false;
            }
            return true;
        }


        private Question convertDbtoDomain(DbQuestion dbQ)
        {
            var q = new Question()
            {
                QuestionID = dbQ.QuestionID,
                Heading = dbQ.Heading,
                Body = dbQ.Body,
                Answer = dbQ.Answer,
                RelevanceScore = dbQ.RelevanceScore,
                RespondEmail = dbQ.RespondEmail,
                CategoryID = dbQ.CategoryID,
                CreatedAt = dbQ.CreatedAt,
                LastModifiedAt = dbQ.LastModifiedAt
            };
            return q;
        }

        private DbQuestion convertDomaintoDb(Question q)
        {
            var dbQ = new DbQuestion()
            {
                
                Heading = q.Heading,
                Body = q.Body,
                Answer = q.Answer,
                RelevanceScore = q.RelevanceScore,
                RespondEmail = q.RespondEmail,
                CategoryID = q.CategoryID,
                
            };
            return dbQ;
        }
    }
}