﻿using TQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace TQL.Controllers
{

    public class ResultsController : ApiController
    {

        private AppDbContext db = new AppDbContext();

        // localhost:xxxxx/api/Results/10
        [HttpGet]
        public JsonRC GetResults(int? nbr)
        {
            if (nbr == null) return new JsonRC { Message = "No number provided" };
            var result = new Result();
            result.Input = (int)nbr;
            result.Sum = SumSeriesMultiplesOfThreeAndFive.FilterAndSum(result.Input);
            result.DateCreated = DateTime.Now;
            db.Results.Add(result);
            db.SaveChanges();
            return new JsonRC
            {
                Result = result,
                Message = "Ok"
            };
        }

        
    }
}
